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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    /***************************************************************************************************
    *                            REGISTRO DE AGENDA PROFESIONAL                                        *
    ***************************************************************************************************/
    public partial class RegistrarAgenda : Form
    {
        public RegistrarAgenda()
        {
            InitializeComponent();
            actualizarFormulario();
        }

        protected void actualizarFormulario()
        {
            errorPanel.Text = "";
            cargarProfesionales();
            cargarEspecialidades();
            cargarDiasAtencionClinica();

            hDesdeLun.Enabled = checkLun.Checked;
            hHastaLun.Enabled = checkLun.Checked;
            hDesdeMar.Enabled = checkMar.Checked;
            hHastaMar.Enabled = checkMar.Checked;
            hDesdeMier.Enabled = checkMier.Checked;
            hHastaMier.Enabled = checkMier.Checked;
            hDesdeJue.Enabled = checkJue.Checked;
            hHastaJue.Enabled = checkJue.Checked;
            hDesdeVier.Enabled = checkVier.Checked;
            hHastaVier.Enabled = checkVier.Checked;
            hDesdeSab.Enabled = checkSab.Checked;
            hHastaSab.Enabled = checkSab.Checked;

            dateDesde.MinDate = DateTime.Parse(ClinicaFrba.fecha.fechaActual);
            dateDesde.Value = DateTime.Parse(ClinicaFrba.fecha.fechaActual);
            dateDesde.MaxDate = new DateTime(2017, 12, 31);
            dateDesde.CustomFormat = "yyyy-MM-dd";
            dateDesde.Format = DateTimePickerFormat.Custom;

            dateHasta.MinDate = dateDesde.Value;
            dateHasta.Value = dateDesde.Value;
            dateHasta.MaxDate = new DateTime(2017, 12, 31);
            dateHasta.CustomFormat = "yyyy-MM-dd";
            dateHasta.Format = DateTimePickerFormat.Custom;
        }

        protected void permitirControles(Boolean valor)
        {
            checkLun.Enabled = valor;
            checkMar.Enabled = valor;
            checkMier.Enabled = valor;
            checkJue.Enabled = valor;
            checkVier.Enabled = valor;
            checkSab.Enabled = valor;
            cEspecialidad.Enabled = valor;
            dateDesde.Enabled = valor;
            dateHasta.Enabled = valor;
            buttonConfirmar.Enabled = valor;
        }

        protected List<Profesional> obtenerProfesionales()
        {
            List<Profesional> profesionales = new List<Profesional>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select distinct(user_profesional) as profesional_id, "+
                                                    "user_apellido+', '+user_nombre as apellido_y_nombre "+
			                                        "from LOS_TRIGGERS.Usuario where user_profesional is not null order by 2",
                                                    conexionBase);

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

        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select espe_codigo, espe_descripcion " +
                                                    "from LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad " +
                                                    "where profesional = @profesional" +
                                                    " AND NOT EXISTS (select * from LOS_TRIGGERS.Dia_Atencion " +
                                                    "where dia_especialidad_profesional=espe_prof_id) AND espe_codigo=especialidad",
                                                    conexionBase);
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)cProfesional.SelectedItem).id));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    especialidades.Add(
                        new Especialidad(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            if (!especialidades.Any())
            {
                errorPanel.Text = "El Profesional ya tiene una Agenda cargada para todas sus especialidades.";
                permitirControles(false);
            }
            else
            {
                errorPanel.Text = "";
                permitirControles(true);
            }

            return especialidades;
        }

        public void cargarDiasAtencionClinica()
        {
            hDesdeLun.DataSource = cargarHorariosAtencionClinica("Lunes", "07:00");
            hHastaLun.DataSource = cargarHorariosAtencionClinica("Lunes", hDesdeLun.SelectedValue.ToString());
            hDesdeMar.DataSource = cargarHorariosAtencionClinica("Martes", "07:00");
            hHastaMar.DataSource = cargarHorariosAtencionClinica("Martes", hDesdeMar.SelectedValue.ToString());
            hDesdeMier.DataSource = cargarHorariosAtencionClinica("Miércoles", "07:00");
            hHastaMier.DataSource = cargarHorariosAtencionClinica("Miércoles", hDesdeMier.SelectedValue.ToString());
            hDesdeJue.DataSource = cargarHorariosAtencionClinica("Jueves", "07:00");
            hHastaJue.DataSource = cargarHorariosAtencionClinica("Jueves", hDesdeJue.SelectedValue.ToString());
            hDesdeVier.DataSource = cargarHorariosAtencionClinica("Viernes", "07:00");
            hHastaVier.DataSource = cargarHorariosAtencionClinica("Viernes", hDesdeVier.SelectedValue.ToString());
            hDesdeSab.DataSource = cargarHorariosAtencionClinica("Sábado", "10:00");
            hHastaSab.DataSource = cargarHorariosAtencionClinica("Sábado", hDesdeSab.SelectedValue.ToString());
        }

        public List<String> cargarHorariosAtencionClinica(String dia, String hora_base)
        {
            List<String> horarios = new List<String>();
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select hora_inicio from LOS_TRIGGERS.Horario_Atencion " +
                                                    "where hora_especialidad_profesional is null AND hora_nombre_dia=@dia " +
                                                    "AND CONVERT(time, hora_inicio) >= CONVERT(time, @hora_base) " +
                                                    "union select MAX(hora_fin) from LOS_TRIGGERS.Horario_Atencion " +
                                                    "where hora_especialidad_profesional is null AND hora_nombre_dia=@dia", conexionBase);
                comando.Parameters.AddWithValue("@dia", dia);
                comando.Parameters.AddWithValue("@hora_base", hora_base);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    horarios.Add(reader.GetString(0));
                }
                conexionBase.Close();
            }
            return horarios;
        }

        protected void cargarEspecialidades()
        {
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

        protected void registrarDiaDeAtencion(String dia, String inicio, String fin)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.RegistrarDiaAtencionProfesional", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)cProfesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad)cEspecialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@dia", dia);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fin", fin);

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
        }

        protected void registrarAgenda()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.RegistrarAgendaProfesional", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)cProfesional.SelectedItem).id));
                comando.Parameters.AddWithValue("@especialidad", Convert.ToDecimal(((Especialidad)cEspecialidad.SelectedItem).id));
                comando.Parameters.AddWithValue("@desde", Convert.ToDateTime(dateDesde.Value));
                comando.Parameters.AddWithValue("@hasta", Convert.ToDateTime(dateHasta.Value));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
        }

        protected int horasLaboralesEnUnDia(String desde, String hasta)
        {
            TimeSpan duracion = Convert.ToDateTime(hasta) - Convert.ToDateTime(desde);

            return duracion.Hours;
        }

        protected Boolean verificarCantidadHorasLaborales()
        {
            int cantHorasLaborales;
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select prof_horas_laborales from LOS_TRIGGERS.Profesional " +
                                                    "where prof_id=@profesional", conexionBase);
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(((Profesional)cProfesional.SelectedItem).id));

                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                cantHorasLaborales = (int)reader.GetDecimal(0);

                conexionBase.Close();
            }
            if (checkLun.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeLun.SelectedValue.ToString(), hHastaLun.SelectedValue.ToString());
            }
            if (checkMar.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeMar.SelectedValue.ToString(), hHastaMar.SelectedValue.ToString());
            }
            if (checkMier.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeMier.SelectedValue.ToString(), hHastaMier.SelectedValue.ToString());
            }
            if (checkJue.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeJue.SelectedValue.ToString(), hHastaJue.SelectedValue.ToString());
            }
            if (checkVier.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeVier.SelectedValue.ToString(), hHastaVier.SelectedValue.ToString());
            }
            if (checkSab.Checked)
            {
                cantHorasLaborales += horasLaboralesEnUnDia(hDesdeSab.SelectedValue.ToString(), hHastaSab.SelectedValue.ToString());
            }
            return cantHorasLaborales <= 48;
        }

        /**************************************************************************************************
        *                                   EVENTOS DEL FORM                                              *
        ***************************************************************************************************/

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (verificarCantidadHorasLaborales())
            {
                if (MessageBox.Show("¿Está seguro de registrar la Agenda con los valores indicados?" + "\n" +
                    "Una vez registrada, la Agenda es inalterable.", "Confirmar registro de Agenda",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkLun.Checked)
                    {
                        registrarDiaDeAtencion("Lunes", hDesdeLun.SelectedValue.ToString(), hHastaLun.SelectedValue.ToString());
                    }
                    if (checkMar.Checked)
                    {
                        registrarDiaDeAtencion("Martes", hDesdeMar.SelectedValue.ToString(), hHastaMar.SelectedValue.ToString());
                    }
                    if (checkMier.Checked)
                    {
                        registrarDiaDeAtencion("Miércoles", hDesdeMier.SelectedValue.ToString(), hHastaMier.SelectedValue.ToString());
                    }
                    if (checkJue.Checked)
                    {
                        registrarDiaDeAtencion("Jueves", hDesdeJue.SelectedValue.ToString(), hHastaJue.SelectedValue.ToString());
                    }
                    if (checkVier.Checked)
                    {
                        registrarDiaDeAtencion("Viernes", hDesdeVier.SelectedValue.ToString(), hHastaVier.SelectedValue.ToString());
                    }
                    if (checkSab.Checked)
                    {
                        registrarDiaDeAtencion("Sábado", hDesdeSab.SelectedValue.ToString(), hHastaSab.SelectedValue.ToString());
                    }
                    registrarAgenda();
                    MessageBox.Show("El registro de la Agenda del Profesional se ha completado satisfactoriamente.",
                        "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarEspecialidades();
                }
            }
            else
            {
                MessageBox.Show("El profesional no puede sumar más de 48 hs laborales. Por favor, revise los horarios de la Agenda.",
                    "No se puede registrar la Agenda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            dateHasta.MinDate = dateDesde.Value;
            dateHasta.Value = dateDesde.Value;
        }

        private void hDesdeLun_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaLun.DataSource = cargarHorariosAtencionClinica("Lunes", hDesdeLun.SelectedValue.ToString());
        }

        private void hDesdeMar_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaMar.DataSource = cargarHorariosAtencionClinica("Martes", hDesdeMar.SelectedValue.ToString());
        }

        private void hDesdeMier_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaMier.DataSource = cargarHorariosAtencionClinica("Miércoles", hDesdeMier.SelectedValue.ToString());
        }

        private void hDesdeJue_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaJue.DataSource = cargarHorariosAtencionClinica("Jueves", hDesdeJue.SelectedValue.ToString());
        }

        private void hDesdeVier_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaVier.DataSource = cargarHorariosAtencionClinica("Viernes", hDesdeVier.SelectedValue.ToString());
        }

        private void hDesdeSab_SelectedValueChanged(object sender, EventArgs e)
        {
            hHastaSab.DataSource = cargarHorariosAtencionClinica("Sábado", hDesdeSab.SelectedValue.ToString());
        }

        private void checkLun_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeLun.Enabled = checkLun.Checked;
            hHastaLun.Enabled = checkLun.Checked;
        }

        private void checkMar_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeMar.Enabled = checkMar.Checked;
            hHastaMar.Enabled = checkMar.Checked;
        }

        private void checkMier_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeMier.Enabled = checkMier.Checked;
            hHastaMier.Enabled = checkMier.Checked;
        }

        private void checkJue_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeJue.Enabled = checkJue.Checked;
            hHastaJue.Enabled = checkJue.Checked;
        }

        private void checkVier_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeVier.Enabled = checkVier.Checked;
            hHastaVier.Enabled = checkVier.Checked;
        }

        private void checkSab_CheckedChanged(object sender, EventArgs e)
        {
            hDesdeSab.Enabled = checkSab.Checked;
            hHastaSab.Enabled = checkSab.Checked;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void cProfesional_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarEspecialidades();
        }
    }
}
