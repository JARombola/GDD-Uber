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
using UberFrba.Abm_Usuario;
using UberFrba.Abm_Turno;

namespace UberFrba.Menues {
    public partial class MenuABM : FormsAdapter {
        private string tipo { get; set; }
       
        public MenuABM (String clase, FormsAdapter anterior) {          // El menú envia como string, el nombre de la "entidad" (chofer, auto, cliente, turno) que se va a "consultar" (alta/baja/modificacion)
            InitializeComponent();
            tipo = clase;
            formAnterior = anterior;
            Text=clase;
        }

        private void btnCarga_Click (object sender, EventArgs e) {                  // Conocemos la "clase" a dar de alta => sabemos que form (carga) hay que mostrar para dar de Alta
            switch (tipo.ToUpper()) {
                case "CLIENTES": new frmCargaCliente(this).Show();
                    this.Hide();
                    break;
                case "CHOFERES": new frmCargaChofer(this).Show();
                    this.Hide();
                    break;
                case "AUTOS": new frmCargaAuto(this).Show();
                    this.Hide();
                    break;
                case "TURNOS": new frmCargaTurno(this).Show();
                    this.Hide();
                    break;

                default: throw new Exception("Error en menu ABM");
            }
        }

        private void btnModif_Click (object sender, EventArgs e) {                  // Conocemos la "clase" a modificar => sabemos que form (listado) hay que mostrar para seleccionar
            switch (tipo.ToUpper()) {
                case "CLIENTES": 
                    FormsAdapter nuevo = new frmListaClientes(this);
                    nuevo.formSiguiente = new frmCargaCliente(this);
                    nuevo.Show();
                    this.Hide();
                    break;
                
                case "CHOFERES": 
                    nuevo = new frmListaChoferes(this);
                    nuevo.formSiguiente = new frmCargaChofer(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                case "AUTOS":
                    nuevo = new frmListaAutos(this);
                    nuevo.formSiguiente = new frmCargaAuto(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                case "TURNOS": 
                    nuevo = new frmListaTurnos(this);
                    nuevo.formSiguiente = new frmCargaTurno(this);
                    nuevo.Show();
                    this.Hide();
                    break;

                default: throw new Exception("Error en menu modificacion");
            }
            
            
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            base.volver();
        }
    }
}
