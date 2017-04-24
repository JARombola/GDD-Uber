using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class frmCargaPersona : ModifAdapter
    {
        public frmCargaPersona(String tipo)             //tipo = "Chofer / Cliente"
        {
            InitializeComponent();
            this.Text += tipo;
        }

       public override void prepararModificacion (IDominio persona) {
           btnAceptar.Text = "Modificar";
           btnEliminar.Visible=true;
           cargarDatosModificacion(persona);
       }


       protected override void cargarDatosModificacion (IDominio persona) {
            Persona p = (Persona) persona;
            txtApellido.Text = p.apellido;
            txtNombre.Text = p.nombre;
            txtDNI.Text = p.dni.ToString();
            txtMail.Text = p.mail;
            txtTel.Text = p.telefono.ToString();
            txtDire.Text = p.direccion;
            txtCodPos.Text = p.codPost;
            dateNacimiento.Value = p.fecha_nacimiento;
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
