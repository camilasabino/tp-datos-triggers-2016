using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Listados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            llenar_especialidades();
            llenar_planes();
        }

        protected void llenar_especialidades()
        {
            c_especialidad.DataSource = especialidades.listar().Tables[0];
            c_especialidad.ValueMember = "id";
            c_especialidad.DisplayMember = "Nombre";
        }

        protected void llenar_planes()
        {
            c_plan.DataSource = listar_planes().Tables[0];
            c_plan.ValueMember = "id";
            c_plan.DisplayMember = "Nombre";
        }

        public static DataSet listar_planes()
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                string cadena = "SELECT plan_id as 'id',plan_med_descripcion as 'Nombre' FROM LOS_TRIGGERS.Plan_Medico " +
                                "GROUP BY plan_id,plan_med_descripcion " +
                                "ORDER BY plan_med_descripcion";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                return ds;
            }
        }

        protected void llenarGrid()
        {
            int anio = Convert.ToDateTime(fecha.fechaActual).Year;
            int mes = Convert.ToDateTime(fecha.fechaActual).Month;
            int semestre = 0;
            if (mes > 6)
                semestre = 2;
            else
                semestre = 1;

            switch (c_opcion.Text)
            {
                case "Especialidades con más cancelaciones":
                    dataGridView1.DataSource = listados.especialidades_cancelaciones(anio, semestre).Tables[0];
                    break;
                case "Profesionales más consultados por Plan":
                    dataGridView1.DataSource = listados.profesionales_consultados(anio, semestre, decimal.Parse(c_plan.SelectedValue.ToString())).Tables[0];
                    break;
                case "Profesionales con menos horas trabajadas":
                    dataGridView1.DataSource = listados.profesionales_horas(anio, semestre, decimal.Parse(c_plan.SelectedValue.ToString()), decimal.Parse(c_especialidad.SelectedValue.ToString())).Tables[0];
                    break;
                case "Afiliados con mayor cantidad de bonos comprados":
                    dataGridView1.DataSource = listados.afiliados_bonos(anio, semestre).Tables[0];
                    break;
                case "Especialidades de profesionales con más bonos de consultas utilizados":
                    dataGridView1.DataSource = listados.especialidades_bonos(anio, semestre).Tables[0];
                    break;
            }
        }

        private void b_mostrar_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            llenarGrid();
        }


        public class listados
        {
            public static DataSet afiliados_bonos(int anio, int semestre)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("[LOS_TRIGGERS].[AfiliadosConMasBonosComprados]", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("anio", anio);
                    command.Parameters.AddWithValue("semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;

                }
            }

            public static DataSet profesionales_horas(int anio, int semestre, decimal plan, decimal especialidad)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("[LOS_TRIGGERS].[ProfesionalesConMenosHorasTrabajadas]", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("anio", anio);
                    command.Parameters.AddWithValue("semestre", semestre);
                    command.Parameters.AddWithValue("plan", plan);
                    command.Parameters.AddWithValue("especialidad", especialidad);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;

                }
            }

            public static DataSet profesionales_consultados(int anio, int semestre, decimal plan)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("[LOS_TRIGGERS].[ProfesionalesMasConsultadosPorPlan]", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("anio", anio);
                    command.Parameters.AddWithValue("semestre", semestre);
                    command.Parameters.AddWithValue("plan", plan);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;
                }
            }


            public static DataSet especialidades_cancelaciones(int anio, int semestre)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("[LOS_TRIGGERS].[EspecialidadesConMasCancelaciones]", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("anio", anio);
                    command.Parameters.AddWithValue("semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;
                }
            }


            public static DataSet especialidades_bonos(int anio, int semestre)
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("[LOS_TRIGGERS].[EspecialidadesConMasBonosUtilizados]", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("anio", anio);
                    command.Parameters.AddWithValue("semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;
                }
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}

