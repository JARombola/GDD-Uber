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
        protected string TABLA;

        public void limpiar (ArrayList cajasTexto) {
            foreach (TextBox t in cajasTexto) {
                t.Clear();
            }
        }

        public Boolean quiereBuscar (String palabra, ref Boolean agregarOR, ref String query) {
            if (!string.IsNullOrEmpty(palabra)) {
                if (agregarOR) query+=" OR ";
                agregarOR=true;
                return true;
            }
            return false;
        }

        protected void ejecutarQuery (SqlCommand command, DataGridView lista) {                            //TODO: Completar listas

    /*    SqlDataReader datos = command.ExecuteReader();            // CARGA MANUAL? FEO

          if (datos.Read()) {
              //Cargar Lista
          }
     */
            ConfiguradorDG config = new ConfiguradorDG();
            config.completarDataGrid(lista, command);        }

        protected virtual string completarQuery () {
            throw new NotImplementedException();
        }
    }
}