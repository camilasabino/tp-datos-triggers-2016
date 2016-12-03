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
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void button_habilitar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                bool habilitado = validarHabilitacion();

                if (!habilitado)
                {
                    this.habilitar();
                }
                else { MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ya se encuentra habilitado"); }
            }
        }

        private void button_deshabilitar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                bool habilitado = validarHabilitacion();

                if (habilitado)
                {
                    this.deshabilitar();
                }
                else { MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ya se encuentra deshabilitado"); }
            }
        }

        private bool validarHabilitacion()
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
        
        private void deshabilitar()
        {
            conn.Open();

            SqlCommand command = new SqlCommand("LOS_TRIGGERS.DeshabilitarUnAfiliado", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            command.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ha sido deshabilitado"); 
        }

        private void habilitar()
        {
            conn.Open();

            SqlCommand command = new SqlCommand("LOS_TRIGGERS.HabilitarUnAfiliado", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            command.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " ha sido habilitado"); 
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
            Abm_Afiliado.Afiliado afiliado = new Abm_Afiliado.Afiliado();
        }

    }
}
