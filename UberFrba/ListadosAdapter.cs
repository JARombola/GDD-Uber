using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;

namespace UberFrba {
    public partial class ListadosAdapter : Form {
        
        protected string  TABLA{ get; set; }

        protected void ejecutarQuery (SqlCommand command, DataGridView lista) {                            //TODO: Completar listas

    /*    SqlDataReader datos = command.ExecuteReader();            // CARGA MANUAL? FEO

          if (datos.Read()) {
              //Cargar Lista
          }
     */
            ConfiguradorDG config = new ConfiguradorDG();
            config.completarDataGrid(lista, command);        
        }

        protected Object valor (string texto) {
            if (!String.IsNullOrWhiteSpace(texto)) return texto;
            return DBNull.Value;
        }
    }
}