﻿namespace ClinicaFrba.Abm_Afiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alta));
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.textBox_afil_usuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_afil_dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_afil_estadoCivil = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_afil_titular = new System.Windows.Forms.TextBox();
            this.comboBox_afil_plan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_afil_CantFamACargo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_afil_relacionConTitular = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_cancelar
            // 
            this.button_cancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Location = new System.Drawing.Point(271, 331);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(76, 23);
            this.button_cancelar.TabIndex = 9;
            this.button_cancelar.Text = "Salir";
            this.button_cancelar.UseVisualStyleBackColor = false;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_confirmar
            // 
            this.button_confirmar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button_confirmar.Location = new System.Drawing.Point(123, 331);
            this.button_confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(78, 23);
            this.button_confirmar.TabIndex = 8;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = false;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // textBox_afil_usuario
            // 
            this.textBox_afil_usuario.Location = new System.Drawing.Point(92, 121);
            this.textBox_afil_usuario.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_afil_usuario.Name = "textBox_afil_usuario";
            this.textBox_afil_usuario.Size = new System.Drawing.Size(117, 20);
            this.textBox_afil_usuario.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Número de Usuario";
            // 
            // textBox_afil_dni
            // 
            this.textBox_afil_dni.Location = new System.Drawing.Point(91, 174);
            this.textBox_afil_dni.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_afil_dni.Name = "textBox_afil_dni";
            this.textBox_afil_dni.Size = new System.Drawing.Size(121, 20);
            this.textBox_afil_dni.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nro. de Dni";
            // 
            // comboBox_afil_estadoCivil
            // 
            this.comboBox_afil_estadoCivil.FormattingEnabled = true;
            this.comboBox_afil_estadoCivil.Location = new System.Drawing.Point(271, 174);
            this.comboBox_afil_estadoCivil.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_afil_estadoCivil.Name = "comboBox_afil_estadoCivil";
            this.comboBox_afil_estadoCivil.Size = new System.Drawing.Size(121, 21);
            this.comboBox_afil_estadoCivil.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Estado Civil";
            // 
            // textBox_afil_titular
            // 
            this.textBox_afil_titular.Location = new System.Drawing.Point(88, 224);
            this.textBox_afil_titular.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_afil_titular.Name = "textBox_afil_titular";
            this.textBox_afil_titular.Size = new System.Drawing.Size(121, 20);
            this.textBox_afil_titular.TabIndex = 2;
            // 
            // comboBox_afil_plan
            // 
            this.comboBox_afil_plan.FormattingEnabled = true;
            this.comboBox_afil_plan.Location = new System.Drawing.Point(271, 224);
            this.comboBox_afil_plan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_afil_plan.Name = "comboBox_afil_plan";
            this.comboBox_afil_plan.Size = new System.Drawing.Size(121, 21);
            this.comboBox_afil_plan.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Plan Médico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Cant. Familiares a Cargo";
            // 
            // comboBox_afil_CantFamACargo
            // 
            this.comboBox_afil_CantFamACargo.FormattingEnabled = true;
            this.comboBox_afil_CantFamACargo.Location = new System.Drawing.Point(271, 275);
            this.comboBox_afil_CantFamACargo.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_afil_CantFamACargo.Name = "comboBox_afil_CantFamACargo";
            this.comboBox_afil_CantFamACargo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_afil_CantFamACargo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Número del Titular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 259);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Relación con el Titular";
            // 
            // comboBox_afil_relacionConTitular
            // 
            this.comboBox_afil_relacionConTitular.FormattingEnabled = true;
            this.comboBox_afil_relacionConTitular.Location = new System.Drawing.Point(88, 275);
            this.comboBox_afil_relacionConTitular.Name = "comboBox_afil_relacionConTitular";
            this.comboBox_afil_relacionConTitular.Size = new System.Drawing.Size(121, 21);
            this.comboBox_afil_relacionConTitular.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(130, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 24);
            this.label8.TabIndex = 42;
            this.label8.Text = "Dar de Alta un Afiliado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(353, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 374);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_afil_relacionConTitular);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_afil_CantFamACargo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_afil_plan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_afil_titular);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_afil_estadoCivil);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_afil_dni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.textBox_afil_usuario);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Alta";
            this.Text = "Alta";
            this.Load += new System.EventHandler(this.alta_Afiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.TextBox textBox_afil_usuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_afil_dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_afil_estadoCivil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_afil_titular;
        private System.Windows.Forms.ComboBox comboBox_afil_plan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_afil_CantFamACargo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_afil_relacionConTitular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}