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
    public partial class frmCargaChofer : ModifAdapter{
        public frmCargaChofer () {
            InitializeComponent();
        }

        public override void prepararModificacion (IDominio cliente) {
            this.Text = "Modificar Cliente";
            btnAceptar.Text = "Modificar";
            btnEliminar.Visible=true;
            cargarDatosModificacion(cliente);
        }


        protected override void cargarDatosModificacion (IDominio unCliente) {
            Persona cliente = (Persona) unCliente;
            txtApellido.Text = cliente.apellido;
            txtNombre.Text = cliente.nombre;
            txtDNI.Text = cliente.dni.ToString();
            txtMail.Text = cliente.mail;
            txtTel.Text = cliente.telefono.ToString();
            txtDire.Text = cliente.direccion;
            txtCodPos.Text = cliente.codPost;
            dateNacimiento.Value = cliente.fecha_nacimiento;
        }

        private void frmCargaPersona_Load (object sender, EventArgs e) {

        }

        private void btnAceptar_Click (object sender, EventArgs e) {

        }

        private void limpiar () {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            txtTel.Clear();
            txtDire.Clear();
            txtCodPos.Clear();
            dateNacimiento.ResetText();
        }
    }
}
