using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Editar : Form
    {

        public Editar()
        {
            InitializeComponent();
            cargarRoles();
            cargarNombre();
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
        }

        public class Funcionalidad
        {
            public decimal id { get; set; }
            public string nombre { get; set; }

            public Funcionalidad(decimal _id, string _nombre)
            {
                this.id = _id;
                this.nombre = _nombre;
            }
        }

        public void cargarNombre()
        {
            String queryNombre = "";
            switch (cRoles.SelectedItem.ToString())
            {
                case "Administrador":
                    queryNombre = "select distinct(nombre_rol) from LOS_TRIGGERS.Administrador";
                    break;
                case "Afiliado":
                    queryNombre = "select distinct(nombre_rol) from LOS_TRIGGERS.Afiliado";
                    break;
                case "Profesional":
                    queryNombre = "select distinct(nombre_rol) from LOS_TRIGGERS.Profesional";
                    break;
            }

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando2 = new SqlCommand(queryNombre, conexionBase);

                SqlDataReader reader = comando2.ExecuteReader();
                reader.Read();
                textNombre.Text = reader.GetString(0);

                conexionBase.Close();
            }
        }

        public List<Funcionalidad> obtenerFuncionalidadesParaAgregar()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(
                    "select distinct(funcionalidad), func_nombre from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad "+
                    "where func_id = funcionalidad AND funcionalidad NOT IN (select distinct(funcionalidad) from LOS_TRIGGERS.Funcionalidad_Rol "+
					"where afiliado = @rol OR profesional = @rol OR administrador = @rol) order by func_nombre", conexionBase);
                comando.Parameters.AddWithValue("@rol", usuario.id_rol);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionalidades.Add(
                        new Funcionalidad(reader.GetDecimal(0), reader.GetString(1)));
                }
                conexionBase.Close();
            }
            return funcionalidades;
        }

        protected void cargarFuncionalidadesParaAgregar()
        {
            cFuncionalidades.DataSource = obtenerFuncionalidadesParaAgregar();
            cFuncionalidades.DisplayMember = "nombre";
            cFuncionalidades.ValueMember = "id";
        }

        public void cargarFuncionalidades()
        {
            String queryFuncionalidades = "";
            switch (cRoles.SelectedItem.ToString())
            {
                case "Administrador":
                    queryFuncionalidades = "select distinct(funcionalidad) as Id, func_nombre as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND administrador is not null";
                    break;
                case "Afiliado":
                    queryFuncionalidades = "select distinct(funcionalidad) as Id, func_nombre as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND afiliado is not null";
                    break;
                case "Profesional":
                    queryFuncionalidades = "select distinct(funcionalidad) as Id, func_nombre as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND profesional is not null";
                    break;
            }

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando1 = new SqlCommand(queryFuncionalidades, conexionBase);

                DataTable funcionalidades = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando1);
                adapter.Fill(funcionalidades);
                gridFuncionalidades.DataSource = funcionalidades;

                conexionBase.Close();
            }
        }

        public void cargarRoles()
        {
            cRoles.Items.Insert(0, "Administrador");
            cRoles.Items.Insert(1, "Afiliado");
            cRoles.Items.Insert(2, "Profesional");
            cRoles.SelectedIndex = 0;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.AgregarFuncionalidadAUnRol", conexionBase);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol", cRoles.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@funcionalidad", cFuncionalidades.SelectedValue.ToString());
                cmd.ExecuteNonQuery();

                conexionBase.Close();
            }
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.QuitarFuncionalidadAUnRol", conexionBase);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol", cRoles.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@funcionalidad", gridFuncionalidades.SelectedRows[0].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();

                conexionBase.Close();
            }
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del Rol.", "No se ha indicado un nombre",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
                using (conexionBase)
                {
                    conexionBase.Open();
                    SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarRol", conexionBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rol", cRoles.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@nuevo_nombre", textNombre.Text);
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void cRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarNombre();
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
