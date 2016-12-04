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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.gridFuncionalidades = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cRoles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cFuncionalidades = new System.Windows.Forms.ComboBox();
            this.buttonHabilitar = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Editar Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Editar Funcionalidades";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(115, 172);
            this.textNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(156, 20);
            this.textNombre.TabIndex = 3;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAgregar.Location = new System.Drawing.Point(380, 278);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(127, 22);
            this.buttonAgregar.TabIndex = 5;
            this.buttonAgregar.Text = "Agregar Funcionalidad";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonEliminar.Location = new System.Drawing.Point(380, 363);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(127, 21);
            this.buttonEliminar.TabIndex = 7;
            this.buttonEliminar.Text = "Eliminar Funcionalidad";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAceptar.Location = new System.Drawing.Point(289, 172);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(93, 24);
            this.buttonAceptar.TabIndex = 8;
            this.buttonAceptar.Text = "Cambiar";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCancelar.Location = new System.Drawing.Point(251, 432);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(93, 24);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Salir";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // gridFuncionalidades
            // 
            this.gridFuncionalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuncionalidades.Location = new System.Drawing.Point(36, 243);
            this.gridFuncionalidades.Name = "gridFuncionalidades";
            this.gridFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFuncionalidades.Size = new System.Drawing.Size(335, 169);
            this.gridFuncionalidades.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Modificación de un Rol del Sistema";
            // 
            // cRoles
            // 
            this.cRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRoles.FormattingEnabled = true;
            this.cRoles.Location = new System.Drawing.Point(115, 87);
            this.cRoles.Name = "cRoles";
            this.cRoles.Size = new System.Drawing.Size(156, 21);
            this.cRoles.Sorted = true;
            this.cRoles.TabIndex = 12;
            this.cRoles.SelectedValueChanged += new System.EventHandler(this.cRoles_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Escoja Rol";
            // 
            // cFuncionalidades
            // 
            this.cFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cFuncionalidades.FormattingEnabled = true;
            this.cFuncionalidades.Location = new System.Drawing.Point(380, 243);
            this.cFuncionalidades.Name = "cFuncionalidades";
            this.cFuncionalidades.Size = new System.Drawing.Size(219, 21);
            this.cFuncionalidades.TabIndex = 14;
            // 
            // buttonHabilitar
            // 
            this.buttonHabilitar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonHabilitar.Location = new System.Drawing.Point(307, 87);
            this.buttonHabilitar.Name = "buttonHabilitar";
            this.buttonHabilitar.Size = new System.Drawing.Size(75, 23);
            this.buttonHabilitar.TabIndex = 15;
            this.buttonHabilitar.Text = "Habilitar";
            this.buttonHabilitar.UseVisualStyleBackColor = false;
            this.buttonHabilitar.Click += new System.EventHandler(this.buttonHabilitar_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Crimson;
            this.labelStatus.Location = new System.Drawing.Point(33, 131);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(64, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "<rol_status>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(485, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "*Seleccione una funcionalidad de la lista";
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 467);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonHabilitar);
            this.Controls.Add(this.cFuncionalidades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cRoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridFuncionalidades);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editar";
            this.Text = "Editar";
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView gridFuncionalidades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cRoles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cFuncionalidades;
        private System.Windows.Forms.Button buttonHabilitar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
    }
}