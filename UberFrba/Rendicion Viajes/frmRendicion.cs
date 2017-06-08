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
using UberFrba.Abm_Turno;
using UberFrba.Dominio;

namespace UberFrba.Rendicion_Viajes
{
    public partial class frmRendicion : FormsAdapter
    {
        private bool buscaChofer { get; set; }
        private int idChofer{get;set;}
        private int idTurno { get; set; }

        public frmRendicion(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior=anterior;
            idTurno=-1;
            idChofer=-1;
        }

        public override void configurar (IDominio elemento) {           // Método usado por el Listado de Choferes. Envía el Chofer seleccionado (al que se le realizará la rendicion)
            if (buscaChofer) {
                Persona chofer = (Persona) elemento;
                idChofer = chofer.id;
                txtChofer.Text = (chofer.nombre +" "+ chofer.apellido);
                toolTip1.SetToolTip(txtChofer, String.Format("{0} {1} \nDNI:{2} \nMail:{3}", chofer.nombre, chofer.apellido, chofer.dni, chofer.mail));
                buscaChofer=false;
            }
            else {                              // Entonces busca turno 
                    Turno turno = (Turno) elemento;
                    idTurno = turno.id;
                    txtTurno.Text = turno.descripcion;
                    toolTip1.SetToolTip(txtTurno,String.Format("Descripcion:{0}\n Horario:{1} - {2} hs.",turno.descripcion,turno.inicio,turno.fin));
                }
        }

        private void btnFacturar_Click (object sender, EventArgs e) {
            String errores = errorCampos();
            if (errores==null) {
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_Rendicion");
                command.Parameters.AddRange(new[]{
                            new SqlParameter("@idChofer",idChofer),
                            new SqlParameter("@fecha",fecha.Value.Date),
                            new SqlParameter("@idturno",idTurno),
                        }
                );
                try {
                    ejecutarQuery(command, dgListado);
                    if (dgListado.Rows.Count==1) MessageBox.Show("No hay viajes registrados en esa fecha", "Sin viajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException error) {
                    switch (error.Number) {
                        case 51002: 
                            if (MessageBox.Show("La rendicion ya se encuentra realizada.\n Desea visualizarla?", "Rendicion Existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) mostrarFacturaExistente(error.Message);
                            break;
                        default: MessageBox.Show("Error de rendicion.\nConsulte al administrador.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); break;
                    }
                }
            }
            else MessageBox.Show(errores, "Error campos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void mostrarFacturaExistente (string codRendicionString) {               // Si la Rendicion ya existía y el usuario desea ver el detalle
            int codRendicion;                     // desde acá se cargan sus datos, en base al Nro de Rendicion obtenido desde la excepcion
            int.TryParse(codRendicionString, out codRendicion);
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getRendicionExistente(@nroRendicion)");
                command.Parameters.AddWithValue("@nroRendicion", codRendicion);
                ejecutarQuery(command, dgListado);
                dgListado.Sort(dgListado.Columns[8],ListSortDirection.Ascending);
        }

        public override string errorCampos () {
            String errores = null;
            if (idChofer == -1) errores+= "- Debe seleccionar un chofer\n";
            if (idTurno==-1) errores+= "- Debe seleccionar un turno\n";
            return errores;
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void frmRendicion_Load (object sender, EventArgs e) {
            fecha.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
            fecha.MaxDate = DateTime.Now;
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
            listaTurnos.Show();
            this.Hide();
        }
        }
}
