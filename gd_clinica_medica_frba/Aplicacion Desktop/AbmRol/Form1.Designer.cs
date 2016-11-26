namespace ClinicaFrba.AbmRol
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
            this.Eliminar = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.Añadir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(253, 196);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(228, 76);
            this.Eliminar.TabIndex = 6;
            this.Eliminar.Text = "Eliminar Rol";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(253, 330);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(228, 76);
            this.Modificar.TabIndex = 9;
            this.Modificar.Text = "Modifar Rol";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Añadir
            // 
            this.Añadir.Location = new System.Drawing.Point(253, 62);
            this.Añadir.Name = "Añadir";
            this.Añadir.Size = new System.Drawing.Size(228, 76);
            this.Añadir.TabIndex = 4;
            this.Añadir.Text = "Añadir Rol";
            this.Añadir.UseVisualStyleBackColor = true;
            this.Añadir.Click += new System.EventHandler(this.Añadir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 510);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Añadir);
            this.Name = "Form1";
            this.Text = "Rol";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button Añadir;
    }
}