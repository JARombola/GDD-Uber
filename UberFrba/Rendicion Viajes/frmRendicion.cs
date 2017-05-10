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
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;
using UberFrba.Dominio;

namespace UberFrba.Rendicion_Viajes
{
    public partial class frmRendicion : FormsAdapter
    {
        private bool buscaChofer { get; set; }
        private int idTurno { get; set; }
        private int idChofer{get;set;}

        public frmRendicion(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior=anterior;
        }

        private void btnChofer_Click (object sender, EventArgs e) {
            frmListaChoferes listaChoferes = new frmListaChoferes(this);
                listaChoferes.formSiguiente=this;
                listaChoferes.soloHabilitados=true;
                buscaChofer = true;
                listaChoferes.Show();
                this.Hide();
        }

        private void btnTurno_Click (object sender, EventArgs e) {
            frmListaTurnos listaTurnos = new frmListaTurnos(this);
                listaTurnos.formSiguiente=this;
                listaTurnos.soloHabilitados=true;
                listaTurnos.Show();
            this.Hide();
        }

        public override void configurar (IDominio elemento) {
            if (buscaChofer) {Persona chofer = (Persona) elemento;
                idChofer = chofer.id;
                txtChofer.Text = (chofer.nombre +" "+ chofer.apellido);
                buscaChofer=false;
            }
            else {                                                              // Si no buscó chofer => Buscó turno
                idTurno = ((Turno) elemento).id;
                txtTurno.Text =  ((Turno) elemento).descripcion;
            }
        }

        private void btnFacturar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_Rendicion");
                command.Parameters.AddRange(new[]{
                        new SqlParameter("@idChofer",idChofer),
                        new SqlParameter("@idTurno",idTurno),
                        new SqlParameter("@fecha",fecha.Value.Date),
                    }
                );
                try {
                    ejecutarQuery(command, dgListado);
                }
                catch (SqlException error) {
                    MessageBox.Show(error.Message, "Error de facturacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

        }
        }
}
