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


namespace UberFrba.Abm_Cliente{
    public partial class frmListaClientes : FormsAdapter {

        public bool soloHabilitados{ get; set; }

        public frmListaClientes (Form anterior) {
            InitializeComponent();
            soloHabilitados=false;
            formAnterior = (FormsAdapter) anterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {             // En algunos casos se verán solo los habilitados (por ejemplo, para asignar viajes) y en otros se pueden ver todos (ej, modificacion clientes)
            string query = soloHabilitados?"fx_filtrarClientesHabilitados(@nombre, @apellido, @DNI)":"fx_filtrarClientes(@nombre, @apellido, @DNI)";
            SqlCommand command= Buscador.getInstancia().getCommandFunctionDeTabla(query);
                command.Parameters.AddWithValue("@nombre", valor(txtNombre.Text));
                command.Parameters.AddWithValue("@apellido", valor(txtApellido.Text));
                command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

            ejecutarQuery(command, dgListado);
            dgListado.Columns["ID"].Visible=false;

        }

        private void enviarDatos () {                           // Crea una "Persona" (dataobject Cliente) para enviar al formulario que los requiere
            Persona cliente= new Persona();
            cliente.nombre = dgListado.CurrentRow.Cells["Nombre"].Value.ToString();
            cliente.telefono = dgListado.CurrentRow.Cells["Telefono"].Value.ToString();
            cliente.apellido = dgListado.CurrentRow.Cells["Apellido"].Value.ToString();
            cliente.direccion = dgListado.CurrentRow.Cells["Direccion"].Value.ToString();
            cliente.localidad = dgListado.CurrentRow.Cells["Localidad"].Value.ToString();

            cliente.piso = (dgListado.CurrentRow.Cells["Piso"].Value==DBNull.Value)?0:(int) dgListado.CurrentRow.Cells["Piso"].Value;
            cliente.dpto= dgListado.CurrentRow.Cells["Depto"].Value.ToString();
            cliente.dni = dgListado.CurrentRow.Cells["DNI"].Value.ToString();
            cliente.fecha_nacimiento= DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
            cliente.mail= dgListado.CurrentRow.Cells["Mail"].Value.ToString();
            cliente.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
            cliente.fecha_nacimiento = DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
            cliente.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            formSiguiente.configurar(cliente);                          // Envia el "Cliente" al formulario correspondiente y lo "configura"
            formSiguiente.Show();
            this.Close();
        }
        
        private void btnClean_Click (object sender, EventArgs e) {
            txtApellido.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            dgListado.DataSource = null;
            dgListado.Refresh();
        }

        //------------------------------------------------------------------------
        //--------------------------- BOTONES -----------------------------------
        //------------------------------------------------------------------------

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

        private void btnTodos_Click (object sender, EventArgs e) {
            if(soloHabilitados) ejecutarQuery(Buscador.getInstancia().verTodosHabilitados("Cliente"), dgListado);
            else ejecutarQuery(Buscador.getInstancia().verTodos("Cliente"), dgListado); 
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void actualizar (object sender, DataGridViewRowsAddedEventArgs e) {
            lblCantResultados.Visible=true;
            lblCantResultados.Text = "Resultados: "+dgListado.RowCount.ToString();
        }

        private void actualizar (object sender, DataGridViewRowsRemovedEventArgs e) {
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
