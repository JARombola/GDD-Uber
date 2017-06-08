using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dominio;

namespace UberFrba.Abm_Cliente
{
    public partial class frmCargaCliente : FormsAdapter
    {
        public frmCargaCliente(Form anterior)             
        {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
        }

       public override void configurar (IDominio persona) {                 //Este metodo es invocado desde los listados => Se trata de una modificacion
           this.Text = "Modificación Cliente";
           btnAceptar.Text = "Modificar";
           Persona cliente = (Persona) persona;
           btnHabilitacion.Text = cliente.habilitado?"Deshabilitar":"Habilitar";
           btnHabilitacion.Visible=true;
           btnClear.Visible=false;
           cargarDatos(cliente);
       }


       public override void cargarDatos (IDominio unCliente) {                  // Carga los textBox con los datos existentes del Cliente (para modificacion)
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
           string errorDatos =errorCampos();
           if (errorDatos==null) {
               try {
                   if (ID==-1) registrarCliente();          //NO hay un ID asociado ====> Es un registro
                   else modificarCliente();
                   MessageBox.Show("Cliente registrado correctamente", "Operacion correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   limpiar();
               }
               catch (SqlException error) {
                   switch (error.Number) {
                       case 2627: MessageBox.Show("El TELEFONO ya se encuentra registrado", "Teléfono Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);    //Violacion de restriccion UNIQUE 
                                  break;                        
                       case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;        //ERROR de conversion de datos
                   }
               }
           }
           else MessageBox.Show(errorDatos, "Error Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }

       public override string errorCampos() {
           String errores =null;
           int asd;
           if (String.IsNullOrWhiteSpace(txtNombre.Text)) errores+="- El campo 'Nombre' no puede estar vacío \n";
           if (String.IsNullOrWhiteSpace(txtApellido.Text)) errores+="- El campo 'Apellido' no puede estar vacío\n";
           if (!int.TryParse(txtDNI.Text, out asd)) errores+="- El 'DNI' debe ser numérico \n";
           if (!int.TryParse(txtTel.Text, out asd)) errores+="- El 'Teléfono' debe ser numérico\n";
           if (String.IsNullOrWhiteSpace(txtDire.Text)) errores+="- El campo 'Direccion' no puede estar vacío\n";
           if (String.IsNullOrWhiteSpace(txtDepto.Text)) errores+="- El campo 'Depto' no puede estar vacío\n";
           if (String.IsNullOrWhiteSpace(txtLocalidad.Text)) errores+="- El campo 'Localidad' no puede estar vacío\n";
           return errores;
       }

       private void registrarCliente () {
           SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaCliente");
               setParametros(ref cmd);
               cmd.ExecuteNonQuery();
           }

       private void modificarCliente () {
           SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifCliente");
               setParametros(ref cmd);
               cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
       }


       private void setParametros (ref SqlCommand command) {
           command.Parameters.AddRange(new[]
                    {new SqlParameter("@nombre",valor(txtNombre.Text)),
                     new SqlParameter("@apellido",valor(txtApellido.Text)),
                     new SqlParameter("@dni",valor(txtDNI.Text)),
                     new SqlParameter("@telefono",valor(txtTel.Text)),                     
                     new SqlParameter("@direccion",valor(txtDire.Text)),
                     new SqlParameter("@piso",cbPiso.Value),
                     new SqlParameter("@depto",valor(txtDepto.Text)),
                     new SqlParameter("@localidad",valor(txtLocalidad.Text)),
                     new SqlParameter("@mail",valor(txtMail.Text))});
            }

       public override void limpiar () {
           txtApellido.Clear();
           txtNombre.Clear();
           txtDNI.Clear();
           txtMail.Clear();
           txtTel.Clear();
           txtDire.Clear();
           dateNacimiento.Value = dateNacimiento.MinDate;
       }

       private void btnHabilitacion_Click (object sender, EventArgs e) {
           int ok;
           if (ID<0) {           //Deshabilitado => Hay que habilitar
               ok = base.habilitar("Cliente", Math.Abs(ID));
               if (ok>0) btnHabilitacion.Text="Deshabilitar";
           }
           else {
               ok =base.deshabilitar("Cliente", ID);
               if (ok>0) btnHabilitacion.Text="Habilitar";
           }
           ID*=-1;
       }

       private void btnVolver_Click (object sender, EventArgs e) {
           base.volver();
       }

       private void frmCargaCliente_Load (object sender, EventArgs e) {
           dateNacimiento.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
           dateNacimiento.Value = dateNacimiento.MinDate;
       }

       private void btnClear_Click (object sender, EventArgs e) {
           limpiar();
       }
        
    }
}
