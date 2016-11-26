namespace ClinicaFrba.Registro_Llegada
{
    partial class Registrar
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
            this.l_titulo = new System.Windows.Forms.Label();
            this.c_especialidad = new System.Windows.Forms.ComboBox();
            this.l_especialidad = new System.Windows.Forms.Label();
            this.c_profesional = new System.Windows.Forms.ComboBox();
            this.l_profesional = new System.Windows.Forms.Label();
            this.b_elegir_prof = new System.Windows.Forms.Button();
            this.grilla_turnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.l_bonos = new System.Windows.Forms.Label();
            this.c_bonos = new System.Windows.Forms.ComboBox();
            this.b_registrar = new System.Windows.Forms.Button();
            this.afiliado = new System.Windows.Forms.Label();
            this.turno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // l_titulo
            // 
            this.l_titulo.AutoSize = true;
            this.l_titulo.Location = new System.Drawing.Point(13, 13);
            this.l_titulo.Name = "l_titulo";
            this.l_titulo.Size = new System.Drawing.Size(124, 13);
            this.l_titulo.TabIndex = 0;
            this.l_titulo.Text = "Selección de Profesional";
            // 
            // c_especialidad
            // 
            this.c_especialidad.FormattingEnabled = true;
            this.c_especialidad.Location = new System.Drawing.Point(128, 41);
            this.c_especialidad.Name = "c_especialidad";
            this.c_especialidad.Size = new System.Drawing.Size(317, 21);
            this.c_especialidad.TabIndex = 1;
            this.c_especialidad.SelectedValueChanged += new System.EventHandler(this.c_especialidad_SelectedValueChanged);
            // 
            // l_especialidad
            // 
            this.l_especialidad.AutoSize = true;
            this.l_especialidad.Location = new System.Drawing.Point(13, 44);
            this.l_especialidad.Name = "l_especialidad";
            this.l_especialidad.Size = new System.Drawing.Size(67, 13);
            this.l_especialidad.TabIndex = 2;
            this.l_especialidad.Text = "Especialidad";
            // 
            // c_profesional
            // 
            this.c_profesional.FormattingEnabled = true;
            this.c_profesional.Location = new System.Drawing.Point(128, 80);
            this.c_profesional.Name = "c_profesional";
            this.c_profesional.Size = new System.Drawing.Size(317, 21);
            this.c_profesional.TabIndex = 3;
            // 
            // l_profesional
            // 
            this.l_profesional.AutoSize = true;
            this.l_profesional.Location = new System.Drawing.Point(13, 88);
            this.l_profesional.Name = "l_profesional";
            this.l_profesional.Size = new System.Drawing.Size(59, 13);
            this.l_profesional.TabIndex = 4;
            this.l_profesional.Text = "Profesional";
            // 
            // b_elegir_prof
            // 
            this.b_elegir_prof.Location = new System.Drawing.Point(534, 61);
            this.b_elegir_prof.Name = "b_elegir_prof";
            this.b_elegir_prof.Size = new System.Drawing.Size(191, 23);
            this.b_elegir_prof.TabIndex = 5;
            this.b_elegir_prof.Text = "Elegir Profesional";
            this.b_elegir_prof.UseVisualStyleBackColor = true;
            this.b_elegir_prof.Click += new System.EventHandler(this.b_elegir_prof_Click);
            // 
            // grilla_turnos
            // 
            this.grilla_turnos.AllowUserToAddRows = false;
            this.grilla_turnos.AllowUserToDeleteRows = false;
            this.grilla_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_turnos.Location = new System.Drawing.Point(16, 143);
            this.grilla_turnos.Name = "grilla_turnos";
            this.grilla_turnos.ReadOnly = true;
            this.grilla_turnos.Size = new System.Drawing.Size(449, 246);
            this.grilla_turnos.TabIndex = 6;
            this.grilla_turnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_turnos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turnos";
            // 
            // l_bonos
            // 
            this.l_bonos.AutoSize = true;
            this.l_bonos.Location = new System.Drawing.Point(481, 143);
            this.l_bonos.Name = "l_bonos";
            this.l_bonos.Size = new System.Drawing.Size(92, 13);
            this.l_bonos.TabIndex = 8;
            this.l_bonos.Text = "Bonos disponibles";
            // 
            // c_bonos
            // 
            this.c_bonos.FormattingEnabled = true;
            this.c_bonos.Location = new System.Drawing.Point(484, 172);
            this.c_bonos.Name = "c_bonos";
            this.c_bonos.Size = new System.Drawing.Size(317, 21);
            this.c_bonos.TabIndex = 9;
            // 
            // b_registrar
            // 
            this.b_registrar.Location = new System.Drawing.Point(596, 318);
            this.b_registrar.Name = "b_registrar";
            this.b_registrar.Size = new System.Drawing.Size(75, 52);
            this.b_registrar.TabIndex = 10;
            this.b_registrar.Text = "Registrar llegada";
            this.b_registrar.UseVisualStyleBackColor = true;
            this.b_registrar.Click += new System.EventHandler(this.b_registrar_Click);
            // 
            // afiliado
            // 
            this.afiliado.AutoSize = true;
            this.afiliado.Location = new System.Drawing.Point(484, 98);
            this.afiliado.Name = "afiliado";
            this.afiliado.Size = new System.Drawing.Size(0, 13);
            this.afiliado.TabIndex = 11;
            this.afiliado.Visible = false;
            // 
            // turno
            // 
            this.turno.AutoSize = true;
            this.turno.Location = new System.Drawing.Point(517, 98);
            this.turno.Name = "turno";
            this.turno.Size = new System.Drawing.Size(0, 13);
            this.turno.TabIndex = 12;
            this.turno.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 409);
            this.Controls.Add(this.turno);
            this.Controls.Add(this.afiliado);
            this.Controls.Add(this.b_registrar);
            this.Controls.Add(this.c_bonos);
            this.Controls.Add(this.l_bonos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grilla_turnos);
            this.Controls.Add(this.b_elegir_prof);
            this.Controls.Add(this.l_profesional);
            this.Controls.Add(this.c_profesional);
            this.Controls.Add(this.l_especialidad);
            this.Controls.Add(this.c_especialidad);
            this.Controls.Add(this.l_titulo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_titulo;
        private System.Windows.Forms.ComboBox c_especialidad;
        private System.Windows.Forms.Label l_especialidad;
        private System.Windows.Forms.ComboBox c_profesional;
        private System.Windows.Forms.Label l_profesional;
        private System.Windows.Forms.Button b_elegir_prof;
        private System.Windows.Forms.DataGridView grilla_turnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_bonos;
        private System.Windows.Forms.ComboBox c_bonos;
        private System.Windows.Forms.Button b_registrar;
        private System.Windows.Forms.Label afiliado;
        private System.Windows.Forms.Label turno;
    }
}