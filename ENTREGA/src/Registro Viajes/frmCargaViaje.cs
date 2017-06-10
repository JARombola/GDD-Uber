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
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Dominio;

namespace UberFrba.Registro_Viajes
{
    public partial class frmCargaViaje : FormsAdapter
    {
        private int choferId, autoId, clienteId;
        private bool buscaChofer=false;

        public frmCargaViaje(FormsAdapter anterior){
            InitializeComponent();
            formAnterior = anterior;
            FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
            fecha.MaxDate = FECHA_ACTUAL;
            fecha.Value = FECHA_ACTUAL;
        }

        private void frmCargaViaje_Load (object sender, EventArgs e) {
            txtKms.Maximum=Decimal.MaxValue;
        }

        private void btnRegistrar_Click (object sender, EventArgs e) {
            String errorDatos = errorCampos();
            if (errorDatos == null) {
                    try{
                        registrarViaje();
                        MessageBox.Show("Viaje registrado correctamente","Viaje registrado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        limpiar();
                    }
                    catch(SqlException error){
                        switch(error.Number){
                            case 51000: MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                            case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;        //ERROR de conversion de datos
                        }
                    }
                }
            else MessageBox.Show(errorDatos, "Error Datos", MessageBoxButtons.OK, MessageBoxIcon.Error); 
       }

        public override string errorCampos(){
            String errores = null;
            if (txtKms.Value == 0) errores += "- La cantidad de kms. debe ser distinta de 0 \n";
            if (horaInicio.Value >= horaFin.Value) errores += "- La hora de inicio no puede ser menor que la de fin\n";
            return errores;
        }

        private void registrarViaje () {
            DateTime date = fecha.Value.AddHours(horaInicio.Value.Hour).AddMinutes(horaInicio.Value.Minute);

            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaViaje");
            command.Parameters.AddRange(new[]{
                    new SqlParameter ("@idChofer",choferId),
                    new SqlParameter ("@idAuto",autoId),
                    new SqlParameter ("@kms",txtKms.Value),
                    new SqlParameter ("@fecha",date),
                    new SqlParameter ("@idCliente",clienteId),
                    new SqlParameter ("@horaFin",horaFin.Value)});
                command.ExecuteNonQuery();            
            }



        public override void configurar (IDominio unaPersona) {             //Los forms de busqueda usan este método para devolver los datos
            Persona persona = (Persona) unaPersona;
            if (buscaChofer) {
                configChofer(persona);
                buscaChofer=false;
            }
            else configCliente(persona);
        }

        private void configChofer (Persona chofer) {                //Acá se cargan los datos del chofer que envió el form de busqueda
            choferId = chofer.id;
            txtChofer.Text = chofer.nombre+" "+chofer.apellido+" ("+chofer.dni+")";
            infoCampo.SetToolTip(txtChofer, String.Format("{0} {1}\n-DNI: {2}\n-Direccion: {3}\n-Teléfono: {4}\n-Mail: {5}", chofer.nombre, chofer.apellido, chofer.dni, chofer.direccion, chofer.telefono, chofer.mail));
            buscarAuto();
        }

        private void buscarAuto () {                                // Acá se buscá el auto que el chofer tiene asignado en ese momento y se carga automaticamente (Si esta habilitado)
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getAutoDelChofer(@idChofer)");
            command.Parameters.AddWithValue("@idChofer", choferId);
            SqlDataReader datosAuto = command.ExecuteReader();
            datosAuto.Read();
            if (datosAuto.HasRows) {                                //Si tiene auto asignado y habilitado
                txtAuto.Text = datosAuto["marca"].ToString() +" "+datosAuto["modelo"].ToString()+"("+datosAuto["patente"]+")";
                infoCampo.SetToolTip(txtAuto, String.Format("-Marca: {0}\n-Modelo: {1}\n-Patente: {2}\n-Licencia: {3}\n-Rodado: {4}\n-Turno:{5}hs-{6}hs",
                    datosAuto["marca"].ToString(), datosAuto["modelo"].ToString(), datosAuto["patente"], datosAuto["licencia"], datosAuto["Rodado"], datosAuto["Hora_Inicio"], datosAuto["Hora_Fin"]));
                txtAuto.Cursor=Cursors.IBeam;
                autoId = (int) datosAuto["ID"];
            }
            else {                                                  //No tiene auto o está deshabilitado
                MessageBox.Show("El chofer no tiene ningún auto habilitado.\nNo podrá registrarse el viaje.", "Chofer sin autos habilitados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                choferId=0;
                txtChofer.Clear();
            }
            datosAuto.Close();
        }

        private void configCliente (Persona cliente) {                  // Configura para mostrar los datos del cliente
            clienteId = cliente.id;
            txtCliente.Text = cliente.nombre+" "+cliente.apellido;
            infoCampo.SetToolTip(txtCliente, String.Format("{0} {1}\n-DNI: {2}\n-Direccion: {3}\n-Teléfono: {4}\n-Mail: {5}", cliente.nombre, cliente.apellido, cliente.dni, cliente.direccion, cliente.telefono, cliente.mail));
        }

        //----------------------------------------- BOTONES---------------------------------------------------------------

        private void button1_Click (object sender, EventArgs e) {
            frmListaChoferes seleccionChofer = new frmListaChoferes(this);
            seleccionChofer.soloHabilitados = true;
            seleccionChofer.formSiguiente = this;
            buscaChofer=true;
            seleccionChofer.Show();
            this.Hide();
        }


        private void btnCliente_Click (object sender, EventArgs e) {
            frmListaClientes busquedaCliente = new frmListaClientes(this);
            busquedaCliente.formSiguiente = this;
            busquedaCliente.soloHabilitados = true;
            busquedaCliente.Show();
            this.Hide();
        }


        private void txtAuto_TextChanged (object sender, EventArgs e) {             // Actualiza el label con la cantidad de resultados obtenidos
            if (!String.IsNullOrEmpty(txtCliente.Text)) btnRegistrar.Enabled=true;
        }

        private void txtCliente_TextChanged (object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(txtAuto.Text)) btnRegistrar.Enabled=true;
        }


        private void btnAtras_Click (object sender, EventArgs e) {
            base.volver();
        }

    }
}
