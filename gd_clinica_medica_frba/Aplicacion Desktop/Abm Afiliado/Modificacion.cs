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
    public partial class
            Modificacion : Form
    {
        public Modificacion()
        {
            InitializeComponent();
            permitirControles(false);
            labelStatus.Text = "";
        }

        Afiliado afiliado = nuevoAfiliado();

        protected void permitirControles(Boolean valor)
        {
            richTextBox_afil_motivo.Enabled = valor;
            comboBox_afil_estadoCivil.Enabled = valor;
            comboBox_afil_plan.Enabled = valor;
            textBox_afil_Direccion.Enabled = valor;
            textBox_afil_mail.Enabled = valor;
            textBox_afil_telefono.Enabled = valor;
            button_confirmar.Enabled = valor;
        }

        public class Afiliado
        {
            public string estadoCivil { get; set; }
            public decimal plan { get; set; }
            public string mail { get; set; }
            public string direccion { get; set; }
            public decimal telefono { get; set; }

            public Afiliado(string e, decimal p, string m, string d, decimal t)
            {
                this.estadoCivil = e;
                this.plan = p;
                this.mail = m;
                this.direccion = d;
                this.telefono = t;
            }
        }

        protected static Afiliado nuevoAfiliado()
        {
            return new Afiliado(null, 0, null, null, 0);
        }

        public class Plan
        {
            public decimal id { get; set; }
            public string descripcion { get; set; }

            public Plan(decimal _id, string _descripcion)
            {
                this.id = _id;
                this.descripcion = _descripcion;
            }
        }

        protected void traerDatosAfiliado()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select ISNULL(afil_estado_civil, 'none'), afil_plan_medico, user_mail, user_direccion, user_telefono " +
                    "from LOS_TRIGGERS.Afiliado, LOS_TRIGGERS.Usuario where afil_numero=@afiliado AND user_afiliado=afil_numero", conn);
                command.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(textBox_afil_numero.Text));

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                afiliado = new Afiliado(reader.GetString(0), reader.GetDecimal(1), reader.GetString(2),
                    reader.GetString(3), reader.GetDecimal(4));
                reader.Close();
                conn.Close();
            }
        }

        private void llenarComboPLan()
        {
            List<Plan> planes = new List<Plan>();
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
                        planes.Add(new Plan(reader.GetDecimal(0), reader.GetString(1)));
                    }

                    comboBox_afil_plan.DataSource = planes;
                    comboBox_afil_plan.DisplayMember = "descripcion";
                    comboBox_afil_plan.ValueMember = "id";

                    comboBox_afil_plan.SelectedItem = comboBox_afil_plan.Items.Cast<Plan>().Where(p => p.id == afiliado.plan).First();
                }
                conn.Close();
            }
        }

        private void llenarComboEstadoCivil()
        {
            comboBox_afil_estadoCivil.Items.Add("Soltero/a");
            comboBox_afil_estadoCivil.Items.Add("Casado/a");
            comboBox_afil_estadoCivil.Items.Add("Viudo/a");
            comboBox_afil_estadoCivil.Items.Add("Concubinato");
            comboBox_afil_estadoCivil.Items.Add("Divorciado/a");

            if (afiliado.estadoCivil == "none") comboBox_afil_estadoCivil.SelectedIndex = -1;
            else comboBox_afil_estadoCivil.SelectedItem = comboBox_afil_estadoCivil.Items.Cast<String>().Where(e => e == afiliado.estadoCivil).First();
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
                if (((Plan)comboBox_afil_plan.SelectedItem).id != afiliado.plan
                    && !string.IsNullOrEmpty(comboBox_afil_plan.Text))
                {
                    if (string.IsNullOrEmpty(richTextBox_afil_motivo.Text))
                        MessageBox.Show("Debe ingresar un motivo que justifique el cambio de Plan Médico.",
                            "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        continuarModificacion(true);
                    }
                }
                else continuarModificacion(false);
        }

        protected void continuarModificacion(Boolean updatePlan)
        {
            if (MessageBox.Show("¿Está seguro de modificar al Afiliado con los siguientes datos?" + "\n\n" +
                "Estado Civil: " + comboBox_afil_estadoCivil.Text + "\n" +
                "Dirección: " + textBox_afil_Direccion.Text + "\n" +
                "Mail: " + textBox_afil_mail.Text + "\n" +
                "Teléfono: " + textBox_afil_telefono.Text + "\n" +
                "Plan Médico: " + comboBox_afil_plan.Text,
                "Confirmación de la Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(textBox_afil_Direccion.Text)) modificarDireccion();

                if (!string.IsNullOrEmpty(comboBox_afil_estadoCivil.Text)) modificarEstadoCivil();

                if (!string.IsNullOrEmpty(textBox_afil_telefono.Text)) modificarTelefono();

                if (!string.IsNullOrEmpty(textBox_afil_mail.Text)) modificarMail();

                if (updatePlan) modificarPlan();

                MessageBox.Show("El afiliado Nº " + textBox_afil_numero.Text + " ha sido modificado exitosamente.",
                    "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox_afil_motivo.Text = "";
                traerDatosAfiliado();
            }
        }

        private void modificarDireccion()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoDireccion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                cmd.Parameters.AddWithValue("@nueva_direccion", SqlDbType.VarChar).Value = textBox_afil_Direccion.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void modificarEstadoCivil()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoEstadoCivil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                cmd.Parameters.AddWithValue("@nuevoEstadoCivil", SqlDbType.VarChar).Value = comboBox_afil_estadoCivil.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void modificarTelefono()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoTelefono", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                cmd.Parameters.AddWithValue("@nuevo_telefono", SqlDbType.Decimal).Value = textBox_afil_telefono.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void modificarMail()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoMail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                cmd.Parameters.AddWithValue("@nuevo_mail", SqlDbType.VarChar).Value = textBox_afil_mail.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void modificarPlan()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoPlanMedico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                cmd.Parameters.AddWithValue("@nuevo_plan", SqlDbType.Decimal).Value = comboBox_afil_plan.SelectedValue;
                cmd.Parameters.AddWithValue("@motivo", SqlDbType.VarChar).Value = richTextBox_afil_motivo.Text;
                cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected String verificarQueExistaElAfiliado()
        {
            String nombreAfiliado = "";
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select user_apellido +', '+ user_nombre as nombre_y_apellido " +
                                                    "from LOS_TRIGGERS.Usuario where user_afiliado = " + textBox_afil_numero.Text, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) nombreAfiliado = reader.GetString(0);

                reader.Close();
                conn.Close();

                return nombreAfiliado;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
            Abm_Afiliado.Afiliado afiliado = new Abm_Afiliado.Afiliado();
        }

        private void buttonDatos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_numero.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado a modificar.", "Hay campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nombreAfiliado = verificarQueExistaElAfiliado();
                if (nombreAfiliado != "")
                {
                    labelStatus.Text = "";
                    permitirControles(true);
                    traerDatosAfiliado();
                    llenarComboPLan();
                    llenarComboEstadoCivil();
                    textBox_afil_telefono.Text = afiliado.telefono.ToString();
                    textBox_afil_mail.Text = afiliado.mail;
                    textBox_afil_Direccion.Text = afiliado.direccion;
                }
                else
                {
                    labelStatus.Text = "El afiliado Nº " + textBox_afil_numero.Text + " no pertenece al sistema.";
                    permitirControles(false);
                    textBox_afil_telefono.Text = "";
                    textBox_afil_mail.Text = "";
                    textBox_afil_Direccion.Text = "";
                    comboBox_afil_plan.SelectedIndex = -1;
                    comboBox_afil_estadoCivil.SelectedIndex = -1;
                }
            }
        }
    }
}
