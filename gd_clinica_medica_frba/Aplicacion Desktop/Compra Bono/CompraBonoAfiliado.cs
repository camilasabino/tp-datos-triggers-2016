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

            if (string.IsNullOrEmpty(comboBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de Bonos a comprar");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ComprarBonos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = Convert.ToString(usuario.id_rol);
            cmd.Parameters.AddWithValue("@cantBonos", SqlDbType.VarChar).Value = comboBox_afil_CantBonos.Text;
            cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            cmd.ExecuteNonQuery();

            //valido si el afiliado esta habilitado para realizar la compra

            string afil_habilitacion = "select afil_habilitacion from LOS_TRIGGERS.Afiliado where afil_numero = " + Convert.ToString(usuario.id_rol);
            SqlCommand command = new SqlCommand(afil_habilitacion, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool habilitacion = reader.GetBoolean(0);
            reader.Close();

            if (!habilitacion)
            {
                MessageBox.Show("El afiliado " + Convert.ToString(usuario.id_rol) + " se encuentra deshabilitado");
            }
            else
            {
                //Se realiza la compra, y muestro el Total a pagar

                string precioBono = "select plan_precio_bono_consulta from LOS_TRIGGERS.Plan_Medico where plan_id = (select afil_plan_medico from LOS_TRIGGERS.Afiliado where afil_numero = " + Convert.ToString(usuario.id_rol) + ")";
                SqlCommand command2 = new SqlCommand(precioBono, conn);
                SqlDataReader reader2 = command2.ExecuteReader();
                reader2.Read();
                decimal precio = reader2.GetDecimal(0);
                decimal totalAPagar = precio * Convert.ToDecimal(comboBox_afil_CantBonos.Text);

                MessageBox.Show("Monto total a pagar es $" + totalAPagar);

                //limpio los campos
                comboBox_afil_CantBonos.SelectedItem = null;

            }

            conn.Close();


        }
        
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
