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
    public partial class Form1 : Form
    {/*
       // public decimal profesional;
        //decimal especialidad;
       // decimal turno;
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        */
        public Form1()
        {
            InitializeComponent();
            //cargarEspecialidades();
            //cargarProfesionales();
           // gridFechas.DataSource = bindingSource;
            //cargarFechas();
            //cargarHorarios();
        }

        /*---- ENTIDADES DEL MODELO ----*/

        /*
        public class Especialidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }
        }

        public class Profesional
        {
            public decimal id { get; set; }
            public string nombreYApellido { get; set; }
        }

        public class FechaDisponible
        {
            public decimal id { get; set; }
            public string fecha { get; set; }
            public string dia { get; set; }
        }

        public class HorarioDisponible
        {
            public decimal id { get; set; }
            public string hora { get; set; }
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

        public List<Profesional> obtenerProfesionales()
        {
            List<Profesional> profesionales = new List<Profesional>();

            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad", conn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(cEspecialidad.SelectedValue));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Profesional prof = new Profesional();

                    prof.id = reader.GetDecimal(0);
                    prof.nombreYApellido = reader.GetString(1);

                    profesionales.Add(prof);
                }
                conn.Close();
            }
            return profesionales;
        }

        public List<FechaDisponible> obtenerFechas()
        {
            List<FechaDisponible> fechas = new List<FechaDisponible>();

            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad", conn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(cProfesional.SelectedValue));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(cEspecialidad.SelectedValue));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    FechaDisponible _fecha = new FechaDisponible();

                    _fecha.id = reader.GetDecimal(0);
                    _fecha.fecha = reader.GetString(1);
                    _fecha.dia = reader.GetString(2);

                    fechas.Add(_fecha);
                }
                conn.Close();
            }
            return fechas;
        }
        
        public List<HorarioDisponible> obtenerHorarios()
        {
            List<HorarioDisponible> horarios = new List<HorarioDisponible>();

            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.HorariosDisponiblesTurno", conn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(cProfesional.SelectedValue));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(cEspecialidad.SelectedValue));
                //comando.Parameters.AddWithValue("@fecha", Convert.ToDateTime());
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    HorarioDisponible _hora = new HorarioDisponible();

                    _hora.id = reader.GetDecimal(0);
                    _hora.hora = reader.GetString(1);

                    horarios.Add(_hora);
                }
                conn.Close();
            }
            return horarios;
        }

        protected void cargarEspecialidades(){
            cEspecialidad.DataSource = obtenerEspecialidades();
            cEspecialidad.DisplayMember = "nombre";
            cEspecialidad.ValueMember = "id";
        }

        protected void cargarProfesionales()
        {
            cProfesional.DataSource = obtenerProfesionales();
            cProfesional.DisplayMember = "nombreYApellido";
            cProfesional.ValueMember = "id";
        }

        protected void cargarFechas()
        {

            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                string query = "LOS_TRIGGERS.ComboFechasDisponiblesTurno " + Convert.ToDecimal(cProfesional.SelectedValue) + ", " + Convert.ToDecimal(cEspecialidad.SelectedValue)
                    + " ," + Convert.ToDateTime(ClinicaFrba.fecha.fechaActual);

                SqlCommand comando = new SqlCommand(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
               // DataSet ds = new DataSet();
                //gridFechas.DataSource = obtenerFechas();
                // SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;

                gridFechas.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
        }
        
        protected void cargarHorarios()
        {
           
        }

        private void cProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO
        }

        private void cEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargarProfesionales();
        }*/

    }
}
