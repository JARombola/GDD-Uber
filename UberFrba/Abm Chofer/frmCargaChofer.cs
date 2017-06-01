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

namespace UberFrba.Abm_Chofer {
    public partial class frmCargaChofer : FormsAdapter{
        
        public frmCargaChofer (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
        }

        public override void configurar (IDominio persona) {
            this.Text = "Modificación Chofer";
            btnAceptar.Text = "Modificar";
            Persona chofer = (Persona) persona;
            btnHabilitacion.Text = chofer.habilitado?"Deshabilitar":"Habilitar";
            btnHabilitacion.Visible=true;
            btnClear.Visible=false;
            cargarDatos(chofer);
        }


        public override void cargarDatos (IDominio unChofer) {
            Persona chofer = (Persona) unChofer;
            txtApellido.Text = chofer.apellido;
            txtNombre.Text = chofer.nombre;
            txtDNI.Text = chofer.dni.ToString();
            txtMail.Text = chofer.mail;
            txtTel.Text = chofer.telefono.ToString();
            txtDire.Text = chofer.direccion;
            dateNacimiento.Value = chofer.fecha_nacimiento;
            ID = chofer.id;
            if (!chofer.habilitado) ID*=-1;         // Solo importa para la habilitacion
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            String errorDatos = errorCampos();
            if (errorDatos == null) {
                try {
                    if (ID==-1) registrarChofer();          //NO hay un ID asociado ====> Es un registro
                    else modificarChofer();
                    MessageBox.Show("Chofer registrado correctamente", "Operacion correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                catch (SqlException error) {
                    switch (error.Number) {
                        case 2627: MessageBox.Show("El DNI ya se encuentra registrado", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);    //Violacion de restriccion UNIQUE 
                            break;
                        case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;        //ERROR de conversion de datos
                    }
                }
            } else MessageBox.Show(errorDatos, "Error Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override string errorCampos () {
            String errores =null;
            int asd;
            if (String.IsNullOrWhiteSpace(txtNombre.Text)) errores+="- El campo 'Nombre' no puede estar vacío \n";
            if (String.IsNullOrWhiteSpace(txtApellido.Text)) errores+="- El campo 'Apellido' no puede estar vacío\n";
            if (!int.TryParse(txtDNI.Text, out asd)) errores+="- El 'DNI' debe ser numérico \n";
            if (String.IsNullOrWhiteSpace(txtMail.Text)) errores+="- El campo 'Mail' no puede estar vacío\n";
            if (!int.TryParse(txtTel.Text, out asd)) errores+="- El 'Teléfono' debe ser numérico\n";
            if (String.IsNullOrWhiteSpace(txtDire.Text)) errores+="- El campo 'Direccion' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(txtDepto.Text)) errores+="- El campo 'Depto' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(txtLocalidad.Text)) errores+="- El campo 'Localidad' no puede estar vacío\n";
            return errores;
        }

        private void registrarChofer () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaCliente");
            setParametros(ref cmd);
            cmd.ExecuteNonQuery();
        }

        private void modificarChofer () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifChofer");
            setParametros(ref cmd);
            cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
            cmd.ExecuteNonQuery();
        }


        private void setParametros (ref SqlCommand command) {
            command.Parameters.AddRange(new[]
                    {new SqlParameter("@nombre",txtNombre.Text),
                     new SqlParameter("@apellido",txtApellido.Text),
                     new SqlParameter("@dni",txtDNI.Text),
                     new SqlParameter("@telefono",txtTel.Text),                     
                      new SqlParameter("@direccion",txtDire.Text),
                     new SqlParameter("@piso",cbPiso.Value),
                     new SqlParameter("@depto",txtDepto.Text),
                     new SqlParameter("@localidad",txtLocalidad.Text),
                     new SqlParameter("@mail",txtMail.Text)});
        }

        private void btnHabilitacion_Click (object sender, EventArgs e) {
            SqlCommand command;
            if (ID<0)           //Deshabilitado => Hay que habilitar
                command = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitarChofer");
            else command = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitarChofer");
            command.Parameters.AddWithValue("@id", Math.Abs(ID));
            int resultado = command.ExecuteNonQuery();
            MessageBox.Show("Actualizados: "+resultado);
            volver();
        }

        public override void limpiar () {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            txtTel.Clear();
            txtDire.Clear();
            dateNacimiento.Value= dateNacimiento.MinDate;
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void frmCargaChofer_Load (object sender, EventArgs e) {
            dateNacimiento.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
            dateNacimiento.Value = dateNacimiento.MinDate;
        }

        private void btnClean_Click (object sender, EventArgs e) {
            limpiar();
        }

        private void exit (object sender, FormClosedEventArgs e) {
            base.cerrar(sender,e);
        }
    }
}
