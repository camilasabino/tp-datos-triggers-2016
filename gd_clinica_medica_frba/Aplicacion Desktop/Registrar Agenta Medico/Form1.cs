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
            cargarEspecialidades();
            cargarDiasAtencionClinica();

            dateDesde.MinDate = Convert.ToDateTime(ClinicaFrba.fecha.fechaActual);
            dateDesde.MaxDate = new DateTime(2017, 12, 31);
            dateDesde.CustomFormat = "yyyy-MM-dd";
            dateDesde.Format = DateTimePickerFormat.Custom;

            dateHasta.MinDate = dateHasta.Value;
            dateHasta.MaxDate = new DateTime(2017, 12, 31);
            dateHasta.CustomFormat = "yyyy-MM-dd";
            dateHasta.Format = DateTimePickerFormat.Custom;
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

        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select espe_codigo, espe_descripcion "+
                                                    "from LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad "+
                    // "where profesional="+Convert.ToDecimal(ClinicaFrba.usuario.id_rol) +" AND espe_codigo=especialidad", conexionBase);
                                                    "where profesional=9719683799 AND espe_codigo=especialidad", conexionBase);

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

        public void cargarDiasAtencionClinica()
        {
            for (int i = 0; i <= 5; i++) gridDiasAtencion.Rows.Add();

            gridDiasAtencion.Rows[0].Cells["Día"].Value = "Lunes";
            gridDiasAtencion.Rows[1].Cells["Día"].Value = "Martes";
            gridDiasAtencion.Rows[2].Cells["Día"].Value = "Miércoles";
            gridDiasAtencion.Rows[3].Cells["Día"].Value = "Jueves";
            gridDiasAtencion.Rows[4].Cells["Día"].Value = "Viernes";
            gridDiasAtencion.Rows[5].Cells["Día"].Value = "Sábado";

            (gridDiasAtencion.Columns[2] as DataGridViewComboBoxColumn).DataSource = cargarHorariosAtencionClinica("Lunes");
            (gridDiasAtencion.Columns[3] as DataGridViewComboBoxColumn).DataSource = cargarHorariosAtencionClinica("Lunes");
            /*gridDiasAtencion.Rows[1].Cells["Día"].Value = "Martes";
            gridDiasAtencion.Rows[2].Cells["Día"].Value = "Miércoles";
            gridDiasAtencion.Rows[3].Cells["Día"].Value = "Jueves";
            gridDiasAtencion.Rows[4].Cells["Día"].Value = "Viernes";
            gridDiasAtencion.Rows[5].Cells["Día"].Value = "Sábado";*/
        }

        public List<String> cargarHorariosAtencionClinica(String dia)
        {
            List<String> horarios = new List<String>();
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select hora_inicio from LOS_TRIGGERS.Horario_Atencion "+
                                                    "where hora_especialidad_profesional is null AND hora_nombre_dia=@dia"+
                                                    " union select MAX(hora_fin) from LOS_TRIGGERS.Horario_Atencion "+
                                                    "where hora_especialidad_profesional is null AND hora_nombre_dia=@dia", conexionBase);
                comando.Parameters.AddWithValue("@dia", dia);

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

        protected void cargarDiasDeAtencionClinica()
        {
            gridDiasAtencion.AutoGenerateColumns = false;
            gridDiasAtencion.DataSource = gridDiasAtencion.Columns;
        }

/**************************************************************************************************
*                                   EVENTOS DEL FORM                                              *
***************************************************************************************************/

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            dateHasta.MinDate = dateHasta.Value;
        }
    }
}
