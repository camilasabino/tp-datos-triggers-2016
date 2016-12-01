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
            cargarTurnos();
            cargarTiposCancelacion();
            cargarFechasDesde();
            cargarFechasHasta();
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

        public void cargarFechasDesde()
        {
            List<String> fechasDesde = new List<String>();
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.FechasDeAtencionProfesional", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_desde", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    fechasDesde.Add(reader.GetString(0));
                }
                cFechaDesde.DataSource = fechasDesde;

                conexionBase.Close();
            }
        }

        public void cargarFechasHasta()
        {
            List<String> fechasHasta = new List<String>();
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.FechasDeAtencionProfesional", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_desde", Convert.ToDateTime(cFechaDesde.SelectedValue));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    fechasHasta.Add(reader.GetString(0));
                }
                cFechaHasta.DataSource = fechasHasta;

                conexionBase.Close();
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
                comando.Parameters.AddWithValue("@fecha", gridTurnos.SelectedRows[0].Cells[3].Value.ToString());
                comando.Parameters.AddWithValue("@tipo_can", Convert.ToDecimal(((TipoCancelacion)cTipoCancelacion.SelectedItem).id));
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
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.CancelarTurnosProfesionalPeriodos", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@profesional", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));    
                comando.Parameters.AddWithValue("@desde", Convert.ToDateTime(gridTurnos.SelectedRows[0].Cells[3].Value.ToString()));
                comando.Parameters.AddWithValue("@desde", Convert.ToDateTime(gridTurnos.SelectedRows[0].Cells[3].Value.ToString()));
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
                    string turnoACancelar = "¿Desea cancelar el siguiente turno?" + "\n\n" +
                        "Especialidad: " + gridTurnos.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                        "Fecha: " + gridTurnos.SelectedRows[0].Cells[3].Value.ToString() + "\n" +
                        "Horario: " + gridTurnos.SelectedRows[0].Cells[4].Value.ToString();

                    if (MessageBox.Show(turnoACancelar, "Confirmar cancelación del Turno",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        confirmarCancelacionDiaParticular();
                        cargarTurnos();
                    }
                }
                else // Cancela un período
                {
                    string periodoACancelar = "¿Desea cancelar el siguiente período de turnos?" + "\n\n" +
                        "Desde Fecha: " + cFechaDesde.SelectedValue.ToString() + "\n" +
                        "Hasta Fecha: " + cFechaHasta.SelectedValue.ToString() + "\n\n";

                    if (MessageBox.Show(periodoACancelar, "Confirmar cancelación del Período de Turnos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        confirmarCancelacionPeriodo();
                        cargarTurnos();
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

        private void cFechaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFechasHasta();
        }
    }
}
