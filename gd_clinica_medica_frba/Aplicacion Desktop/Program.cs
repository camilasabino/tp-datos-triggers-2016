using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
 /***************************************************************************************************
  *                                  PROGRAMA PRINCIPAL                                             *
  ***************************************************************************************************/
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Abm_Afiliado.Afiliado());
            //Application.Run(new ClinicaFrba.Pedir_Turno.PedirTurno());
            //Application.Run(new ClinicaFrba.Cancelar_Atencion.CancelacionAfiliado());
           // Application.Run(new ClinicaFrba.Cancelar_Atencion.CancelacionProfesional());
            Application.Run(new ClinicaFrba.Registrar_Agenta_Medico.RegistrarAgenda());
            //Application.Run(new ClinicaFrba.Login());
            //Application.Run(new ClinicaFrba.Compra_Bono.CompraBono());
            //Application.Run(new ClinicaFrba.AbmRol.Editar());
            //Application.Run(new ClinicaFrba.AbmRol.Form1());
        }
    }

/***************************************************************************************************
*                            CADENA DE CONEXIÓN Y FECHA DEL SISTEMA                                *
***************************************************************************************************/
    public class conexion
    {
        public static string cadena = ConfigurationManager.AppSettings["cadena_conexion"].ToString();
    }

    public class fecha
    {
        public static string fechaActual = ConfigurationManager.AppSettings["fecha_sistema"].ToString();
    }
}
