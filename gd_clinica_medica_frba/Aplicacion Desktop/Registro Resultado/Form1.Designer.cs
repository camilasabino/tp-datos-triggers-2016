namespace ClinicaFrba.Registro_Resultado
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.grilla_turnos = new System.Windows.Forms.DataGridView();
            this.l_titulo = new System.Windows.Forms.Label();
            this.t_afiliado = new System.Windows.Forms.TextBox();
            this.l_afiliado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c_turno = new System.Windows.Forms.ComboBox();
            this.b_filtrar = new System.Windows.Forms.Button();
            this.t_sintomas = new System.Windows.Forms.TextBox();
            this.l_sintomas = new System.Windows.Forms.Label();
            this.l_diagnostico = new System.Windows.Forms.Label();
            this.t_diagnostico = new System.Windows.Forms.TextBox();
            this.b_registrar = new System.Windows.Forms.Button();
            this.l_profesional = new System.Windows.Forms.Label();
            this.t_profesional = new System.Windows.Forms.TextBox();
            this.b_turnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Turnos";
            // 
            // grilla_turnos
            // 
            this.grilla_turnos.AllowUserToAddRows = false;
            this.grilla_turnos.AllowUserToDeleteRows = false;
            this.grilla_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_turnos.Location = new System.Drawing.Point(28, 144);
            this.grilla_turnos.Name = "grilla_turnos";
            this.grilla_turnos.ReadOnly = true;
            this.grilla_turnos.Size = new System.Drawing.Size(449, 246);
            this.grilla_turnos.TabIndex = 8;
            this.grilla_turnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_turnos_CellClick);
            this.grilla_turnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_turnos_CellContentClick);
            // 
            // l_titulo
            // 
            this.l_titulo.AutoSize = true;
            this.l_titulo.Location = new System.Drawing.Point(28, 13);
            this.l_titulo.Name = "l_titulo";
            this.l_titulo.Size = new System.Drawing.Size(82, 13);
            this.l_titulo.TabIndex = 10;
            this.l_titulo.Text = "Filtrar búsqueda";
            // 
            // t_afiliado
            // 
            this.t_afiliado.Location = new System.Drawing.Point(31, 73);
            this.t_afiliado.Name = "t_afiliado";
            this.t_afiliado.Size = new System.Drawing.Size(189, 20);
            this.t_afiliado.TabIndex = 11;
            // 
            // l_afiliado
            // 
            this.l_afiliado.AutoSize = true;
            this.l_afiliado.Location = new System.Drawing.Point(30, 57);
            this.l_afiliado.Name = "l_afiliado";
            this.l_afiliado.Size = new System.Drawing.Size(95, 13);
            this.l_afiliado.TabIndex = 13;
            this.l_afiliado.Text = "Número de afiliado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hora de turno";
            // 
            // c_turno
            // 
            this.c_turno.FormattingEnabled = true;
            this.c_turno.Items.AddRange(new object[] {
            "Todas",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.c_turno.Location = new System.Drawing.Point(288, 71);
            this.c_turno.Name = "c_turno";
            this.c_turno.Size = new System.Drawing.Size(189, 21);
            this.c_turno.TabIndex = 15;
            // 
            // b_filtrar
            // 
            this.b_filtrar.Location = new System.Drawing.Point(215, 100);
            this.b_filtrar.Name = "b_filtrar";
            this.b_filtrar.Size = new System.Drawing.Size(77, 23);
            this.b_filtrar.TabIndex = 16;
            this.b_filtrar.Text = "Filtrar";
            this.b_filtrar.UseVisualStyleBackColor = true;
            this.b_filtrar.Click += new System.EventHandler(this.b_filtrar_Click);
            // 
            // t_sintomas
            // 
            this.t_sintomas.Location = new System.Drawing.Point(546, 115);
            this.t_sintomas.Multiline = true;
            this.t_sintomas.Name = "t_sintomas";
            this.t_sintomas.Size = new System.Drawing.Size(269, 80);
            this.t_sintomas.TabIndex = 17;
            // 
            // l_sintomas
            // 
            this.l_sintomas.AutoSize = true;
            this.l_sintomas.Location = new System.Drawing.Point(543, 96);
            this.l_sintomas.Name = "l_sintomas";
            this.l_sintomas.Size = new System.Drawing.Size(52, 13);
            this.l_sintomas.TabIndex = 18;
            this.l_sintomas.Text = "Síntomas";
            // 
            // l_diagnostico
            // 
            this.l_diagnostico.AutoSize = true;
            this.l_diagnostico.Location = new System.Drawing.Point(543, 217);
            this.l_diagnostico.Name = "l_diagnostico";
            this.l_diagnostico.Size = new System.Drawing.Size(63, 13);
            this.l_diagnostico.TabIndex = 20;
            this.l_diagnostico.Text = "Diagnóstico";
            // 
            // t_diagnostico
            // 
            this.t_diagnostico.Location = new System.Drawing.Point(546, 236);
            this.t_diagnostico.Multiline = true;
            this.t_diagnostico.Name = "t_diagnostico";
            this.t_diagnostico.Size = new System.Drawing.Size(269, 80);
            this.t_diagnostico.TabIndex = 19;
            // 
            // b_registrar
            // 
            this.b_registrar.Location = new System.Drawing.Point(642, 335);
            this.b_registrar.Name = "b_registrar";
            this.b_registrar.Size = new System.Drawing.Size(75, 52);
            this.b_registrar.TabIndex = 21;
            this.b_registrar.Text = "Registrar resultado";
            this.b_registrar.UseVisualStyleBackColor = true;
            this.b_registrar.Click += new System.EventHandler(this.b_registrar_Click);
            // 
            // l_profesional
            // 
            this.l_profesional.AutoSize = true;
            this.l_profesional.Location = new System.Drawing.Point(285, 9);
            this.l_profesional.Name = "l_profesional";
            this.l_profesional.Size = new System.Drawing.Size(113, 13);
            this.l_profesional.TabIndex = 23;
            this.l_profesional.Text = "Número de profesional";
            this.l_profesional.Visible = false;
            // 
            // t_profesional
            // 
            this.t_profesional.Location = new System.Drawing.Point(286, 25);
            this.t_profesional.Name = "t_profesional";
            this.t_profesional.Size = new System.Drawing.Size(189, 20);
            this.t_profesional.TabIndex = 22;
            this.t_profesional.Visible = false;
            // 
            // b_turnos
            // 
            this.b_turnos.Location = new System.Drawing.Point(505, 25);
            this.b_turnos.Name = "b_turnos";
            this.b_turnos.Size = new System.Drawing.Size(75, 23);
            this.b_turnos.TabIndex = 24;
            this.b_turnos.Text = "Turnos";
            this.b_turnos.UseVisualStyleBackColor = true;
            this.b_turnos.Visible = false;
            this.b_turnos.Click += new System.EventHandler(this.b_turnos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 484);
            this.Controls.Add(this.b_turnos);
            this.Controls.Add(this.l_profesional);
            this.Controls.Add(this.t_profesional);
            this.Controls.Add(this.b_registrar);
            this.Controls.Add(this.l_diagnostico);
            this.Controls.Add(this.t_diagnostico);
            this.Controls.Add(this.l_sintomas);
            this.Controls.Add(this.t_sintomas);
            this.Controls.Add(this.b_filtrar);
            this.Controls.Add(this.c_turno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_afiliado);
            this.Controls.Add(this.t_afiliado);
            this.Controls.Add(this.l_titulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grilla_turnos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grilla_turnos;
        private System.Windows.Forms.Label l_titulo;
        private System.Windows.Forms.TextBox t_afiliado;
        private System.Windows.Forms.Label l_afiliado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox c_turno;
        private System.Windows.Forms.Button b_filtrar;
        private System.Windows.Forms.TextBox t_sintomas;
        private System.Windows.Forms.Label l_sintomas;
        private System.Windows.Forms.Label l_diagnostico;
        private System.Windows.Forms.TextBox t_diagnostico;
        private System.Windows.Forms.Button b_registrar;
        private System.Windows.Forms.Label l_profesional;
        private System.Windows.Forms.TextBox t_profesional;
        private System.Windows.Forms.Button b_turnos;
    }
}