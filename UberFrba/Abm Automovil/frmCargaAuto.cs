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
using UberFrba.Dominio;

namespace UberFrba.Abm_Automovil {
    public partial class frmCargaAuto : FormsAdapter {
        
        public frmCargaAuto (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
            Buscador.getInstancia().cargarMarcas(cbMarca);            
        }


        public override void cargarDatos (IDominio auto) {
            this.Text="Modificación Auto";
            btnAceptar.Text = "Modificar";
            Auto autito = (Auto) auto;
            btnHabilitacion.Text = autito.habilitado?"Deshabilitar":"Habilitar";
            btnHabilitacion.Visible=true;
            configurar(autito);
        }

        public override void configurar (IDominio unAuto) {
            Auto auto = (Auto) unAuto;
            cbMarca.Text = auto.marca;
            txtModelo.Text = auto.modelo;
            txtPatente.Text = auto.patente;
            txtLicencia.Text = auto.licencia;
            txtRodado.Text = auto.rodado;
            //TODO: Chofer, Turnos
            // buscarTurno();
            // buscarChofer();
            ID = auto.id;
            if (!auto.habilitado) ID*=-1;               //Solo importa para la habilitacion/deshabilitacion
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            if (ID==-1) registrarAuto();          //NO hay un ID asociado ====> Es un registro
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

    }
}
