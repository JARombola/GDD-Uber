using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;

namespace UberFrba.Menues {
    public partial class MenuABM : FormsAdapter {
        private string tipo { get; set; }
       
        public MenuABM (String clase) {
            InitializeComponent();
            tipo = clase;
        }

        private void btnCarga_Click (object sender, EventArgs e) {
            switch (tipo) {
                case "CLIENTE": new frmCargaCliente(this).Show();
                    this.Hide();            
                    break;
                case "CHOFER": new frmCargaChofer(this).Show();
                    this.Hide();
                    break;
                case "AUTO": new frmCargaAuto(this).Show();
                    this.Hide();
                    break;
                case "TURNO": new frmCargaTurno(this).Show();
                    this.Hide();
                    break;
                default: MessageBox.Show("ESTO NO DEBERIA HABER PASADO, MAL MENUES CARGA");
                    break;
            }
        }

        private void btnModif_Click (object sender, EventArgs e) {
            switch (tipo) {
                case "CLIENTE": new frmListaClientes(this).Show();
                    this.Hide();
                    break;
                case "CHOFER": new frmListaChoferes(new frmCargaChofer(this)).Show();       //Es raro, no importa.... :)
                    this.Hide();
                    break;
                case "AUTO": new frmListaAutos(this).Show();
                    this.Hide();
                    break;
                case "TURNO": new frmListaTurnos(this).Show();
                    this.Hide();
                    break;
                default: MessageBox.Show("ESTO NO DEBERIA HABER PASADO, MAL MENUES MODIF");
                    break;
            }
            
            
        }
    }
}
