using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menues {
    public partial class menuRoles : FormsAdapter {

        public menuRoles (ArrayList roles) {                // Carga los roles del usuario para que seleccione uno
            InitializeComponent();
            foreach (string rol in roles){
                cbRol.Items.Add(rol);
            }
        }

        private void button1_Click (object sender, EventArgs e) {                   // Envia el nombre del rol para que el MenuInicial actualice los botones segun funcionalidades
            new MenuInicial(cbRol.SelectedItem.ToString()).Show();
            this.Close();
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            btnIngresar.Enabled=true;
        }

        private void button1_Click_1 (object sender, EventArgs e) {
            Login.mostrar();
            this.Close();
        }
    }
}
