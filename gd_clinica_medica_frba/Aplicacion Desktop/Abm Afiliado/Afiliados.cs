using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Afiliado : Form
    {
        public Afiliado()
        {
            InitializeComponent();
        }

        private void buttonSalir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Alta alta = new Abm_Afiliado.Alta();
            alta.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.HabilitacionDeshabilitacion baja = new Abm_Afiliado.HabilitacionDeshabilitacion();
            baja.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Modificacion modificacion = new Abm_Afiliado.Modificacion();
            modificacion.Show();
        }
    }
}
