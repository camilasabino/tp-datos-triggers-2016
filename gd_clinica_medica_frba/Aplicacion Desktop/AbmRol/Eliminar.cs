using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void Aceptar_Click(object sender, EventArgs e)
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

            SqlCommand command = new SqlCommand("LOS_TRIGGERS.DarDeBajaRol", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Rol", SqlDbType.Decimal).Value = nombreRol.Text;
            command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            command.ExecuteNonQuery();

            conn.Close();

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
