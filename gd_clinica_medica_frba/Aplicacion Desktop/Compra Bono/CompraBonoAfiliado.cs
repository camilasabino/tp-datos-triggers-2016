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
        }

        SqlConnection conn = new SqlConnection(conexion.cadena);

        private void button_confirmar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de Bonos a comprar");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ComprarBonos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = Convert.ToString(usuario.id_rol);
            cmd.Parameters.AddWithValue("@cantBonos", SqlDbType.VarChar).Value = textBox_afil_CantBonos.Text;
            cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            cmd.ExecuteNonQuery();

            //Se realiza la compra, y muestro el Total a pagar

            string precioBono = "select plan_precio_bono_consulta from LOS_TRIGGERS.Plan_Medico where plan_id = (select afil_plan_medico from LOS_TRIGGERS.Afiliado where afil_numero = " + Convert.ToString(usuario.id_rol) + ")";
            SqlCommand command2 = new SqlCommand(precioBono, conn);
            SqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            decimal precio = reader2.GetDecimal(0);
            decimal totalAPagar = precio * Convert.ToDecimal(textBox_afil_CantBonos.Text);

            MessageBox.Show("Monto total a pagar es $" + totalAPagar);

            //limpio los campos
            textBox_afil_CantBonos.Text = "";

            conn.Close();

        }
        
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }


    }
}
