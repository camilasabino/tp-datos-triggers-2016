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
        public Editar(Menu m)
        {
            InitializeComponent();
            this.menu = m;
            cargarRoles();
            cargarNombre();
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
            obtenerHabilitacion();
        }

        Menu menu;
        String nombre_rol = "";

        public void obtenerHabilitacion()
        {
            String query = "";
            Boolean habilitacion;
            switch (cRoles.SelectedItem.ToString())
            {
                case "Administrador":
                    query = "select distinct(admi_habilitacion) from LOS_TRIGGERS.Administrador";
                    break;
                case "Afiliado":
                    query = "select distinct(afil_habilitacion) from LOS_TRIGGERS.Afiliado";
                    break;
                case "Profesional":
                    query = "select distinct(prof_habilitacion) from LOS_TRIGGERS.Profesional";
                    break;
            }

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(query, conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                habilitacion = reader.GetBoolean(0);

                conexionBase.Close();
            }
            if (habilitacion)
            {
                labelStatus.Text = "El rol se encuentra actualmente habilitado.";
                buttonHabilitar.Enabled = false;
            }
            else
            {
                labelStatus.Text = "El rol se encuentra actualmente inhabilitado.";
                buttonHabilitar.Enabled = true;
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
                nombre_rol = reader.GetString(0);

                conexionBase.Close();
            }
        }

        public List<String> obtenerFuncionalidadesParaAgregar()
        {
            List<String> funcionalidades = new List<String>();
            String query = "";
            switch (cRoles.SelectedItem.ToString())
            {
                case "Administrador":
                    query = "select distinct(func_nombre) from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where funcionalidad NOT IN (select distinct(funcionalidad) " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol where administrador is not null) " +
                            "AND func_id = funcionalidad";
                    break;
                case "Afiliado":
                    query = "select distinct(func_nombre) from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where funcionalidad NOT IN (select distinct(funcionalidad) " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol where afiliado is not null) " +
                            "AND func_id = funcionalidad"; ;
                    break;
                case "Profesional":
                    query = "select distinct(func_nombre) from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where funcionalidad NOT IN (select distinct(funcionalidad) " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol where profesional is not null) " +
                            "AND func_id = funcionalidad"; ;
                    break;
            }

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(query, conexionBase);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionalidades.Add(reader.GetString(0));
                }
                conexionBase.Close();
            }
            return funcionalidades;
        }

        protected void cargarFuncionalidadesParaAgregar()
        {
            cFuncionalidades.DataSource = obtenerFuncionalidadesParaAgregar();
        }

        public void cargarFuncionalidades()
        {
            String queryFuncionalidades = "";
            switch (cRoles.SelectedItem.ToString())
            {
                case "Administrador":
                    queryFuncionalidades = "select distinct(func_nombre) as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND administrador is not null";
                    break;
                case "Afiliado":
                    queryFuncionalidades = "select distinct(func_nombre) as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND afiliado is not null";
                    break;
                case "Profesional":
                    queryFuncionalidades = "select distinct(func_nombre) as Nombre " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where func_id=funcionalidad AND profesional is not null";
                    break;
            }

            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(queryFuncionalidades, conexionBase);

                DataTable funcionalidades = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
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


        private void habilitarRol()
        {
            SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("LOS_TRIGGERS.HabilitarRol", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@rol", cRoles.Text);

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
            obtenerHabilitacion();
        }

        /**************************************************************************************************
        *                                   EVENTOS DEL FORM                                              *
        ***************************************************************************************************/

        private void cRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarNombre();
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
            obtenerHabilitacion();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea habilitar el rol: " + cRoles.Text + "?", "Habilitación de rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                habilitarRol();
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de agregar la funcionalidad: " + cFuncionalidades.Text + "?", "Agregar Funcionalidad",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
                using (conexionBase)
                {
                    conexionBase.Open();
                    SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.AgregarFuncionalidadAUnRol", conexionBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rol", cRoles.Text);
                    cmd.Parameters.AddWithValue("@funcionalidad", cFuncionalidades.Text);
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
                cargarFuncionalidadesParaAgregar();
                cargarFuncionalidades();
                this.menu.cargarFuncionalidadesRol();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de quitar la funcionalidad: "
                + gridFuncionalidades.SelectedRows[0].Cells[0].Value.ToString() + "?", "Eliminar Funcionalidad",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
                using (conexionBase)
                {
                    conexionBase.Open();
                    SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.QuitarFuncionalidadAUnRol", conexionBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rol", cRoles.Text);
                    cmd.Parameters.AddWithValue("@funcionalidad", gridFuncionalidades.SelectedRows[0].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
                cargarFuncionalidadesParaAgregar();
                cargarFuncionalidades();
                this.menu.cargarFuncionalidadesRol();
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del Rol.", "No se ha indicado un nombre",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de cambiar el nombre de: " + nombre_rol + " a: " + textNombre.Text + "?",
                    "Cambiar Nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conexionBase = new SqlConnection(ClinicaFrba.conexion.cadena);
                    using (conexionBase)
                    {
                        conexionBase.Open();
                        SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarRol", conexionBase);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rol", nombre_rol);
                        cmd.Parameters.AddWithValue("@nuevo_nombre", textNombre.Text);
                        cmd.ExecuteNonQuery();

                        conexionBase.Close();
                    }
                    cargarNombre();
                }
            }
        }
    }
}
