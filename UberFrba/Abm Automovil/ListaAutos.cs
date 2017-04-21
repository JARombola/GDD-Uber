using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;


namespace UberFrba.Abm_Automovil {
    public partial class frmListAutomoviles : ListadosAdapter {

        private String COLUMNA_PATENTE = "Patente";
        private String COLUMNA_MODELO = "Modelo";
        private String COLUMNA_MARCA = "Marca";
        private String COLUMNA_CHOFER = "Chofer";


        public frmListAutomoviles () {
            InitializeComponent();
            TABLA = "Automoviles";
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            base.ejecutarQuery(dgListado);
        }

        protected override String completarQuery(){
            String query = "SELECT * FROM "+ TABLA+" WHERE ";

            Boolean agregarOR = false,
                   concatenar=false;
            concatenar = quiereBuscar(txtPatente.Text, ref agregarOR, ref query);
            if (concatenar)
                query+=COLUMNA_PATENTE+" = '"+txtPatente.Text+"'";

            concatenar = quiereBuscar(txtModelo.Text, ref agregarOR, ref query);
            if (concatenar)
                query+=COLUMNA_MODELO+" LIKE '%"+txtModelo.Text+"%'";

            concatenar = quiereBuscar(cbMarca.Text, ref agregarOR, ref query);
            if (concatenar)
                query+=COLUMNA_MARCA+" = '"+cbMarca.Text+"'";

            concatenar = quiereBuscar(txtChofer.Text, ref agregarOR, ref query);
                query+=COLUMNA_CHOFER+" = "+txtChofer.Text+"'";             //TODO: REVISAR POR LA FK.

                return query;
        }

        private void btnClean_Click (object sender, EventArgs e) {
            ArrayList cajasTexto = new ArrayList();
                cajasTexto.Add(txtChofer);
                cajasTexto.Add(txtModelo);
                cajasTexto.Add(txtPatente);
            limpiar(cajasTexto);
        }
    }
}
