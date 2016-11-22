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
    public partial class CompraBono : Form
    {
        public CompraBono()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void compraBonos_Load(object sender, EventArgs e)
        {
            this.llenarCantidadBonos(comboBox_afil_CantBonos);
        }

        private void llenarCantidadBonos(ComboBox cantidadBonos)
        {
            for (int i = 0; i <= 10; i++)
            {
                cantidadBonos.Items.Add(i);
            }
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {

            //validar que los campos esten completados
            if (string.IsNullOrEmpty(textBox_afil_numero.Text) && string.IsNullOrEmpty(comboBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado y la cantidad de bonos a comprar");
                return;
            }
            else if (string.IsNullOrEmpty(textBox_afil_numero.Text) && !string.IsNullOrEmpty(comboBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado");
                return;
            }
            else if (!string.IsNullOrEmpty(textBox_afil_numero.Text) && string.IsNullOrEmpty(comboBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de bonos a comprar");
                return;
            }

            //confirmar la compra
            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ComprarBonos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            cmd.Parameters.AddWithValue("@cantBonos", SqlDbType.VarChar).Value = comboBox_afil_CantBonos.Text;
            cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            cmd.ExecuteNonQuery();
            conn.Close();

            this.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
