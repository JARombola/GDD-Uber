namespace UberFrba.Abm_Rol
{
    partial class frmRoles
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
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.btnDeshabiliar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listFunciones = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(113, 37);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(173, 21);
            this.cbRol.Sorted = true;
            this.cbRol.TabIndex = 0;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            this.cbRol.TextUpdate += new System.EventHandler(this.botonRegistrar);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(27, 41);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Rol";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(207, 401);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 31);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Aceptar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHabilitar);
            this.groupBox1.Controls.Add(this.btnDeshabiliar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbRol);
            this.groupBox1.Controls.Add(this.lblRol);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 369);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Rol";
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Enabled = false;
            this.btnHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.Location = new System.Drawing.Point(332, 31);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(127, 31);
            this.btnHabilitar.TabIndex = 4;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // btnDeshabiliar
            // 
            this.btnDeshabiliar.Enabled = false;
            this.btnDeshabiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeshabiliar.Location = new System.Drawing.Point(332, 77);
            this.btnDeshabiliar.Name = "btnDeshabiliar";
            this.btnDeshabiliar.Size = new System.Drawing.Size(127, 31);
            this.btnDeshabiliar.TabIndex = 3;
            this.btnDeshabiliar.Text = "Deshabilitar";
            this.btnDeshabiliar.UseVisualStyleBackColor = true;
            this.btnDeshabiliar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listFunciones);
            this.groupBox2.Location = new System.Drawing.Point(0, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funcionalidades";
            // 
            // listFunciones
            // 
            this.listFunciones.CheckOnClick = true;
            this.listFunciones.FormattingEnabled = true;
            this.listFunciones.Items.AddRange(new object[] {
            "Admin Clientes",
            "Admin Choferes",
            "Admin Autos",
            "Admin Roles",
            "Admin Turnos",
            "Registro Viajes",
            "Facturacion",
            "Rendicion",
            "Estadísticas"});
            this.listFunciones.Location = new System.Drawing.Point(11, 36);
            this.listFunciones.Name = "listFunciones";
            this.listFunciones.Size = new System.Drawing.Size(457, 199);
            this.listFunciones.TabIndex = 0;
            // 
            // frmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "frmRoles";
            this.Text = "Modificación Roles";
            this.Load += new System.EventHandler(this.frmModifRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox listFunciones;
        private System.Windows.Forms.Button btnDeshabiliar;
        private System.Windows.Forms.Button btnHabilitar;
    }
}