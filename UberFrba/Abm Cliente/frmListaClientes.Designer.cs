﻿namespace UberFrba.Abm_Cliente {
    partial class frmListaClientes {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grFiltros = new System.Windows.Forms.GroupBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.menuDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblHabilitados = new System.Windows.Forms.Label();
            this.lblCantResultados = new System.Windows.Forms.Label();
            this.grFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            this.menuDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(153, 76);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(185, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(153, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(185, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // grFiltros
            // 
            this.grFiltros.Controls.Add(this.txtDNI);
            this.grFiltros.Controls.Add(this.label1);
            this.grFiltros.Controls.Add(this.label2);
            this.grFiltros.Controls.Add(this.label3);
            this.grFiltros.Controls.Add(this.txtNombre);
            this.grFiltros.Controls.Add(this.txtApellido);
            this.grFiltros.Location = new System.Drawing.Point(30, 12);
            this.grFiltros.Name = "grFiltros";
            this.grFiltros.Size = new System.Drawing.Size(700, 122);
            this.grFiltros.TabIndex = 0;
            this.grFiltros.TabStop = false;
            this.grFiltros.Text = "Búsqueda Clientes";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(448, 32);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(185, 20);
            this.txtDNI.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(623, 140);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar!";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(30, 140);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(80, 23);
            this.btnClean.TabIndex = 4;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
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
            this.dgListado.ContextMenuStrip = this.menuDerecho;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgListado.EnableHeadersVisualStyles = false;
            this.dgListado.Location = new System.Drawing.Point(30, 182);
            this.dgListado.MultiSelect = false;
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListado.Size = new System.Drawing.Size(700, 208);
            this.dgListado.TabIndex = 12;
            this.dgListado.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.actualizar);
            this.dgListado.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.actualizar);
            this.dgListado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.seleccion);
            // 
            // menuDerecho
            // 
            this.menuDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcHabilitar,
            this.opcDeshabilitar});
            this.menuDerecho.Name = "cgDerecho";
            this.menuDerecho.Size = new System.Drawing.Size(137, 48);
            // 
            // opcHabilitar
            // 
            this.opcHabilitar.Name = "opcHabilitar";
            this.opcHabilitar.Size = new System.Drawing.Size(136, 22);
            this.opcHabilitar.Text = "Habilitar";
            // 
            // opcDeshabilitar
            // 
            this.opcDeshabilitar.Name = "opcDeshabilitar";
            this.opcDeshabilitar.Size = new System.Drawing.Size(136, 22);
            this.opcDeshabilitar.Text = "Deshabilitar";
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(650, 396);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(80, 23);
            this.btnTodos.TabIndex = 6;
            this.btnTodos.Text = "Ver todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(30, 396);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(80, 23);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "<< Atras";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblHabilitados
            // 
            this.lblHabilitados.AutoSize = true;
            this.lblHabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHabilitados.Location = new System.Drawing.Point(27, 166);
            this.lblHabilitados.Name = "lblHabilitados";
            this.lblHabilitados.Size = new System.Drawing.Size(232, 13);
            this.lblHabilitados.TabIndex = 15;
            this.lblHabilitados.Text = "<Sólo se verán los clientes habilitados>";
            // 
            // lblCantResultados
            // 
            this.lblCantResultados.AutoSize = true;
            this.lblCantResultados.Location = new System.Drawing.Point(464, 401);
            this.lblCantResultados.Name = "lblCantResultados";
            this.lblCantResultados.Size = new System.Drawing.Size(97, 13);
            this.lblCantResultados.TabIndex = 16;
            this.lblCantResultados.Text = "<Cant Resultados>";
            this.lblCantResultados.Visible = false;
            // 
            // frmListaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 431);
            this.Controls.Add(this.lblCantResultados);
            this.Controls.Add(this.lblHabilitados);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.dgListado);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grFiltros);
            this.Name = "frmListaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Clientes";
            this.Load += new System.EventHandler(this.frmListado_Load);
            this.grFiltros.ResumeLayout(false);
            this.grFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.menuDerecho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmListado_Load (object sender, System.EventArgs e) {
            lblHabilitados.Visible=soloHabilitados;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox grFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.ContextMenuStrip menuDerecho;
        private System.Windows.Forms.ToolStripMenuItem opcHabilitar;
        private System.Windows.Forms.ToolStripMenuItem opcDeshabilitar;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblHabilitados;
        private System.Windows.Forms.Label lblCantResultados;
    }

}