using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;
using UberFrba.Dominio;

namespace UberFrba.Abm_Automovil {
    public partial class frmCargaAutos : ModifAdapter {
        
        public frmCargaAutos () {
            InitializeComponent();
            TABLA = "gd_esquema.Maestra";
            Buscador.getInstancia().cargarMarcas(cbMarca,TABLA);            
        }


        public override void prepararModificacion (IDominio auto) {
            btnAceptar.Text = "Modificar Auto";
            btnEliminar.Visible=true;
            cargarDatosModificacion(auto);
        }

        protected override void cargarDatosModificacion (IDominio unAuto) {
            Auto auto = (Auto) unAuto;
            cbMarca.Text = auto.marca;
            txtModelo.Text = auto.modelo;
            txtPatente.Text = auto.patente;
            txtLicencia.Text = auto.licencia;
            // buscarTurno();
            // buscarChofer();
        }

        private void frmCargaAutos_Load (object sender, EventArgs e) {
       
        }

        private void btnEliminar_Click (object sender, EventArgs e) {

        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            if (cbMarca.SelectedItem == null) MessageBox.Show("VACIO");
            else
            MessageBox.Show(cbMarca.SelectedItem.ToString());
        }
    }
}
