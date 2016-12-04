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
            labelStatus.Text = "";
            llenarComboRelacionConTitular();
            llenarComboPLan();
            llenarComboEstadoCivil();
            llenarCantidadFamiliaresACargo();
            permitirControles(false);
            button_confirmar.Enabled = false;
        }

        protected void permitirControles(Boolean valor)
        {
            comboBox_afil_CantFamACargo.Enabled = valor;
            comboBox_afil_estadoCivil.Enabled = valor;
            comboBox_afil_plan.Enabled = valor;
            comboBox_afil_relacionConTitular.Enabled = valor;
            textBox_afil_titular.Enabled = valor;
        }

        protected void limpiarFormulario()
        {
            labelStatus.Text = "";
            textBox_afil_usuario.Text = "";
            textBox_afil_titular.Text = "";
            comboBox_afil_relacionConTitular.SelectedIndex = -1;
            comboBox_afil_CantFamACargo.SelectedIndex = -1;
            comboBox_afil_estadoCivil.SelectedIndex = -1;
            comboBox_afil_plan.SelectedIndex = -1;
            permitirControles(false);
            button_confirmar.Enabled = false;
        }

        private void llenarComboPLan()
        {
            List<Modificacion.Plan> planes = new List<Modificacion.Plan>();
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
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
        }

        private void llenarComboRelacionConTitular()
        {
            comboBox_afil_relacionConTitular.Items.Add("Titular");
            comboBox_afil_relacionConTitular.Items.Add("Cónyuge");
            comboBox_afil_relacionConTitular.Items.Add("Hijo/a");
        }

        private void llenarComboEstadoCivil()
        {
            comboBox_afil_estadoCivil.Items.Add("Soltero/a");
            comboBox_afil_estadoCivil.Items.Add("Casado/a");
            comboBox_afil_estadoCivil.Items.Add("Viudo/a");
            comboBox_afil_estadoCivil.Items.Add("Concubinato");
            comboBox_afil_estadoCivil.Items.Add("Divorciado/a");
        }

        private void llenarCantidadFamiliaresACargo()
        {
            for (int i = 0; i <= 10; i++) comboBox_afil_CantFamACargo.Items.Add(i);
        }

        protected void traerNumeroDelTitular()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                string consultaNumeroDelTitular = "select user_afiliado from LOS_TRIGGERS.Usuario where user_id =" + textBox_afil_usuario.Text;
                SqlCommand command = new SqlCommand(consultaNumeroDelTitular, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string numeroDelTitular = Convert.ToString(reader.GetDecimal(0));
                reader.Close();
                conn.Close();
            }
        }

        private void limpiarCamposParaConyuge(String numeroTitular)
        {
            textBox_afil_usuario.Text = "";
            textBox_afil_titular.Text = numeroTitular;
            textBox_afil_titular.Enabled = false;
            comboBox_afil_plan.Enabled = false;
            comboBox_afil_relacionConTitular.Text = "Cónyuge";
            comboBox_afil_relacionConTitular.Enabled = false;
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
            labelStatus.Text = "";
        }

        private void limpiarCamposParaHijos(String numeroTitular)
        {
            textBox_afil_titular.Text = numeroTitular;
            textBox_afil_titular.Enabled = false;
            textBox_afil_usuario.Text = "";
            comboBox_afil_relacionConTitular.Text = "Hijo/a";
            comboBox_afil_estadoCivil.Text = "";
            comboBox_afil_plan.Enabled = false;
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
            labelStatus.Text = "";
        }

        protected void ofrecerAsignacionAFamiliares(String numeroTitular)
        {
            if (comboBox_afil_relacionConTitular.Text.Equals("Titular") && (comboBox_afil_estadoCivil.Text.Equals("Casado/a")
                || comboBox_afil_estadoCivil.Text.Equals("Concubinato")))
            {
                if (MessageBox.Show("¿Desea asociar al Cónyuge del nuevo Afiliado?", "Confirmar asociación del familiar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    limpiarCamposParaConyuge(numeroTitular);
                }
                else limpiarFormulario();
            }

            int cantHijos = Convert.ToInt32(comboBox_afil_CantFamACargo.Text);
            for (int i = 0; i < cantHijos; i++)
            {
                if (MessageBox.Show("¿Desea asociar al Hijo/a del nuevo Afiliado?", "Confirmar asociación del familiar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    limpiarCamposParaHijos(numeroTitular);
                }
                else limpiarFormulario();
            }
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_afil_titular.Text))
            {
            //seteamos valores a la base de datos
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.DarDeAltaUnAfiliado", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", SqlDbType.Decimal).Value = textBox_afil_usuario.Text;
                if (textBox_afil_titular.Text.Equals("")) { cmd.Parameters.AddWithValue("@titularNumero", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@titularNumero", SqlDbType.Decimal).Value = textBox_afil_titular.Text; }
                cmd.Parameters.AddWithValue("@estadoCivil", SqlDbType.VarChar).Value = comboBox_afil_estadoCivil.Text;
                cmd.Parameters.AddWithValue("@plan", SqlDbType.Decimal).Value = comboBox_afil_plan.SelectedValue;
                cmd.Parameters.AddWithValue("@familiaresACargo", SqlDbType.Decimal).Value = comboBox_afil_CantFamACargo.Text;
                cmd.Parameters.AddWithValue("@relacionConTitular", SqlDbType.VarChar).Value = comboBox_afil_relacionConTitular.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("La asiganción del rol Afiliado al usuario Nº " + textBox_afil_usuario.Text + " ha sido exitosa.",
                "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ofrece asociar al cónyuge si está casado o en concubinato, e hijos si tiene
            ofrecerAsignacionAFamiliares(textBox_afil_usuario.Text+"01");
            }
            else
            {
                MessageBox.Show("Debe ingresar el número del Afiliado titular. Si se está registrando a un titular, ingresar "+
                    "'Nº de Usuario' +'01'.", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        protected String verificarQueExistaElUsuario()
        {
            String nombreUsuario = "";
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select user_apellido +', '+ user_nombre as nombre_y_apellido " +
                                                    "from LOS_TRIGGERS.Usuario where user_name = cast(@usuario as varchar)", conn);
                command.Parameters.AddWithValue("@usuario", textBox_afil_usuario.Text);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) nombreUsuario = reader.GetString(0);

                reader.Close();
                conn.Close();

                return nombreUsuario;
            }
        }

        protected decimal verificarSiTieneRolAfiliado()
        {
            decimal numeroAfiliado = 0;
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select ISNULL(user_afiliado, 0) from LOS_TRIGGERS.Usuario "+
                    "where user_name = cast(@usuario as varchar)", conn);
                command.Parameters.AddWithValue("@usuario", textBox_afil_usuario.Text);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) numeroAfiliado = reader.GetDecimal(0);

                reader.Close();
                conn.Close();

                return numeroAfiliado;
            }
        }

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_usuario.Text))
            {
                MessageBox.Show("Debe ingresar el número del Usuario a verificar.", "Hay campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nombreUsuario = verificarQueExistaElUsuario();
                if (nombreUsuario != "")
                {
                    if (verificarSiTieneRolAfiliado() == 0)
                    {
                        labelStatus.Text = "Se le asignará el rol Afiliado al usuario " + nombreUsuario + ".";
                        permitirControles(true);
                        button_confirmar.Enabled = true;
                    }
                    else
                    {
                        labelStatus.Text = "El usuario " +nombreUsuario +" ya tiene asignado el rol Afiliado.";
                        permitirControles(false);
                        button_confirmar.Enabled = false;
                    }
                }
                else
                {
                    labelStatus.Text = "El usuario Nº " + textBox_afil_usuario.Text + " no pertenece al sistema.";
                    permitirControles(false);
                    button_confirmar.Enabled = false;
                }
            }
        }
    }
}
