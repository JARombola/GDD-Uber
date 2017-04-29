namespace UberFrba.Menues {
    partial class MenuInicial {
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
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnChoferes = new System.Windows.Forms.Button();
            this.btnAutos = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRendicion = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(15, 15);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(10);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(240, 34);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnChoferes
            // 
            this.btnChoferes.Location = new System.Drawing.Point(15, 69);
            this.btnChoferes.Margin = new System.Windows.Forms.Padding(10);
            this.btnChoferes.Name = "btnChoferes";
            this.btnChoferes.Size = new System.Drawing.Size(240, 34);
            this.btnChoferes.TabIndex = 1;
            this.btnChoferes.Text = "Choferes";
            this.btnChoferes.UseVisualStyleBackColor = true;
            this.btnChoferes.Click += new System.EventHandler(this.btnChoferes_Click);
            // 
            // btnAutos
            // 
            this.btnAutos.Location = new System.Drawing.Point(275, 69);
            this.btnAutos.Margin = new System.Windows.Forms.Padding(10);
            this.btnAutos.Name = "btnAutos";
            this.btnAutos.Size = new System.Drawing.Size(240, 34);
            this.btnAutos.TabIndex = 2;
            this.btnAutos.Text = "Autos";
            this.btnAutos.UseVisualStyleBackColor = true;
            this.btnAutos.Click += new System.EventHandler(this.btnAutos_Click);
            // 
            // btnTurnos
            // 
            this.btnTurnos.Location = new System.Drawing.Point(275, 123);
            this.btnTurnos.Margin = new System.Windows.Forms.Padding(10);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(240, 34);
            this.btnTurnos.TabIndex = 3;
            this.btnTurnos.Text = "Turnos";
            this.btnTurnos.UseVisualStyleBackColor = true;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Location = new System.Drawing.Point(15, 123);
            this.btnFacturacion.Margin = new System.Windows.Forms.Padding(10);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(240, 34);
            this.btnFacturacion.TabIndex = 4;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "Viajes";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnRendicion
            // 
            this.btnRendicion.Location = new System.Drawing.Point(275, 177);
            this.btnRendicion.Margin = new System.Windows.Forms.Padding(10);
            this.btnRendicion.Name = "btnRendicion";
            this.btnRendicion.Size = new System.Drawing.Size(240, 34);
            this.btnRendicion.TabIndex = 6;
            this.btnRendicion.Text = "Rendicion";
            this.btnRendicion.UseVisualStyleBackColor = true;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(15, 177);
            this.btnEstadisticas.Margin = new System.Windows.Forms.Padding(10);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(240, 34);
            this.btnEstadisticas.TabIndex = 7;
            this.btnEstadisticas.Text = "Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnClientes);
            this.panel.Controls.Add(this.button2);
            this.panel.Controls.Add(this.btnChoferes);
            this.panel.Controls.Add(this.btnAutos);
            this.panel.Controls.Add(this.btnFacturacion);
            this.panel.Controls.Add(this.btnTurnos);
            this.panel.Controls.Add(this.btnEstadisticas);
            this.panel.Controls.Add(this.btnRendicion);
            this.panel.Location = new System.Drawing.Point(89, 97);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(5);
            this.panel.Size = new System.Drawing.Size(533, 227);
            this.panel.TabIndex = 10;
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 346);
            this.Controls.Add(this.panel);
            this.Name = "MenuInicial";
            this.Text = "MenuInicial";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnChoferes;
        private System.Windows.Forms.Button btnAutos;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRendicion;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.FlowLayoutPanel panel;
    }
}