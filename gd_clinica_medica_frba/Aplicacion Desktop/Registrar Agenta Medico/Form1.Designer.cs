namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class RegistrarAgenda
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
            this.cEspecialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridDiasAtencion = new System.Windows.Forms.DataGridView();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.Atenderé = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Día = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiasAtencion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Agenda Profesional";
            // 
            // cEspecialidad
            // 
            this.cEspecialidad.FormattingEnabled = true;
            this.cEspecialidad.Location = new System.Drawing.Point(161, 74);
            this.cEspecialidad.Name = "cEspecialidad";
            this.cEspecialidad.Size = new System.Drawing.Size(233, 21);
            this.cEspecialidad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione Especialidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Indique día de atención:";
            // 
            // gridDiasAtencion
            // 
            this.gridDiasAtencion.AllowUserToAddRows = false;
            this.gridDiasAtencion.AllowUserToDeleteRows = false;
            this.gridDiasAtencion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDiasAtencion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDiasAtencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDiasAtencion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Atenderé,
            this.Día,
            this.HoraInicio,
            this.HoraFin});
            this.gridDiasAtencion.Location = new System.Drawing.Point(35, 146);
            this.gridDiasAtencion.Name = "gridDiasAtencion";
            this.gridDiasAtencion.Size = new System.Drawing.Size(444, 153);
            this.gridDiasAtencion.TabIndex = 9;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(404, 359);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 10;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(404, 320);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 11;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // Atenderé
            // 
            this.Atenderé.HeaderText = "Atenderé";
            this.Atenderé.Name = "Atenderé";
            // 
            // Día
            // 
            this.Día.HeaderText = "Día";
            this.Día.Name = "Día";
            this.Día.ReadOnly = true;
            // 
            // HoraInicio
            // 
            this.HoraInicio.HeaderText = "Hora Inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // HoraFin
            // 
            this.HoraFin.HeaderText = "Hora Fin";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoraFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dateDesde
            // 
            this.dateDesde.Location = new System.Drawing.Point(136, 319);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(200, 20);
            this.dateDesde.TabIndex = 13;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
            // 
            // dateHasta
            // 
            this.dateHasta.Location = new System.Drawing.Point(136, 358);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(200, 20);
            this.dateHasta.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Desde la fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hasta la fecha";
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 397);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.gridDiasAtencion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cEspecialidad);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarAgenda";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridDiasAtencion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridDiasAtencion;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Atenderé;
        private System.Windows.Forms.DataGridViewTextBoxColumn Día;
        private System.Windows.Forms.DataGridViewComboBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn HoraFin;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}