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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Registrar_resul : Form
    {
        public Registrar_resul()
        {
            InitializeComponent();
            cargarEspecialidades();
        }

        public class Especialidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }

            public Especialidad(decimal _id, string _nombre)
            {
                this.id = _id;
                this.nombre = _nombre;
            }
        }

        protected void cargarEspecialidades()
        {
            cEspecialidad.DataSource = obtenerEspecialidades();
            cEspecialidad.DisplayMember = "nombre";
            cEspecialidad.ValueMember = "id";
        }

        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(
                    "select especialidad, espe_descripcion " +
                    "from LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad " +
                    "where profesional=@profesional AND espe_codigo=especialidad", conexionBase);
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));

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

        protected void llenar_grilla()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ConsultasPendientesAfiliado", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad)cEspecialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(t_afiliado.Text));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable consultas = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(consultas);
                grilla_consultas.DataSource = consultas;

                conexionBase.Close();
            }
        }

        private void b_filtrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(t_afiliado.Text))
            {
                llenar_grilla();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el número del Afiliado correspondiente.", "No se ha indicado número de Afiliado",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_registrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(t_sintomas.Text) && !string.IsNullOrEmpty(t_diagnostico.Text))
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("LOS_TRIGGERS.registro_resultado", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@consulta_numero", Convert.ToDecimal(grilla_consultas.SelectedRows[0].Cells[0].Value.ToString()));
                    command.Parameters.AddWithValue("@fecha_y_hora", ClinicaFrba.fecha.fechaActual);
                    command.Parameters.AddWithValue("@diag_sintomas", t_sintomas.Text);
                    command.Parameters.AddWithValue("@diag_descripcion", t_diagnostico.Text);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("El registro del Diagnóstico se ha completado satisfactoriamente.");
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los datos correspondientes al Diagnóstico.", "No se han completado todos los campos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}