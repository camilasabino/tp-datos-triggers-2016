﻿using System;
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
//        public int habilitado { get; set; }
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

            //valido si el afiliado esta habilitado para realizar la compra

            string afil_habilitacion = "select afil_habilitacion from LOS_TRIGGERS.Afiliado where afil_numero = " + textBox_afil_numero.Text;
            SqlCommand command = new SqlCommand(afil_habilitacion, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool habilitacion = reader.GetBoolean(0);
//            bool habilitado = System.Object.ReferenceEquals(Convert.ToInt32(habilitacion), 0);
            reader.Close();

            if (!habilitacion)
            {
                MessageBox.Show("El afiliado " + textBox_afil_numero.Text + " se encuentra deshabilitado");
            }
            else
            {
                //Se realiza la compra, y muestro el Total a pagar

                string precioBono = "select plan_precio_bono_consulta from LOS_TRIGGERS.Plan_Medico where plan_id = (select afil_plan_medico from LOS_TRIGGERS.Afiliado where afil_numero = " + textBox_afil_numero.Text + ")" ;
                SqlCommand command2= new SqlCommand(precioBono, conn);
                SqlDataReader reader2 = command2.ExecuteReader();
                reader2.Read();
                decimal precio = reader2.GetDecimal(0);
                decimal totalAPagar = precio * Convert.ToDecimal(comboBox_afil_CantBonos.Text);

                MessageBox.Show("Monto total a pagar es $" + totalAPagar);

                //limpio los campos

                textBox_afil_numero.Text = "";
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
