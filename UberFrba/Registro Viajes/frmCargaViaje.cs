using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class frmCargaViaje : Form
    {
        public frmCargaViaje()
        {
            InitializeComponent();

        }

        private void frmCargaViaje_Load (object sender, EventArgs e) {
            txtKms.Maximum=Decimal.MaxValue;
        }

    }
}
