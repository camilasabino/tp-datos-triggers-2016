namespace ClinicaFrba.Abm_Profesional
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
            this.DardeAlta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DardeAlta
            // 
            this.DardeAlta.Location = new System.Drawing.Point(291, 101);
            this.DardeAlta.Name = "DardeAlta";
            this.DardeAlta.Size = new System.Drawing.Size(296, 72);
            this.DardeAlta.TabIndex = 0;
            this.DardeAlta.Text = "DAR DE ALTA";
            this.DardeAlta.UseVisualStyleBackColor = true;
            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(296, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "DAR DE BAJA";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(291, 367);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 72);
            this.button3.TabIndex = 2;
            this.button3.Text = "MODIFICAR";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 527);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DardeAlta);
            this.Name = "Form1";
            this.Text = "Profesional";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DardeAlta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}