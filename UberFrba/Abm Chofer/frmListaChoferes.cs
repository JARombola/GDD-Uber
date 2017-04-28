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


namespace UberFrba.Abm_Chofer{
    public partial class frmListaChoferes : FormsAdapter {

        public frmListaChoferes (Form formularioAnterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) formularioAnterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().getCommandFunction("fx_filtrarChoferes(@nombre, @apellido, @DNI)");
                command.Parameters.AddWithValue("@nombre", valor(txtNombre.Text));
                command.Parameters.AddWithValue("@apellido", valor(txtApellido.Text));
                command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

            ejecutarQuery(command, dgListado);
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtApellido.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            dgListado.DataSource = null;
            dgListado.Refresh();
        }

        private void eliminar (object sender, EventArgs e) {
            DialogResult opcion = MessageBox.Show(null, "Eliminar "+dgListado.CurrentRow.Cells["Chofer_nombre"].Value.ToString()+"?", "Baja Auto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                //TODO: Borrado real
                dgListado.Rows.RemoveAt(dgListado.CurrentRow.Index);
        }

        private void enviarDatos () {
            Persona chofer = new Persona();
            chofer.nombre = dgListado.CurrentRow.Cells["Nombre"].Value.ToString();
            chofer.telefono = dgListado.CurrentRow.Cells["Telefono"].Value.ToString();
            chofer.apellido = dgListado.CurrentRow.Cells["Apellido"].Value.ToString();
            chofer.direccion = dgListado.CurrentRow.Cells["Direccion"].Value.ToString();
            chofer.dni = dgListado.CurrentRow.Cells["DNI"].Value.ToString();
            chofer.fecha_nacimiento = DateTime.Parse(dgListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());
            chofer.mail= dgListado.CurrentRow.Cells["Mail"].Value.ToString();
            chofer.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
            chofer.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            formAnterior.configurar(chofer);
            formAnterior.Show();
            this.Close();
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
            int p = base.habilitar("Chofer", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Habilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value = true;
            dgListado.Refresh();
        }

        private void deshabilitar (object sender, EventArgs e) {
            int p = base.deshabilitar("Chofer", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Deshabilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value= false;
            dgListado.Refresh();
        }

    }
}
