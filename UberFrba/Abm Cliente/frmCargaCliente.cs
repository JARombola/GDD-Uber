using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;

namespace UberFrba.Abm_Cliente
{
    public partial class frmCargaCliente : CargasAdapter
    {
        public frmCargaCliente()             
        {
            InitializeComponent();
            ID = 2;
        }

       public override void prepararModificacion (IDominio persona) {
           this.Text = "Modificar Cliente";
           btnAceptar.Text = "Modificar";
           btnEliminar.Visible=true;
           cargarDatosModificacion(persona);
       }


       protected override void cargarDatosModificacion (IDominio unCliente) {
            Persona cliente = (Persona) unCliente;
            txtApellido.Text = cliente.apellido;
            txtNombre.Text = cliente.nombre;
            txtDNI.Text = cliente.dni.ToString();
            txtMail.Text = cliente.mail;
            txtTel.Text = cliente.telefono.ToString();
            txtDire.Text = cliente.direccion;
            dateNacimiento.Value = cliente.fecha_nacimiento;
            ID = cliente.id;
        }

       private void frmCargaPersona_Load (object sender, EventArgs e) {

       }

       private void btnAceptar_Click (object sender, EventArgs e) {
          // if (ID==-1) registrarCliente();          //NO hay un ID asociado ====> Es un registro
          // else modificarCliente();
           SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_bajaCliente");
           cmd.Parameters.AddWithValue("@id", 2);
           cmd.ExecuteNonQuery();
       }

       private void registrarCliente () {
           SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaCliente");
               setParametros(ref cmd);
           int p=cmd.ExecuteNonQuery();
           MessageBox.Show("Agregados = "+p);
       }

       private void modificarCliente () {
           SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifCliente");
               setParametros(ref cmd);
               cmd.Parameters.AddWithValue("@id", ID);
           int p = cmd.ExecuteNonQuery();
           MessageBox.Show("Modificados = "+ p);
       }


       private void setParametros (ref SqlCommand command) {
           command.Parameters.AddRange(new[]
                    {new SqlParameter("@nombre",valor(txtNombre.Text)),
                     new SqlParameter("@apellido",valor(txtApellido.Text)),
                     new SqlParameter("@direccion",valor(txtDire.Text)),
                     new SqlParameter("@dni",valor(txtDNI.Text)),
                     new SqlParameter("@mail",valor(txtMail.Text)),
                     new SqlParameter("@telefono",valor(txtTel.Text)),
                     new SqlParameter("@fecha_nacimiento",dateNacimiento.Value)
                }
                );
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
    }
}
