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

            labelNombreUsuario.Text = usuario.nombre_usuario;
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
            (new Abm_Afiliado.Afiliado()).Show();
        }

        private void b_cerrar_sesion_Click(object sender, EventArgs e)
        {
            usuario.id_rol = 0;
            usuario.nombre_usuario = "";
            usuario.rol = "";

            Login f1 = new Login();
            this.Close();
            f1.Show();
        }

       /***************************************************************************************************
        *                                FUNCIONALIDADES DEL SISTEMA                                      *
        ***************************************************************************************************/

        private void b_registrar_llegada_Click(object sender, EventArgs e)
        {
            (new Registro_Llegada.Registrar()).Show();
        }

        private void b_registrar_resultado_Click(object sender, EventArgs e)
        {
            (new Registro_Resultado.Registrar_resul()).Show();
        }

        private void b_abm_rol_Click(object sender, EventArgs e)
        {
            (new AbmRol.Form1()).Show();
        }

        private void b_cancelar_atencion_Click(object sender, EventArgs e)
        {
            if (usuario.rol == "Afiliado") (new Cancelar_Atencion.CancelacionAfiliado()).Show();
            else if (usuario.rol == "Profesional") (new Cancelar_Atencion.CancelacionProfesional()).Show();
        }

        private void b_compra_bono_Click(object sender, EventArgs e)
        {
            if (usuario.rol == "Afiliado") (new Compra_Bono.CompraBonoAfiliado()).Show();
            else if (usuario.rol == "Administrador") (new Compra_Bono.CompraBonoAdministrador()).Show();

        }

        private void b_listados_Click(object sender, EventArgs e)
        {
            (new Listados.Form1()).Show();
        }

        private void b_pedir_turno_Click(object sender, EventArgs e)
        {
            (new Pedir_Turno.PedirTurno()).Show();
        }

        private void b_registrar_agenda_Click(object sender, EventArgs e)
        {
            (new Registrar_Agenta_Medico.RegistrarAgenda()).Show();
        }

       /***************************************************************************************************
        *                             FUNCIONALIDADES NO IMPLEMENTADAS                                    *
        ***************************************************************************************************/

        private void mostrarAltertaDeNoImplementacion()
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada por no ser un requisito del trabajo práctico.",
                "Funcionalidad no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void b_abm_espcialidades_Click(object sender, EventArgs e)
        {
            mostrarAltertaDeNoImplementacion();
        }

        private void b_abm_planes_Click(object sender, EventArgs e)
        {
            mostrarAltertaDeNoImplementacion();
        }

        private void b_abm_profesional_Click(object sender, EventArgs e)
        {
            mostrarAltertaDeNoImplementacion();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
