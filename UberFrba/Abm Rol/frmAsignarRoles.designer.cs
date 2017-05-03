namespace UberFrba.Abm_Usuario
{
    partial class frmAsignarRoles
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
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.Usuario = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listRoles = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUsuario
            // 
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(113, 37);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(173, 21);
            this.cbUsuario.Sorted = true;
            this.cbUsuario.TabIndex = 0;
            this.cbUsuario.SelectedIndexChanged += new System.EventHandler(this.cbUsuario_SelectedIndexChanged);
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(27, 41);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(43, 13);
            this.Usuario.TabIndex = 1;
            this.Usuario.Text = "Usuario";
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(207, 401);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 31);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Modificar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbUsuario);
            this.groupBox1.Controls.Add(this.Usuario);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listRoles);
            this.groupBox2.Location = new System.Drawing.Point(0, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 280);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roles";
            // 
            // listRoles
            // 
            this.listRoles.CheckOnClick = true;
            this.listRoles.FormattingEnabled = true;
            this.listRoles.Location = new System.Drawing.Point(11, 36);
            this.listRoles.Name = "listRoles";
            this.listRoles.Size = new System.Drawing.Size(448, 229);
            this.listRoles.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "<< Atrás";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAsignarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 455);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "frmAsignarRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion Roles de Usuario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox listRoles;
        private System.Windows.Forms.Button button1;
    }
}