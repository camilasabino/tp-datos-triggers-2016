using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    public class login
    {
        public static int validar(string usuario, string contrasena, string rol)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("LOS_TRIGGERS.usuario_login", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_name", usuario);
                command.Parameters.AddWithValue("@user_password", contrasena);
                command.Parameters.AddWithValue("@rol", rol);

                SqlParameter paramRetorno = new SqlParameter("@resultado", SqlDbType.Int);
                paramRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramRetorno);

                command.ExecuteNonQuery();
                int resultado = Convert.ToInt32(command.Parameters["@resultado"].Value);
                conn.Close();
                return resultado;
            }
        }
    }

    public class usuario
    {
        public static string nombre_usuario;
        public static decimal id_rol;
        public static string rol;

        public static decimal traer_id_rol(string usuario, string rol)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("LOS_TRIGGERS.usuario_traer_ID_rol", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@rol", rol);

                SqlParameter paramRetorno = new SqlParameter("@nro", SqlDbType.Decimal);
                paramRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramRetorno);

                command.ExecuteNonQuery();
                decimal numero = Convert.ToDecimal(command.Parameters["@nro"].Value);
                conn.Close();
                return numero;
            }
        }

        public static bool permiso(string funcionalidad, string rol)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("LOS_TRIGGERS.usuario_tiene_permiso", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@funcionalidad", funcionalidad);
                command.Parameters.AddWithValue("@rol", rol);

                SqlParameter paramRetorno = new SqlParameter("@resultado", SqlDbType.Bit);
                paramRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramRetorno);

                command.ExecuteNonQuery();
                bool resultado = Convert.ToBoolean(command.Parameters["@resultado"].Value);
                conn.Close();
                return resultado;
            }
        }
    }

    public class Especialidad
    {
        public decimal id { get; set; }
        public string nombre { get; set; }

        public Especialidad(decimal _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }

        public static List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(
                    "select espe_codigo, espe_descripcion from LOS_TRIGGERS.Especialidad order by espe_descripcion",
                    conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    especialidades.Add(
                        new Especialidad(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return especialidades;
        }
    }

    public class Profesional
    {
        public decimal id { get; set; }
        public string nombreYApellido { get; set; }

        public Profesional(decimal _id, string _nombre)
        {
            this.id = _id;
            this.nombreYApellido = _nombre;
        }

        public static List<Profesional> obtenerProfesionales(decimal id_especialidad)
        {
            List<Profesional> profesionales = new List<Profesional>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@especialidad", id_especialidad);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    profesionales.Add(
                        new Profesional(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return profesionales;
        }
    }
}
