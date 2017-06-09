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

        public override void configurar (IDominio persona) {                    // Este metodo es usado por el Listado de Choferes
            this.Text = "Modificación Chofer";                                  // Por lo tanto, se quiere modificar un chofer => Se configuran los botones
            btnAceptar.Text = "Modificar";
            Persona chofer = (Persona) persona;
            btnHabilitacion.Text = chofer.habilitado?"Deshabilitar":"Habilitar";
            btnHabilitacion.Visible=true;
            btnClear.Visible=false;
            cargarDatos(chofer);
        }


        public override void cargarDatos (IDominio unChofer) {                  // Se cargan los datos del CHOFER que se desea modificar
            Persona chofer = (Persona) unChofer;
                txtApellido.Text = chofer.apellido;
                txtNombre.Text = chofer.nombre;
                txtDNI.Text = chofer.dni.ToString();
                txtMail.Text = chofer.mail;
                txtTel.Text = chofer.telefono.ToString();
                txtDire.Text = chofer.direccion;
                txtDepto.Text=chofer.dpto;
                txtLocalidad.Text = chofer.localidad;
                cbPiso.Value = chofer.piso;
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

        public override string errorCampos () {             // Verifica campos correctos
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
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaChofer");
            setParametros(ref cmd);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Chofer registrado correctamente", "Registro completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
        }

        private void modificarChofer () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifChofer");
            setParametros(ref cmd);
            cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Chofer actualizado correctamente", "Modificacion completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formAnterior.Show();
            this.Close();
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
                     new SqlParameter("@fecha_nacimiento",dateNacimiento.Value),
                     new SqlParameter("@mail",txtMail.Text)});
        }

        private void btnHabilitacion_Click (object sender, EventArgs e) {
            int ok;
            if (ID<0) {           //Deshabilitado => Hay que habilitar
                ok = base.habilitar("Chofer", Math.Abs(ID));
                if (ok>0) btnHabilitacion.Text="Deshabilitar";
            }
            else {
                ok =base.deshabilitar("Chofer", ID);
                if (ok>0) btnHabilitacion.Text="Habilitar";
            }
            ID*=-1;
        }

        public override void limpiar () {
            ID=-1;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            txtTel.Clear();
            txtDire.Clear();
            txtLocalidad.Clear();
            cbPiso.ResetText();
            txtDepto.ResetText();
            dateNacimiento.Value= DateTime.Now.Date;
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void frmCargaChofer_Load (object sender, EventArgs e) {
            dateNacimiento.MaxDate= DateTime.Now.Date;
            if (ID==-1) dateNacimiento.Value = DateTime.Now.Date;
        }

        private void btnClear_Click (object sender, EventArgs e) {
            limpiar();
        }
    }
}
