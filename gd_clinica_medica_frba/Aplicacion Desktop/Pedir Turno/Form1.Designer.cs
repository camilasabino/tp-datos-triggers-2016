namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitud de Turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione Profesional:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccione Especialidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Escoja fecha de atención:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Escoja horario de atención:";
            // 
            // cEspecialidad
            // 
            this.cEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cEspecialidad.FormattingEnabled = true;
            this.cEspecialidad.Location = new System.Drawing.Point(263, 75);
            this.cEspecialidad.Name = "cEspecialidad";
            this.cEspecialidad.Size = new System.Drawing.Size(247, 21);
            this.cEspecialidad.TabIndex = 5;
            this.cEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cEspecialidad_SelectedIndexChanged);
            // 
            // cProfesional
            // 
            this.cProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cProfesional.FormattingEnabled = true;
            this.cProfesional.Location = new System.Drawing.Point(263, 119);
            this.cProfesional.Name = "cProfesional";
            this.cProfesional.Size = new System.Drawing.Size(247, 21);
            this.cProfesional.TabIndex = 6;
            this.cProfesional.SelectedIndexChanged += new System.EventHandler(this.cProfesional_SelectedIndexChanged);
            // 
            // gridFechas
            // 
            this.gridFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFechas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFechas.Location = new System.Drawing.Point(55, 208);
            this.gridFechas.MultiSelect = false;
            this.gridFechas.Name = "gridFechas";
            this.gridFechas.ReadOnly = true;
            this.gridFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFechas.ShowEditingIcon = false;
            this.gridFechas.Size = new System.Drawing.Size(237, 191);
            this.gridFechas.TabIndex = 8;
            this.gridFechas.SelectionChanged += new System.EventHandler(this.gridFechas_SelectionChanged);
            // 
            // gridHorarios
            // 
            this.gridHorarios.AllowUserToAddRows = false;
            this.gridHorarios.AllowUserToDeleteRows = false;
            this.gridHorarios.AllowUserToOrderColumns = true;
            this.gridHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHorarios.Location = new System.Drawing.Point(337, 208);
            this.gridHorarios.Name = "gridHorarios";
            this.gridHorarios.ReadOnly = true;
            this.gridHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHorarios.ShowEditingIcon = false;
            this.gridHorarios.Size = new System.Drawing.Size(158, 191);
            this.gridHorarios.TabIndex = 9;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(159, 446);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 10;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(316, 446);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 11;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "* Se muestran las fechas disponibles de los próximos 6 (seis) meses.";
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 483);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.gridHorarios);
            this.Controls.Add(this.gridFechas);
            this.Controls.Add(this.cProfesional);
            this.Controls.Add(this.cEspecialidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PedirTurno";
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
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Label label6;
    }
}