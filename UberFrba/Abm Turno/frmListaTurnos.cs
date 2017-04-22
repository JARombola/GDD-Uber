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
            TABLA="Turnos";
        }

        private void button1_Click (object sender, EventArgs e) {
            txtDescripcion.Clear();
            dgTurnos.DataSource = null;
            dgTurnos.Refresh();
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            //TODO:                 CAMBIAR ESTO CUANDO SE ARMEN LAS TABLAS REALES
//          string query = TABLA +" Where Turno_Descripcion like '%"+valor(txtDescripcion.Text)+"%'";
            string query = "Select Turno_hora_inicio, Turno_descripcion"
                            +" FROM gd_esquema.Maestra Where Turno_Descripcion like '%"+valor(txtDescripcion.Text)+"%'";
            SqlCommand command= Buscador.getInstancia().getCommand(query);
            ejecutarQuery(command, dgTurnos);
        }

    }
}
