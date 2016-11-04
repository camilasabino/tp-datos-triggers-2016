using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ClinicaFrba
{
    class Modelo
    {
    }

    public class conexion
    {
        static string server = "PC-MARCOS\\SQLSERVER2012";
        static string bd = "GD2C2016";
        static string user = "gd";
        static string pass = "gd2016";
        
        public static string cadena_de_conexion = "data source=" + server + " ;initial catalog="+ bd +";persist security info=True;user id=" + user + ";password="+ pass +"";
    }

    public class login
    {
        public static int validar(string usuario, string contrasena,string rol)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("usuario_login", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("user_name", usuario);
                command.Parameters.AddWithValue("user_password", contrasena);
                command.Parameters.AddWithValue("rol", rol);

                SqlParameter paramRetorno = new SqlParameter("resultado", SqlDbType.Int);
                paramRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramRetorno);

                command.ExecuteNonQuery();
                return Convert.ToInt16(command.Parameters["resultado"].Value);

            }
        }

    }

    public class profesionales
    {
        public static DataSet listar(string especialidad)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();
                
                string cadena = "SELECT user_profesional as 'id' ,upper(user_apellido +', '+user_nombre) as 'Nombre' FROM LOS_TRIGGERS.Usuario as u "+
                                "JOIN LOS_TRIGGERS.Especialidad_Profesional as ep on u.user_profesional = ep.profesional "+
                                "JOIN LOS_TRIGGERS.Especialidad as e on e.espe_codigo = ep.especialidad "+
                                "JOIN LOS_TRIGGERS.Profesional as p on p.prof_id = u.user_profesional " +
                                "WHERE (user_profesional is not null) and (('" + especialidad + "' = '') or ('" + especialidad + "' = e.espe_descripcion)) " +
                                "and (prof_habilitacion=1) "+
                                "GROUP BY (user_apellido +', '+user_nombre),user_profesional " +
                                "ORDER BY (user_apellido +', '+user_nombre) ";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                return ds;

            }
        }
    }

    public class especialidades
    {
        public static DataSet listar()
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                string cadena = "SELECT espe_codigo as 'id',espe_descripcion as 'Nombre' FROM LOS_TRIGGERS.Especialidad "+
                                "GROUP BY espe_codigo,espe_descripcion " +
                                "ORDER BY espe_descripcion";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                return ds;

            }
        }
    }

    public class turnos
    {
        public static DataSet listar(decimal profesional,string fecha)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                string cadena = "SELECT turn_numero as 'Nro de turno' ," +
                                "turn_afiliado as 'Nro Afiliado',upper(u2.user_apellido +', '+u2.user_nombre) as 'Nombre Afiliado',turn_fecha_atencion as 'Fecha' " +
                                "FROM LOS_TRIGGERS.Turno as t " +
                                "JOIN LOS_TRIGGERS.Usuario as u1 on u1.user_profesional = turn_profesional " +
                                "JOIN LOS_TRIGGERS.Usuario as u2 on u2.user_afiliado = turn_afiliado "+
                                "WHERE turn_profesional = "+ profesional +" and "+ 
                                "turn_fecha_atencion between convert(datetime,'"+fecha+"') and convert(datetime,DATEADD(DAY,1,'"+fecha+"')) "+
                                "AND turn_fecha_y_hora_asistencia is null "+
                                "ORDER BY turn_fecha_atencion";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                return ds;

            }
        }
    }

    public class bonos
    {
        public static DataSet listar_disponibles_afiliado(decimal afiliado)
        {
            string afil_grupo_familiar = afiliado.ToString().Substring(0, afiliado.ToString().Length - 2);
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                string cadena = "SELECT bono_numero as 'id' " +
                                "FROM [GD2C2016].[LOS_TRIGGERS].[Bono] " +
                                "WHERE left(bono_afiliado,len(bono_afiliado)-2) = " + afil_grupo_familiar + ""+
                                "and bono_consulta_medica is null";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                return ds;

            }
        }
    }

    public class registrar
    {
        public static void llegada(decimal turno, decimal bono, decimal afiliado, string fecha)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("registro_llegada", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("turn_numero", turno);
                command.Parameters.AddWithValue("bono_numero", bono);
                command.Parameters.AddWithValue("afiliado", afiliado);
                command.Parameters.AddWithValue("fecha", fecha);

                command.ExecuteNonQuery();

            }
        }

        public static void registro_resultado(decimal turno, string fecha, string sintomas, string descripcion)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena_de_conexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("registro_llegada", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("turn_numero", turno);
                command.Parameters.AddWithValue("fecha_y_hora", fecha);
                command.Parameters.AddWithValue("diag_sintomas", sintomas);
                command.Parameters.AddWithValue("diag_descripcion", descripcion);

                command.ExecuteNonQuery();

            }
        }

    }



}
