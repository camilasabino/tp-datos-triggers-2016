namespace ClinicaFrba
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_bienvenido = new System.Windows.Forms.Label();
            this.l_nom_user = new System.Windows.Forms.Label();
            this.b_abm_afiliado = new System.Windows.Forms.Button();
            this.b_abm_espcialidades = new System.Windows.Forms.Button();
            this.b_abm_planes = new System.Windows.Forms.Button();
            this.b_abm_profesional = new System.Windows.Forms.Button();
            this.b_abm_rol = new System.Windows.Forms.Button();
            this.b_cancelar_atencion = new System.Windows.Forms.Button();
            this.b_compra_bono = new System.Windows.Forms.Button();
            this.b_listados = new System.Windows.Forms.Button();
            this.b_pedir_turno = new System.Windows.Forms.Button();
            this.b_registrar_agenda = new System.Windows.Forms.Button();
            this.b_registrar_llegada = new System.Windows.Forms.Button();
            this.b_registrar_resultado = new System.Windows.Forms.Button();
            this.b_cerrar_sesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_bienvenido
            // 
            this.l_bienvenido.AutoSize = true;
            this.l_bienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_bienvenido.Location = new System.Drawing.Point(39, 25);
            this.l_bienvenido.Name = "l_bienvenido";
            this.l_bienvenido.Size = new System.Drawing.Size(144, 18);
            this.l_bienvenido.TabIndex = 0;
            this.l_bienvenido.Text = "Bienvenido Usuario: ";
            // 
            // l_nom_user
            // 
            this.l_nom_user.AutoSize = true;
            this.l_nom_user.Location = new System.Drawing.Point(87, 13);
            this.l_nom_user.Name = "l_nom_user";
            this.l_nom_user.Size = new System.Drawing.Size(0, 13);
            this.l_nom_user.TabIndex = 1;
            // 
            // b_abm_afiliado
            // 
            this.b_abm_afiliado.Location = new System.Drawing.Point(43, 70);
            this.b_abm_afiliado.Name = "b_abm_afiliado";
            this.b_abm_afiliado.Size = new System.Drawing.Size(121, 80);
            this.b_abm_afiliado.TabIndex = 2;
            this.b_abm_afiliado.Text = "ABM Afiliado";
            this.b_abm_afiliado.UseVisualStyleBackColor = true;
            this.b_abm_afiliado.Click += new System.EventHandler(this.b_abm_afiliado_Click);
            // 
            // b_abm_espcialidades
            // 
            this.b_abm_espcialidades.Location = new System.Drawing.Point(191, 70);
            this.b_abm_espcialidades.Name = "b_abm_espcialidades";
            this.b_abm_espcialidades.Size = new System.Drawing.Size(121, 80);
            this.b_abm_espcialidades.TabIndex = 3;
            this.b_abm_espcialidades.Text = "ABM Especialidad Médica";
            this.b_abm_espcialidades.UseVisualStyleBackColor = true;
            this.b_abm_espcialidades.Click += new System.EventHandler(this.b_abm_espcialidades_Click);
            // 
            // b_abm_planes
            // 
            this.b_abm_planes.Location = new System.Drawing.Point(340, 70);
            this.b_abm_planes.Name = "b_abm_planes";
            this.b_abm_planes.Size = new System.Drawing.Size(121, 80);
            this.b_abm_planes.TabIndex = 4;
            this.b_abm_planes.Text = "ABM Plan";
            this.b_abm_planes.UseVisualStyleBackColor = true;
            this.b_abm_planes.Click += new System.EventHandler(this.b_abm_planes_Click);
            // 
            // b_abm_profesional
            // 
            this.b_abm_profesional.Location = new System.Drawing.Point(489, 70);
            this.b_abm_profesional.Name = "b_abm_profesional";
            this.b_abm_profesional.Size = new System.Drawing.Size(121, 80);
            this.b_abm_profesional.TabIndex = 5;
            this.b_abm_profesional.Text = "ABM Profesional";
            this.b_abm_profesional.UseVisualStyleBackColor = true;
            this.b_abm_profesional.Click += new System.EventHandler(this.b_abm_profesional_Click);
            // 
            // b_abm_rol
            // 
            this.b_abm_rol.Location = new System.Drawing.Point(43, 165);
            this.b_abm_rol.Name = "b_abm_rol";
            this.b_abm_rol.Size = new System.Drawing.Size(121, 80);
            this.b_abm_rol.TabIndex = 6;
            this.b_abm_rol.Text = "ABM Rol";
            this.b_abm_rol.UseVisualStyleBackColor = true;
            this.b_abm_rol.Click += new System.EventHandler(this.b_abm_rol_Click);
            // 
            // b_cancelar_atencion
            // 
            this.b_cancelar_atencion.Location = new System.Drawing.Point(191, 165);
            this.b_cancelar_atencion.Name = "b_cancelar_atencion";
            this.b_cancelar_atencion.Size = new System.Drawing.Size(121, 80);
            this.b_cancelar_atencion.TabIndex = 7;
            this.b_cancelar_atencion.Text = "Cancelar Atención Médica";
            this.b_cancelar_atencion.UseVisualStyleBackColor = true;
            this.b_cancelar_atencion.Click += new System.EventHandler(this.b_cancelar_atencion_Click);
            // 
            // b_compra_bono
            // 
            this.b_compra_bono.Location = new System.Drawing.Point(340, 165);
            this.b_compra_bono.Name = "b_compra_bono";
            this.b_compra_bono.Size = new System.Drawing.Size(121, 80);
            this.b_compra_bono.TabIndex = 8;
            this.b_compra_bono.Text = "Comprar Bono";
            this.b_compra_bono.UseVisualStyleBackColor = true;
            this.b_compra_bono.Click += new System.EventHandler(this.b_compra_bono_Click);
            // 
            // b_listados
            // 
            this.b_listados.Location = new System.Drawing.Point(489, 165);
            this.b_listados.Name = "b_listados";
            this.b_listados.Size = new System.Drawing.Size(121, 80);
            this.b_listados.TabIndex = 9;
            this.b_listados.Text = "Listados Estadísticos";
            this.b_listados.UseVisualStyleBackColor = true;
            this.b_listados.Click += new System.EventHandler(this.b_listados_Click);
            // 
            // b_pedir_turno
            // 
            this.b_pedir_turno.Location = new System.Drawing.Point(43, 262);
            this.b_pedir_turno.Name = "b_pedir_turno";
            this.b_pedir_turno.Size = new System.Drawing.Size(121, 80);
            this.b_pedir_turno.TabIndex = 10;
            this.b_pedir_turno.Text = "Pedir Turno";
            this.b_pedir_turno.UseVisualStyleBackColor = true;
            this.b_pedir_turno.Click += new System.EventHandler(this.b_pedir_turno_Click);
            // 
            // b_registrar_agenda
            // 
            this.b_registrar_agenda.Location = new System.Drawing.Point(191, 262);
            this.b_registrar_agenda.Name = "b_registrar_agenda";
            this.b_registrar_agenda.Size = new System.Drawing.Size(121, 80);
            this.b_registrar_agenda.TabIndex = 11;
            this.b_registrar_agenda.Text = "Registrar Agenda Profesional";
            this.b_registrar_agenda.UseVisualStyleBackColor = true;
            this.b_registrar_agenda.Click += new System.EventHandler(this.b_registrar_agenda_Click);
            // 
            // b_registrar_llegada
            // 
            this.b_registrar_llegada.Location = new System.Drawing.Point(340, 262);
            this.b_registrar_llegada.Name = "b_registrar_llegada";
            this.b_registrar_llegada.Size = new System.Drawing.Size(121, 80);
            this.b_registrar_llegada.TabIndex = 12;
            this.b_registrar_llegada.Text = "Registrar Llegada Atención Médica";
            this.b_registrar_llegada.UseVisualStyleBackColor = true;
            this.b_registrar_llegada.Click += new System.EventHandler(this.b_registrar_llegada_Click);
            // 
            // b_registrar_resultado
            // 
            this.b_registrar_resultado.Location = new System.Drawing.Point(489, 262);
            this.b_registrar_resultado.Name = "b_registrar_resultado";
            this.b_registrar_resultado.Size = new System.Drawing.Size(121, 80);
            this.b_registrar_resultado.TabIndex = 13;
            this.b_registrar_resultado.Text = "Registrar Resultado Atención Médica";
            this.b_registrar_resultado.UseVisualStyleBackColor = true;
            this.b_registrar_resultado.Click += new System.EventHandler(this.b_registrar_resultado_Click);
            // 
            // b_cerrar_sesion
            // 
            this.b_cerrar_sesion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_cerrar_sesion.Location = new System.Drawing.Point(513, 22);
            this.b_cerrar_sesion.Name = "b_cerrar_sesion";
            this.b_cerrar_sesion.Size = new System.Drawing.Size(97, 23);
            this.b_cerrar_sesion.TabIndex = 14;
            this.b_cerrar_sesion.Text = "Cerrar Sesión";
            this.b_cerrar_sesion.UseVisualStyleBackColor = false;
            this.b_cerrar_sesion.Click += new System.EventHandler(this.b_cerrar_sesion_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 367);
            this.Controls.Add(this.b_cerrar_sesion);
            this.Controls.Add(this.b_registrar_resultado);
            this.Controls.Add(this.b_registrar_llegada);
            this.Controls.Add(this.b_registrar_agenda);
            this.Controls.Add(this.b_pedir_turno);
            this.Controls.Add(this.b_listados);
            this.Controls.Add(this.b_compra_bono);
            this.Controls.Add(this.b_cancelar_atencion);
            this.Controls.Add(this.b_abm_rol);
            this.Controls.Add(this.b_abm_profesional);
            this.Controls.Add(this.b_abm_planes);
            this.Controls.Add(this.b_abm_espcialidades);
            this.Controls.Add(this.b_abm_afiliado);
            this.Controls.Add(this.l_nom_user);
            this.Controls.Add(this.l_bienvenido);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_bienvenido;
        private System.Windows.Forms.Label l_nom_user;
        private System.Windows.Forms.Button b_abm_afiliado;
        private System.Windows.Forms.Button b_abm_espcialidades;
        private System.Windows.Forms.Button b_abm_planes;
        private System.Windows.Forms.Button b_abm_profesional;
        private System.Windows.Forms.Button b_abm_rol;
        private System.Windows.Forms.Button b_cancelar_atencion;
        private System.Windows.Forms.Button b_compra_bono;
        private System.Windows.Forms.Button b_listados;
        private System.Windows.Forms.Button b_pedir_turno;
        private System.Windows.Forms.Button b_registrar_agenda;
        private System.Windows.Forms.Button b_registrar_llegada;
        private System.Windows.Forms.Button b_registrar_resultado;
        private System.Windows.Forms.Button b_cerrar_sesion;
    }
}