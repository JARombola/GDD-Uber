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

namespace UberFrba.Abm_Turno {
    public partial class frmListaTurnos : FormsAdapter {
        
        public bool soloHabilitados {get; set;}                    // Indica si SOLO deben mostrarse los habilitados (true) o todos (false)

        public frmListaTurnos (Form anterior) {
            InitializeComponent();
            soloHabilitados=false;
            formAnterior = (FormsAdapter) anterior;
        }

        private void btnBuscar_Click (object sender, EventArgs e) {
            string query =(soloHabilitados)? "fx_filtrarTurnosHabilitados(@descripcion)":"fx_filtrarTurnos(@descripcion)";
            SqlCommand command= Buscador.getInstancia().getCommandFunctionDeTabla(query);
                    command.Parameters.AddWithValue("@descripcion", valor(txtDescripcion.Text));
            ejecutarQuery(command, dgListado);
        }


        private void enviarDatos () {               //Crea un Turno para que el formulario de carga muestre estos datos (para modificar)
            Turno turno = new Turno();
                turno.inicio = (decimal) dgListado.CurrentRow.Cells["Hora_inicio"].Value;
                turno.fin = (decimal) dgListado.CurrentRow.Cells["Hora_fin"].Value;
                turno.precioBase= (decimal) dgListado.CurrentRow.Cells["Precio_Base"].Value;
                turno.precioKm= (decimal) dgListado.CurrentRow.Cells["Precio_Km"].Value;
                turno.descripcion= (string) dgListado.CurrentRow.Cells["Descripcion"].Value;
                turno.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;
                turno.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
         formSiguiente.configurar(turno);
         formSiguiente.Show();
         this.Close();  
        }


        private void btnClean_Click (object sender, EventArgs e) {
            txtDescripcion.Clear();
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
            try { dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true; }
            catch (System.ArgumentOutOfRangeException) { //.... Hizo click derecho en cualquier lado
            }
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
            int p = base.habilitar("Turno", (int) dgListado.CurrentRow.Cells["ID"].Value);              //La SuperClase implementa el metodo para habilitar
            MessageBox.Show("Habilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value = true;
            dgListado.Refresh();
        }

        private void deshabilitar (object sender, EventArgs e) {
            int p = base.deshabilitar("Turno", (int) dgListado.CurrentRow.Cells["ID"].Value);           //La superclase implementa el metodo para deshabilitar
            MessageBox.Show("Deshabilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value= false;
            dgListado.Refresh();
        }


        private void btnTodos_Click (object sender, EventArgs e) {
            ejecutarQuery(Buscador.getInstancia().verTodos("Turnos"), dgListado);
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

        private void btnTodos_Click_1 (object sender, EventArgs e) {
            if(soloHabilitados)ejecutarQuery(Buscador.getInstancia().verTodosHabilitados("Turnos"),dgListado);
            else ejecutarQuery(Buscador.getInstancia().verTodos("Turnos"), dgListado);
        }

        private void btnAtras_Click_1 (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

        private void frmListaTurnos_Load (object sender, EventArgs e) {
            lblHabilitados.Visible=soloHabilitados;
        }

        private void exit (object sender, FormClosedEventArgs e) {
            base.cerrar(sender, e);
        }

    }
}
