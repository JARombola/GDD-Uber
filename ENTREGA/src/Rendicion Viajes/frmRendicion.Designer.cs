﻿namespace UberFrba.Rendicion_Viajes
{
    partial class frmRendicion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTurno = new System.Windows.Forms.Button();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChofer = new System.Windows.Forms.Button();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTurno);
            this.groupBox1.Controls.Add(this.txtTurno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnChofer);
            this.groupBox1.Controls.Add(this.txtChofer);
            this.groupBox1.Controls.Add(this.fecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // btnTurno
            // 
            this.btnTurno.Location = new System.Drawing.Point(558, 60);
            this.btnTurno.Name = "btnTurno";
            this.btnTurno.Size = new System.Drawing.Size(75, 23);
            this.btnTurno.TabIndex = 2;
            this.btnTurno.Text = "Buscar...";
            this.btnTurno.UseVisualStyleBackColor = true;
            this.btnTurno.Click += new System.EventHandler(this.btnTurno_Click);
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(352, 63);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(187, 20);
            this.txtTurno.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Turno";
            // 
            // btnChofer
            // 
            this.btnChofer.Location = new System.Drawing.Point(558, 31);
            this.btnChofer.Name = "btnChofer";
            this.btnChofer.Size = new System.Drawing.Size(75, 23);
            this.btnChofer.TabIndex = 1;
            this.btnChofer.Text = "Buscar...";
            this.btnChofer.UseVisualStyleBackColor = true;
            this.btnChofer.Click += new System.EventHandler(this.btnChofer_Click);
            // 
            // txtChofer
            // 
            this.txtChofer.Location = new System.Drawing.Point(352, 34);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(187, 20);
            this.txtChofer.TabIndex = 1;
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(94, 34);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(135, 20);
            this.fecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chofer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // dgListado
            // 
            this.dgListado.AllowUserToAddRows = false;
            this.dgListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListado.EnableHeadersVisualStyles = false;
            this.dgListado.Location = new System.Drawing.Point(12, 168);
            this.dgListado.MultiSelect = false;
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            this.dgListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListado.Size = new System.Drawing.Size(639, 246);
            this.dgListado.TabIndex = 4;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(277, 124);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(109, 26);
            this.btnFacturar.TabIndex = 5;
            this.btnFacturar.Text = "Generar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "<<Atrás";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 455);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.dgListado);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRendicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendicion viajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChofer;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnTurno;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Label label3;
    }
}