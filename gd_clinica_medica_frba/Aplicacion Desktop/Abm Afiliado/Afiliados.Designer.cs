namespace ClinicaFrba.Abm_Afiliado
{
    partial class Afiliado
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
            this.buttonBaja = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "ABM de Afiliado";
            // 
            // buttonBaja
            // 
            this.buttonBaja.Location = new System.Drawing.Point(125, 166);
            this.buttonBaja.Name = "buttonBaja";
            this.buttonBaja.Size = new System.Drawing.Size(115, 36);
            this.buttonBaja.TabIndex = 7;
            this.buttonBaja.Text = "Habilitar/ Inhabilitar";
            this.buttonBaja.UseVisualStyleBackColor = true;
            this.buttonBaja.Click += new System.EventHandler(this.buttonBaja_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAlta
            // 
            this.buttonAlta.Location = new System.Drawing.Point(125, 104);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(117, 36);
            this.buttonAlta.TabIndex = 9;
            this.buttonAlta.Text = "Dar de Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSalir.Location = new System.Drawing.Point(140, 305);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 10;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click_1);
            // 
            // Afiliado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(390, 361);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonBaja);
            this.Controls.Add(this.label1);
            this.Name = "Afiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afiliados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBaja;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Button buttonSalir;

    }
}