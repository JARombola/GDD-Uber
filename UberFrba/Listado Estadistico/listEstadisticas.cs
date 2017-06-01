using System;
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
        }

        private void frmEstadistica_Load (object sender, EventArgs e) {
            dateAnio.Value = DateTime.Now;
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            int trimestre = this.getTrimestre();
            string funcion = this.getTipoEstadistica();
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla(funcion+"(@anio, @trimestre)");
            command.Parameters.AddWithValue("@anio", dateAnio.Value.Year);
            command.Parameters.AddWithValue("@trimestre", trimestre);
            ejecutarQuery(command, dgEstadisticas);
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
            formAnterior.Show();
            this.Close();
        }

        private void exit (object sender, FormClosedEventArgs e) {
            base.cerrar(sender, e);
        }
        }

}
