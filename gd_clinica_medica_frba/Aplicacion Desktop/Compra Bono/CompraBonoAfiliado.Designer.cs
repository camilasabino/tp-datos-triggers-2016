namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonoAfiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompraBonoAfiliado));
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_afil_CantBonos = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonMonto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMonto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_cancelar
            // 
            this.button_cancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Location = new System.Drawing.Point(280, 218);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(86, 25);
            this.button_cancelar.TabIndex = 4;
            this.button_cancelar.Text = "Salir";
            this.button_cancelar.UseVisualStyleBackColor = false;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_confirmar
            // 
            this.button_confirmar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button_confirmar.Location = new System.Drawing.Point(151, 218);
            this.button_confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(87, 25);
            this.button_confirmar.TabIndex = 3;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = false;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cantidad de Bonos:";
            // 
            // textBox_afil_CantBonos
            // 
            this.textBox_afil_CantBonos.Location = new System.Drawing.Point(242, 116);
            this.textBox_afil_CantBonos.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_afil_CantBonos.Name = "textBox_afil_CantBonos";
            this.textBox_afil_CantBonos.Size = new System.Drawing.Size(113, 20);
            this.textBox_afil_CantBonos.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // buttonMonto
            // 
            this.buttonMonto.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonMonto.Location = new System.Drawing.Point(375, 114);
            this.buttonMonto.Name = "buttonMonto";
            this.buttonMonto.Size = new System.Drawing.Size(92, 23);
            this.buttonMonto.TabIndex = 32;
            this.buttonMonto.Text = "Consultar Monto";
            this.buttonMonto.UseVisualStyleBackColor = false;
            this.buttonMonto.Click += new System.EventHandler(this.buttonMonto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Compra de Bonos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Monto a Pagar:";
            // 
            // labelMonto
            // 
            this.labelMonto.AutoSize = true;
            this.labelMonto.ForeColor = System.Drawing.Color.Crimson;
            this.labelMonto.Location = new System.Drawing.Point(239, 161);
            this.labelMonto.Name = "labelMonto";
            this.labelMonto.Size = new System.Drawing.Size(19, 13);
            this.labelMonto.TabIndex = 35;
            this.labelMonto.Text = "$ -";
            // 
            // CompraBonoAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 273);
            this.Controls.Add(this.labelMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMonto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_afil_CantBonos);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CompraBonoAfiliado";
            this.Text = "CompraBonoAfiliado";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_afil_CantBonos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMonto;

    }
}