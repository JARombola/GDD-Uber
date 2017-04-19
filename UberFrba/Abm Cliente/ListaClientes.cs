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


namespace UberFrba.Abm_Cliente{
    public partial class frmListClientes : ListadosAdapter {
            //PARA CONSULTAS A LA BASE..........
        private String COLUMNA_DNI = "DNI";
        private String COLUMNA_NOMBRE = "NOMBRE";
        private String COLUMNA_APELLIDO = "APELLIDO";

        public frmListClientes () {
            InitializeComponent();
            //--------------PRUEBA
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            Buscador b = Buscador.getInstancia();
            ManejoQuerys creadorQuerys = new ManejoQuerys();
            Boolean agregarOR=false, concatenar=false;

            String query = "SELECT * FROM cliente WHERE ";

            concatenar = quiereBuscar(txtNombre.Text, ref agregarOR, ref query);
            if (concatenar) 
                query+=COLUMNA_NOMBRE+" LIKE '%"+txtNombre.Text+"%'";

            concatenar = quiereBuscar(txtApellido.Text, ref agregarOR, ref query);
                if (concatenar) 
                    query+=COLUMNA_APELLIDO+" LIKE '%"+txtApellido.Text+"%'";

            concatenar = quiereBuscar(txtDNI.Text, ref agregarOR, ref query);
                if (concatenar) 
                    query+=COLUMNA_DNI+" = '"+txtDNI.Text+"'";

            MessageBox.Show(query);
            //b.ejecutarQuery(query, dgListado);

        }

        private void btnClean_Click (object sender, EventArgs e) {
            ArrayList cajasTexto = new ArrayList();
                cajasTexto.Add(txtApellido);
                cajasTexto.Add(txtDNI);
                cajasTexto.Add(txtNombre);
            limpiar(cajasTexto);
        }
    }
}
