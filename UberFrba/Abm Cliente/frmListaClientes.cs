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
    public partial class frmListaClientes : ListadosAdapter {
    
        public frmListaClientes (ListadosAdapter anterior) {
            InitializeComponent();
            formAnterior = anterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().getCommandFunction("fx_filtrarClientes(@nombre, @apellido, @DNI)");
            command.Parameters.AddWithValue("@nombre", valor(txtNombre.Text));
            command.Parameters.AddWithValue("@apellido", valor(txtApellido.Text));
            command.Parameters.AddWithValue("@DNI", valor(txtDNI.Text));

            ejecutarQuery(command, dgListado);
        }

        private void eliminar (object sender, EventArgs e) {
            DialogResult opcion = MessageBox.Show(null, "Eliminar "+dgListado.CurrentRow.Cells["Cliente_nombre"].Value.ToString()+"?", "Baja Auto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                //TODO: Borrado real
                dgListado.Rows.RemoveAt(dgListado.CurrentRow.Index);
        }

        private void mostrarDatos () {
            MessageBox.Show(dgListado.CurrentRow.Cells["Cliente_nombre"].Value.ToString());
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
            if (e.Button==MouseButtons.Left) mostrarDatos();
        }

        protected override bool ProcessCmdKey (ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) {
            if ((!dgListado.Focused)) return base.ProcessCmdKey(ref msg, keyData);
            if (keyData != Keys.Enter && keyData != Keys.Space) return base.ProcessCmdKey(ref msg, keyData);
            mostrarDatos();
            return true;
        }

        private void dgListado_MouseDown (object sender, MouseEventArgs e) {
            var hit = dgListado.HitTest(e.X, e.Y);
            dgListado.ClearSelection();
            dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true;
        }

        private void derecho (object sender, MouseEventArgs e) {
            if (e.Button==MouseButtons.Right) dgListado_MouseDown(sender, e);
        }

        private void de (object sender, MouseEventArgs e) {

        }

    }
}
