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
            Application.Run(new ClinicaFrba.Login());
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
