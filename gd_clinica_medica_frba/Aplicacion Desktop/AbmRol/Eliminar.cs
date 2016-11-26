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
            cargarRoles();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                darDeBaja();
                this.Close();
            }
        }

        public void cargarRoles()
        {
            cRoles.Items.Insert(0, "Administrador");
            cRoles.Items.Insert(1, "Afiliado");
            cRoles.Items.Insert(2, "Profesional");
            cRoles.SelectedIndex = 0;
        }

        private void darDeBaja()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            conn.Open();

            SqlCommand command = new SqlCommand("LOS_TRIGGERS.DarDeBajaRol", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Rol", cRoles.SelectedItem.ToString());
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
