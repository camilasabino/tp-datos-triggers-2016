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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrar));
            this.l_titulo = new System.Windows.Forms.Label();
            this.c_especialidad = new System.Windows.Forms.ComboBox();
            this.l_especialidad = new System.Windows.Forms.Label();
            this.c_profesional = new System.Windows.Forms.ComboBox();
            this.l_profesional = new System.Windows.Forms.Label();
            this.grilla_turnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.l_bonos = new System.Windows.Forms.Label();
            this.c_bonos = new System.Windows.Forms.ComboBox();
            this.b_registrar = new System.Windows.Forms.Button();
            this.afiliado = new System.Windows.Forms.Label();
            this.turno = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelBonos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // l_titulo
            // 
            this.l_titulo.AutoSize = true;
            this.l_titulo.Location = new System.Drawing.Point(12, 70);
            this.l_titulo.Name = "l_titulo";
            this.l_titulo.Size = new System.Drawing.Size(129, 13);
            this.l_titulo.TabIndex = 0;
            this.l_titulo.Text = "Selección del Profesional:";
            // 
            // c_especialidad
            // 
            this.c_especialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_especialidad.FormattingEnabled = true;
            this.c_especialidad.Location = new System.Drawing.Point(96, 95);
            this.c_especialidad.Name = "c_especialidad";
            this.c_especialidad.Size = new System.Drawing.Size(317, 21);
            this.c_especialidad.TabIndex = 1;
            this.c_especialidad.SelectedValueChanged += new System.EventHandler(this.c_especialidad_SelectedValueChanged);
            // 
            // l_especialidad
            // 
            this.l_especialidad.AutoSize = true;
            this.l_especialidad.Location = new System.Drawing.Point(13, 98);
            this.l_especialidad.Name = "l_especialidad";
            this.l_especialidad.Size = new System.Drawing.Size(67, 13);
            this.l_especialidad.TabIndex = 2;
            this.l_especialidad.Text = "Especialidad";
            // 
            // c_profesional
            // 
            this.c_profesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_profesional.FormattingEnabled = true;
            this.c_profesional.Location = new System.Drawing.Point(96, 139);
            this.c_profesional.Name = "c_profesional";
            this.c_profesional.Size = new System.Drawing.Size(317, 21);
            this.c_profesional.TabIndex = 3;
            this.c_profesional.SelectedValueChanged += new System.EventHandler(this.c_profesional_SelectedValueChanged);
            // 
            // l_profesional
            // 
            this.l_profesional.AutoSize = true;
            this.l_profesional.Location = new System.Drawing.Point(12, 142);
            this.l_profesional.Name = "l_profesional";
            this.l_profesional.Size = new System.Drawing.Size(59, 13);
            this.l_profesional.TabIndex = 4;
            this.l_profesional.Text = "Profesional";
            // 
            // grilla_turnos
            // 
            this.grilla_turnos.AllowUserToAddRows = false;
            this.grilla_turnos.AllowUserToDeleteRows = false;
            this.grilla_turnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grilla_turnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_turnos.Location = new System.Drawing.Point(16, 205);
            this.grilla_turnos.MultiSelect = false;
            this.grilla_turnos.Name = "grilla_turnos";
            this.grilla_turnos.ReadOnly = true;
            this.grilla_turnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grilla_turnos.Size = new System.Drawing.Size(449, 184);
            this.grilla_turnos.TabIndex = 6;
            this.grilla_turnos.SelectionChanged += new System.EventHandler(this.grilla_turnos_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turnos del Profesional en el día de hoy:";
            // 
            // l_bonos
            // 
            this.l_bonos.AutoSize = true;
            this.l_bonos.Location = new System.Drawing.Point(484, 184);
            this.l_bonos.Name = "l_bonos";
            this.l_bonos.Size = new System.Drawing.Size(149, 13);
            this.l_bonos.TabIndex = 8;
            this.l_bonos.Text = "Bonos disponibles del Afiliado:";
            // 
            // c_bonos
            // 
            this.c_bonos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_bonos.FormattingEnabled = true;
            this.c_bonos.Location = new System.Drawing.Point(487, 205);
            this.c_bonos.Name = "c_bonos";
            this.c_bonos.Size = new System.Drawing.Size(177, 21);
            this.c_bonos.TabIndex = 9;
            // 
            // b_registrar
            // 
            this.b_registrar.Location = new System.Drawing.Point(534, 326);
            this.b_registrar.Name = "b_registrar";
            this.b_registrar.Size = new System.Drawing.Size(103, 24);
            this.b_registrar.TabIndex = 10;
            this.b_registrar.Text = "Registrar Llegada";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Registro de Llegada a la Atención Médica";
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(562, 366);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 14;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(523, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // labelBonos
            // 
            this.labelBonos.AutoSize = true;
            this.labelBonos.ForeColor = System.Drawing.Color.Crimson;
            this.labelBonos.Location = new System.Drawing.Point(487, 243);
            this.labelBonos.Name = "labelBonos";
            this.labelBonos.Size = new System.Drawing.Size(106, 13);
            this.labelBonos.TabIndex = 16;
            this.labelBonos.Text = "<bonos_disponibles>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "(Selecciones Afiliado)";
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelBonos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.turno);
            this.Controls.Add(this.afiliado);
            this.Controls.Add(this.b_registrar);
            this.Controls.Add(this.c_bonos);
            this.Controls.Add(this.l_bonos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grilla_turnos);
            this.Controls.Add(this.l_profesional);
            this.Controls.Add(this.c_profesional);
            this.Controls.Add(this.l_especialidad);
            this.Controls.Add(this.c_especialidad);
            this.Controls.Add(this.l_titulo);
            this.Name = "Registrar";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grilla_turnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_titulo;
        private System.Windows.Forms.ComboBox c_especialidad;
        private System.Windows.Forms.Label l_especialidad;
        private System.Windows.Forms.ComboBox c_profesional;
        private System.Windows.Forms.Label l_profesional;
        private System.Windows.Forms.DataGridView grilla_turnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_bonos;
        private System.Windows.Forms.ComboBox c_bonos;
        private System.Windows.Forms.Button b_registrar;
        private System.Windows.Forms.Label afiliado;
        private System.Windows.Forms.Label turno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelBonos;
        private System.Windows.Forms.Label label3;
    }
}