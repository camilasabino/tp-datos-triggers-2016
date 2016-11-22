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
    public partial class PedirTurno : Form
    {
        public PedirTurno()
        {
            InitializeComponent();
            cargarEspecialidades();
            cargarProfesionales();
            cargarFechas();
            cargarHorarios();
        }

        public class Especialidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }

            public Especialidad(decimal _id, string _nombre) {
                this.id = _id;
                this.nombre = _nombre;
            }
        }

        public class Profesional
        {
            public decimal id { get; set; }
            public string nombreYApellido { get; set; }

            public Profesional(decimal _id, string _nombre) {
                this.id = _id;
                this.nombreYApellido = _nombre;
            }
        }

        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(
                    "select espe_codigo, espe_descripcion from LOS_TRIGGERS.Especialidad order by espe_descripcion",
                    conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                  especialidades.Add(
                      new Especialidad(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return especialidades;
        }

        public List<Profesional> obtenerProfesionales() 
        {
            List<Profesional> profesionales = new List<Profesional>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad) cEspecialidad.SelectedItem).id));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    profesionales.Add(
                        new Profesional(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return profesionales;
        }

        protected void cargarEspecialidades() {
            cEspecialidad.DataSource = obtenerEspecialidades();
            cEspecialidad.DisplayMember = "nombre";
            cEspecialidad.ValueMember = "id";
        }

        protected void cargarProfesionales() {
            cProfesional.DataSource = obtenerProfesionales();
            cProfesional.DisplayMember = "nombreYApellido";
            cProfesional.ValueMember = "id";
        }

        protected void cargarFechas()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboFechasDisponiblesTurno", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional) cProfesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad) cEspecialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));
                
                DataTable fechas = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(fechas);
                gridFechas.DataSource = fechas;

                conexionBase.Close();
            }
        }

        protected void cargarHorarios()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();

                string fechaSeleccionada = "2100/01/01";
                try
                {
                    fechaSeleccionada = gridFechas.SelectedRows[0].Cells[0].Value.ToString();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.HorariosDisponiblesTurno", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional) cProfesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad) cEspecialidad.SelectedItem).id)); 
                comando.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fechaSeleccionada));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable horarios = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(horarios);
                gridHorarios.DataSource = horarios;

                conexionBase.Close();
            }
        }

        protected void confirmarTurno()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.PedirTurno", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)cProfesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad)cEspecialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@fecha", Convert.ToDateTime(gridFechas.SelectedRows[0].Cells[0].Value.ToString()));
                comando.Parameters.AddWithValue("@hora", gridHorarios.SelectedRows[0].Cells[0].Value.ToString());

                conexionBase.Close();
            }
        }

/**************************************************************************************************
*                                   EVENTOS DEL FORM                                              *
***************************************************************************************************/
      
        private void cEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProfesionales();
        }

        private void cProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFechas();
        }

        private void gridFechas_SelectionChanged(object sender, EventArgs e)
        {
            cargarHorarios();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            string turnoAConfirmar = "¿Desea confirmar el siguiente turno?" + "\n\n" +
                                     "Especialidad: " + ((Especialidad) cEspecialidad.SelectedItem).nombre + "\n" +
                                     "Profesional: " + ((Profesional) cProfesional.SelectedItem).nombreYApellido + "\n" +
                                     "Fecha: " + gridFechas.SelectedRows[0].Cells[0].Value.ToString() + "\n" +
                                     "Horario: " + gridHorarios.SelectedRows[0].Cells[0].Value.ToString();

            if (MessageBox.Show(turnoAConfirmar, "Confirmar Turno",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                confirmarTurno();
                this.Hide();
            }
        }
    }
}
                                                                                                                    
