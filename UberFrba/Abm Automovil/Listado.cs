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
    public partial class FormListado : Form {
        private string tipoListado { get; set; }             //Automovil, Chofer, Clientes...
        private ArrayList columnasString { get; set; }
        private ArrayList columnasInt { get; set; }

        public FormListado () {
            InitializeComponent();
            //--------------PRUEBA
            tipoListado = "Datos_Animal";
            columnasString = new ArrayList();
            columnasInt = new ArrayList();
            columnasString.Add("Nombre");
            columnasInt.Add("Edad");

        }

        private void frmListado_Load (object sender, EventArgs e) {
            this.Text = "Listado "+tipoListado;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            Buscador b = Buscador.getInstancia();
            ManejoQuerys creadorQuerys = new ManejoQuerys();
            ArrayList todasColumnas = (ArrayList) columnasInt.Clone();
            todasColumnas.AddRange(columnasString);
            
            String query = "Select "+creadorQuerys.campos(todasColumnas) + "FROM "+tipoListado;
            Boolean agregarOR = false, agregarWhere=true, concatenar=false;

            concatenar = quiereBuscar(txtRelacionadas.Text, ref agregarWhere, ref agregarOR, ref query);    //busqueda Like
            if (concatenar) query+=creadorQuerys.concatenarBusquedaConLike(todasColumnas, txtRelacionadas.Text);
            
            concatenar = quiereBuscar(txtExacta.Text, ref agregarWhere, ref agregarOR, ref query);      //busqueda Exacta
            if (concatenar) {
                query+=creadorQuerys.concatenarBusquedaExactaStrings(columnasString, txtExacta.Text);
                int n;
                bool esNumero = int.TryParse(txtExacta.Text, out n);
                if (agregarOR && esNumero) query+=" OR ";
                if (esNumero) query+=creadorQuerys.concatenarBusquedaExactaInts(columnasInt, txtExacta.Text);
            }
            b.ejecutarQuery(query, dgListado);

        }

        private Boolean quiereBuscar(String palabra, ref Boolean agregarWhere, ref Boolean agregarOR, ref String query) {
            if (!string.IsNullOrEmpty(palabra)) {
                if (agregarWhere) query+= " WHERE ";
                agregarWhere= false;
                if (agregarOR) query+=" OR ";
                agregarOR=true;
                return true;
            }
            return false;
        }
    }
}
