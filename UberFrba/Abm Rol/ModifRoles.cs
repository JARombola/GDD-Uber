using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmModifRol_Load (object sender, EventArgs e) {
                                                //TODO: Cargar Roles.
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            cbRol.DropDownStyle = ComboBoxStyle.DropDown;
            btnModificar.Visible=true;
            MessageBox.Show(cbRol.SelectedIndex.ToString());
        }


    }
}
