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
        public frmCargaCliente(Form anterior)             
        {
            InitializeComponent();
            frmAnterior = anterior;
        }

       public override void prepararModificacion (IDominio persona) {
           this.Text = "Modificación Cliente";
           btnAceptar.Text = "Modificar";
           Persona cliente = (Persona) persona;
           btnHabilitacion.Text = cliente.habilitado?"Deshabilitar":"Habilitar";
           btnHabilitacion.Visible=true;
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
            dateNacimiento.Value = cliente.fecha_nacimiento;
            ID = cliente.id;
            if (!cliente.habilitado) ID*=-1;            // Solo importa para la habilitacion/deshabilitacion
        }

       private void btnAceptar_Click (object sender, EventArgs e) {
           if (ID==-1) registrarCliente();          //NO hay un ID asociado ====> Es un registro
           else modificarCliente();
           volver();
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
               cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
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

       private void btnHabilitacion_Click (object sender, EventArgs e) {
           SqlCommand command ;
           if (ID<0)           //Deshabilitado => Hay que habilitar
               command = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitarCliente");
           else command = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitarCliente");
           command.Parameters.AddWithValue("@id", Math.Abs(ID));
           int resultado = command.ExecuteNonQuery();
           MessageBox.Show("Actualizados: "+resultado);
           volver();
       }

    }
}
