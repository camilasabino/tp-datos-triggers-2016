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
            this.button_alta = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_baja = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_alta
            // 
            this.button_alta.AccessibleDescription = "";
            this.button_alta.AccessibleName = "";
            this.button_alta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_alta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_alta.Location = new System.Drawing.Point(438, 125);
            this.button_alta.Name = "button_alta";
            this.button_alta.Size = new System.Drawing.Size(196, 54);
            this.button_alta.TabIndex = 1;
            this.button_alta.Text = "Dar de Alta un Afiliado";
            this.button_alta.UseVisualStyleBackColor = true;
            this.button_alta.Click += new System.EventHandler(this.button_alta_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.AccessibleDescription = "";
            this.button_modificar.AccessibleName = "";
            this.button_modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.Location = new System.Drawing.Point(438, 231);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(196, 54);
            this.button_modificar.TabIndex = 2;
            this.button_modificar.Text = "Modificar un Afiliado";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // button_baja
            // 
            this.button_baja.AccessibleDescription = "";
            this.button_baja.AccessibleName = "";
            this.button_baja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_baja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_baja.Location = new System.Drawing.Point(438, 338);
            this.button_baja.Name = "button_baja";
            this.button_baja.Size = new System.Drawing.Size(196, 54);
            this.button_baja.TabIndex = 3;
            this.button_baja.Text = "Dar de Baja un Afiliado";
            this.button_baja.UseVisualStyleBackColor = true;
            this.button_baja.Click += new System.EventHandler(this.button_baja_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalir.Location = new System.Drawing.Point(468, 447);
            this.buttonSalir.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(139, 45);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(366, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(319, 37);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ABM de Afiliados";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // Afiliado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1083, 551);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.button_baja);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_alta);
            this.Name = "Afiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afiliados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_alta;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_baja;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}