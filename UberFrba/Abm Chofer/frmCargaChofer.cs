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

namespace UberFrba.Abm_Chofer {
    public partial class frmCargaChofer : CargasAdapter{
        
        public frmCargaChofer (Form anterior) {
            InitializeComponent();
            frmAnterior = anterior;
        }

        public override void prepararModificacion (IDominio persona) {
            this.Text = "Modificación Chofer";
            btnAceptar.Text = "Modificar";
            Persona chofer = (Persona) persona;
            btnHabilitacion.Text = chofer.habilitado?"Deshabilitar":"Habilitar";
            btnHabilitacion.Visible=true;
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
            if (!chofer.habilitado) ID*=-1;         // Solo importa para la habilitacion
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            if (ID==-1) registrarChofer();          //NO hay un ID asociado ====> Es un registro
            else modificarChofer();
            volver();
        }

        private void registrarChofer () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaCliente");
            setParametros(ref cmd);
            int p=cmd.ExecuteNonQuery();
            MessageBox.Show("Agregados = "+p);
        }

        private void modificarChofer () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifChofer");
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
            dateNacimiento.ResetText();
        }

    }
}
