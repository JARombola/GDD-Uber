using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer {
    public partial class frmCargaChofer : CargasAdapter{
        public frmCargaChofer () {
            InitializeComponent();
        }

        public override void prepararModificacion (IDominio chofer) {
            this.Text = "Modificar Chofer";
            btnAceptar.Text = "Modificar";
            btnEliminar.Visible=true;
            cargarDatosModificacion(chofer);
        }


        protected override void cargarDatosModificacion (IDominio unChofer) {
            Persona chofer = (Persona) unChofer;
            txtApellido.Text = chofer.apellido;
            txtNombre.Text = chofer.nombre;
            txtDNI.Text = chofer.dni.ToString();
            txtMail.Text = chofer.mail;
            txtTel.Text = chofer.telefono.ToString();
            txtDire.Text = chofer.direccion;
            dateNacimiento.Value = chofer.fecha_nacimiento;
            ID = chofer.id;
        }

        private void frmCargaPersona_Load (object sender, EventArgs e) {

        }

        private void btnAceptar_Click (object sender, EventArgs e) {

        }

        public override void limpiar () {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            txtTel.Clear();
            txtDire.Clear();
            dateNacimiento.ResetText();
        }

        private void frmCargaChofer_Load (object sender, EventArgs e) {

        }
    }
}
