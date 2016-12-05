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
    public partial class CancelacionAfiliado : Form
    {
        public CancelacionAfiliado()
        {
            InitializeComponent();
            cargarTurnos();
            cargarCancelaciones();
            gridCancelaciones.DefaultCellStyle.SelectionBackColor = gridTurnos.DefaultCellStyle.BackColor;
            gridCancelaciones.DefaultCellStyle.SelectionForeColor = gridTurnos.DefaultCellStyle.ForeColor;
            cargarTiposCancelacion();
        }

        protected void cargarTurnos()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.TurnosAsignadosAUnAfiliado", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable turnos = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(turnos);
                gridTurnos.DataSource = turnos;

                conexionBase.Close();
            }
        }

        protected void cargarCancelaciones()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.TurnosCanceladosAfiliado", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@fecha_sistema", Convert.ToDateTime(ClinicaFrba.fecha.fechaActual));

                DataTable cancelaciones = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(cancelaciones);
                gridCancelaciones.DataSource = cancelaciones;

                conexionBase.Close();
            }
        }

        protected void cargarTiposCancelacion()
        {
            cTipoCancelacion.DataSource = TipoCancelacion.obtenerTiposCancelacion();
            cTipoCancelacion.DisplayMember = "descripcion";
            cTipoCancelacion.ValueMember = "id";
        }

        protected void confirmarCancelacion()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.CancelarTurnoAfiliado", conexionBase);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(ClinicaFrba.usuario.id_rol));
                comando.Parameters.AddWithValue("@turno", Convert.ToDecimal(gridTurnos.SelectedRows[0].Cells[0].Value.ToString()));
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
                string turnoACancelar = "¿Desea cancelar el siguiente turno?" + "\n\n" +
                             "Especialidad: " + gridTurnos.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                             "Profesional: " + gridTurnos.SelectedRows[0].Cells[1].Value.ToString() + "\n" +
                             "Fecha: " + gridTurnos.SelectedRows[0].Cells[3].Value.ToString() + "\n" +
                             "Horario: " + gridTurnos.SelectedRows[0].Cells[5].Value.ToString();

                if (MessageBox.Show(turnoACancelar, "Confirmar cancelación del Turno",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    confirmarCancelacion();
                    MessageBox.Show("La Cancelación del Turno se ha completado satisfactoriamente.",
                        "Resultado de la Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarTurnos();
                    textMotivo.Text = "";
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
    }
}
