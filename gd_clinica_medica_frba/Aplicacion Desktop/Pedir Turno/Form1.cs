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
using System.Configuration;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*---- ENTIDADES DEL MODELO ----*/
        public class Especialidad {
            public int id { get; set; }
            public string nombre { get; set; }
        }

        public class Profesional {
            public int id { get; set; }
            public string nombreYApellido { get; set; }
        }

        public class Turno {
            public int id { get; set; }
            public string hora { get; set; }
            public string fecha { get; set; }
        }


        protected void cargarProfesionales(string especialidad){
           using (SqlConnection conn = new SqlConnection(conexion.cadena)){
                conn.Open();

               /* comando.Parameters.AddWithValue("turn_numero", turno);
                command.Parameters.AddWithValue("bono_numero", bono);
                command.Parameters.AddWithValue("afiliado", afiliado);
                command.Parameters.AddWithValue("fecha", fecha);

                String query = "EXEC DB_MASTERS.InsertarPublicacion '" + username + "', '" + comboBoxVisibilidad.Text + "', '" + estado
             + "', '" + comboBoxRubro.Text + "', '" + fechaInicio.ToString(Properties.Settings.Default.SYSTEM_DATE) + "', '" + fechaFin.ToString(Properties.Settings.Default.SYSTEM_DATE)
             + "', '" + textBoxDetail.Text + "', " + textBoxPrecio.Text + ", " + int.Parse(textBoxStock.Text);*/
        }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e){

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e){

        }

        private void button1_Click(object sender, EventArgs e){

        }

        private void button2_Click(object sender, EventArgs e){

        }

        public static List<Especialidad> obtenerEspecialidades(){
            List<Especialidad> especialidades = new List<Especialidad>();

            using (SqlConnection conn = new SqlConnection(conexion.cadena)){
                conn.Open();

                SqlCommand comando = new SqlCommand("EXEC LOS_TRIGGERS.ComboEspecialidades", conn);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read()){
                    Especialidad espe = new Especialidad();

                    espe.id = reader.GetInt32(0);
                    espe.nombre = reader.GetString(1);

                    especialidades.Add(espe);
                }
                conn.Close();
            }
            return especialidades;
        }
    }
}
