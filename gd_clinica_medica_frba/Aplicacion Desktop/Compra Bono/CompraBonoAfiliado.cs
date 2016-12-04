using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBonoAfiliado : Form
    {
        public CompraBonoAfiliado()
        {
            InitializeComponent();
            textBox_afil_CantBonos.MaxLength = 2;
            labelMonto.Text = "$ -";
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Por favor, indique la cantidad de Bonos a comprar.", "No se ha indicado una cantidad",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                calcularMontoAPagar();

                if (MessageBox.Show("¿Está seguro de realizar la compra de " + textBox_afil_CantBonos.Text +
                " bonos por " + labelMonto.Text + "?", "Confirmación de la Compra", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(conexion.cadena);
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ComprarBonos", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = Convert.ToDecimal(usuario.id_rol);
                        cmd.Parameters.AddWithValue("@cantBonos", SqlDbType.VarChar).Value = textBox_afil_CantBonos.Text;
                        cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha.fechaActual);
                        cmd.ExecuteNonQuery();

                        //limpio los campos
                        textBox_afil_CantBonos.Text = "";
                        labelMonto.Text = "$ -";
                        conn.Close();
                        MessageBox.Show("La Compra se ha realizado con éxito.", "Resultado de la Compra",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        protected void calcularMontoAPagar()
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select plan_precio_bono_consulta from LOS_TRIGGERS.Plan_Medico " +
                                                     "where plan_id = (select afil_plan_medico from LOS_TRIGGERS.Afiliado " +
                                                     "where afil_numero = @afiliado)", conn);
                command.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(usuario.id_rol));
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                decimal precio = reader.GetDecimal(0);
                decimal totalAPagar = precio * Convert.ToDecimal(textBox_afil_CantBonos.Text);
                labelMonto.Text = "$ " + totalAPagar.ToString();
                conn.Close();
            }
        }

        private void buttonMonto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Por favor, indique la cantidad de Bonos a comprar.", "No se ha indicado una cantidad",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else calcularMontoAPagar();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}
