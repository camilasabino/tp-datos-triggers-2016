using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// DB Connection:
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Pedir_Turno
{
/***************************************************************************************************
 *                                   PEDIDO DE TURNOS                                              *
 ***************************************************************************************************/
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //cargarEspecialidades();
        }

        /*---- ENTIDADES DEL MODELO ----*/

        public class Especialidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }
        }

        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboEspecialidades", conn);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Especialidad espe = new Especialidad();

                    espe.id = reader.GetDecimal(0);
                    espe.nombre = reader.GetString(1);

                    especialidades.Add(espe);
                }
                conn.Close();
            }
            return especialidades;
        }

        protected void cargarEspecialidades(){
            cEspecialidad.DataSource = obtenerEspecialidades();
            cEspecialidad.DisplayMember = "nombre";
            cEspecialidad.ValueMember = "id";
        }

        private void cProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargarProfesionales();
        }

    }
}
