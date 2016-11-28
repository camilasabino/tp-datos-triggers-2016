namespace ClinicaFrba.Listados
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
            this.gridListado = new System.Windows.Forms.DataGridView();
            this.l_titulo = new System.Windows.Forms.Label();
            this.c_opcion = new System.Windows.Forms.ComboBox();
            this.b_mostrar = new System.Windows.Forms.Button();
            this.c_plan = new System.Windows.Forms.ComboBox();
            this.l_plan = new System.Windows.Forms.Label();
            this.l_especialidad = new System.Windows.Forms.Label();
            this.c_especialidad = new System.Windows.Forms.ComboBox();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cSemestre = new System.Windows.Forms.ComboBox();
            this.textAnio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListado
            // 
            this.gridListado.AllowUserToDeleteRows = false;
            this.gridListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListado.Location = new System.Drawing.Point(53, 282);
            this.gridListado.Name = "gridListado";
            this.gridListado.ReadOnly = true;
            this.gridListado.Size = new System.Drawing.Size(734, 150);
            this.gridListado.TabIndex = 0;
            this.gridListado.Visible = false;
            // 
            // l_titulo
            // 
            this.l_titulo.AutoSize = true;
            this.l_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_titulo.Location = new System.Drawing.Point(299, 18);
            this.l_titulo.Name = "l_titulo";
            this.l_titulo.Size = new System.Drawing.Size(181, 24);
            this.l_titulo.TabIndex = 1;
            this.l_titulo.Text = "Listados Estadísticos";
            // 
            // c_opcion
            // 
            this.c_opcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_opcion.FormattingEnabled = true;
            this.c_opcion.Items.AddRange(new object[] {
            "Especialidades con más cancelaciones",
            "Profesionales más consultados por Plan",
            "Profesionales con menos horas trabajadas",
            "Afiliados con mayor cantidad de bonos comprados",
            "Especialidades de médicos con más bonos de consultas utilizados"});
            this.c_opcion.Location = new System.Drawing.Point(188, 80);
            this.c_opcion.Name = "c_opcion";
            this.c_opcion.Size = new System.Drawing.Size(426, 21);
            this.c_opcion.TabIndex = 2;
            // 
            // b_mostrar
            // 
            this.b_mostrar.Location = new System.Drawing.Point(354, 243);
            this.b_mostrar.Name = "b_mostrar";
            this.b_mostrar.Size = new System.Drawing.Size(117, 23);
            this.b_mostrar.TabIndex = 3;
            this.b_mostrar.Text = "Mostrar Listado";
            this.b_mostrar.UseVisualStyleBackColor = true;
            this.b_mostrar.Click += new System.EventHandler(this.b_mostrar_Click);
            // 
            // c_plan
            // 
            this.c_plan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_plan.FormattingEnabled = true;
            this.c_plan.Location = new System.Drawing.Point(217, 193);
            this.c_plan.Name = "c_plan";
            this.c_plan.Size = new System.Drawing.Size(153, 21);
            this.c_plan.TabIndex = 4;
            // 
            // l_plan
            // 
            this.l_plan.AutoSize = true;
            this.l_plan.Location = new System.Drawing.Point(145, 196);
            this.l_plan.Name = "l_plan";
            this.l_plan.Size = new System.Drawing.Size(66, 13);
            this.l_plan.TabIndex = 5;
            this.l_plan.Text = "Plan Médico";
            // 
            // l_especialidad
            // 
            this.l_especialidad.AutoSize = true;
            this.l_especialidad.Location = new System.Drawing.Point(415, 196);
            this.l_especialidad.Name = "l_especialidad";
            this.l_especialidad.Size = new System.Drawing.Size(105, 13);
            this.l_especialidad.TabIndex = 6;
            this.l_especialidad.Text = "Especialidad Médica";
            // 
            // c_especialidad
            // 
            this.c_especialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_especialidad.FormattingEnabled = true;
            this.c_especialidad.Location = new System.Drawing.Point(526, 193);
            this.c_especialidad.Name = "c_especialidad";
            this.c_especialidad.Size = new System.Drawing.Size(261, 21);
            this.c_especialidad.TabIndex = 7;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(384, 450);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 8;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione un Listado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Otros filtros:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtros temporales:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Semestre";
            // 
            // cSemestre
            // 
            this.cSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cSemestre.FormattingEnabled = true;
            this.cSemestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cSemestre.Location = new System.Drawing.Point(473, 137);
            this.cSemestre.Name = "cSemestre";
            this.cSemestre.Size = new System.Drawing.Size(101, 21);
            this.cSemestre.TabIndex = 15;
            // 
            // textAnio
            // 
            this.textAnio.Location = new System.Drawing.Point(218, 137);
            this.textAnio.Name = "textAnio";
            this.textAnio.Size = new System.Drawing.Size(100, 20);
            this.textAnio.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 494);
            this.Controls.Add(this.textAnio);
            this.Controls.Add(this.cSemestre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.c_especialidad);
            this.Controls.Add(this.l_especialidad);
            this.Controls.Add(this.l_plan);
            this.Controls.Add(this.c_plan);
            this.Controls.Add(this.b_mostrar);
            this.Controls.Add(this.c_opcion);
            this.Controls.Add(this.l_titulo);
            this.Controls.Add(this.gridListado);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridListado;
        private System.Windows.Forms.Label l_titulo;
        private System.Windows.Forms.ComboBox c_opcion;
        private System.Windows.Forms.Button b_mostrar;
        private System.Windows.Forms.ComboBox c_plan;
        private System.Windows.Forms.Label l_plan;
        private System.Windows.Forms.Label l_especialidad;
        private System.Windows.Forms.ComboBox c_especialidad;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cSemestre;
        private System.Windows.Forms.TextBox textAnio;
    }
}