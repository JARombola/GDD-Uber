using System;
using System.Collections;
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
using UberFrba.Abm_Chofer;


namespace UberFrba.Abm_Automovil {
    public partial class frmListaAutos : FormsAdapter {

        public bool soloHabilitados { get; set; }

        public frmListaAutos (Form anterior) {
            InitializeComponent();
            soloHabilitados=false;
            formAnterior = (FormsAdapter) anterior;
        }

        private void frmListAutomoviles_Load (object sender, EventArgs e) {
            Buscador.getInstancia().cargarMarcas(cbMarca);
            lblHabilitados.Visible=soloHabilitados;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().getCommandFunctionDeTabla("fx_filtrarAutos(@modelo, @patente, @marca, @choferID)");
            command.Parameters.AddRange(new[]{
                    new SqlParameter ("@modelo", valor(txtModelo.Text)),
                    new SqlParameter ("@patente", valor(txtPatente.Text)),
                    new SqlParameter ("@marca", valor(cbMarca.Text)),
                    new SqlParameter ("@choferID", ID),      
                    new SqlParameter ("@habilitado", ID),      
            });

            ejecutarQuery(command, dgListado);
            base.ocultarColumnas(dgListado);
            dgListado.Columns["IDChofer"].Visible=false;
            dgListado.Columns["IDTurno"].Visible=false;
        }

        private void enviarDatos () {                       // Configura un "Auto" para enviar al formulario que solicito los datos
            Auto auto = new Auto();
                auto.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
                auto.licencia = dgListado.CurrentRow.Cells["Licencia"].Value.ToString();
                auto.marca = dgListado.CurrentRow.Cells["Marca"].Value.ToString();
                auto.modelo = dgListado.CurrentRow.Cells["Modelo"].Value.ToString();
                auto.patente = dgListado.CurrentRow.Cells["Patente"].Value.ToString();
                auto.rodado = dgListado.CurrentRow.Cells["Rodado"].Value.ToString();
                auto.habilitado=(bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            if (dgListado.CurrentRow.Cells["Chofer"].Value == DBNull.Value) {           //Carga los datos del chofer para la modificacion
                auto.choferID=-1;                                                               // Aunque nunca debería ser Null (por constraints en la base)
            }
            else {
                auto.choferID =(int) dgListado.CurrentRow.Cells["IDChofer"].Value;
                auto.choferNombre = (string) dgListado.CurrentRow.Cells["Chofer"].Value;
            }
            if (dgListado.CurrentRow.Cells["Turno"].Value == DBNull.Value) {        //carga los datos del turno para la modificacion
                auto.turnoID = -1;                                                              // Aunque nunca debería ser Null (por constraints en la base)
            }
            else {
                auto.turnoID = (int) dgListado.CurrentRow.Cells["IDTurno"].Value;
                auto.turnoDescripcion = (string) dgListado.CurrentRow.Cells["Turno"].Value; ;
            }
            formSiguiente.configurar(auto);                         // Envía los datos del "Auto" al formulario que los solicitó y "lo configura"
            formSiguiente.Show();
            this.Close();
        }
         
        public override void configurar (IDominio elemento) {           // Cuando se busca un chofer, el listado va a usar este metodo para que se configure ESTE formulario
            Persona chofer = (Persona) elemento;
            txtChofer.Text = chofer.nombre;
            ID = chofer.id;
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtChofer.Clear();
            txtModelo.Clear();
            txtPatente.Clear();
            cbMarca.SelectedIndex=-1;
            dgListado.DataSource = null;
            dgListado.Refresh();
        }


        
        //--------------------------- BOTONES -----------------------------------

        private void seleccion (object sender, MouseEventArgs e) {
            if (e.Button==MouseButtons.Left) enviarDatos();
        }

       protected override bool ProcessCmdKey (ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) {
            if ((!dgListado.Focused)) return base.ProcessCmdKey(ref msg, keyData);
            if (keyData != Keys.Enter && keyData != Keys.Space) return base.ProcessCmdKey(ref msg, keyData);
            enviarDatos();
            return true;
        }

        private void marcarFila (object sender, MouseEventArgs e) {
            var hit = dgListado.HitTest(e.X, e.Y);
            dgListado.ClearSelection();
            dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true;
        }

         private void selecChofer_Click (object sender, EventArgs e) {
            new frmListaChoferes(this).Show();
            this.Hide();
        }

        private void btnTodos_Click (object sender, EventArgs e) {
            ejecutarQuery(Buscador.getInstancia().verTodos("Auto"), dgListado);
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void selecChofer_Click_1 (object sender, EventArgs e) {
            frmListaChoferes listaChoferes = new frmListaChoferes(this);
                listaChoferes.formSiguiente=this;
                listaChoferes.soloHabilitados=false;
                listaChoferes.Show();
            this.Hide();
        }

        private void actualizarResultados (object sender, DataGridViewRowsAddedEventArgs e) {
            lblCantResultados.Visible=true;
            lblCantResultados.Text = "Resultados: "+dgListado.RowCount.ToString();
        }

        private void actualizarResultados (object sender, DataGridViewRowsRemovedEventArgs e) {
            lblCantResultados.Visible=true;
            lblCantResultados.Text = "Resultados: "+dgListado.RowCount.ToString();
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            this.enviarDatos();
        }

        private void dgListado_CellClick (object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex!=-1) btnAceptar.Enabled=true;
            else btnAceptar.Enabled=false;
        }
    }
}
