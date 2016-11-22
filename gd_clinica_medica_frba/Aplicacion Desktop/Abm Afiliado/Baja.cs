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
    public partial class Baja : Form
    {

        public Baja()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                this.darDeBaja();
                this.Close();
            }
        }

        private void darDeBaja()
        {
            conn.Open();

            SqlCommand command = new SqlCommand("LOS_TRIGGERS.DarDeBajaUnAfiliado", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            command.ExecuteNonQuery();

            conn.Close();

        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}
