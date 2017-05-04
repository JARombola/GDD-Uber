using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dominio;

namespace UberFrba {
    public partial class FormsAdapter : Form {

        protected string TABLA { get; set; }
        public FormsAdapter formAnterior { get; set; }
        public FormsAdapter formSiguiente { get; set; }
        public int ID { get; set; }

        public FormsAdapter () {
            ID = 0;
        }

        protected void ejecutarQuery (SqlCommand command, DataGridView lista) {                            //TODO: Completar listas
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tabla);
            lista.DataSource = tabla;
        }


        protected int deshabilitar (string SP, int id){
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        protected int habilitar (string SP, int id) {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        protected Object valor (string texto) {
            if (!String.IsNullOrWhiteSpace(texto)) return texto;
            return DBNull.Value;
        }

        protected void volver () {
            formAnterior.Show();
            Close();
        }

        public virtual void configurar (IDominio elemento) {
        }
        public virtual void cargarDatos (IDominio elemento) {
        }
        public virtual void limpiar () {
        }

        private void InitializeComponent () {
            this.SuspendLayout();
            // 
            // FormsAdapter
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormsAdapter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}