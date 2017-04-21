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


namespace UberFrba.Abm_Chofer{
    public partial class frmListChofer : ListadosAdapter {

        public frmListChofer () {
            InitializeComponent();
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().obtenerCommand("ASD");
                command.Parameters.AddWithValue("@Apellido", valor(txtApellido.Text));
                command.Parameters.AddWithValue("@Nombre", valor(txtNombre.Text));
                command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

            ejecutarQuery(command, dgListado);
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtApellido.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            dgListado.DataSource = null;
            dgListado.Refresh();
        }
    }
}
