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
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

               
    private void aceptar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(nombreRol.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del Rol");
                return;
            }

            //seteamos valores a la base de datos

            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.AltaRol", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol", SqlDbType.Decimal).Value = nombreRol.Text;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Funcionalidades.Text))
            {
                Funcionalidades.Items.Clear();
            }
            this.Close();
        }

        private void agregarFuncionalidad_Click(object sender, EventArgs e)
        {
            Funcionalidades.Items.Add(agregar.Text);

            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.AgregarFuncionalidadAUnRol", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol", SqlDbType.VarChar).Value = nombreRol.Text;
            cmd.Parameters.AddWithValue("@funcionalidad", SqlDbType.VarChar).Value = agregarFuncionalidad.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

