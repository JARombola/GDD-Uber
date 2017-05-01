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
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;
using UberFrba.Dominio;

namespace UberFrba.Abm_Automovil {              //TODO: Terminar carga
    public partial class frmCargaAuto : FormsAdapter {
        bool buscaTurno = false, buscaChofer = false;
        int idChofer, idTurno;
        
        public frmCargaAuto (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
            Buscador.getInstancia().cargarMarcas(cbMarca);
        }


        public override void configurar (IDominio objeto) {
            if (buscaTurno) {
                Turno turno = (Turno) objeto;
                txtTurno.Text = turno.descripcion;
                idTurno = turno.id;
                buscaTurno=false;
            }else
                if (buscaChofer) {
                    Persona chofer = (Persona) objeto;
                    txtChofer.Text = chofer.nombre + " " + chofer.apellido;
                    idChofer = chofer.id;
                    buscaChofer=false;
                }
                else {                      //Si llego a configurar y no habia buscado chofer ni turno => Queria modificar un auto
                    this.Text="Modificación Auto";
                    btnAceptar.Text = "Modificar";
                    Auto autito = (Auto) objeto;
                    btnHabilitacion.Text = autito.habilitado?"Deshabilitar":"Habilitar";
                    btnHabilitacion.Visible=true;
                    cargarDatos(autito);
                }
        }

        public override void cargarDatos (IDominio unAuto) {
            Auto auto = (Auto) unAuto;
            cbMarca.Text = auto.marca;
            txtModelo.Text = auto.modelo;
            txtPatente.Text = auto.patente;
            txtLicencia.Text = auto.licencia;
            txtRodado.Text = auto.rodado;
            if (auto.choferID != -1) {
                idChofer = auto.choferID;
                txtChofer.Text = auto.choferNombre;
            }
            if (auto.turnoID!=-1) {
                idTurno = auto.turnoID;
                txtTurno.Text=auto.turnoDescripcion;
            }
            ID = auto.id;
            if (!auto.habilitado) ID*=-1;               //Solo importa para la habilitacion/deshabilitacion... Si <0 => Deshabilitado,  
                                                                                                        //        >0 => Habilitado
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            if (ID==-1) registrarAuto();          //NO hay un ID asociado ====> Es un registro. SINO, es una modificacion
            else modificarAuto();
            volver();
        }

        private void registrarAuto () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaAuto");
            setParametros(ref cmd);
            int p=cmd.ExecuteNonQuery();
            MessageBox.Show("Agregados = "+p);
        }

        private void modificarAuto () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifAuto");
            setParametros(ref cmd);
            cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
            int p = cmd.ExecuteNonQuery();
            MessageBox.Show("Modificados = "+ p);
        }


        private void setParametros (ref SqlCommand command) {
            command.Parameters.AddRange(new[]
                    {new SqlParameter("@marca",valor(cbMarca.Text)),
                     new SqlParameter("@modelo",valor(txtModelo.Text)),
                     new SqlParameter("@patente",valor(txtPatente.Text)),
                     new SqlParameter("@licencia",valor(txtLicencia.Text)),
                     new SqlParameter("@rodado",valor(txtRodado.Text)),
                     new SqlParameter("@chofer",idChofer),
                     new SqlParameter("@turno",idTurno),
                }
                 );
        }

        private void btnHabilitacion_Click (object sender, EventArgs e) {
            SqlCommand command;
            if (ID<0)           //Deshabilitado => Hay que habilitar
                command = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitarAuto");
            else command = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitarAuto");
            command.Parameters.AddWithValue("@id", Math.Abs(ID));
            int resultado = command.ExecuteNonQuery();
            MessageBox.Show("Actualizados: "+resultado);
            volver();
        }

        private void btnBuscTurno_Click (object sender, EventArgs e) {
            new frmListaTurnos(this).Show();
            buscaTurno = true;
            this.Hide();
        }

        private void btnBuscChofer_Click (object sender, EventArgs e) {
            new frmListaChoferes(this).Show();
            buscaChofer=true;
            this.Hide();
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

    }
}
