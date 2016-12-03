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

        private void button_alta_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Alta alta = new Abm_Afiliado.Alta();
            alta.Show();

        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Modificacion modificacion = new Abm_Afiliado.Modificacion();
            modificacion.Show();
        }

        private void button_baja_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.HabilitacionDeshabilitacion baja = new Abm_Afiliado.HabilitacionDeshabilitacion();
            baja.Show();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();

        }
    }
}
