namespace ClinicaFrba.AbmRol
{
    partial class Alta
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
            this.nombreRol = new System.Windows.Forms.TextBox();
            this.Funcionalidades = new System.Windows.Forms.ListBox();
            this.agregarFuncionalidad = new System.Windows.Forms.Button();
            this.agregar = new System.Windows.Forms.TextBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionalidad ";
            // 
            // nombreRol
            // 
            this.nombreRol.Location = new System.Drawing.Point(241, 66);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(191, 31);
            this.nombreRol.TabIndex = 2;
            // 
            // Funcionalidades
            // 
            this.Funcionalidades.AccessibleName = "Funcionalidades";
            this.Funcionalidades.FormattingEnabled = true;
            this.Funcionalidades.ItemHeight = 25;
            this.Funcionalidades.Location = new System.Drawing.Point(241, 134);
            this.Funcionalidades.Name = "Funcionalidades";
            this.Funcionalidades.Size = new System.Drawing.Size(262, 154);
            this.Funcionalidades.TabIndex = 3;
            // 
            // agregarFuncionalidad
            // 
            this.agregarFuncionalidad.Location = new System.Drawing.Point(530, 185);
            this.agregarFuncionalidad.Name = "agregarFuncionalidad";
            this.agregarFuncionalidad.Size = new System.Drawing.Size(257, 44);
            this.agregarFuncionalidad.TabIndex = 4;
            this.agregarFuncionalidad.Text = "Agregar Funcionalidad";
            this.agregarFuncionalidad.UseVisualStyleBackColor = true;
            this.agregarFuncionalidad.Click += new System.EventHandler(this.agregarFuncionalidad_Click);
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(530, 134);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(257, 31);
            this.agregar.TabIndex = 6;
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(74, 351);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(200, 39);
            this.aceptar.TabIndex = 7;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(505, 351);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(200, 39);
            this.cancelar.TabIndex = 8;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 402);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.agregarFuncionalidad);
            this.Controls.Add(this.Funcionalidades);
            this.Controls.Add(this.nombreRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Alta";
            this.Text = "Alta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreRol;
        private System.Windows.Forms.ListBox Funcionalidades;
        private System.Windows.Forms.Button agregarFuncionalidad;
        private System.Windows.Forms.TextBox agregar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
    }
}