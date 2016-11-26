namespace ClinicaFrba.AbmRol
{
    partial class Editar
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreRol = new System.Windows.Forms.TextBox();
            this.agregar = new System.Windows.Forms.Button();
            this.agregarFuncionalidad = new System.Windows.Forms.TextBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(260, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 179);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades";
            // 
            // nombreRol
            // 
            this.nombreRol.Location = new System.Drawing.Point(260, 49);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(254, 31);
            this.nombreRol.TabIndex = 3;
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(531, 207);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(254, 43);
            this.agregar.TabIndex = 5;
            this.agregar.Text = "Agregar Funcionalidad";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // agregarFuncionalidad
            // 
            this.agregarFuncionalidad.Location = new System.Drawing.Point(531, 136);
            this.agregarFuncionalidad.Name = "agregarFuncionalidad";
            this.agregarFuncionalidad.Size = new System.Drawing.Size(254, 31);
            this.agregarFuncionalidad.TabIndex = 6;
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(531, 274);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(254, 41);
            this.eliminar.TabIndex = 7;
            this.eliminar.Text = "Eliminar Funcionalidad";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(65, 460);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(223, 46);
            this.aceptar.TabIndex = 8;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(489, 460);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(223, 46);
            this.cancelar.TabIndex = 9;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 553);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.agregarFuncionalidad);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.nombreRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Editar";
            this.Text = "Editar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreRol;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.TextBox agregarFuncionalidad;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
    }
}