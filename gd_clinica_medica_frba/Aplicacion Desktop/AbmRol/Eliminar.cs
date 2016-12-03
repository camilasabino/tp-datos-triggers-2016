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
            if (MessageBox.Show("¿Está seguro de que desea inhabilitar el rol: "+cRoles.Text+"?", "Inhabilitación de rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                darDeBaja();
            }
        }

        public void cargarRoles()
        {
            List<String> rolesHabilitados = new List<String>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select nombre_rol from LOS_TRIGGERS.Afiliado where afil_habilitacion = 1 "+
                                                    "union select nombre_rol from LOS_TRIGGERS.Profesional where prof_habilitacion = 1 "+
                                                    "union select nombre_rol from LOS_TRIGGERS.Administrador where admi_habilitacion = 1",
                                                    conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    rolesHabilitados.Add(reader.GetString(0));
                }
                conexionBase.Close();
            }
            cRoles.DataSource = rolesHabilitados;
        }

        private void darDeBaja()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.InhabilitarRol", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@rol", cRoles.Text);

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
            cargarRoles();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}
