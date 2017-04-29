using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menues {
    public partial class MenuInicial : FormsAdapter {
        public MenuInicial (string rol) {
            InitializeComponent();
        }

        private void btnClientes_Click (object sender, EventArgs e) {
            new MenuABM("CLIENTE").Show();
            this.Hide();
        }

        private void btnChoferes_Click (object sender, EventArgs e) {
            new MenuABM("CHOFER").Show();
            this.Hide();
        }

        private void btnAutos_Click (object sender, EventArgs e) {
            new MenuABM("AUTO").Show();
            this.Hide();
        }

        private void btnTurnos_Click (object sender, EventArgs e) {
            new MenuABM("TURNO").Show();
            this.Hide();
        }
    }
}
