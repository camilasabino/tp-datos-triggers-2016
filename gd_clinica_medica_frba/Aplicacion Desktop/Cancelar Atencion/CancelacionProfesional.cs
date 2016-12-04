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

namespace ClinicaFrba.Cancelar_Atencion
{
    /**************************************************************************************************
    *                              CANCELACIÓN TURNO PROFESIONAL                                      *
    ***************************************************************************************************/
    public partial class CancelacionProfesional : Form
    {
        public CancelacionProfesional()
        {
            InitializeComponent();

            if (tieneAgendaRegistrada())
            {
                labelAgenda.Text = "";
                cargarFechasAtencion();
                cargarTurnos();
                gridTurnos.DefaultCellStyle.SelectionBackColor = gridTurnos.DefaultCellStyle.BackColor;
                gridTurnos.DefaultCellStyle.SelectionForeColor = gridTurnos.DefaultCellStyle.ForeColor;
                cargarTiposCancelacion();
                gridFechas.ClearSelection();

                dateDesde.MinDate = DateTime.Parse(ClinicaFrba.fecha.fechaActual);
                dateDesde.Value = DateTime.Parse(ClinicaFrba.fecha.fechaActual);
                dateDesde.MaxDate = fechaHastaDeAtencion();
                dateDesde.CustomFormat = "yyyy-MM-dd";
                dateDesde.Format = DateTimePickerFormat.Custom;

                dateHasta.MinDate = dateDesde.Value;
                dateHasta.Value = dateDesde.Value;
                dateHasta.MaxDate = fechaHastaDeAtencion();
                dateHasta.CustomFormat = "yyyy-MM-dd";
                dateHasta.Format = DateTimePickerFormat.Custom;

                checkModoCancelacion.Checked = true;
                gridTurnos.Enabled = true;
                dateDesde.Enabled = false;
                dateHasta.Enabled = false;
            }
            else
            {
                labelAgenda.Text = "NO DISPONIBLE: El Profesional aún no cuenta con una Agenda registrada.";
                gridTurnos.Enabled = false;
                gridFechas.Enabled = false;
                dateDesde.Enabled = false;
                dateHasta.Enabled = false;
                checkModoCancelacion.Enabled = false;
                buttonConfirmar.Enabled = false;
                cTipoCancelacion.Enabled = false;
                textMotivo.Enabled = false;
            }
        }

        public class TipoCancelacion
        {
            public decimal id { get; set; }
            public string descripcion { get; set; }

            public TipoCancelacion(decimal _id, string _descripcion)
            {
                this.id = _id;
                this.descripcion = _descripcion;
            }
        }

        protected Boolean tieneAgendaRegistrada()
        {
            List<decimal> diasDeAtencion = new List<decimal>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select dia_id from LOS_TRIGGERS.Dia_Atencion " +
                                                    "where dia_especialidad_profesional IN (select espe_prof_id " +
                                                    "from LOS_TRIGGERS.Especialidad_Profesional " +
                                                    "where profesional = @profesional)", conexionBase);
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    diasDeAtencion.Add(reader.GetDecimal(0));
                }

                conexionBase.Close();
            }
            return diasDeAtencion.Any();
        }

        protected void cargarTurnos()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.TurnosDeUnProfesional", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable turnos = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(turnos);
                gridTurnos.DataSource = turnos;

                conexionBase.Close();
            }
        }

        protected void cargarFechasAtencion()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.FechasDeAtencionProfesional", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable fechas = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(fechas);
                gridFechas.DataSource = fechas;

                conexionBase.Close();
            }
        }

        public List<TipoCancelacion> obtenerTiposCancelacion()
        {
            List<TipoCancelacion> cancelaciones = new List<TipoCancelacion>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select * from LOS_TRIGGERS.Tipo_Cancelacion", conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cancelaciones.Add(
                        new TipoCancelacion(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return cancelaciones;
        }

        public DateTime fechaHastaDeAtencion()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select MAX(disponible_hasta_fecha) " +
                                                    "from LOS_TRIGGERS.Especialidad_Profesional " +
                                                    "where profesional=@profesional", conexionBase);
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));

                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                DateTime fechaHasta = reader.GetDateTime(0);
                conexionBase.Close();

                return fechaHasta;
            }
        }

        protected void cargarTiposCancelacion()
        {
            cTipoCancelacion.DataSource = obtenerTiposCancelacion();
            cTipoCancelacion.DisplayMember = "descripcion";
            cTipoCancelacion.ValueMember = "id";
        }

        protected void confirmarCancelacionDiaParticular()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha", gridFechas.SelectedRows[0].Cells[0].Value.ToString());
                comando.Parameters.AddWithValue("@tipo_canc", Convert.ToDecimal(((TipoCancelacion)cTipoCancelacion.SelectedItem).id));
                comando.Parameters.AddWithValue("@motivo", textMotivo.Text);
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
        }

        protected void confirmarCancelacionPeriodo()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@desde", dateDesde.Value);
                comando.Parameters.AddWithValue("@hasta", dateHasta.Value);
                comando.Parameters.AddWithValue("@tipo_canc", Convert.ToDecimal(((TipoCancelacion)cTipoCancelacion.SelectedItem).id));
                comando.Parameters.AddWithValue("@motivo", textMotivo.Text);
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
        }

        /**************************************************************************************************
        *                                   EVENTOS DEL FORM                                              *
        ***************************************************************************************************/

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textMotivo.Text))
            {
                if (checkModoCancelacion.Checked) // Cancela un día particular
                {
                    string turnoACancelar = "¿Desea cancelar la siguiente fecha de atención?" + "\n\n" +
                        "Fecha: " + gridFechas.SelectedRows[0].Cells[0].Value.ToString() + "\n" +
                        "Día: " + gridFechas.SelectedRows[0].Cells[1].Value.ToString();

                    if (MessageBox.Show(turnoACancelar, "Confirmar cancelación del día de atención",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        confirmarCancelacionDiaParticular();
                        MessageBox.Show("La Cancelación de la Atención en la fecha indicada se ha completado satisfactoriamente.",
                            "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarFechasAtencion();
                        cargarTurnos();
                        textMotivo.Text = "";
                    }
                }
                else // Cancela un período
                {
                    string periodoACancelar = "¿Desea cancelar el siguiente período de turnos?" + "\n\n" +
                        "Desde Fecha: " + dateDesde.Value.ToString() + "\n" +
                        "Hasta Fecha: " + dateHasta.Value.ToString() + "\n\n";

                    if (MessageBox.Show(periodoACancelar, "Confirmar cancelación del Período de Turnos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        confirmarCancelacionPeriodo();
                        MessageBox.Show("Las Cancelación de la Atención en el período indicado se ha completado satisfactoriamente.",
                            "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarFechasAtencion();
                        cargarTurnos();
                        textMotivo.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, indique el motivo de la cancelación.", "No se ha indicado un motivo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void checkModoCancelacion_CheckedChanged(object sender, EventArgs e)
        {
            gridTurnos.Enabled = checkModoCancelacion.Checked;
            gridFechas.Enabled = checkModoCancelacion.Checked;
            dateDesde.Enabled = !checkModoCancelacion.Checked;
            dateHasta.Enabled = !checkModoCancelacion.Checked;
            gridFechas.ClearSelection();
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            dateHasta.MinDate = dateDesde.Value;
            dateHasta.Value = dateDesde.Value;
        }
    }
}
