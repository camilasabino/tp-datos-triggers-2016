using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Registrar_resul : Form
    {
        public Registrar_resul()
        {
            InitializeComponent();
            if (usuario.rol == "Profesional")
            {
                t_profesional.Text = usuario.id_rol.ToString();
                llenar_grilla(0, 0);
            }
            else
            {
                t_profesional.Visible = true;
                l_profesional.Visible = true;
                b_turnos.Visible = true;
            }

        }

        protected void llenar_grilla(int hora, decimal afiliado)
        {
            grilla_turnos.DataSource = turnos.listar(decimal.Parse(t_profesional.Text),fecha.fechaActual,hora,afiliado).Tables[0];
        }

        private void b_filtrar_Click(object sender, EventArgs e)
        {
            int hora;
            decimal afiliado;
            
            if (t_afiliado.Text == "")
                afiliado = 0;
            else
                afiliado = decimal.Parse(t_afiliado.Text);

            if (c_turno.Text == "Todas")
                hora = 0;
            else
                hora = int.Parse(c_turno.Text);

            llenar_grilla(hora, afiliado);
        }

        private void grilla_turnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grilla_turnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void b_registrar_Click(object sender, EventArgs e)
        {
            if (grilla_turnos.Rows[grilla_turnos.CurrentRow.Index].Cells[0].Value.ToString() == "")
                MessageBox.Show("Elija un turno");
            else
            {
                if (t_diagnostico.Text == "" || t_sintomas.Text == "")
                    MessageBox.Show("Complete los campos vacíos");
                else
                {
                    registrar.registro_resultado(decimal.Parse(grilla_turnos.Rows[grilla_turnos.CurrentRow.Index].Cells[0].Value.ToString()), fecha.fechaActual, t_sintomas.Text, t_diagnostico.Text);
                    MessageBox.Show("El registro se ha completado");                
                }
            }
        }

        private void b_turnos_Click(object sender, EventArgs e)
        {
            llenar_grilla(0, 0);
        }
    }
}
