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
            textAnio.MaxLength = 4;
            cargarEspecialidades();
            llenar_planes();
            c_opcion.SelectedIndex = 0;
            cSemestre.SelectedIndex = 0;
            c_plan.Enabled = false;
            c_especialidad.Enabled = false;
            labelResultado.Text = "";

            if (c_opcion.Text == "Profesionales más consultados por plan")
                c_plan.Enabled = true;
            else if (c_opcion.Text == "Profesionales con menos horas trabajadas")
            {
                c_plan.Enabled = true;
                c_especialidad.Enabled = true;
            }
        }

        protected void cargarEspecialidades()
        {
            c_especialidad.DataSource = Especialidad.obtenerEspecialidades();
            c_especialidad.DisplayMember = "nombre";
            c_especialidad.ValueMember = "id";
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
                                "GROUP BY plan_id, plan_med_descripcion " +
                                "ORDER BY plan_med_descripcion";

                SqlCommand comando = new SqlCommand(cadena, conn);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();

                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }

        protected void llenarGrid()
        {
            if (!string.IsNullOrEmpty(textAnio.Text))
            {
                int anio = Convert.ToInt32(textAnio.Text);
                int semestre = Convert.ToInt32(cSemestre.SelectedItem);

                switch (c_opcion.Text)
                {
                    case "Especialidades con más cancelaciones de atención médica":
                        gridListado.DataSource = listados.especialidades_cancelaciones(anio, semestre).Tables[0];
                        break;
                    case "Profesionales más consultados por plan":
                        gridListado.DataSource = listados.profesionales_consultados(anio, semestre, decimal.Parse(c_plan.SelectedValue.ToString())).Tables[0];
                        break;
                    case "Profesionales con menos horas trabajadas":
                        gridListado.DataSource = listados.profesionales_horas(anio, semestre, decimal.Parse(c_plan.SelectedValue.ToString()), decimal.Parse(c_especialidad.SelectedValue.ToString())).Tables[0];
                        break;
                    case "Afiliados con mayor cantidad de bonos comprados":
                        gridListado.DataSource = listados.afiliados_bonos(anio, semestre).Tables[0];
                        break;
                    case "Especialidades médicas con más bonos de consulta utilizados":
                        gridListado.DataSource = listados.especialidades_bonos(anio, semestre).Tables[0];
                        break;
                }
                if (gridListado.Rows.Count != 0) labelResultado.Text = "";
                else labelResultado.Text = "No se han encontrado resultados para la consulta.";
            }
            else
            {
                MessageBox.Show("Por favor, indique el año en base al cual producir el Listado.", "No se ha indicado un año",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_mostrar_Click(object sender, EventArgs e)
        {
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
                    command.Parameters.AddWithValue("@anio", anio);
                    command.Parameters.AddWithValue("@semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    conn.Close();
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
                    command.Parameters.AddWithValue("@anio", anio);
                    command.Parameters.AddWithValue("@semestre", semestre);
                    command.Parameters.AddWithValue("@plan", plan);
                    command.Parameters.AddWithValue("@especialidad", especialidad);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    conn.Close();
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
                    command.Parameters.AddWithValue("@anio", anio);
                    command.Parameters.AddWithValue("@semestre", semestre);
                    command.Parameters.AddWithValue("@plan", plan);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    conn.Close();
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
                    command.Parameters.AddWithValue("@anio", anio);
                    command.Parameters.AddWithValue("@semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    conn.Close();
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
                    command.Parameters.AddWithValue("@anio", anio);
                    command.Parameters.AddWithValue("@semestre", semestre);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    conn.Close();
                    return ds;
                }
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void c_opcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_opcion.Text == "Profesionales más consultados por plan")
                c_plan.Enabled = true;
            else if (c_opcion.Text == "Profesionales con menos horas trabajadas")
            {
                c_plan.Enabled = true;
                c_especialidad.Enabled = true;
            }
            else
            {
                c_plan.Enabled = false;
                c_especialidad.Enabled = false;
            }
        }
    }
}

