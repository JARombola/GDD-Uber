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

namespace UberFrba.Abm_Turno {
    public partial class frmListaTurnos : ListadosAdapter {
        private string COLUMNA_DESCRIPCION = "descripcion";

        public frmListaTurnos () {
            InitializeComponent();
            TABLA = "Turnos";
        }

        private void button1_Click (object sender, EventArgs e) {
            ArrayList cajasTexto = new ArrayList();
                cajasTexto.Add(txtDescripcion);
            limpiar(cajasTexto);
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().obtenerCommand("ASD");
            //            config.completarDataGrid(dataGrid, command);
            command.Parameters.AddWithValue("@param", null);

            ejecutarQuery(command, dgTurnos);
        }

        protected override String completarQuery () {
            String query = "SELECT * FROM "+TABLA+" WHERE ";
            if (!String.IsNullOrEmpty( txtDescripcion.Text))
                query+=COLUMNA_DESCRIPCION+" LIKE '%"+txtDescripcion.Text+"%'";
            return query;
        }
}
}
