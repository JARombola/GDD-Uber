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

        public frmListaTurnos () {
            InitializeComponent();
        }

        private void button1_Click (object sender, EventArgs e) {
            txtDescripcion.Clear();
            dgTurnos.DataSource = null;
            dgTurnos.Refresh();
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().obtenerCommand("ASD");
                command.Parameters.AddWithValue("@Descripcion", valor(txtDescripcion.Text));

            ejecutarQuery(command, dgTurnos);
        }

    }
}
