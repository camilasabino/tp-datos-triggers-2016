﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void b_ingresar_Click(object sender, EventArgs e)
        {           

           int resultado = login.validar(t_usuario.Text,t_contrasena.Text,c_rol.Text);
           if (resultado == 1)
           {   
               //try
               //{
               decimal id = usuario.traer_id_rol(t_usuario.Text, c_rol.Text);
               if (id != 0)
               {
                usuario.nombre_usuario = t_usuario.Text;
                   usuario.rol = c_rol.Text;
                   usuario.id_rol = id;                   
                   MessageBox.Show("Login correcto!");
                   Menu m1 = new Menu();
                   this.Hide();
                   m1.ShowDialog(); 
               }
               else 
               {
                   MessageBox.Show("El usuario: "+ t_usuario.Text + " no tiene asignado el rol "+c_rol.Text +"");
               }
            
           }
           else
           {
               MessageBox.Show("Login INCORRECTO!");
               if (resultado == 2)
                   MessageBox.Show("El usuario fue inhabilitado");
           }
        }


    }
}
