namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class RegistrarAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarAgenda));
            this.label1 = new System.Windows.Forms.Label();
            this.cEspecialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkLun = new System.Windows.Forms.CheckBox();
            this.checkMar = new System.Windows.Forms.CheckBox();
            this.checkMier = new System.Windows.Forms.CheckBox();
            this.checkJue = new System.Windows.Forms.CheckBox();
            this.checkVier = new System.Windows.Forms.CheckBox();
            this.checkSab = new System.Windows.Forms.CheckBox();
            this.hDesdeLun = new System.Windows.Forms.ComboBox();
            this.hHastaLun = new System.Windows.Forms.ComboBox();
            this.hDesdeMar = new System.Windows.Forms.ComboBox();
            this.hHastaMar = new System.Windows.Forms.ComboBox();
            this.hDesdeMier = new System.Windows.Forms.ComboBox();
            this.hHastaMier = new System.Windows.Forms.ComboBox();
            this.hDesdeJue = new System.Windows.Forms.ComboBox();
            this.hHastaJue = new System.Windows.Forms.ComboBox();
            this.hDesdeVier = new System.Windows.Forms.ComboBox();
            this.hHastaVier = new System.Windows.Forms.ComboBox();
            this.hDesdeSab = new System.Windows.Forms.ComboBox();
            this.hHastaSab = new System.Windows.Forms.ComboBox();
            this.errorPanel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Agenda Profesional";
            // 
            // cEspecialidad
            // 
            this.cEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cEspecialidad.FormattingEnabled = true;
            this.cEspecialidad.Location = new System.Drawing.Point(161, 65);
            this.cEspecialidad.Name = "cEspecialidad";
            this.cEspecialidad.Size = new System.Drawing.Size(233, 21);
            this.cEspecialidad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione Especialidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Indique día de atención:";
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(184, 426);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 10;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(328, 426);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 11;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // dateDesde
            // 
            this.dateDesde.Location = new System.Drawing.Point(119, 383);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(163, 20);
            this.dateDesde.TabIndex = 13;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
            // 
            // dateHasta
            // 
            this.dateHasta.Location = new System.Drawing.Point(393, 383);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(163, 20);
            this.dateHasta.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Desde la fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hasta la fecha";
            // 
            // checkLun
            // 
            this.checkLun.AutoSize = true;
            this.checkLun.Location = new System.Drawing.Point(42, 151);
            this.checkLun.Name = "checkLun";
            this.checkLun.Size = new System.Drawing.Size(55, 17);
            this.checkLun.TabIndex = 17;
            this.checkLun.Text = "Lunes";
            this.checkLun.UseVisualStyleBackColor = true;
            this.checkLun.CheckedChanged += new System.EventHandler(this.checkLun_CheckedChanged);
            // 
            // checkMar
            // 
            this.checkMar.AutoSize = true;
            this.checkMar.Location = new System.Drawing.Point(39, 190);
            this.checkMar.Name = "checkMar";
            this.checkMar.Size = new System.Drawing.Size(58, 17);
            this.checkMar.TabIndex = 18;
            this.checkMar.Text = "Martes";
            this.checkMar.UseVisualStyleBackColor = true;
            this.checkMar.CheckedChanged += new System.EventHandler(this.checkMar_CheckedChanged);
            // 
            // checkMier
            // 
            this.checkMier.AutoSize = true;
            this.checkMier.Location = new System.Drawing.Point(39, 228);
            this.checkMier.Name = "checkMier";
            this.checkMier.Size = new System.Drawing.Size(71, 17);
            this.checkMier.TabIndex = 19;
            this.checkMier.Text = "Miércoles";
            this.checkMier.UseVisualStyleBackColor = true;
            this.checkMier.CheckedChanged += new System.EventHandler(this.checkMier_CheckedChanged);
            // 
            // checkJue
            // 
            this.checkJue.AutoSize = true;
            this.checkJue.Location = new System.Drawing.Point(40, 266);
            this.checkJue.Name = "checkJue";
            this.checkJue.Size = new System.Drawing.Size(60, 17);
            this.checkJue.TabIndex = 20;
            this.checkJue.Text = "Jueves";
            this.checkJue.UseVisualStyleBackColor = true;
            this.checkJue.CheckedChanged += new System.EventHandler(this.checkJue_CheckedChanged);
            // 
            // checkVier
            // 
            this.checkVier.AutoSize = true;
            this.checkVier.Location = new System.Drawing.Point(39, 305);
            this.checkVier.Name = "checkVier";
            this.checkVier.Size = new System.Drawing.Size(61, 17);
            this.checkVier.TabIndex = 21;
            this.checkVier.Text = "Viernes";
            this.checkVier.UseVisualStyleBackColor = true;
            this.checkVier.CheckedChanged += new System.EventHandler(this.checkVier_CheckedChanged);
            // 
            // checkSab
            // 
            this.checkSab.AutoSize = true;
            this.checkSab.Location = new System.Drawing.Point(40, 343);
            this.checkSab.Name = "checkSab";
            this.checkSab.Size = new System.Drawing.Size(63, 17);
            this.checkSab.TabIndex = 22;
            this.checkSab.Text = "Sábado";
            this.checkSab.UseVisualStyleBackColor = true;
            this.checkSab.CheckedChanged += new System.EventHandler(this.checkSab_CheckedChanged);
            // 
            // hDesdeLun
            // 
            this.hDesdeLun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeLun.FormattingEnabled = true;
            this.hDesdeLun.Location = new System.Drawing.Point(161, 146);
            this.hDesdeLun.Name = "hDesdeLun";
            this.hDesdeLun.Size = new System.Drawing.Size(121, 21);
            this.hDesdeLun.TabIndex = 23;
            this.hDesdeLun.SelectedValueChanged += new System.EventHandler(this.hDesdeLun_SelectedValueChanged);
            // 
            // hHastaLun
            // 
            this.hHastaLun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaLun.FormattingEnabled = true;
            this.hHastaLun.Location = new System.Drawing.Point(340, 149);
            this.hHastaLun.Name = "hHastaLun";
            this.hHastaLun.Size = new System.Drawing.Size(121, 21);
            this.hHastaLun.TabIndex = 24;
            // 
            // hDesdeMar
            // 
            this.hDesdeMar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeMar.FormattingEnabled = true;
            this.hDesdeMar.Location = new System.Drawing.Point(161, 186);
            this.hDesdeMar.Name = "hDesdeMar";
            this.hDesdeMar.Size = new System.Drawing.Size(121, 21);
            this.hDesdeMar.TabIndex = 25;
            this.hDesdeMar.SelectedValueChanged += new System.EventHandler(this.hDesdeMar_SelectedValueChanged);
            // 
            // hHastaMar
            // 
            this.hHastaMar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaMar.FormattingEnabled = true;
            this.hHastaMar.Location = new System.Drawing.Point(340, 188);
            this.hHastaMar.Name = "hHastaMar";
            this.hHastaMar.Size = new System.Drawing.Size(121, 21);
            this.hHastaMar.TabIndex = 26;
            // 
            // hDesdeMier
            // 
            this.hDesdeMier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeMier.FormattingEnabled = true;
            this.hDesdeMier.Location = new System.Drawing.Point(161, 224);
            this.hDesdeMier.Name = "hDesdeMier";
            this.hDesdeMier.Size = new System.Drawing.Size(121, 21);
            this.hDesdeMier.TabIndex = 27;
            this.hDesdeMier.SelectedValueChanged += new System.EventHandler(this.hDesdeMier_SelectedValueChanged);
            // 
            // hHastaMier
            // 
            this.hHastaMier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaMier.FormattingEnabled = true;
            this.hHastaMier.Location = new System.Drawing.Point(340, 224);
            this.hHastaMier.Name = "hHastaMier";
            this.hHastaMier.Size = new System.Drawing.Size(121, 21);
            this.hHastaMier.TabIndex = 28;
            // 
            // hDesdeJue
            // 
            this.hDesdeJue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeJue.FormattingEnabled = true;
            this.hDesdeJue.Location = new System.Drawing.Point(161, 262);
            this.hDesdeJue.Name = "hDesdeJue";
            this.hDesdeJue.Size = new System.Drawing.Size(121, 21);
            this.hDesdeJue.TabIndex = 29;
            this.hDesdeJue.SelectedValueChanged += new System.EventHandler(this.hDesdeJue_SelectedValueChanged);
            // 
            // hHastaJue
            // 
            this.hHastaJue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaJue.FormattingEnabled = true;
            this.hHastaJue.Location = new System.Drawing.Point(340, 262);
            this.hHastaJue.Name = "hHastaJue";
            this.hHastaJue.Size = new System.Drawing.Size(121, 21);
            this.hHastaJue.TabIndex = 30;
            // 
            // hDesdeVier
            // 
            this.hDesdeVier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeVier.FormattingEnabled = true;
            this.hDesdeVier.Location = new System.Drawing.Point(161, 301);
            this.hDesdeVier.Name = "hDesdeVier";
            this.hDesdeVier.Size = new System.Drawing.Size(121, 21);
            this.hDesdeVier.TabIndex = 31;
            this.hDesdeVier.SelectedValueChanged += new System.EventHandler(this.hDesdeVier_SelectedValueChanged);
            // 
            // hHastaVier
            // 
            this.hHastaVier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaVier.FormattingEnabled = true;
            this.hHastaVier.Location = new System.Drawing.Point(340, 301);
            this.hHastaVier.Name = "hHastaVier";
            this.hHastaVier.Size = new System.Drawing.Size(121, 21);
            this.hHastaVier.TabIndex = 32;
            // 
            // hDesdeSab
            // 
            this.hDesdeSab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hDesdeSab.FormattingEnabled = true;
            this.hDesdeSab.Location = new System.Drawing.Point(161, 339);
            this.hDesdeSab.Name = "hDesdeSab";
            this.hDesdeSab.Size = new System.Drawing.Size(121, 21);
            this.hDesdeSab.TabIndex = 33;
            this.hDesdeSab.SelectedValueChanged += new System.EventHandler(this.hDesdeSab_SelectedValueChanged);
            // 
            // hHastaSab
            // 
            this.hHastaSab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hHastaSab.FormattingEnabled = true;
            this.hHastaSab.Location = new System.Drawing.Point(340, 339);
            this.hHastaSab.Name = "hHastaSab";
            this.hHastaSab.Size = new System.Drawing.Size(121, 21);
            this.hHastaSab.TabIndex = 34;
            // 
            // errorPanel
            // 
            this.errorPanel.AutoSize = true;
            this.errorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorPanel.ForeColor = System.Drawing.Color.Crimson;
            this.errorPanel.Location = new System.Drawing.Point(101, 98);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(72, 13);
            this.errorPanel.TabIndex = 35;
            this.errorPanel.Text = "<error_panel>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(463, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorPanel);
            this.Controls.Add(this.hHastaSab);
            this.Controls.Add(this.hDesdeSab);
            this.Controls.Add(this.hHastaVier);
            this.Controls.Add(this.hDesdeVier);
            this.Controls.Add(this.hHastaJue);
            this.Controls.Add(this.hDesdeJue);
            this.Controls.Add(this.hHastaMier);
            this.Controls.Add(this.hDesdeMier);
            this.Controls.Add(this.hHastaMar);
            this.Controls.Add(this.hDesdeMar);
            this.Controls.Add(this.hHastaLun);
            this.Controls.Add(this.hDesdeLun);
            this.Controls.Add(this.checkSab);
            this.Controls.Add(this.checkVier);
            this.Controls.Add(this.checkJue);
            this.Controls.Add(this.checkMier);
            this.Controls.Add(this.checkMar);
            this.Controls.Add(this.checkLun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cEspecialidad);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarAgenda";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkLun;
        private System.Windows.Forms.CheckBox checkMar;
        private System.Windows.Forms.CheckBox checkMier;
        private System.Windows.Forms.CheckBox checkJue;
        private System.Windows.Forms.CheckBox checkVier;
        private System.Windows.Forms.CheckBox checkSab;
        private System.Windows.Forms.ComboBox hDesdeLun;
        private System.Windows.Forms.ComboBox hHastaLun;
        private System.Windows.Forms.ComboBox hDesdeMar;
        private System.Windows.Forms.ComboBox hHastaMar;
        private System.Windows.Forms.ComboBox hDesdeMier;
        private System.Windows.Forms.ComboBox hHastaMier;
        private System.Windows.Forms.ComboBox hDesdeJue;
        private System.Windows.Forms.ComboBox hHastaJue;
        private System.Windows.Forms.ComboBox hDesdeVier;
        private System.Windows.Forms.ComboBox hHastaVier;
        private System.Windows.Forms.ComboBox hDesdeSab;
        private System.Windows.Forms.ComboBox hHastaSab;
        private System.Windows.Forms.Label errorPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}