namespace UberFrba.Registro_Viajes
{
    partial class frmCargaViaje
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
            this.components = new System.ComponentModel.Container();
            this.infoAuto = new System.Windows.Forms.ToolTip(this.components);
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.horaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.horaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKms = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChofer = new System.Windows.Forms.Button();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.lblAuto = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKms)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoAuto
            // 
            this.infoAuto.AutomaticDelay = 100;
            this.infoAuto.AutoPopDelay = 3000;
            this.infoAuto.InitialDelay = 100;
            this.infoAuto.IsBalloon = true;
            this.infoAuto.ReshowDelay = 20;
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(48, 428);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(96, 21);
            this.btnAtras.TabIndex = 18;
            this.btnAtras.Text = "<<Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Location = new System.Drawing.Point(256, 414);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(111, 35);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.horaFin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.fecha);
            this.groupBox2.Controls.Add(this.horaInicio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKms);
            this.groupBox2.Location = new System.Drawing.Point(48, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 178);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // horaFin
            // 
            this.horaFin.CustomFormat = "HH:mm";
            this.horaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horaFin.Location = new System.Drawing.Point(342, 61);
            this.horaFin.Name = "horaFin";
            this.horaFin.ShowUpDown = true;
            this.horaFin.Size = new System.Drawing.Size(92, 20);
            this.horaFin.TabIndex = 15;
            this.horaFin.Value = new System.DateTime(2017, 5, 1, 18, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fin";
            // 
            // fecha
            // 
            this.fecha.CustomFormat = "dd/MM/yyyy";
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(125, 31);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(120, 20);
            this.fecha.TabIndex = 9;
            this.fecha.Value = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            // 
            // horaInicio
            // 
            this.horaInicio.CustomFormat = "HH:mm";
            this.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horaInicio.Location = new System.Drawing.Point(342, 35);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ShowUpDown = true;
            this.horaInicio.Size = new System.Drawing.Size(92, 20);
            this.horaInicio.TabIndex = 11;
            this.horaInicio.Value = new System.DateTime(2017, 5, 1, 18, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Recorrido (Kms.)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Inicio";
            // 
            // txtKms
            // 
            this.txtKms.Location = new System.Drawing.Point(125, 123);
            this.txtKms.Name = "txtKms";
            this.txtKms.Size = new System.Drawing.Size(120, 20);
            this.txtKms.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnChofer);
            this.groupBox1.Controls.Add(this.txtAuto);
            this.groupBox1.Controls.Add(this.lblAuto);
            this.groupBox1.Controls.Add(this.txtChofer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(48, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion del Viaje";
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(370, 125);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(111, 23);
            this.btnCliente.TabIndex = 16;
            this.btnCliente.Text = "Seleccionar...";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(140, 128);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(199, 20);
            this.txtCliente.TabIndex = 15;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cliente";
            // 
            // btnChofer
            // 
            this.btnChofer.Location = new System.Drawing.Point(370, 36);
            this.btnChofer.Name = "btnChofer";
            this.btnChofer.Size = new System.Drawing.Size(111, 23);
            this.btnChofer.TabIndex = 5;
            this.btnChofer.Text = "Seleccionar...";
            this.btnChofer.UseVisualStyleBackColor = true;
            this.btnChofer.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAuto
            // 
            this.txtAuto.Cursor = System.Windows.Forms.Cursors.No;
            this.txtAuto.Location = new System.Drawing.Point(140, 81);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.ReadOnly = true;
            this.txtAuto.Size = new System.Drawing.Size(199, 20);
            this.txtAuto.TabIndex = 4;
            this.infoAuto.SetToolTip(this.txtAuto, "Este campo se completará automáticamente\r\ncuando seleccione un chofer");
            this.txtAuto.TextChanged += new System.EventHandler(this.txtAuto_TextChanged);
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Location = new System.Drawing.Point(41, 81);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(29, 13);
            this.lblAuto.TabIndex = 3;
            this.lblAuto.Text = "Auto";
            // 
            // txtChofer
            // 
            this.txtChofer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChofer.Location = new System.Drawing.Point(140, 36);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(199, 20);
            this.txtChofer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chofer";
            // 
            // frmCargaViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 486);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCargaViaje";
            this.Text = "Registro Viaje";
            this.Load += new System.EventHandler(this.frmCargaViaje_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKms)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChofer;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.DateTimePicker horaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtKms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.ToolTip infoAuto;
        private System.Windows.Forms.DateTimePicker horaFin;
        private System.Windows.Forms.Label label6;
    }
}