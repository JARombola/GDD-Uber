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


namespace UberFrba.Abm_Chofer{
    public partial class frmListaChoferes : FormsAdapter {

        public bool soloHabilitados { get; set; }

        public frmListaChoferes (Form formularioAnterior) {
            InitializeComponent();
            soloHabilitados=false;
            formAnterior = (FormsAdapter) formularioAnterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            string query = soloHabilitados?"fx_filtrarChoferesHabilitados(@nombre, @apellido, @DNI)":"fx_filtrarChoferes(@nombre, @apellido, @DNI)";
            SqlCommand command= Buscador.getInstancia().getCommandFunctionDeTabla(query);
                command.Parameters.AddWithValue("@nombre", valor(txtNombre.Text));
                command.Parameters.AddWithValue("@apellido", valor(txtApellido.Text));
                command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

                ejecutarQuery(command, dgListado);
                base.ocultarColumnas(dgListado);
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtApellido.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            dgListado.DataSource = null;
            dgListado.Refresh();
        }

        private void enviarDatos () {               // Configura una "Persona" para enviarla al Formulario que solicitó los datos
            Persona chofer = new Persona();
                chofer.nombre = dgListado.CurrentRow.Cells["Nombre"].Value.ToString();
                chofer.telefono = dgListado.CurrentRow.Cells["Telefono"].Value.ToString();
                chofer.apellido = dgListado.CurrentRow.Cells["Apellido"].Value.ToString();
                chofer.direccion = dgListado.CurrentRow.Cells["Direccion"].Value.ToString();
                chofer.localidad= dgListado.CurrentRow.Cells["Localidad"].Value.ToString();
                chofer.piso = (dgListado.CurrentRow.Cells["Piso"].Value==DBNull.Value)?0:(int) dgListado.CurrentRow.Cells["Piso"].Value;

                chofer.dpto = dgListado.CurrentRow.Cells["Depto"].Value.ToString();

                chofer.dni = dgListado.CurrentRow.Cells["DNI"].Value.ToString();
                chofer.fecha_nacimiento = DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
                chofer.mail= dgListado.CurrentRow.Cells["Mail"].Value.ToString();
                chofer.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
                chofer.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            formSiguiente.configurar(chofer);                   // Envía la "Persona" al formulario y "lo configura"
            formSiguiente.Show();
            this.Close();
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
            try { dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true; }
            catch (System.ArgumentOutOfRangeException) { //.... y que queres que haga?
            }
        }

        private void btnTodos_Click (object sender, EventArgs e) {
            if(soloHabilitados) ejecutarQuery(Buscador.getInstancia().verTodosHabilitados("Chofer"),dgListado);
            else ejecutarQuery(Buscador.getInstancia().verTodos("Chofer"), dgListado);
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            base.volver();
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
