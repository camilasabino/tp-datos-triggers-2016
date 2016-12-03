namespace ClinicaFrba.Abm_Afiliado
{
    partial class HabilitacionDeshabilitacion
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
            this.textBox_afil_numero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_habilitar = new System.Windows.Forms.Button();
            this.button_deshabilitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_afil_numero
            // 
            this.textBox_afil_numero.Location = new System.Drawing.Point(199, 116);
            this.textBox_afil_numero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_afil_numero.Name = "textBox_afil_numero";
            this.textBox_afil_numero.Size = new System.Drawing.Size(149, 20);
            this.textBox_afil_numero.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Número de Afiliado";
            // 
            // button_cancelar
            // 
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Location = new System.Drawing.Point(348, 208);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(92, 31);
            this.button_cancelar.TabIndex = 23;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_habilitar
            // 
            this.button_habilitar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_habilitar.Location = new System.Drawing.Point(116, 208);
            this.button_habilitar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_habilitar.Name = "button_habilitar";
            this.button_habilitar.Size = new System.Drawing.Size(92, 31);
            this.button_habilitar.TabIndex = 22;
            this.button_habilitar.Text = "Habilitar";
            this.button_habilitar.UseVisualStyleBackColor = true;
            this.button_habilitar.Click += new System.EventHandler(this.button_habilitar_Click);
            // 
            // button_deshabilitar
            // 
            this.button_deshabilitar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_deshabilitar.Location = new System.Drawing.Point(235, 208);
            this.button_deshabilitar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_deshabilitar.Name = "button_deshabilitar";
            this.button_deshabilitar.Size = new System.Drawing.Size(92, 31);
            this.button_deshabilitar.TabIndex = 24;
            this.button_deshabilitar.Text = "Deshabilitar";
            this.button_deshabilitar.UseVisualStyleBackColor = true;
            this.button_deshabilitar.Click += new System.EventHandler(this.button_deshabilitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Habilitación/Deshabilitación de un Afiliado";
            // 
            // HabilitacionDeshabilitacion
            // 
            this.AcceptButton = this.button_habilitar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancelar;
            this.ClientSize = new System.Drawing.Size(586, 275);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_deshabilitar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_habilitar);
            this.Controls.Add(this.textBox_afil_numero);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HabilitacionDeshabilitacion";
            this.Text = "HabilitacionDeshabilitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_afil_numero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_habilitar;
        private System.Windows.Forms.Button button_deshabilitar;
        private System.Windows.Forms.Label label1;
    }
}