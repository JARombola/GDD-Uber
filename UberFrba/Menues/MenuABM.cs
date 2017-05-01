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
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;

namespace UberFrba.Menues {
    public partial class MenuABM : FormsAdapter {
        private string tipo { get; set; }
       
        public MenuABM (String clase, FormsAdapter anterior) {
            InitializeComponent();
            tipo = clase;
            formAnterior = anterior;
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
                case "ROL": new frmCargaRol(this).Show();
                    this.Hide();
                    break;

                default: MessageBox.Show("ESTO NO DEBERIA HABER PASADO, MAL MENUES CARGA");
                    break;
            }
        }

        private void btnModif_Click (object sender, EventArgs e) {
            switch (tipo) {
                case "CLIENTE": 
                    FormsAdapter nuevo = new frmListaClientes(this);
                    nuevo.formSiguiente = new frmCargaCliente(this);
                    nuevo.Show();
                    this.Hide();
                    break;
                
                case "CHOFER": 
                    nuevo = new frmListaChoferes(this);
                    nuevo.formSiguiente = new frmCargaChofer(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                case "AUTO":
                    nuevo = new frmListaAutos(this);
                    nuevo.formSiguiente = new frmCargaAuto(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                case "TURNO": 
                    nuevo = new frmListaTurnos(this);
                    nuevo.formSiguiente = new frmCargaTurno(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                case "ROL":
                    nuevo = new frmModifRoles(this);
                    nuevo.formSiguiente = new frmCargaRol(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                default: MessageBox.Show("ESTO NO DEBERIA HABER PASADO, MAL MENUES MODIF");
                    break;
            }
            
            
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }
    }
}
