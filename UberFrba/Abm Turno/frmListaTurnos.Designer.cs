namespace UberFrba.Abm_Turno {
    partial class frmListaTurnos {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.menuDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblHabilitados = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            this.menuDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(39, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda Turnos";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(204, 35);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(307, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(612, 124);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar!";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(39, 124);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnClean_Click);
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
            this.dgListado.EnableHeadersVisualStyles = false;
            this.dgListado.Location = new System.Drawing.Point(39, 192);
            this.dgListado.MultiSelect = false;
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            this.dgListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListado.Size = new System.Drawing.Size(648, 175);
            this.dgListado.TabIndex = 3;
            this.dgListado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.seleccion);
            this.dgListado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.derecho);
            // 
            // menuDerecho
            // 
            this.menuDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.deshabilitarToolStripMenuItem});
            this.menuDerecho.Name = "cgDerecho";
            this.menuDerecho.Size = new System.Drawing.Size(137, 48);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.eliminarToolStripMenuItem.Text = "Habilitar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.habilitar);
            // 
            // deshabilitarToolStripMenuItem
            // 
            this.deshabilitarToolStripMenuItem.Name = "deshabilitarToolStripMenuItem";
            this.deshabilitarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deshabilitarToolStripMenuItem.Text = "Deshabilitar";
            this.deshabilitarToolStripMenuItem.Click += new System.EventHandler(this.deshabilitar);
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(612, 373);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(75, 23);
            this.btnTodos.TabIndex = 4;
            this.btnTodos.Text = "Ver todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click_1);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(39, 373);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "<< Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click_1);
            // 
            // lblHabilitados
            // 
            this.lblHabilitados.AutoSize = true;
            this.lblHabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHabilitados.Location = new System.Drawing.Point(36, 176);
            this.lblHabilitados.Name = "lblHabilitados";
            this.lblHabilitados.Size = new System.Drawing.Size(223, 13);
            this.lblHabilitados.TabIndex = 14;
            this.lblHabilitados.Text = "<Sólo se verán los turnos habilitados>";
            // 
            // frmListaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 400);
            this.Controls.Add(this.lblHabilitados);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.dgListado);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListaTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Turnos";
            this.Load += new System.EventHandler(this.frmListaTurnos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.menuDerecho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.ContextMenuStrip menuDerecho;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshabilitarToolStripMenuItem;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblHabilitados;
    }
}