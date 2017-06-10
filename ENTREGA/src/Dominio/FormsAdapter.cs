using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dominio;
using UberFrba.Menues;

namespace UberFrba {
    public partial class FormsAdapter : Form {              // Clase de la que herdan todos los formularios de la aplicacion.
                                                                // Para reutilizar metodos
        protected string TABLA { get; set; }
        public FormsAdapter formAnterior { get; set; }
        public FormsAdapter formSiguiente { get; set; }
        public int ID { get; set; }
        public DateTime FECHA_ACTUAL { get; set; }

        public FormsAdapter () {                        // Inicializa con -1 
            ID = -1;
        }

        protected void ejecutarQuery (SqlCommand command, DataGridView lista) {                // Ejecuta una query y completa una lista con los resultados obtenidos           
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tabla);
            lista.DataSource = tabla;
        }

        protected Object valor (string texto) {                                 // Devuelve nulo (para la base) en caso de que que el string esté vacio
            if (!String.IsNullOrWhiteSpace(texto)) return texto;
            return DBNull.Value;
        }

        protected int deshabilitar (string SP, int id){                             // Metodo usado por los formularios para deshabilitar Choferes/Autos/Turnos/Roles/Clientes
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            int resultado= cmd.ExecuteNonQuery();
            if (resultado>0) MessageBox.Show(SP+" deshabilitado correctamente", SP+" deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return resultado;
        }

        protected int habilitar (string SP, int id) {                           // Metodo usado por los formularios para habilitar Choferes/Autos/Turnos/Roles/Clientes
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            int resultado= cmd.ExecuteNonQuery();
            if (resultado>0) MessageBox.Show(SP+" habilitado correctamente", SP+" habilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return resultado;
        }

        protected void volver () {                              // Usado en todos los formularios para volver al formulario anterior
            formAnterior.Show();
            Close();
        }

        public virtual void configurar (IDominio elemento) {
        }
        public virtual void cargarDatos (IDominio elemento) {
        }
        public virtual void limpiar () {
        }
        public virtual string errorCampos() {
            return null;
        }

        private void InitializeComponent () {
            this.SuspendLayout();
            // 
            // FormsAdapter
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormsAdapter";
            this.ResumeLayout(false);
        }

        internal void ocultarColumnas (DataGridView listado) {                  // Oculta columnas que el usuario no necesita ver, pero la aplicacion SI las utiliza
            listado.Columns["ID"].Visible=false;
            listado.Columns["Habilitado"].Visible=false;
        }
    }
}