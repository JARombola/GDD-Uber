namespace UberFrba.Menues {
    partial class Login {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkPass = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblIntentos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkPass);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Iniciar Sesión";
            // 
            // checkPass
            // 
            this.checkPass.AutoSize = true;
            this.checkPass.Location = new System.Drawing.Point(305, 111);
            this.checkPass.Name = "checkPass";
            this.checkPass.Size = new System.Drawing.Size(118, 17);
            this.checkPass.TabIndex = 2;
            this.checkPass.TabStop = false;
            this.checkPass.Text = "Mostrar Contraseña";
            this.checkPass.UseVisualStyleBackColor = true;
            this.checkPass.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(219, 72);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(204, 20);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(219, 34);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(204, 20);
            this.txtUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(228, 181);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(95, 31);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "Ingresar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lblIntentos
            // 
            this.lblIntentos.AutoSize = true;
            this.lblIntentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntentos.ForeColor = System.Drawing.Color.Red;
            this.lblIntentos.Location = new System.Drawing.Point(128, 149);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(102, 13);
            this.lblIntentos.TabIndex = 2;
            this.lblIntentos.Text = "- Intentos Restantes";
            this.lblIntentos.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 224);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox checkPass;
        private System.Windows.Forms.Label lblIntentos;
    }
}