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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.l_titulo = new System.Windows.Forms.Label();
            this.c_opcion = new System.Windows.Forms.ComboBox();
            this.b_mostrar = new System.Windows.Forms.Button();
            this.c_plan = new System.Windows.Forms.ComboBox();
            this.l_plan = new System.Windows.Forms.Label();
            this.l_especialidad = new System.Windows.Forms.Label();
            this.c_especialidad = new System.Windows.Forms.ComboBox();
            this.buttonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 231);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
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
            this.c_opcion.FormattingEnabled = true;
            this.c_opcion.Items.AddRange(new object[] {
            "Especialidades con mas cancelaciones",
            "Profesionales mas consultados por Plan",
            "Profesionales con menos horas trabajadas",
            "Afiliados con mayor cantidad de bonos comprados",
            "Especialidades de médicos con mas bonos de consultas utilizados"});
            this.c_opcion.Location = new System.Drawing.Point(56, 69);
            this.c_opcion.Name = "c_opcion";
            this.c_opcion.Size = new System.Drawing.Size(734, 21);
            this.c_opcion.TabIndex = 2;
            // 
            // b_mostrar
            // 
            this.b_mostrar.Location = new System.Drawing.Point(363, 181);
            this.b_mostrar.Name = "b_mostrar";
            this.b_mostrar.Size = new System.Drawing.Size(117, 23);
            this.b_mostrar.TabIndex = 3;
            this.b_mostrar.Text = "Mostrar Listado";
            this.b_mostrar.UseVisualStyleBackColor = true;
            this.b_mostrar.Click += new System.EventHandler(this.b_mostrar_Click);
            // 
            // c_plan
            // 
            this.c_plan.FormattingEnabled = true;
            this.c_plan.Location = new System.Drawing.Point(56, 134);
            this.c_plan.Name = "c_plan";
            this.c_plan.Size = new System.Drawing.Size(153, 21);
            this.c_plan.TabIndex = 4;
            // 
            // l_plan
            // 
            this.l_plan.AutoSize = true;
            this.l_plan.Location = new System.Drawing.Point(53, 107);
            this.l_plan.Name = "l_plan";
            this.l_plan.Size = new System.Drawing.Size(66, 13);
            this.l_plan.TabIndex = 5;
            this.l_plan.Text = "Plan Médico";
            // 
            // l_especialidad
            // 
            this.l_especialidad.AutoSize = true;
            this.l_especialidad.Location = new System.Drawing.Point(506, 107);
            this.l_especialidad.Name = "l_especialidad";
            this.l_especialidad.Size = new System.Drawing.Size(105, 13);
            this.l_especialidad.TabIndex = 6;
            this.l_especialidad.Text = "Especialidad Médica";
            // 
            // c_especialidad
            // 
            this.c_especialidad.FormattingEnabled = true;
            this.c_especialidad.Location = new System.Drawing.Point(509, 134);
            this.c_especialidad.Name = "c_especialidad";
            this.c_especialidad.Size = new System.Drawing.Size(261, 21);
            this.c_especialidad.TabIndex = 7;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(389, 401);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 8;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 436);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.c_especialidad);
            this.Controls.Add(this.l_especialidad);
            this.Controls.Add(this.l_plan);
            this.Controls.Add(this.c_plan);
            this.Controls.Add(this.b_mostrar);
            this.Controls.Add(this.c_opcion);
            this.Controls.Add(this.l_titulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label l_titulo;
        private System.Windows.Forms.ComboBox c_opcion;
        private System.Windows.Forms.Button b_mostrar;
        private System.Windows.Forms.ComboBox c_plan;
        private System.Windows.Forms.Label l_plan;
        private System.Windows.Forms.Label l_especialidad;
        private System.Windows.Forms.ComboBox c_especialidad;
        private System.Windows.Forms.Button buttonSalir;
    }
}