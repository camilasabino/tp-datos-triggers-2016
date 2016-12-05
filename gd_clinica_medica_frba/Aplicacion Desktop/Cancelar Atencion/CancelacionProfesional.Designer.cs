namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionProfesional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelacionProfesional));
            this.label1 = new System.Windows.Forms.Label();
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.cTipoCancelacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkModoCancelacion = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.gridFechas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.labelAgenda = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFechas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancelación de Turno Profesional";
            // 
            // gridTurnos
            // 
            this.gridTurnos.AllowUserToAddRows = false;
            this.gridTurnos.AllowUserToDeleteRows = false;
            this.gridTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Location = new System.Drawing.Point(409, 224);
            this.gridTurnos.MultiSelect = false;
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.ReadOnly = true;
            this.gridTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTurnos.Size = new System.Drawing.Size(275, 165);
            this.gridTurnos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione fecha que desea cancelar:";
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonConfirmar.Location = new System.Drawing.Point(623, 438);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(82, 23);
            this.buttonConfirmar.TabIndex = 3;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = false;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSalir.Location = new System.Drawing.Point(623, 480);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(82, 23);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione tipo de cancelación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Indique un motivo:";
            // 
            // textMotivo
            // 
            this.textMotivo.Location = new System.Drawing.Point(211, 440);
            this.textMotivo.Multiline = true;
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(355, 63);
            this.textMotivo.TabIndex = 7;
            // 
            // cTipoCancelacion
            // 
            this.cTipoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cTipoCancelacion.FormattingEnabled = true;
            this.cTipoCancelacion.Location = new System.Drawing.Point(211, 407);
            this.cTipoCancelacion.Name = "cTipoCancelacion";
            this.cTipoCancelacion.Size = new System.Drawing.Size(355, 21);
            this.cTipoCancelacion.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Indique período que desea cancelar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hasta";
            // 
            // checkModoCancelacion
            // 
            this.checkModoCancelacion.AutoSize = true;
            this.checkModoCancelacion.Location = new System.Drawing.Point(52, 170);
            this.checkModoCancelacion.Name = "checkModoCancelacion";
            this.checkModoCancelacion.Size = new System.Drawing.Size(181, 17);
            this.checkModoCancelacion.TabIndex = 16;
            this.checkModoCancelacion.Text = "Deseo cancelar un día particular";
            this.checkModoCancelacion.UseVisualStyleBackColor = true;
            this.checkModoCancelacion.CheckedChanged += new System.EventHandler(this.checkModoCancelacion_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // dateDesde
            // 
            this.dateDesde.Location = new System.Drawing.Point(498, 91);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(200, 20);
            this.dateDesde.TabIndex = 18;
            // 
            // dateHasta
            // 
            this.dateHasta.Location = new System.Drawing.Point(498, 139);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(200, 20);
            this.dateHasta.TabIndex = 19;
            // 
            // gridFechas
            // 
            this.gridFechas.AllowUserToAddRows = false;
            this.gridFechas.AllowUserToDeleteRows = false;
            this.gridFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFechas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFechas.Location = new System.Drawing.Point(49, 224);
            this.gridFechas.MultiSelect = false;
            this.gridFechas.Name = "gridFechas";
            this.gridFechas.ReadOnly = true;
            this.gridFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFechas.Size = new System.Drawing.Size(275, 165);
            this.gridFechas.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(406, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Fechas con turnos solicitados:";
            // 
            // labelAgenda
            // 
            this.labelAgenda.AutoSize = true;
            this.labelAgenda.ForeColor = System.Drawing.Color.Crimson;
            this.labelAgenda.Location = new System.Drawing.Point(339, 30);
            this.labelAgenda.Name = "labelAgenda";
            this.labelAgenda.Size = new System.Drawing.Size(89, 13);
            this.labelAgenda.TabIndex = 24;
            this.labelAgenda.Text = "<agenda_status>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(350, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "* Las cancelaciones se realizan con, por lo menos, un día de antelación.";
            // 
            // CancelacionProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 515);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelAgenda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gridFechas);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkModoCancelacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cTipoCancelacion);
            this.Controls.Add(this.textMotivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridTurnos);
            this.Controls.Add(this.label1);
            this.Name = "CancelacionProfesional";
            this.Text = "CancelacionAfiliado";
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFechas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMotivo;
        private System.Windows.Forms.ComboBox cTipoCancelacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkModoCancelacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.DataGridView gridFechas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelAgenda;
        private System.Windows.Forms.Label label9;
    }
}