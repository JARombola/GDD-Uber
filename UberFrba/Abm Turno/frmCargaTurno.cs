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
using UberFrba.Dominio;

namespace UberFrba.Abm_Turno {
    public partial class frmCargaTurno : FormsAdapter {
        public frmCargaTurno (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
            precioBase.Maximum = decimal.MaxValue;
            precioKm.Maximum = decimal.MaxValue;
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            String errorDatos = errorCampos();
            if (errorDatos == null) {
                try {
                    if (ID == -1) registrarTurno();
                    else modificarTurno();
                    MessageBox.Show("Turno registrado correctamente", "Operacion completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                catch (SqlException error) {
                    switch (error.Number) {
                        case 51000: MessageBox.Show(null, error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;        //ERROR de conversion de datos
                    }
                }
            } else MessageBox.Show(errorDatos, "Error Datos", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        public override string errorCampos () {
            String errores=null;
            if (horaInicio.Value>horaFin.Value) errores+="- La hora de inicio debe ser menor que la de fin\n";
            if (String.IsNullOrEmpty(txtDescripcion.Text)) errores+="- La descripción no puede estar vacía\n";
            return errores;
        }

        private void registrarTurno(){
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaTurno");
            setearParametros(ref command);
            command.ExecuteNonQuery();
        }

        private void modificarTurno () {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_modifTurno");
            command.Parameters.AddWithValue("@id", ID);                         //Necesito agregarle el ID porque es una modificacion
            command.ExecuteNonQuery();
        }

        private void setearParametros (ref SqlCommand command) {
            command.Parameters.AddRange(new[] {
                new SqlParameter ("@inicio", horaInicio.Value),
                new SqlParameter ("@fin", horaFin.Value),
                new SqlParameter ("@precioBase", precioBase.Value),
                new SqlParameter ("@precioKm", precioKm.Value),
                new SqlParameter ("@descripcion", txtDescripcion.Text),
                new SqlParameter ("@habilitado", chkHabilitado.Checked)}
            );
        }


        public override void configurar (IDominio unTurno) {                //El listado de Turnos usa este formulario para indicar que es una Modiicacion
            this.Text="Modificación Turno";                                 // Envia como parametro un "Turno" (sus datos)
            btnAceptar.Text = "Modificar";
            Turno turnito = (Turno) unTurno;
            chkHabilitado.Checked = turnito.habilitado;
            btnClear.Visible=false;
            cargarDatos(turnito);
        }

        public override void cargarDatos (IDominio unTurno) {              // Se completa el formulario con los datos del Turno recibido
            Turno turno = (Turno) unTurno;
            horaInicio.Value= turno.inicio;
            horaFin.Value= turno.fin;
            precioBase.Value= turno.precioBase;
            precioKm.Value= turno.precioKm;
            txtDescripcion.Text=turno.descripcion;
            ID = turno.id;   
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            base.volver();
        }
        public override void limpiar () {
            horaInicio.Value=0;
            horaFin.Value=0;
            precioBase.Value=0;
            precioKm.Value=0;
            txtDescripcion.ResetText();
        }

        private void btnClear_Click (object sender, EventArgs e) {
            limpiar();
        }
    }
}
