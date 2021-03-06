﻿using System;
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
            base.ocultarColumnas(dgListado);
        }


        private void enviarDatos () {               //Crea un data-object TURNO (con los datos obtenidos de la base) para enviar al formulario de carga
            Turno turno = new Turno();
                turno.inicio = (decimal) dgListado.CurrentRow.Cells["Hora_inicio"].Value;
                turno.fin = (decimal) dgListado.CurrentRow.Cells["Hora_fin"].Value;
                turno.precioBase= (decimal) dgListado.CurrentRow.Cells["Precio_Base"].Value;
                turno.precioKm= (decimal) dgListado.CurrentRow.Cells["Precio_Km"].Value;
                turno.descripcion= (string) dgListado.CurrentRow.Cells["Descripcion"].Value;
                turno.habilitado = (bool) dgListado.CurrentRow.Cells["Habilitado"].Value;
                turno.id = (int) dgListado.CurrentRow.Cells["ID"].Value;
         formSiguiente.configurar(turno);                       // Envia los datos del turno y lo "configura" para una modificacion
         formSiguiente.Show();
         this.Close();  
        }


        private void btnClean_Click (object sender, EventArgs e) {
            txtDescripcion.Clear();
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
            try { dgListado[hit.ColumnIndex, hit.RowIndex].Selected = true; }
            catch (System.ArgumentOutOfRangeException) { //.... Hizo click derecho en cualquier lado
            }
        }

        private void btnTodos_Click_1 (object sender, EventArgs e) {
            if(soloHabilitados)ejecutarQuery(Buscador.getInstancia().verTodosHabilitados("Turno"),dgListado);
            else ejecutarQuery(Buscador.getInstancia().verTodos("Turno"), dgListado);
        }

        private void btnAtras_Click_1 (object sender, EventArgs e) {
            base.volver();
        }

        private void frmListaTurnos_Load (object sender, EventArgs e) {
            lblHabilitados.Visible=soloHabilitados;
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
