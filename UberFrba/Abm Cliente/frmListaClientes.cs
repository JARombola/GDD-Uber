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
using UberFrba.A__Buscador;


namespace UberFrba.Abm_Cliente{
    public partial class frmListaClientes : FormsAdapter {

        public bool soloHabilitados{ get; set; }

        public frmListaClientes (Form anterior) {
            InitializeComponent();
            soloHabilitados=false;
            formAnterior = (FormsAdapter) anterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            string query = soloHabilitados?"fx_filtrarClientesHabilitados(@nombre, @apellido, @DNI)":"fx_filtrarClientes(@nombre, @apellido, @DNI)";
            SqlCommand command= Buscador.getInstancia().getCommandFunctionDeTabla(query);
                command.Parameters.AddWithValue("@nombre", valor(txtNombre.Text));
                command.Parameters.AddWithValue("@apellido", valor(txtApellido.Text));
                command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

            ejecutarQuery(command, dgListado);
        }

        private void enviarDatos () {
            Persona cliente= new Persona();
            cliente.nombre = dgListado.CurrentRow.Cells["Nombre"].Value.ToString();
            cliente.telefono = dgListado.CurrentRow.Cells["Telefono"].Value.ToString();
            cliente.apellido = dgListado.CurrentRow.Cells["Apellido"].Value.ToString();
            cliente.direccion = dgListado.CurrentRow.Cells["Direccion"].Value.ToString();
            cliente.dni = dgListado.CurrentRow.Cells["DNI"].Value.ToString();
            cliente.fecha_nacimiento= DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
            cliente.mail= dgListado.CurrentRow.Cells["Mail"].Value.ToString();
            cliente.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
            cliente.fecha_nacimiento = DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
            cliente.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            FormsAdapter frmModif = new frmCargaCliente(formAnterior);
            frmModif.configurar(cliente);
            frmModif.Show();
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
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
        //--------------------------- BOTONES -----------------------------------
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
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

        private void derecho (object sender, MouseEventArgs e) {
            if (e.Button==MouseButtons.Right) {
                marcarFila(sender, e);
                bool habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;
                if (habilitado) {
                    menuDerecho.Items[0].Visible=false;            //Habilitar
                    menuDerecho.Items[1].Visible=true;
                }
                else {
                    menuDerecho.Items[0].Visible=true;
                    menuDerecho.Items[1].Visible=false;
                }
            }
        }

        private void habilitar (object sender, EventArgs e) {
            int p = base.habilitar("Cliente", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Habilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value = true;
            dgListado.Refresh();
        }

        private void deshabilitar (object sender, EventArgs e) {
            int p = base.deshabilitar("Cliente", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Deshabilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value= false;
            dgListado.Refresh();
        }

        private void btnTodos_Click (object sender, EventArgs e) {
            if(soloHabilitados) ejecutarQuery(Buscador.getInstancia().verTodosHabilitados("Clientes"), dgListado);
            else ejecutarQuery(Buscador.getInstancia().verTodos("Clientes"), dgListado); 
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

    }
}
