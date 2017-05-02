using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Usuario;

namespace UberFrba.Menus {
    public partial class MenuABMRol : FormsAdapter {
        public MenuABMRol (FormsAdapter anterior) {
            InitializeComponent();
            formAnterior = anterior;
        }

        private void btnAlta_Click (object sender, EventArgs e) {
            new frmCargaRol(this).Show();
            this.Hide();
        }

        private void btnModif_Click (object sender, EventArgs e) {
            new frmModifRol(this).Show();
            this.Hide();
        }

        private void btnAsignar_Click (object sender, EventArgs e) {
            new frmAsignarRoles(this).Show();
            this.Hide();
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }
    }
}
