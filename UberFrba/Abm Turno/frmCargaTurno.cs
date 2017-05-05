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
            if (ID == 0) registrarTurno();
            else modificarTurno();
        }

        private void registrarTurno(){
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaTurno");
            setearParametros(ref command);
            try {
                command.ExecuteNonQuery();
                MessageBox.Show("Guardado");
            }
            catch (SqlException error) {                // La excepcion desde SQL envia el mensaje de falla
                MessageBox.Show(null,error.Message,"Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarTurno () {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_modifTurno");
            command.Parameters.AddWithValue("@id", ID);                         //Necesito agregarle el ID porque es una modificacion
            setearParametros(ref command);
            try {
                command.ExecuteNonQuery();
                MessageBox.Show("Modificado!");
            }
            catch (SqlException error) {
                MessageBox.Show(null, error.Message, "Error de modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setearParametros (ref SqlCommand command) {
            command.Parameters.AddRange(new[] {
                new SqlParameter ("@inicio", horaInicio.Value),
                new SqlParameter ("@fin", horaFin.Value),
                new SqlParameter ("@precioBase", precioBase.Value),
                new SqlParameter ("@precioKm", precioKm.Value),
                new SqlParameter ("@descripcion", txtDescripcion.Text),
                new SqlParameter ("@habilitado", chkHabilitado.Checked),
            }
            );
        }

        public override void cargarDatos (IDominio unTurno) {              //Carga los datos porque es una modificacion
            Turno turno = (Turno) unTurno;
            horaInicio.Value= turno.inicio;
            horaFin.Value= turno.fin;
            precioBase.Value= turno.precioBase;
            precioKm.Value= turno.precioKm;
            txtDescripcion.Text=turno.descripcion;
            ID = turno.id;   
        }

        public override void configurar (IDominio unTurno) {                //IDominio, para respetar polimorfismo superclase
            this.Text="Modificación Turno";
            btnAceptar.Text = "Modificar";
            Turno turnito = (Turno) unTurno;
            chkHabilitado.Checked = turnito.habilitado;
            cargarDatos(turnito);
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

    }
}
