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
using UberFrba.Abm_Usuarios;

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

        private void button3_Click (object sender, EventArgs e) {
            new frmAltaUsuario(this).Show();
            this.Hide();
        }

        private void button2_Click (object sender, EventArgs e) {
            new frmModifUsuario(this).Show();
            this.Hide();
        }
    }
}
