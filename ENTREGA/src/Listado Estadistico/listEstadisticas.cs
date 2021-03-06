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
using UberFrba.Dominio;

namespace UberFrba.Listado_Estadistico          // TODO: Eliminar barra herrmientas
{
    public partial class frmEstadistica : FormsAdapter
    {
        public frmEstadistica(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior = anterior;
            FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
            dateAnio.MaxDate = FECHA_ACTUAL;
            dateAnio.Value = FECHA_ACTUAL;
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            int trimestre = this.getTrimestre();
            string funcion = this.getTipoEstadistica();
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla(funcion+"(@anio, @trimestre)");
            command.Parameters.AddWithValue("@anio", dateAnio.Value.Year);
            command.Parameters.AddWithValue("@trimestre", trimestre);
            ejecutarQuery(command, dgEstadisticas);             // <<----- Ejecuta la query (o sea, la funcion indicada) y carga el listado
        }

        private int getTrimestre () {               // Devuelve el trimestre segun el radioButton seleccionado
            if (radioButton1.Checked) return 1;
            if (radioButton2.Checked) return 2;
            if (radioButton3.Checked) return 3;
            else return 4;
            }

        private string getTipoEstadistica () {          // Devuelve el nombre de la funcion (SQL) segun la opcion elegida
            switch (cbTipo.SelectedIndex) {
                case 0: return "fx_choferesMayorRecaudacion";
                case 1: return "fx_choferesViajesMasLargos";
                case 2: return "fx_clientesMayorConsumo";
                case 3: return "fx_clientesMismoAuto";
            }
            return null;
        }

        private void btnAtras_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void cbTipo_SelectedIndexChanged (object sender, EventArgs e) {
            btnAceptar.Enabled=true;
        }
  }
}
