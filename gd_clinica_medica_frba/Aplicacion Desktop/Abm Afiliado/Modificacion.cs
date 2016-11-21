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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Modificacion : Form
    {
        SqlDataReader dr;
        public Modificacion()
        {
            InitializeComponent();
        }

        private void comboBox_afil_plan_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion.cadena))
            {
                conn.Open();

                String query = "select plan_med_descripcion from LOS_TRIGGERS.Plan_Medico";
                SqlCommand command = new SqlCommand(query, conn);
                dr = command.ExecuteReader();
                if (comboBox_afil_plan.Items.Count <= 0)
                {

                    while (dr.Read())
                    {
                        comboBox_afil_plan.Items.Add(dr["plan_med_descripcion"].ToString());
                    }
                    dr.Close();
                }
            }
        }

    }
}
