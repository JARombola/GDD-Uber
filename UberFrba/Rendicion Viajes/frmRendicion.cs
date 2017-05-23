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

        public override void configurar (IDominio elemento) {
            Persona chofer = (Persona) elemento;
                idChofer = chofer.id;
                txtChofer.Text = (chofer.nombre +" "+ chofer.apellido);
            toolTip1.SetToolTip(txtChofer,String.Format("{0} {1} \nDNI:{2} \nMail:{3}",chofer.nombre, chofer.apellido, chofer.dni,chofer.mail));
        }

        private void btnFacturar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_Rendicion");
                command.Parameters.AddRange(new[]{
                        new SqlParameter("@idChofer",idChofer),
                        new SqlParameter("@fecha",fecha.Value.Date),
                    }
                );
                try {
                    ejecutarQuery(command, dgListado);
                }
                catch (SqlException error) {
                    MessageBox.Show(error.Message, "Error de rendicion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

        }
        }
}
