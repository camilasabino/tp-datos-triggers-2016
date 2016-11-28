using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
            llenar_especialidades();
            llenar_profesionales("");
        }

        protected void llenar_profesionales(string especialidad)
        {
            c_profesional.DataSource = profesionales.listar(especialidad).Tables[0];
            c_profesional.ValueMember = "id";
            c_profesional.DisplayMember = "Nombre";
        }

        protected void llenar_especialidades()
        {
            c_especialidad.DataSource = especialidades.listar().Tables[0];
            c_especialidad.ValueMember = "id";
            c_especialidad.DisplayMember = "Nombre";
        }

        protected void llenar_grilla()
        {
            grilla_turnos.DataSource = turnos.listar(decimal.Parse(c_profesional.SelectedValue.ToString()), fecha.fechaActual, 0, 0).Tables[0];
        }

        protected void llenar_bonos(decimal afiliado)
        {
            c_bonos.DataSource = bonos.listar_disponibles_afiliado(afiliado).Tables[0];
            c_bonos.DisplayMember = "id";
        }

        private void c_especialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            llenar_profesionales(c_especialidad.Text);
        }

        private void b_elegir_prof_Click(object sender, EventArgs e)
        {
            llenar_grilla();
        }

        private void grilla_turnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar_bonos(decimal.Parse(grilla_turnos.Rows[grilla_turnos.CurrentRow.Index].Cells[1].Value.ToString()));
            afiliado.Text = grilla_turnos.Rows[grilla_turnos.CurrentRow.Index].Cells[1].Value.ToString();
            turno.Text = grilla_turnos.Rows[grilla_turnos.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void b_registrar_Click(object sender, EventArgs e)
        {
            if (c_bonos.Text == "")
                MessageBox.Show("No hay bonos disponibles para el Afiliado indicado.", "Alerta");
            else
            {
                registrar.llegada(decimal.Parse(turno.Text), decimal.Parse(c_bonos.Text), decimal.Parse(afiliado.Text), fecha.fechaActual);
                MessageBox.Show("El registro se ha completado satisfactoriamente.");
            }
        }
    }
}
