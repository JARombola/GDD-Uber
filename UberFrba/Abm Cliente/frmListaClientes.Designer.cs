namespace UberFrba.Abm_Cliente {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.grFiltros = new System.Windows.Forms.GroupBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.grFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Filtro";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(153, 76);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(185, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(153, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(185, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(448, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 3;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(593, 75);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(80, 23);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar...";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // grFiltros
            // 
            this.grFiltros.Controls.Add(this.txtDNI);
            this.grFiltros.Controls.Add(this.btnSeleccionar);
            this.grFiltros.Controls.Add(this.label1);
            this.grFiltros.Controls.Add(this.textBox1);
            this.grFiltros.Controls.Add(this.label2);
            this.grFiltros.Controls.Add(this.label3);
            this.grFiltros.Controls.Add(this.txtNombre);
            this.grFiltros.Controls.Add(this.label4);
            this.grFiltros.Controls.Add(this.txtApellido);
            this.grFiltros.Location = new System.Drawing.Point(30, 12);
            this.grFiltros.Name = "grFiltros";
            this.grFiltros.Size = new System.Drawing.Size(700, 122);
            this.grFiltros.TabIndex = 9;
            this.grFiltros.TabStop = false;
            this.grFiltros.Text = "Búsqueda Clientes";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(448, 32);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(185, 20);
            this.txtDNI.TabIndex = 5;
            // 
            // dgListado
            // 
            this.dgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListado.Location = new System.Drawing.Point(30, 186);
            this.dgListado.Name = "dgListado";
            this.dgListado.Size = new System.Drawing.Size(700, 168);
            this.dgListado.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(623, 140);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar!";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(30, 140);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(80, 23);
            this.btnClean.TabIndex = 5;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // frmListClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 366);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgListado);
            this.Controls.Add(this.grFiltros);
            this.Name = "frmListClientes";
            this.Text = "Listado Clientes";
            this.Load += new System.EventHandler(this.frmListado_Load);
            this.grFiltros.ResumeLayout(false);
            this.grFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.ResumeLayout(false);

        }

        private void frmListado_Load (object sender, System.EventArgs e) {
            
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.GroupBox grFiltros;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtDNI;
    }

}