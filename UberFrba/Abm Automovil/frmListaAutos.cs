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
        public frmListAutomoviles () {
            InitializeComponent();
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().obtenerCommand("ASD");
                command.Parameters.AddWithValue("@modelo", valor(txtModelo.Text));
                command.Parameters.AddWithValue("@patente", valor(txtPatente.Text));
                command.Parameters.AddWithValue("@chofer", valor(txtChofer.Text));

            ejecutarQuery(command, dgListado);
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtChofer.Clear();
            txtModelo.Clear();
            txtPatente.Clear();
            dgListado.DataSource = null;
            dgListado.Refresh();
        }
    }
}
