namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionAfiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelacionAfiliado));
            this.label1 = new System.Windows.Forms.Label();
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.cTipoCancelacion = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridCancelaciones = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCancelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(237, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancelación de Turno";
            // 
            // gridTurnos
            // 
            this.gridTurnos.AllowUserToAddRows = false;
            this.gridTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Location = new System.Drawing.Point(31, 110);
            this.gridTurnos.MultiSelect = false;
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.ReadOnly = true;
            this.gridTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTurnos.Size = new System.Drawing.Size(665, 130);
            this.gridTurnos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el turno que desea cancelar:";
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonConfirmar.Location = new System.Drawing.Point(630, 431);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 3;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = false;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSalir.Location = new System.Drawing.Point(630, 473);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione tipo de cancelación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Indique un motivo:";
            // 
            // textMotivo
            // 
            this.textMotivo.Location = new System.Drawing.Point(211, 433);
            this.textMotivo.Multiline = true;
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(355, 63);
            this.textMotivo.TabIndex = 7;
            // 
            // cTipoCancelacion
            // 
            this.cTipoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cTipoCancelacion.FormattingEnabled = true;
            this.cTipoCancelacion.Location = new System.Drawing.Point(211, 392);
            this.cTipoCancelacion.Name = "cTipoCancelacion";
            this.cTipoCancelacion.Size = new System.Drawing.Size(355, 21);
            this.cTipoCancelacion.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // gridCancelaciones
            // 
            this.gridCancelaciones.AllowUserToAddRows = false;
            this.gridCancelaciones.AllowUserToDeleteRows = false;
            this.gridCancelaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCancelaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCancelaciones.Location = new System.Drawing.Point(31, 271);
            this.gridCancelaciones.MultiSelect = false;
            this.gridCancelaciones.Name = "gridCancelaciones";
            this.gridCancelaciones.ReadOnly = true;
            this.gridCancelaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCancelaciones.Size = new System.Drawing.Size(665, 102);
            this.gridCancelaciones.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Futuros turnos cancelados por parte del Profesional:";
            // 
            // CancelacionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 511);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridCancelaciones);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cTipoCancelacion);
            this.Controls.Add(this.textMotivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridTurnos);
            this.Controls.Add(this.label1);
            this.Name = "CancelacionAfiliado";
            this.Text = "CancelacionAfiliado";
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCancelaciones)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView gridCancelaciones;
        private System.Windows.Forms.Label label5;
    }
}