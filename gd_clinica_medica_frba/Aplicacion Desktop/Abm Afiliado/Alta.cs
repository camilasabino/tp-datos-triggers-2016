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
            textDni.Text = "";
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
            comboBox_afil_plan.DataSource = Plan.traerPlanesMedicos();
            comboBox_afil_plan.DisplayMember = "descripcion";
            comboBox_afil_plan.ValueMember = "id";

            comboBox_afil_plan.SelectedIndex = -1;
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

        private void limpiarCamposParaConyuge(String numeroTitular)
        {
            labelStatus.Text = "";
            textBox_afil_usuario.Text = "";
            textDni.Text = "";
            button_confirmar.Enabled = false;
            textBox_afil_titular.Text = numeroTitular;
            textBox_afil_titular.Enabled = false;
            comboBox_afil_plan.Enabled = false;
            comboBox_afil_relacionConTitular.Text = "Cónyuge";
            comboBox_afil_relacionConTitular.Enabled = false;
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
            comboBox_afil_estadoCivil.Enabled = false;
            button_confirmar.Enabled = false;
        }

        private void limpiarCamposParaHijos(String numeroTitular)
        {
            labelStatus.Text = "";
            textBox_afil_usuario.Text = "";
            textDni.Text = "";
            button_confirmar.Enabled = false;
            textBox_afil_titular.Text = numeroTitular;
            textBox_afil_titular.Enabled = false;
            comboBox_afil_plan.Enabled = false;
            comboBox_afil_relacionConTitular.Text = "Hijo/a";
            comboBox_afil_relacionConTitular.Enabled = false;
            label3.Visible = false;
            comboBox_afil_CantFamACargo.Visible = false;
            comboBox_afil_estadoCivil.SelectedIndex = -1; 
            comboBox_afil_estadoCivil.Enabled = true;
            button_confirmar.Enabled = false;
        }

        protected void ofrecerAsignacionAHijos(String numeroTitular, String familiaresACargo)
        {
            int cantHijos = Convert.ToInt32(familiaresACargo);
            if (cantHijos != 0)
            {
                if (MessageBox.Show("¿Desea asociar al Hijo/a del nuevo Afiliado Titular?", "Confirmar asociación del familiar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    limpiarCamposParaHijos(numeroTitular);
                }
                comboBox_afil_CantFamACargo.Text = Convert.ToString(cantHijos - 1);
            }
            else limpiarFormulario();
        }

        protected void ofrecerAsignacionAConyuge(String numeroTitular)
        {
            if (comboBox_afil_estadoCivil.Text.Equals("Casado/a") || comboBox_afil_estadoCivil.Text.Equals("Concubinato"))
            {
                if (MessageBox.Show("¿Desea asociar al Cónyuge del nuevo Afiliado Titular?", "Confirmar asociación del familiar",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    limpiarCamposParaConyuge(numeroTitular);
                }
            }
        }

        protected Boolean validarCamposCompletos()
        {
            Boolean validacion = true;
            if (string.IsNullOrEmpty(comboBox_afil_CantFamACargo.Text)) validacion = false;
            if (string.IsNullOrEmpty(comboBox_afil_estadoCivil.Text)) validacion = false;
            if (string.IsNullOrEmpty(comboBox_afil_plan.Text)) validacion = false;
            if (string.IsNullOrEmpty(comboBox_afil_relacionConTitular.Text)) validacion = false;
            return validacion;
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textDni.Text))
            {
                if (!string.IsNullOrEmpty(textBox_afil_titular.Text))
                {
                    if (validarCamposCompletos())
                    {
                        //seteamos valores a la base de datos
                        SqlConnection conn = new SqlConnection(conexion.cadena);
                        using (conn)
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.DarDeAltaUnAfiliado", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@usuario", textBox_afil_usuario.Text);
                            cmd.Parameters.AddWithValue("@dni", Convert.ToDecimal(textDni.Text));
                            cmd.Parameters.AddWithValue("@titularNumero", Convert.ToDecimal(textBox_afil_titular.Text));
                            cmd.Parameters.AddWithValue("@estadoCivil", comboBox_afil_estadoCivil.Text);
                            cmd.Parameters.AddWithValue("@plan", ((Plan)comboBox_afil_plan.SelectedItem).id);
                            cmd.Parameters.AddWithValue("@familiaresACargo", Convert.ToDecimal(comboBox_afil_CantFamACargo.Text));
                            cmd.Parameters.AddWithValue("@relacionConTitular", comboBox_afil_relacionConTitular.Text);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        MessageBox.Show("La asiganción del rol Afiliado al Usuario " + textBox_afil_usuario.Text + " ha sido exitosa.",
                            "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //ofrece asociar al cónyuge si está casado o en concubinato, e hijos si tiene
                        if (comboBox_afil_relacionConTitular.Text.Equals("Titular"))
                            ofrecerAsignacionAConyuge(textDni.Text + "01");
                        else if (comboBox_afil_relacionConTitular.Text.Equals("Cónyuge"))
                            ofrecerAsignacionAHijos(textBox_afil_titular.Text, comboBox_afil_CantFamACargo.Text);
                        else if(comboBox_afil_relacionConTitular.Text.Equals("Hijo/a"))
                            ofrecerAsignacionAHijos(textBox_afil_titular.Text, comboBox_afil_CantFamACargo.Text);
                        else limpiarFormulario();
                    }
                    else MessageBox.Show("Debe completar todos los datos necesarios para la creación del Afiliado. Revise todos los combobox.",
                        "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Debe ingresar el número del Afiliado titular. Si se está registrando a un titular, ingresar " +
                    "'Nº de DNI' + '01'.", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Debe ingresar el número de DNI del usuario.", "Hay campos incompletos",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SqlCommand command = new SqlCommand("select ISNULL(user_afiliado, 0) from LOS_TRIGGERS.Usuario " +
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
                        if (string.IsNullOrEmpty(comboBox_afil_relacionConTitular.Text))
                            permitirControles(true);
                        else if (comboBox_afil_relacionConTitular.Text.Equals("Cónyuge"))
                        {
                            textBox_afil_titular.Enabled = false;
                            comboBox_afil_plan.Enabled = false;
                            comboBox_afil_relacionConTitular.Enabled = false;
                            comboBox_afil_estadoCivil.Enabled = false;
                        }
                        else if (comboBox_afil_relacionConTitular.Text.Equals("Hijo/a"))
                        {
                            textBox_afil_titular.Enabled = false;
                            comboBox_afil_plan.Enabled = false;
                            comboBox_afil_relacionConTitular.Enabled = false;
                            comboBox_afil_estadoCivil.Enabled = true;
                        }
                        button_confirmar.Enabled = true;
                    }
                    else
                    {
                        labelStatus.Text = "El usuario " + nombreUsuario + " ya tiene asignado el rol Afiliado.";
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
