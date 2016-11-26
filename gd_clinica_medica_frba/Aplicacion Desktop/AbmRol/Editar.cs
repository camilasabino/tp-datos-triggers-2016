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
    public partial class Editar : Form
    {

        public class Funcionalidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }

            public Funcionalidad(decimal _id, string _nombre)
            {
                this.id = _id;
                this.nombre = _nombre;
            }
        }

      
        public Editar()
        {
            InitializeComponent();
            cargarFuncionalidades();
            
        }
        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void modificacion_Afiliado_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                this.cargarFuncionalidadesDeRol();
            }
        }


        public List<Funcionalidad> cargarFuncionalidadesDeRol()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboFuncionalidadesRol", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@rol", SqlDbType.VarChar).Value = nombreRol.Text;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(new Funcionalidad(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();

            }
            return funcionalidades;
        }
        protected void cargarFuncionalidades()
        {
            listBox1.DataSource = cargarFuncionalidadesDeRol();
            listBox1.DisplayMember = "nombre";
            listBox1.ValueMember = "id";
        }


        private void modificarNombre()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarRol", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol", SqlDbType.VarChar).Value = nombreRol.Text;
            cmd.Parameters.AddWithValue("@nuevo_nombre", SqlDbType.VarChar).Value = nombreRol.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        
        }


        private void eliminar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }


        private void agregar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(agregarFuncionalidad.Text);

            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.AgregarFuncionalidadAUnRol", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol", SqlDbType.VarChar).Value = nombreRol.Text;
            cmd.Parameters.AddWithValue("@funcionalidad", SqlDbType.VarChar).Value = agregarFuncionalidad.Text;
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        private void aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombreRol.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del ROL");

                return;
            }
            this.Close();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
