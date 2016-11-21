namespace ClinicaFrba
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.t_usuario = new System.Windows.Forms.TextBox();
            this.l_usuario = new System.Windows.Forms.Label();
            this.l_contrasena = new System.Windows.Forms.Label();
            this.t_contrasena = new System.Windows.Forms.TextBox();
            this.c_rol = new System.Windows.Forms.ComboBox();
            this.t_rol = new System.Windows.Forms.Label();
            this.b_ingresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // t_usuario
            // 
            this.t_usuario.Location = new System.Drawing.Point(127, 103);
            this.t_usuario.Name = "t_usuario";
            this.t_usuario.Size = new System.Drawing.Size(320, 20);
            this.t_usuario.TabIndex = 0;
            // 
            // l_usuario
            // 
            this.l_usuario.AutoSize = true;
            this.l_usuario.Location = new System.Drawing.Point(122, 78);
            this.l_usuario.Name = "l_usuario";
            this.l_usuario.Size = new System.Drawing.Size(43, 13);
            this.l_usuario.TabIndex = 1;
            this.l_usuario.Text = "Usuario";
            // 
            // l_contrasena
            // 
            this.l_contrasena.AutoSize = true;
            this.l_contrasena.Location = new System.Drawing.Point(122, 150);
            this.l_contrasena.Name = "l_contrasena";
            this.l_contrasena.Size = new System.Drawing.Size(61, 13);
            this.l_contrasena.TabIndex = 3;
            this.l_contrasena.Text = "Contraseña";
            // 
            // t_contrasena
            // 
            this.t_contrasena.Location = new System.Drawing.Point(127, 175);
            this.t_contrasena.Name = "t_contrasena";
            this.t_contrasena.Size = new System.Drawing.Size(320, 20);
            this.t_contrasena.TabIndex = 2;
            this.t_contrasena.UseSystemPasswordChar = true;
            // 
            // c_rol
            // 
            this.c_rol.FormattingEnabled = true;
            this.c_rol.Items.AddRange(new object[] {
            "Administrador",
            "Afiliado",
            "Profesional"});
            this.c_rol.Location = new System.Drawing.Point(127, 232);
            this.c_rol.Name = "c_rol";
            this.c_rol.Size = new System.Drawing.Size(320, 21);
            this.c_rol.TabIndex = 4;
            // 
            // t_rol
            // 
            this.t_rol.AutoSize = true;
            this.t_rol.Location = new System.Drawing.Point(122, 208);
            this.t_rol.Name = "t_rol";
            this.t_rol.Size = new System.Drawing.Size(23, 13);
            this.t_rol.TabIndex = 5;
            this.t_rol.Text = "Rol";
            // 
            // b_ingresar
            // 
            this.b_ingresar.Location = new System.Drawing.Point(255, 303);
            this.b_ingresar.Name = "b_ingresar";
            this.b_ingresar.Size = new System.Drawing.Size(75, 23);
            this.b_ingresar.TabIndex = 6;
            this.b_ingresar.Text = "Ingresar";
            this.b_ingresar.UseVisualStyleBackColor = true;
            this.b_ingresar.Click += new System.EventHandler(this.b_ingresar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 423);
            this.Controls.Add(this.b_ingresar);
            this.Controls.Add(this.t_rol);
            this.Controls.Add(this.c_rol);
            this.Controls.Add(this.l_contrasena);
            this.Controls.Add(this.t_contrasena);
            this.Controls.Add(this.l_usuario);
            this.Controls.Add(this.t_usuario);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_usuario;
        private System.Windows.Forms.Label l_usuario;
        private System.Windows.Forms.Label l_contrasena;
        private System.Windows.Forms.TextBox t_contrasena;
        private System.Windows.Forms.ComboBox c_rol;
        private System.Windows.Forms.Label t_rol;
        private System.Windows.Forms.Button b_ingresar;
    }
}

