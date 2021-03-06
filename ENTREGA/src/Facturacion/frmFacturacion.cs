﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;
using UberFrba.Dominio;

namespace UberFrba.Facturacion {
    public partial class frmFacturacion : FormsAdapter {
        private bool buscaCliente { get; set; }
        private int idCliente { get; set; }

        public frmFacturacion (FormsAdapter anterior) {
            InitializeComponent();
            formAnterior=anterior;
            FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
            FECHA_ACTUAL=FECHA_ACTUAL.AddMonths(-1);              //LA factura podrá ser del mes anterior
            fechaInicio.MaxDate = new DateTime(FECHA_ACTUAL.Year,FECHA_ACTUAL.Month,1);
            fechaFin.MaxDate = new DateTime(fechaInicio.MaxDate.Year, fechaInicio.MaxDate.Month, DateTime.DaysInMonth(fechaInicio.MaxDate.Year, fechaInicio.MaxDate.Month));
            fechaFin.Value = fechaFin.MaxDate;
            fechaInicio.Value =fechaInicio.MaxDate;
        }

        public override void configurar (IDominio elemento) {               // Método usado por el Listado de Clientes. Envía el Cliente seleccionado (al que se le realizará la facturación)
            Persona cliente = (Persona) elemento;
            idCliente = cliente.id;
            txtCliente.Text = (cliente.nombre +" "+ cliente.apellido);
            toolTip1.SetToolTip(txtCliente, String.Format("{0} {1}\n -DNI: {2}\n-Direccion: {3}\n-Telefono: {4}", cliente.nombre, cliente.apellido, cliente.dni, cliente.direccion, cliente.telefono));
        }

        private void btnFacturar_Click (object sender, EventArgs e) {
            String errores = errorCampos();
            if (errores==null) {
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_Facturacion");
                command.Parameters.AddRange(new[]{
                        new SqlParameter("@idCliente",idCliente),
                        new SqlParameter("@fechaInicio",fechaInicio.Value),
                        new SqlParameter("@fechaFin",fechaFin.Value),                       
                        new SqlParameter("@fechaFactura",FECHA_ACTUAL),                       
                    }
                );
                try {
                    ejecutarQuery(command, dgListado);
                    if (dgListado.Rows.Count==1) MessageBox.Show("No hay viajes registrados en ese mes", "Sin viajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException error) {
                    if (error.Number == 51002){
                        if (MessageBox.Show("La factura ya se encuentra registrada.\n Desea visualizarla?", "Factura Existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            ==DialogResult.Yes) mostrarFacturacionExistente(error.Message);             // Si el cliente desea ver una factura que YA ESTABA registrada
                }else MessageBox.Show(error.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            }else MessageBox.Show(errores, "Error de campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mostrarFacturacionExistente(string codFacturaString){                 // Si la factura ya existía y el usuario desea ver el detalle
            int codFactura;                                                                 // desde acá se cargan sus datos, en base al cod de factura obtenido de la excepcion
            int.TryParse(codFacturaString, out codFactura);
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getFacturaExistente(@nroFactura)");
            command.Parameters.AddWithValue("@nroFactura", codFactura);
            ejecutarQuery(command, dgListado);
            dgListado.Sort(dgListado.Columns[7], ListSortDirection.Ascending);
        }
            
        public override string errorCampos () {                 //Valida campos
            String errores = null;
            if (String.IsNullOrWhiteSpace(txtCliente.Text)) errores+="- Debe seleccionar un Cliente\n";
            if (fechaInicio.Value>=fechaFin.Value) errores+= "- La fecha de inicio debe ser mayor que la de fin\n";
            return errores;
        }

        //--------------------------------------------- BOTONES---------------------------------
        private void btnChofer_Click (object sender, EventArgs e) {
            frmListaClientes listaClientes = new frmListaClientes(this);
            listaClientes.formSiguiente=this;
            listaClientes.soloHabilitados=true;
            buscaCliente = true;
            listaClientes.Show();
            this.Hide();
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void fechaInicio_ValueChanged (object sender, EventArgs e) {
            fechaInicio.Value = new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Month, 1);
            fechaFin.Value= new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Month, DateTime.DaysInMonth(fechaInicio.Value.Year, fechaInicio.Value.Month));
        }

        private void fechaFin_ValueChanged (object sender, EventArgs e){
            fechaFin.Value = new DateTime(fechaFin.Value.Year, fechaFin.Value.Month,DateTime.DaysInMonth(fechaFin.Value.Year,fechaFin.Value.Month));
            fechaInicio.Value = new DateTime(fechaFin.Value.Year, fechaFin.Value.Month, 1);
        }


    }
}
