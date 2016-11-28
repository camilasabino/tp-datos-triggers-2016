using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            l_nom_user.Text = usuario.nombre_usuario;
            b_abm_afiliado.Visible = usuario.permiso("Abm de Afiliado", usuario.rol);
            b_abm_profesional.Visible = usuario.permiso("Abm de Profesional", usuario.rol);
            b_abm_espcialidades.Visible = usuario.permiso("Abm de Especialidad Médica", usuario.rol);
            b_abm_planes.Visible = usuario.permiso("Abm de Plan", usuario.rol);
            b_abm_rol.Visible = usuario.permiso("Abm de Rol", usuario.rol);
            b_cancelar_atencion.Visible = usuario.permiso("Cancelación de Turno", usuario.rol);
            b_compra_bono.Visible = usuario.permiso("Compra de Bono", usuario.rol);
            b_listados.Visible = usuario.permiso("Listado Estadístico", usuario.rol);
            b_pedir_turno.Visible = usuario.permiso("Pedido de Turno", usuario.rol);
            b_registrar_agenda.Visible = usuario.permiso("Registro de Agenda Profesional", usuario.rol);
            b_registrar_llegada.Visible = usuario.permiso("Registro de Consulta Médica", usuario.rol);
            b_registrar_resultado.Visible = usuario.permiso("Registro de Diagnóstico Médico", usuario.rol);
                
            
        }

        private void b_abm_afiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Afiliado f1 = new Abm_Afiliado.Afiliado();
            f1.Show();
        }

        private void b_cerrar_sesion_Click(object sender, EventArgs e)
        {
            usuario.id_rol = 0;
            usuario.nombre_usuario = "";
            usuario.rol = "";
            
            Login f1 = new Login();
            this.Hide();
            f1.Show();
            
        }

        private void b_registrar_llegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Registrar f1 = new Registro_Llegada.Registrar();
            f1.Show();
        }

        private void b_registrar_resultado_Click(object sender, EventArgs e)
        {
            Registro_Resultado.Registrar_resul f1 = new Registro_Resultado.Registrar_resul();
            f1.Show();
        }

        private void b_abm_espcialidades_Click(object sender, EventArgs e)
        {
            Abm_Especialidades_Medicas.Form1 em1 = new Abm_Especialidades_Medicas.Form1();
            em1.Show();
        }

        private void b_abm_planes_Click(object sender, EventArgs e)
        {
            Abm_Planes.Form1 p1 = new Abm_Planes.Form1();
            p1.Show();
        }

        private void b_abm_profesional_Click(object sender, EventArgs e)
        {
            Abm_Profesional.Form1 ap1 = new Abm_Profesional.Form1();
            ap1.Show();
        }

        private void b_abm_rol_Click(object sender, EventArgs e)
        {
            AbmRol.Form1 ar1 = new AbmRol.Form1();
            ar1.Show();
        }

        private void b_cancelar_atencion_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.Form1 ca1 = new Cancelar_Atencion.Form1();
            ca1.Show();
        }

        private void b_compra_bono_Click(object sender, EventArgs e)
        {
            Compra_Bono.CompraBono cb1 = new Compra_Bono.CompraBono();
            cb1.Show();
        }

        private void b_listados_Click(object sender, EventArgs e)
        {
            Listados.Form1 l1 = new Listados.Form1();
            l1.Show();
        }

        private void b_pedir_turno_Click(object sender, EventArgs e)
        {
            Pedir_Turno.PedirTurno pt1 = new Pedir_Turno.PedirTurno();
            pt1.Show();
        }

        private void b_registrar_agenda_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.RegistrarAgenda ra1 = new Registrar_Agenta_Medico.RegistrarAgenda();
            ra1.Show();
        }
    }
}
