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
using UberFrba.Abm_Chofer;


namespace UberFrba.Abm_Automovil {
    public partial class frmListAutomoviles : ListadosAdapter {
        
        public frmListAutomoviles (ListadosAdapter anterior) {
            InitializeComponent();
            formAnterior = anterior;
            TABLA = "gd_esquema.Maestra";
        }

        private void frmListAutomoviles_Load (object sender, EventArgs e) {
            Buscador.getInstancia().cargarMarcas(cbMarca,TABLA);
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().getCommandFunction("fx_filtrarAutos(@modelo, @patente, @marca)");
                command.Parameters.AddWithValue("@modelo", valor(txtModelo.Text));
                command.Parameters.AddWithValue("@patente", valor(txtPatente.Text));
                command.Parameters.AddWithValue("@marca", valor(cbMarca.Text));
                //command.Parameters.Add("@modelo", SqlDbType.VarChar).Value=valor(txtModelo.Text);
                //command.Parameters.Add("@patente", SqlDbType.VarChar).Value=valor(txtPatente.Text);
                //command.Parameters.Add("@marca", SqlDbType.VarChar).Value=valor(cbMarca.Text);
           
            //TODO filtrar por chofer
            //                command.Parameters.AddWithValue("@chofer", valor(txtChofer.Text));            
            ejecutarQuery(command, dgListado);
        }

        private void eliminar (object sender, EventArgs e) {
            DialogResult opcion = MessageBox.Show(null,"Eliminar "+dgListado.CurrentRow.Cells["Auto_Patente"].Value.ToString()+"?","Baja Auto",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(opcion == DialogResult.Yes) 
            //TODO: Borrado real
                    dgListado.Rows.RemoveAt(dgListado.CurrentRow.Index);
        }

        private void mostrarDatos () {
            MessageBox.Show(dgListado.CurrentRow.Cells["Auto_Patente"].Value.ToString());
        }

        private void btnClean_Click (object sender, EventArgs e) {
            txtChofer.Clear();
            txtModelo.Clear();
            txtPatente.Clear();
            cbMarca.SelectedIndex=-1;
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

        private void marcarFila (object sender, MouseEventArgs e) {
            var hit = dgListado.HitTest(e.X, e.Y);
            dgListado.ClearSelection();
            dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true;
        }

        private void derecho (object sender, MouseEventArgs e) {
            if (e.Button==MouseButtons.Right) marcarFila(sender, e);
        }

        private void button1_Click (object sender, EventArgs e) {

        }

    }
}
