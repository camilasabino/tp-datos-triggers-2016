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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.t_usuario = new System.Windows.Forms.TextBox();
            this.l_usuario = new System.Windows.Forms.Label();
            this.l_contrasena = new System.Windows.Forms.Label();
            this.t_contrasena = new System.Windows.Forms.TextBox();
            this.c_rol = new System.Windows.Forms.ComboBox();
            this.t_rol = new System.Windows.Forms.Label();
            this.b_ingresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_usuario
            // 
            this.t_usuario.Location = new System.Drawing.Point(99, 221);
            this.t_usuario.Name = "t_usuario";
            this.t_usuario.Size = new System.Drawing.Size(320, 20);
            this.t_usuario.TabIndex = 0;
            // 
            // l_usuario
            // 
            this.l_usuario.AutoSize = true;
            this.l_usuario.Location = new System.Drawing.Point(96, 205);
            this.l_usuario.Name = "l_usuario";
            this.l_usuario.Size = new System.Drawing.Size(43, 13);
            this.l_usuario.TabIndex = 1;
            this.l_usuario.Text = "Usuario";
            // 
            // l_contrasena
            // 
            this.l_contrasena.AutoSize = true;
            this.l_contrasena.Location = new System.Drawing.Point(96, 265);
            this.l_contrasena.Name = "l_contrasena";
            this.l_contrasena.Size = new System.Drawing.Size(61, 13);
            this.l_contrasena.TabIndex = 3;
            this.l_contrasena.Text = "Contraseña";
            // 
            // t_contrasena
            // 
            this.t_contrasena.Location = new System.Drawing.Point(99, 281);
            this.t_contrasena.Name = "t_contrasena";
            this.t_contrasena.Size = new System.Drawing.Size(320, 20);
            this.t_contrasena.TabIndex = 2;
            this.t_contrasena.UseSystemPasswordChar = true;
            // 
            // c_rol
            // 
            this.c_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_rol.FormattingEnabled = true;
            this.c_rol.Location = new System.Drawing.Point(101, 339);
            this.c_rol.Name = "c_rol";
            this.c_rol.Size = new System.Drawing.Size(320, 21);
            this.c_rol.TabIndex = 4;
            // 
            // t_rol
            // 
            this.t_rol.AutoSize = true;
            this.t_rol.Location = new System.Drawing.Point(98, 323);
            this.t_rol.Name = "t_rol";
            this.t_rol.Size = new System.Drawing.Size(23, 13);
            this.t_rol.TabIndex = 5;
            this.t_rol.Text = "Rol";
            // 
            // b_ingresar
            // 
            this.b_ingresar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_ingresar.Location = new System.Drawing.Point(212, 402);
            this.b_ingresar.Name = "b_ingresar";
            this.b_ingresar.Size = new System.Drawing.Size(75, 23);
            this.b_ingresar.TabIndex = 6;
            this.b_ingresar.Text = "Ingresar";
            this.b_ingresar.UseVisualStyleBackColor = false;
            this.b_ingresar.Click += new System.EventHandler(this.b_ingresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bienvenido al Sistema de Clínica FRBA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Iniciar sesión";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "* Se muestran solo los roles habilitados";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 443);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_ingresar);
            this.Controls.Add(this.t_rol);
            this.Controls.Add(this.c_rol);
            this.Controls.Add(this.l_contrasena);
            this.Controls.Add(this.t_contrasena);
            this.Controls.Add(this.l_usuario);
            this.Controls.Add(this.t_usuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

