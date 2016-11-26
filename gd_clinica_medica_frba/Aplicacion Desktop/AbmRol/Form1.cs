using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Añadir_Click(object sender, EventArgs e)
        {
            AbmRol.Alta alta = new AbmRol.Alta();
            alta.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            AbmRol.Eliminar eliminar = new AbmRol.Eliminar();
            eliminar.Show();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            AbmRol.Editar editar = new AbmRol.Editar();
            editar.Show();
        }
    }
}
