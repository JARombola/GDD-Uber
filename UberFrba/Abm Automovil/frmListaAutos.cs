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
using UberFrba.A__Buscador;


namespace UberFrba.Abm_Automovil {
    public partial class frmListAutomoviles : ListadosAdapter {
        public frmListAutomoviles () {
            InitializeComponent();
            TABLA = "gd_esquema.Maestra";
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

        private void btnClean_Click (object sender, EventArgs e) {
            txtChofer.Clear();
            txtModelo.Clear();
            txtPatente.Clear();
            cbMarca.SelectedIndex=-1;
            dgListado.DataSource = null;
            dgListado.Refresh();
        }

        private void frmListAutomoviles_Load (object sender, EventArgs e) {
            SqlConnection conn = Buscador.getInstancia().conexion;
            String query = "SELECT Distinct Auto_Marca FROM "+TABLA+" order by 1";
            SqlCommand command= new SqlCommand(query, conn);
            SqlDataReader datos = command.ExecuteReader();            // CARGA MANUAL? FEO

            while (datos.Read()) {
                cbMarca.Items.Add(datos.GetString(0));
            }
            datos.Close();
            cbMarca.SelectedIndex=0;

        }

    }
}
