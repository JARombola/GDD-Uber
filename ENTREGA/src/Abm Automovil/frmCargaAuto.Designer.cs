﻿namespace UberFrba.Abm_Automovil {
    partial class frmCargaAuto {
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
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.btnBuscChofer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHabilitacion = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTurno);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtChofer);
            this.groupBox1.Controls.Add(this.btnBuscChofer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbMarca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Auto";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(407, 335);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 26);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "(*) = Campo Obligatorio";
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(150, 247);
            this.txtTurno.MaxLength = 26;
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(233, 20);
            this.txtTurno.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 20;
            this.button1.TabStop = false;
            this.button1.Text = "Buscar...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Turno*";
            // 
            // txtChofer
            // 
            this.txtChofer.Location = new System.Drawing.Point(150, 175);
            this.txtChofer.MaxLength = 26;
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(233, 20);
            this.txtChofer.TabIndex = 19;
            // 
            // btnBuscChofer
            // 
            this.btnBuscChofer.Location = new System.Drawing.Point(399, 175);
            this.btnBuscChofer.Name = "btnBuscChofer";
            this.btnBuscChofer.Size = new System.Drawing.Size(75, 22);
            this.btnBuscChofer.TabIndex = 6;
            this.btnBuscChofer.TabStop = false;
            this.btnBuscChofer.Text = "Buscar...";
            this.btnBuscChofer.UseVisualStyleBackColor = true;
            this.btnBuscChofer.Click += new System.EventHandler(this.btnBuscChofer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Chofer*";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(150, 100);
            this.txtPatente.MaxLength = 10;
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(233, 20);
            this.txtPatente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Patente*";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(150, 67);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(233, 20);
            this.txtModelo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modelo*";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(150, 29);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(233, 21);
            this.cbMarca.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca*";
            // 
            // btnHabilitacion
            // 
            this.btnHabilitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnHabilitacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHabilitacion.FlatAppearance.BorderSize = 2;
            this.btnHabilitacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHabilitacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHabilitacion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHabilitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitacion.Location = new System.Drawing.Point(407, 420);
            this.btnHabilitacion.Name = "btnHabilitacion";
            this.btnHabilitacion.Size = new System.Drawing.Size(125, 27);
            this.btnHabilitacion.TabIndex = 8;
            this.btnHabilitacion.UseVisualStyleBackColor = false;
            this.btnHabilitacion.Visible = false;
            this.btnHabilitacion.Click += new System.EventHandler(this.btnHabilitacion_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(196, 417);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(164, 31);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Registrar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(27, 422);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 26);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.TabStop = false;
            this.btnVolver.Text = "<< Atras";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmCargaAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(575, 472);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnHabilitacion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCargaAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Autos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscChofer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Button btnHabilitacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
    }
}