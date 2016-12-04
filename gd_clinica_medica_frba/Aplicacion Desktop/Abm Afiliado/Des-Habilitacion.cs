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
    public partial class HabilitacionDeshabilitacion : Form
    {
        public HabilitacionDeshabilitacion()
        {
            InitializeComponent();
            limpiarFormulario();
        }

        protected void limpiarFormulario()
        {
            button_habilitar.Enabled = false;
            button_deshabilitar.Enabled = false;
            textBox_afil_numero.Text = "";
            labelStatus.Text = "";
        }

        private void button_habilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de habilitar al Afiliado indicado?", "Confirmación de la Operación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(conexion.cadena);
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("LOS_TRIGGERS.HabilitarUnAfiliado", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                    command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
                    command.ExecuteNonQuery();

                    MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ha sido habilitado",
                        "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
                limpiarFormulario();
            }
        }

        private void button_deshabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de inhabilitar al Afiliado indicado?", "Confirmación de la Operación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(conexion.cadena);
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("LOS_TRIGGERS.DeshabilitarUnAfiliado", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                    command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
                    command.ExecuteNonQuery();

                    MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ha sido inhabilitado",
                        "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
                limpiarFormulario();
            }
        }

        private Boolean validarHabilitacion()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                string afil_habilitacion = "select afil_habilitacion from LOS_TRIGGERS.Afiliado where afil_numero = " + textBox_afil_numero.Text;
                SqlCommand command = new SqlCommand(afil_habilitacion, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                bool habilitacion = reader.GetBoolean(0);
                reader.Close();
                conn.Close();

                return habilitacion;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
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

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_numero.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado a validar.", "Hay campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nombreAfiliado = verificarQueExistaElAfiliado();
                if (nombreAfiliado != "")
                {
                    if (validarHabilitacion())
                    {
                        labelStatus.Text = "El afiliado " + nombreAfiliado + " se encuentra actualmente habilitado.";
                        button_habilitar.Enabled = false;
                        button_deshabilitar.Enabled = true;
                    }
                    else
                    {
                        labelStatus.Text = "El afiliado " + nombreAfiliado + " se encuentra actualmente inhabilitado.";
                        button_habilitar.Enabled = true;
                        button_deshabilitar.Enabled = false;
                    }
                }
                else
                {
                    labelStatus.Text = "El afiliado Nº " + textBox_afil_numero.Text + " no pertenece al sistema.";
                    button_habilitar.Enabled = false;
                    button_deshabilitar.Enabled = false;
                }
            }
        }
    }
}
