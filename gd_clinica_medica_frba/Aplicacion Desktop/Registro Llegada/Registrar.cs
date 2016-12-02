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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
            cargarEspecialidades();
            cargarProfesionales();
            labelBonos.Text = "";
        }

        protected void cargarEspecialidades()
        {
            c_especialidad.DataSource = Especialidad.obtenerEspecialidades();
            c_especialidad.DisplayMember = "nombre";
            c_especialidad.ValueMember = "id";
        }

        protected void cargarProfesionales()
        {
            c_profesional.DataSource = Profesional.obtenerProfesionales(((Especialidad)c_especialidad.SelectedItem).id);
            c_profesional.DisplayMember = "nombreYApellido";
            c_profesional.ValueMember = "id";
        }

        protected void llenar_grilla_turnos()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.TurnosAsignadosProfesionalEspecialidad", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)c_profesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad)c_especialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable turnos = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(turnos);
                grilla_turnos.DataSource = turnos;

                conexionBase.Close();
            }
        }

        public List<decimal> listar_disponibles_afiliado()
        {
            List<decimal> bonos = new List<decimal>();

            if (grilla_turnos.Rows.Count != 0 && grilla_turnos.SelectedRows.Count != 0)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();
                    SqlCommand comando = new SqlCommand("SELECT bono_numero FROM LOS_TRIGGERS.Bono, LOS_TRIGGERS.Compra_Bono " +
                                                        "where bono_consulta_medica is null AND comp_numero=bono_compra " +
                                                        "AND left(comp_afiliado, len(comp_afiliado)-2) = left(comp_afiliado, len(@afiliado)-2)", conn);
                    comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(grilla_turnos.SelectedRows[0].Cells[2].Value.ToString()));
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        bonos.Add(reader.GetDecimal(0));
                    }
                    conn.Close();
                }
            }
            if (!bonos.Any())
            {
                labelBonos.Text = "No hay bonos disponibles.";
                c_bonos.Enabled = false;
                b_registrar.Enabled = false;
            }
            else
            {
                labelBonos.Text = "";
                c_bonos.Enabled = true;
                b_registrar.Enabled = true;
            }
            return bonos;
        }

        protected void llenar_bonos()
        {
            c_bonos.DataSource = listar_disponibles_afiliado();
        }

        public void registrarLlegada()
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("LOS_TRIGGERS.registro_llegada", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@turn_numero", Convert.ToDecimal(grilla_turnos.SelectedRows[0].Cells[0].Value.ToString()));
                command.Parameters.AddWithValue("@bono_numero", Convert.ToDecimal(c_bonos.Text));
                command.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(grilla_turnos.SelectedRows[0].Cells[2].Value.ToString()));
                command.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha.fechaActual));

                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void b_registrar_Click(object sender, EventArgs e)
        {
                string consultaARegistrar = "¿Desea registrar la siguiente Consulta Médica?" + "\n\n" +
                    "Nº Turno: " + grilla_turnos.SelectedRows[0].Cells[0].Value.ToString() + "\n" +
                    "Horario: " + grilla_turnos.SelectedRows[0].Cells[1].Value.ToString() + "\n" +
                    "Profesional: " + c_profesional.SelectedValue.ToString() + "\n" +
                    "Especialidad: " + c_especialidad.SelectedValue.ToString() + "\n" +
                    "Afiliado: " + grilla_turnos.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                    "Bono Consulta: " + c_bonos.Text;

                if (MessageBox.Show(consultaARegistrar, "Confirmar registro de la Consulta Médica",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    registrarLlegada();

                    llenar_grilla_turnos();
                    grilla_turnos.ClearSelection();
                    MessageBox.Show("El registro de la Llegada se ha completado satisfactoriamente.");
                }
        }

        private void c_especialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarProfesionales();
        }

        private void grilla_turnos_SelectionChanged(object sender, EventArgs e)
        {
            llenar_bonos();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenar_grilla_turnos();
        }

        private void c_profesional_SelectedValueChanged(object sender, EventArgs e)
        {
            llenar_grilla_turnos();
        }
    }
}
