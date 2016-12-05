namespace ClinicaFrba.Registro_Resultado
{
    partial class Registrar_resul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrar_resul));
            this.label1 = new System.Windows.Forms.Label();
            this.grilla_consultas = new System.Windows.Forms.DataGridView();
            this.t_afiliado = new System.Windows.Forms.TextBox();
            this.l_afiliado = new System.Windows.Forms.Label();
            this.b_filtrarConsultas = new System.Windows.Forms.Button();
            this.t_sintomas = new System.Windows.Forms.TextBox();
            this.l_sintomas = new System.Windows.Forms.Label();
            this.l_diagnostico = new System.Windows.Forms.Label();
            this.t_diagnostico = new System.Windows.Forms.TextBox();
            this.b_registrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cEspecialidad = new System.Windows.Forms.ComboBox();
            this.labelConsultas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_consultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccionar Consulta Pendiente del Afiliado";
            // 
            // grilla_consultas
            // 
            this.grilla_consultas.AllowUserToAddRows = false;
            this.grilla_consultas.AllowUserToDeleteRows = false;
            this.grilla_consultas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grilla_consultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_consultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_consultas.Location = new System.Drawing.Point(28, 230);
            this.grilla_consultas.MultiSelect = false;
            this.grilla_consultas.Name = "grilla_consultas";
            this.grilla_consultas.ReadOnly = true;
            this.grilla_consultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grilla_consultas.Size = new System.Drawing.Size(449, 171);
            this.grilla_consultas.TabIndex = 8;
            // 
            // t_afiliado
            // 
            this.t_afiliado.Location = new System.Drawing.Point(160, 131);
            this.t_afiliado.Name = "t_afiliado";
            this.t_afiliado.Size = new System.Drawing.Size(189, 20);
            this.t_afiliado.TabIndex = 11;
            // 
            // l_afiliado
            // 
            this.l_afiliado.AutoSize = true;
            this.l_afiliado.Location = new System.Drawing.Point(30, 133);
            this.l_afiliado.Name = "l_afiliado";
            this.l_afiliado.Size = new System.Drawing.Size(96, 13);
            this.l_afiliado.TabIndex = 13;
            this.l_afiliado.Text = "Número de Afiliado";
            // 
            // b_filtrarConsultas
            // 
            this.b_filtrarConsultas.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_filtrarConsultas.Location = new System.Drawing.Point(366, 133);
            this.b_filtrarConsultas.Name = "b_filtrarConsultas";
            this.b_filtrarConsultas.Size = new System.Drawing.Size(99, 23);
            this.b_filtrarConsultas.TabIndex = 16;
            this.b_filtrarConsultas.Text = "Buscar Consultas";
            this.b_filtrarConsultas.UseVisualStyleBackColor = false;
            this.b_filtrarConsultas.Click += new System.EventHandler(this.b_filtrar_Click);
            // 
            // t_sintomas
            // 
            this.t_sintomas.Location = new System.Drawing.Point(505, 201);
            this.t_sintomas.Multiline = true;
            this.t_sintomas.Name = "t_sintomas";
            this.t_sintomas.Size = new System.Drawing.Size(269, 79);
            this.t_sintomas.TabIndex = 17;
            // 
            // l_sintomas
            // 
            this.l_sintomas.AutoSize = true;
            this.l_sintomas.Location = new System.Drawing.Point(502, 185);
            this.l_sintomas.Name = "l_sintomas";
            this.l_sintomas.Size = new System.Drawing.Size(52, 13);
            this.l_sintomas.TabIndex = 18;
            this.l_sintomas.Text = "Síntomas";
            // 
            // l_diagnostico
            // 
            this.l_diagnostico.AutoSize = true;
            this.l_diagnostico.Location = new System.Drawing.Point(502, 305);
            this.l_diagnostico.Name = "l_diagnostico";
            this.l_diagnostico.Size = new System.Drawing.Size(63, 13);
            this.l_diagnostico.TabIndex = 20;
            this.l_diagnostico.Text = "Descripción";
            // 
            // t_diagnostico
            // 
            this.t_diagnostico.Location = new System.Drawing.Point(505, 321);
            this.t_diagnostico.Multiline = true;
            this.t_diagnostico.Name = "t_diagnostico";
            this.t_diagnostico.Size = new System.Drawing.Size(269, 80);
            this.t_diagnostico.TabIndex = 19;
            // 
            // b_registrar
            // 
            this.b_registrar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_registrar.Location = new System.Drawing.Point(252, 426);
            this.b_registrar.Name = "b_registrar";
            this.b_registrar.Size = new System.Drawing.Size(110, 27);
            this.b_registrar.TabIndex = 21;
            this.b_registrar.Text = "Registrar Resultado";
            this.b_registrar.UseVisualStyleBackColor = false;
            this.b_registrar.Click += new System.EventHandler(this.b_registrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "Registro del Resultado de Atención Médica";
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSalir.Location = new System.Drawing.Point(437, 426);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(81, 27);
            this.buttonSalir.TabIndex = 26;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(614, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Datos del Diagnóstico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Indique Especialidad:";
            // 
            // cEspecialidad
            // 
            this.cEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cEspecialidad.FormattingEnabled = true;
            this.cEspecialidad.Location = new System.Drawing.Point(160, 83);
            this.cEspecialidad.Name = "cEspecialidad";
            this.cEspecialidad.Size = new System.Drawing.Size(266, 21);
            this.cEspecialidad.TabIndex = 30;
            // 
            // labelConsultas
            // 
            this.labelConsultas.AutoSize = true;
            this.labelConsultas.ForeColor = System.Drawing.Color.Crimson;
            this.labelConsultas.Location = new System.Drawing.Point(33, 172);
            this.labelConsultas.Name = "labelConsultas";
            this.labelConsultas.Size = new System.Drawing.Size(98, 13);
            this.labelConsultas.TabIndex = 31;
            this.labelConsultas.Text = "<consultas_status>";
            // 
            // Registrar_resul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 470);
            this.Controls.Add(this.labelConsultas);
            this.Controls.Add(this.cEspecialidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_registrar);
            this.Controls.Add(this.l_diagnostico);
            this.Controls.Add(this.t_diagnostico);
            this.Controls.Add(this.l_sintomas);
            this.Controls.Add(this.t_sintomas);
            this.Controls.Add(this.b_filtrarConsultas);
            this.Controls.Add(this.l_afiliado);
            this.Controls.Add(this.t_afiliado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grilla_consultas);
            this.Name = "Registrar_resul";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grilla_consultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grilla_consultas;
        private System.Windows.Forms.TextBox t_afiliado;
        private System.Windows.Forms.Label l_afiliado;
        private System.Windows.Forms.Button b_filtrarConsultas;
        private System.Windows.Forms.TextBox t_sintomas;
        private System.Windows.Forms.Label l_sintomas;
        private System.Windows.Forms.Label l_diagnostico;
        private System.Windows.Forms.TextBox t_diagnostico;
        private System.Windows.Forms.Button b_registrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cEspecialidad;
        private System.Windows.Forms.Label labelConsultas;
    }
}