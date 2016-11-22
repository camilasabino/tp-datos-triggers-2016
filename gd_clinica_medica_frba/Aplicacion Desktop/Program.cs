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
            //Application.Run(new Abm_Afiliado.Afiliado());
            //Application.Run(new ClinicaFrba.Pedir_Turno.PedirTurno());
            //Application.Run(new ClinicaFrba.Cancelar_Atencion.CancelacionAfiliado());
            //Application.Run(new ClinicaFrba.Cancelar_Atencion.CancelacionProfesional());
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

/***************************************************************************************************
 *                           CONEXIÓN CON LA BASE DE DATOS                                         *
 ***************************************************************************************************/

    public class DBHelper
    {
        public static DataSet ExecuteDataSet(string sqlSpName, SqlParameter[] dbParams)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            DataSet dataSet = null;
            dataSet = new DataSet();
            SqlCommand cmd = new SqlCommand(sqlSpName, conexionBase);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    dataAdapter.SelectCommand.Parameters.Add(dbParam);
                }
            }
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static SqlDataReader ExecuteDataReader(string sqlSpName, SqlParameter[] dbParams)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            SqlDataReader dataReader;
            SqlCommand cmd = new SqlCommand(sqlSpName, conexionBase);
            cmd.CommandType = CommandType.StoredProcedure;


            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }
            conexionBase.Open();

            try
            {
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
            return dataReader;
        }

        public static void ExecuteNonQuery(string sqlSpName, SqlParameter[] dbParams)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            SqlCommand cmd = new SqlCommand(sqlSpName, conexionBase);
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }

            conexionBase.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (null != conexionBase)
                    conexionBase.Close();
            }
        }

        #region Example
        //public static DataSet Get(CGasto gasto)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            DBHelper.MakeParam("@Id", SqlDbType.Int, 0, gasto.Id),
        //        };
        //    return DBHelper.ExecuteDataSet("usp_CListGasto_Get", dbParams);

        //} 
        #endregion

    }

}
