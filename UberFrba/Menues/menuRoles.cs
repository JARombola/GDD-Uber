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
    public partial class menuRoles : Form {

        public menuRoles (ArrayList roles) {
            InitializeComponent();
            foreach (string rol in roles){
                cbRol.Items.Add(rol);
            }
        }

        private void button1_Click (object sender, EventArgs e) {
            new MenuInicial(cbRol.SelectedItem.ToString()).Show();
            this.Close();
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            btnIngresar.Enabled=true;
        }
    }
}
