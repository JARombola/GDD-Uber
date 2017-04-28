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
using UberFrba.Dominio;


namespace UberFrba.Abm_Automovil {
    public partial class frmListaAutos : FormsAdapter {
        
        public frmListaAutos (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
        }

        private void frmListAutomoviles_Load (object sender, EventArgs e) {
            Buscador.getInstancia().cargarMarcas(cbMarca);
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            SqlCommand command= Buscador.getInstancia().getCommandFunction("fx_filtrarAutos(@modelo, @patente, @marca, @choferID)");
            command.Parameters.AddRange(new[]{
                    new SqlParameter ("@modelo", valor(txtModelo.Text)),
                    new SqlParameter ("@patente", valor(txtPatente.Text)),
                    new SqlParameter ("@marca", valor(cbMarca.Text)),
                    new SqlParameter ("@choferID", ID),       //TODO: verificar que funcione
            });

                    
            ejecutarQuery(command, dgListado);
        }

        private void eliminar (object sender, EventArgs e) {
            DialogResult opcion = MessageBox.Show(null,"Eliminar "+dgListado.CurrentRow.Cells["Auto_Patente"].Value.ToString()+"?","Baja Auto",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(opcion == DialogResult.Yes) 
            //TODO: Borrado real
                    dgListado.Rows.RemoveAt(dgListado.CurrentRow.Index);
        }

        private void enviarDatos () {
            Auto auto = new Auto();
            auto.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
            auto.licencia = dgListado.CurrentRow.Cells["Licencia"].Value.ToString();
            auto.marca = dgListado.CurrentRow.Cells["Marca"].Value.ToString();
            auto.modelo = dgListado.CurrentRow.Cells["Modelo"].Value.ToString();
            auto.patente = dgListado.CurrentRow.Cells["Patente"].Value.ToString();
            auto.rodado = dgListado.CurrentRow.Cells["Rodado"].Value.ToString();
            auto.habilitado =(bool) dgListado.CurrentRow.Cells["Habilitado"].Value;

            FormsAdapter frmModif = new frmCargaAuto(formAnterior);
            frmModif.configurar(auto);
            frmModif.Show();
            this.Close();
            
        }

        public override void configurar (IDominio elemento) {
            Persona chofer = (Persona) elemento;
            txtChofer.Text = chofer.nombre + " (ID: "+chofer.id.ToString()+")";
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
            int p = base.habilitar("Auto", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Habilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value = true;
            dgListado.Refresh();
        }

        private void deshabilitar (object sender, EventArgs e) {
            int p = base.deshabilitar("Auto", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Deshabilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value= false;
            dgListado.Refresh();
        }

        private void selecChofer_Click (object sender, EventArgs e) {
            new frmListaChoferes(this).Show();
            this.Hide();
        }
        

    }
}
