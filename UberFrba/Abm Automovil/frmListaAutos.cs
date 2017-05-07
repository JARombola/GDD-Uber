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
                    new SqlParameter ("@choferID", ID),       //TODO: verificar que funcione
            });

            ejecutarQuery(command, dgListado);
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

            if (dgListado.CurrentRow.Cells["Chofer"].Value == DBNull.Value) {           //Carga los datos del chofer para la modificacion
                auto.choferID=-1;
            }
            else {
                auto.choferID =(int) dgListado.CurrentRow.Cells["Chofer"].Value;
                auto.choferNombre = nombreChofer();
            }

            formSiguiente.configurar(auto);
            formSiguiente.Show();
            this.Close();
        }
         
        private string nombreChofer(){
            SqlCommand nombreChofer = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getNombreChofer(@id)");
                nombreChofer.Parameters.AddWithValue("@id", dgListado.CurrentRow.Cells["Chofer"].Value);
            SqlDataReader datosChofer = nombreChofer.ExecuteReader();
            string nombre = null;
            while (datosChofer.Read()) {
                nombre = datosChofer["nombre"] + " "+ datosChofer["apellido"];
            }
            datosChofer.Close();
            return nombre;
        }

        private string descripcionTurno () {
            SqlCommand descripcionTurno = Buscador.getInstancia().getCommandFunction("fx_getDescripcion(@id)");
            descripcionTurno.Parameters.AddWithValue("@id", dgListado.CurrentRow.Cells["Turno"].Value);
            string descripcion = (string) descripcionTurno.ExecuteScalar();
            return descripcion;
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
        }

        private void deshabilitar (object sender, EventArgs e) {
            int p = base.deshabilitar("Auto", (int) dgListado.CurrentRow.Cells["ID"].Value);
            MessageBox.Show("Deshabilitados: "+ p);
            dgListado.CurrentRow.Cells["Habilitado"].Value= false;
        }

        private void selecChofer_Click (object sender, EventArgs e) {
            new frmListaChoferes(this).Show();
            this.Hide();
        }

        private void btnTodos_Click (object sender, EventArgs e) {
            ejecutarQuery(Buscador.getInstancia().verTodos("Autos"), dgListado);
        }

        private void button1_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
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
        

    }
}
