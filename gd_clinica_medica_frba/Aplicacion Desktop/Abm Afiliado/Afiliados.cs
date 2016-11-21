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

        private void Form1_Load(object sender, EventArgs e)
        {

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
            Abm_Afiliado.Baja baja = new Abm_Afiliado.Baja();
            baja.Show();
        }
    }
}
