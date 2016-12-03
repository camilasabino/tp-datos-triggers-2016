using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Alta : Form
    {

        public Alta()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void alta_Afiliado_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                this.llenarComboRelacionConTitular(comboBox_afil_relacionConTitular);
                this.llenarComboPLan(comboBox_afil_plan);
                this.llenarComboEstadoCivil(comboBox_afil_estadoCivil);
                this.llenarCantidadFamiliaresACargo(comboBox_afil_CantFamACargo);
            }
        }

        private void llenarComboPLan(ComboBox combo)
        {
            List<Modificacion.Plan> planes = new List<Modificacion.Plan>();

            conn.Open();

            String query = "select plan_id, plan_med_descripcion from LOS_TRIGGERS.Plan_Medico";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (comboBox_afil_plan.Items.Count <= 0)
            {
                while (reader.Read())
                {
                    planes.Add(new Modificacion.Plan(reader.GetDecimal(0), reader.GetString(1)));
                }

                comboBox_afil_plan.DataSource = planes;
                comboBox_afil_plan.DisplayMember = "descripcion";
                comboBox_afil_plan.ValueMember = "id";

                comboBox_afil_plan.SelectedItem = null;

            }
            conn.Close();
        }

        private void llenarComboRelacionConTitular(ComboBox relacion)
        {
            relacion.Items.Add("Titular");
            relacion.Items.Add("Cónyuge");
            relacion.Items.Add("Hijo/a");
        }

        private void llenarComboEstadoCivil(ComboBox estado)
        {
            estado.Items.Add("Soltero/a");
            estado.Items.Add("Casado/a");
            estado.Items.Add("Viudo/a");
            estado.Items.Add("Concubinato");
            estado.Items.Add("Divorciado/a");
        }

        private void llenarCantidadFamiliaresACargo(ComboBox cantFam)
        {
            for (int i = 0; i <= 10; i++)
            {
                cantFam.Items.Add(i);
            }
        }

        private void limpiarCamposParaConyuge()
        {
            //numeroDelTitular
            conn.Open();
            string consultaNumeroDelTitular = "select user_afiliado from LOS_TRIGGERS.Usuario where user_id =" + textBox_afil_usuario.Text;
            SqlCommand command = new SqlCommand(consultaNumeroDelTitular, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string numeroDelTitular = Convert.ToString(reader.GetDecimal(0));
            reader.Close();
            conn.Close();

            textBox_afil_usuario.Text = "";
            textBox_afil_titular.Text = numeroDelTitular;
            textBox_afil_titular.Enabled = false;
            comboBox_afil_plan.Enabled = false;
            comboBox_afil_relacionConTitular.Text = "Cónyuge";
            comboBox_afil_relacionConTitular.Enabled = false;
            textBox_afil_dni.Text = "";
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
        }

        private void limpiarCamposParaHijos()
        {
            //numeroDelTitular
            conn.Open();
            string consultaNumeroDelTitular = "select user_afiliado from LOS_TRIGGERS.Usuario where user_id =" + textBox_afil_usuario.Text;
            SqlCommand command = new SqlCommand(consultaNumeroDelTitular, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string numeroDelTitular = Convert.ToString(reader.GetDecimal(0));
            reader.Close();
            conn.Close();

            textBox_afil_titular.Text = numeroDelTitular;
            textBox_afil_titular.Enabled = false;
            textBox_afil_usuario.Text = "";
            comboBox_afil_relacionConTitular.Text = "Hijo/a";
            textBox_afil_dni.Text = "";
            comboBox_afil_estadoCivil.Text = "";
            comboBox_afil_plan.Enabled = false;
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {

            //valido que los campos necesarios estén completos
            if (string.IsNullOrEmpty(textBox_afil_usuario.Text) && string.IsNullOrEmpty(textBox_afil_dni.Text))
            {
                MessageBox.Show("Debe ingresar el número de Usuario y dni del afiliado");
                return;
            }
            else if (string.IsNullOrEmpty(textBox_afil_usuario.Text) && !string.IsNullOrEmpty(textBox_afil_dni.Text))
            {
                MessageBox.Show("Debe ingresar el número de Usuario");
                return;
            }
            else if (!string.IsNullOrEmpty(textBox_afil_usuario.Text) && string.IsNullOrEmpty(textBox_afil_dni.Text))
            {
                MessageBox.Show("Debe ingresar el dni del afiliado");
                return;
            }

            //seteamos valores a la base de datos

            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.DarDeAltaUnAfiliado", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", SqlDbType.Decimal).Value = textBox_afil_usuario.Text;
            cmd.Parameters.AddWithValue("@dni", SqlDbType.Decimal).Value = textBox_afil_dni.Text;
            if (textBox_afil_titular.Text.Equals("")) { cmd.Parameters.AddWithValue("@titularNumero", DBNull.Value); }
            else { cmd.Parameters.AddWithValue("@titularNumero", SqlDbType.Decimal).Value = textBox_afil_titular.Text; }
            cmd.Parameters.AddWithValue("@estadoCivil", SqlDbType.VarChar).Value = comboBox_afil_estadoCivil.Text;
            cmd.Parameters.AddWithValue("@plan", SqlDbType.Decimal).Value = comboBox_afil_plan.SelectedValue;
            cmd.Parameters.AddWithValue("@familiaresACargo", SqlDbType.Decimal).Value = comboBox_afil_CantFamACargo.Text;
            cmd.Parameters.AddWithValue("@relacionConTitular", SqlDbType.VarChar).Value = comboBox_afil_relacionConTitular.Text;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("La Alta se ha realizado con éxito");

            //ofrece asociar al cónyuge si está casado o en concubinato, e hijos si tiene

            if (comboBox_afil_relacionConTitular.Text.Equals("Titular") && (comboBox_afil_estadoCivil.Text.Equals("Casado/a") | comboBox_afil_estadoCivil.Text.Equals("Concubinato")))
            {
                if (MessageBox.Show("¿Desea asociar a su Cónyuge?", "Confirmar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.limpiarCamposParaConyuge();
                    return;
                }
            }

            int cantHijos = Convert.ToInt16(comboBox_afil_CantFamACargo.Text);
            for (int i = 0; i < cantHijos; i++)
            {
                if (MessageBox.Show("¿Desea asociar a su hijo/a?", "Confirmar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.limpiarCamposParaHijos();
                    return;
                }
            }
            this.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
            Abm_Afiliado.Afiliado afiliado = new Abm_Afiliado.Afiliado();
        }
    }
}
