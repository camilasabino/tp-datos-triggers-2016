namespace ClinicaFrba.Pedir_Turno
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cEspecialidad = new System.Windows.Forms.ComboBox();
            this.cProfesional = new System.Windows.Forms.ComboBox();
            this.gridFechas = new System.Windows.Forms.DataGridView();
            this.gridHorarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido de Turnos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione Profesional:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccione Especialidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Escoja fecha de atención:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Escoja horario de atención:";
            // 
            // cEspecialidad
            // 
            this.cEspecialidad.FormattingEnabled = true;
            this.cEspecialidad.Location = new System.Drawing.Point(217, 70);
            this.cEspecialidad.Name = "cEspecialidad";
            this.cEspecialidad.Size = new System.Drawing.Size(247, 21);
            this.cEspecialidad.TabIndex = 5;
//            this.cEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cEspecialidad_SelectedIndexChanged);
            // 
            // cProfesional
            // 
            this.cProfesional.FormattingEnabled = true;
            this.cProfesional.Location = new System.Drawing.Point(217, 124);
            this.cProfesional.Name = "cProfesional";
            this.cProfesional.Size = new System.Drawing.Size(247, 21);
            this.cProfesional.TabIndex = 6;
     //       this.cProfesional.SelectedIndexChanged += new System.EventHandler(this.cProfesional_SelectedIndexChanged);
            // 
            // gridFechas
            // 
            this.gridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFechas.Location = new System.Drawing.Point(33, 208);
            this.gridFechas.Name = "gridFechas";
            this.gridFechas.Size = new System.Drawing.Size(193, 197);
            this.gridFechas.TabIndex = 8;
            // 
            // gridHorarios
            // 
            this.gridHorarios.AllowUserToOrderColumns = true;
            this.gridHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHorarios.Location = new System.Drawing.Point(258, 208);
            this.gridHorarios.Name = "gridHorarios";
            this.gridHorarios.Size = new System.Drawing.Size(194, 197);
            this.gridHorarios.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 488);
            this.Controls.Add(this.gridHorarios);
            this.Controls.Add(this.gridFechas);
            this.Controls.Add(this.cProfesional);
            this.Controls.Add(this.cEspecialidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHorarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cEspecialidad;
        private System.Windows.Forms.ComboBox cProfesional;
        private System.Windows.Forms.DataGridView gridFechas;
        private System.Windows.Forms.DataGridView gridHorarios;
    }
}