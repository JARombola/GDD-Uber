using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dominio;

namespace UberFrba.Abm_Automovil {
    public partial class frmCargaAutos : ModifAdapter {
        public frmCargaAutos () {
            InitializeComponent();
        }

        public override void cargarDatosModificacion (IDominio unAuto) {
            Auto auto = (Auto) unAuto;
            //TODO: Cargar textbox con los datos que vengan de la ventana de seleccion
        }

        private void frmCargaAutos_Load (object sender, EventArgs e) {

        }
    }
}
