using System;
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
using UberFrba.Menus;

namespace UberFrba.Menues {
    public partial class MenuInicial : FormsAdapter {

        public MenuInicial (string rol) {
            InitializeComponent();              //TODO: Buscar funcionalidades y eliminar los botones que no corresponden
            groupBox1.Text="Funciones ("+rol+")";
            obtenerFuncionalidades(rol);
        }

        private void btnClientes_Click (object sender, EventArgs e) {
            new MenuABM("CLIENTE",this).Show();
            this.Hide();
        }

        private void btnChoferes_Click (object sender, EventArgs e) {
            new MenuABM("CHOFER",this).Show();
            this.Hide();
        }

        private void btnAutos_Click (object sender, EventArgs e) {
            new MenuABM("AUTO", this).Show();
            this.Hide();
        }

        private void btnTurnos_Click (object sender, EventArgs e) {
            new MenuABM("TURNO", this).Show();
            this.Hide();
        }

        private void btnRoles_Click (object sender, EventArgs e) {
            new MenuABMRol(this).Show();
            this.Hide();
        }


        private void obtenerFuncionalidades(string rol){
            SqlCommand commandFuncionalidades = Buscador.getInstancia().getCommandFunction("fx_getRolId(@rol)");
                commandFuncionalidades.Parameters.AddWithValue("@rol", rol);
                int rolID = (int) commandFuncionalidades.ExecuteScalar();                //Busco el ID del rol (Solo tenia el nombre...)
            
            commandFuncionalidades = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getRol(@id)");           //Busco las funcionalidades 
            commandFuncionalidades.Parameters.AddWithValue("@id", rolID);

            SqlDataReader funcionalidadesReader = commandFuncionalidades.ExecuteReader();
            actualizarBotones(funcionalidadesReader);
        }

        private void actualizarBotones(SqlDataReader funcionalidades){
            funcionalidades.Read();
            bool activado;
            
                activado = (bool) funcionalidades["Clientes"];
                if (!activado) panel.Controls.Remove(btnClientes);
            
                activado = (bool) funcionalidades["Choferes"];
                if (!activado) panel.Controls.Remove(btnChoferes);
            
                activado = (bool) funcionalidades["Autos"];
                if (!activado) panel.Controls.Remove(btnAutos);
            
                activado = (bool) funcionalidades["Roles"];
                if (!activado) panel.Controls.Remove(btnRoles);
            
                activado = (bool) funcionalidades["Turnos"];
                if (!activado) panel.Controls.Remove(btnTurnos);
            
                activado = (bool) funcionalidades["Viajes"];
                if (!activado) panel.Controls.Remove(btnViajes);
            
                activado = (bool) funcionalidades["Facturacion"];
                if (!activado) panel.Controls.Remove(btnFacturacion);

                activado = (bool) funcionalidades["Rendicion"];
                if (!activado) panel.Controls.Remove(btnRendicion);
            
                activado = (bool) funcionalidades["Estadisticas"];
                if (!activado) panel.Controls.Remove(btnEstadisticas);
            
            funcionalidades.Close();

        }

        private void button1_Click (object sender, EventArgs e) {
            this.Close();
            Login.mostrar();
        }

       

    }
}
