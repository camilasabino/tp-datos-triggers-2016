using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    /** En este archivo se incluyen todas las abstracciones y métodos de uso común para los formularios. */

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

        public static List<String> traerRolesHabilitados()
        {
            List<String> rolesHabilitados = new List<String>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select nombre_rol from LOS_TRIGGERS.Administrador where admi_habilitacion = 1 " +
                                                    "union select nombre_rol from LOS_TRIGGERS.Afiliado where afil_habilitacion = 1 " +
                                                    "union select nombre_rol from LOS_TRIGGERS.Profesional where prof_habilitacion = 1 " +
                                                    "order by nombre_rol", conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    rolesHabilitados.Add(reader.GetString(0));
                }
                conexionBase.Close();
            }
            return rolesHabilitados;
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

    public class AfiliadoRol
    {
        public string estadoCivil { get; set; }
        public decimal plan { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public decimal telefono { get; set; }

        public AfiliadoRol(string e, decimal p, string m, string d, decimal t)
        {
            this.estadoCivil = e;
            this.plan = p;
            this.mail = m;
            this.direccion = d;
            this.telefono = t;
        }


        public static AfiliadoRol nuevoAfiliado()
        {
            return new AfiliadoRol(null, 0, null, null, 0);
        }

        public static String verificarQueExistaElAfiliado(String afilNumero)
        {
            String nombreAfiliado = "";
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select user_apellido +', '+ user_nombre as nombre_y_apellido " +
                                                    "from LOS_TRIGGERS.Usuario where user_afiliado = " + afilNumero, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) nombreAfiliado = reader.GetString(0);

                reader.Close();
                conn.Close();

                return nombreAfiliado;
            }
        }

        public static Boolean validarHabilitacion(String afilNumero)
        {
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();
                string afil_habilitacion = "select afil_habilitacion from LOS_TRIGGERS.Afiliado where afil_numero = " + afilNumero;
                SqlCommand command = new SqlCommand(afil_habilitacion, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                bool habilitacion = reader.GetBoolean(0);
                reader.Close();
                conn.Close();

                return habilitacion;
            }
        }
    }

    public class Plan
    {
        public decimal id { get; set; }
        public string descripcion { get; set; }

        public Plan(decimal _id, string _descripcion)
        {
            this.id = _id;
            this.descripcion = _descripcion;
        }

        public static List<Plan> traerPlanesMedicos()
        {
            List<Plan> planes = new List<Plan>();
            SqlConnection conn = new SqlConnection(conexion.cadena);
            using (conn)
            {
                conn.Open();

                String query = "select plan_id, plan_med_descripcion from LOS_TRIGGERS.Plan_Medico";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    planes.Add(new Plan(reader.GetDecimal(0), reader.GetString(1)));
                }
                conn.Close();
                return planes;
            }
        }
    }

    public class TipoCancelacion
    {
        public decimal id { get; set; }
        public string descripcion { get; set; }

        public TipoCancelacion(decimal _id, string _descripcion)
        {
            this.id = _id;
            this.descripcion = _descripcion;
        }

        public static List<TipoCancelacion> obtenerTiposCancelacion()
        {
            List<TipoCancelacion> cancelaciones = new List<TipoCancelacion>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("select * from LOS_TRIGGERS.Tipo_Cancelacion", conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cancelaciones.Add(
                        new TipoCancelacion(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return cancelaciones;
        }
    }
}
