namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonoAdministrador
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox_afil_numero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.textBox_afil_CantBonos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(204, 36);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(319, 37);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Compra de Bonos";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // textBox_afil_numero
            // 
            this.textBox_afil_numero.Location = new System.Drawing.Point(284, 134);
            this.textBox_afil_numero.Name = "textBox_afil_numero";
            this.textBox_afil_numero.Size = new System.Drawing.Size(148, 22);
            this.textBox_afil_numero.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Numero de Afiliado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Cantidad de Bonos";
            // 
            // button_cancelar
            // 
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Location = new System.Drawing.Point(460, 324);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(129, 38);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_confirmar
            // 
            this.button_confirmar.Location = new System.Drawing.Point(150, 324);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(123, 38);
            this.button_confirmar.TabIndex = 4;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // textBox_afil_CantBonos
            // 
            this.textBox_afil_CantBonos.Location = new System.Drawing.Point(284, 196);
            this.textBox_afil_CantBonos.Name = "textBox_afil_CantBonos";
            this.textBox_afil_CantBonos.Size = new System.Drawing.Size(148, 22);
            this.textBox_afil_CantBonos.TabIndex = 3;
            // 
            // CompraBonoAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 513);
            this.Controls.Add(this.textBox_afil_CantBonos);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_afil_numero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CompraBonoAdministrador";
            this.Text = "Comprar Bono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox_afil_numero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.TextBox textBox_afil_CantBonos;


    }
}