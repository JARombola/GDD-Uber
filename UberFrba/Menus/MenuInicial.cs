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
using UberFrba.Facturacion;
using UberFrba.Listado_Estadistico;
using UberFrba.Menus;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;

namespace UberFrba.Menues {
    public partial class MenuInicial : FormsAdapter {

        enum Funcion{CLIENTES=1, CHOFERES, AUTOS, ROLES, TURNOS, VIAJES, FACTURACION, RENDICION, ESTADISTICAS}

        public MenuInicial (string rol) {
            InitializeComponent();              
            groupBox1.Text="Funciones ("+rol+")";
            obtenerFuncionalidades(rol);
        }

        private void obtenerFuncionalidades(string rol){                    // Consulta las funcionalidades del rol en la base de datos
            SqlCommand commandFuncionalidades = Buscador.getInstancia().getCommandFunction("fx_getRolId(@rol)");
                commandFuncionalidades.Parameters.AddWithValue("@rol", rol);
                int rolID = (int) commandFuncionalidades.ExecuteScalar();                //Busco el ID del rol (Solo tenia el nombre...)
            
            commandFuncionalidades = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getFuncionalidades(@idRol)");           //Busco las funcionalidades 
            commandFuncionalidades.Parameters.AddWithValue("@idRol", rolID);

            SqlDataReader funcionalidadesReader = commandFuncionalidades.ExecuteReader();
            actualizarBotones(funcionalidadesReader);
        }

        private void actualizarBotones(SqlDataReader funcionalidades){              // Elimina botones que no corresponden con las funciones del rol
            ArrayList funciones = new ArrayList();
            while (funcionalidades.Read()) {
                funciones.Add(funcionalidades.GetInt32(0));                    
                }
            funcionalidades.Close();
            if (!funciones.Contains((int)Funcion.CLIENTES)) panel.Controls.Remove(btnClientes);
            if (!funciones.Contains((int) Funcion.CHOFERES)) panel.Controls.Remove(btnChoferes);
            if (!funciones.Contains((int) Funcion.AUTOS)) panel.Controls.Remove(btnAutos);
            if (!funciones.Contains((int) Funcion.ROLES)) panel.Controls.Remove(btnRoles);
            if (!funciones.Contains((int) Funcion.TURNOS)) panel.Controls.Remove(btnTurnos);
            if (!funciones.Contains((int) Funcion.VIAJES)) panel.Controls.Remove(btnViajes);
            if (!funciones.Contains((int) Funcion.FACTURACION)) panel.Controls.Remove(btnFacturacion);
            if (!funciones.Contains((int) Funcion.RENDICION)) panel.Controls.Remove(btnRendicion);
            if (!funciones.Contains((int) Funcion.ESTADISTICAS)) panel.Controls.Remove(btnEstadisticas);
        }


        private void btnClientes_Click (object sender, EventArgs e) {
            new MenuABM("Clientes", this).Show();
            this.Hide();
        }

        private void btnChoferes_Click (object sender, EventArgs e) {
            new MenuABM("Choferes", this).Show();
            this.Hide();
        }

        private void btnAutos_Click (object sender, EventArgs e) {
            new MenuABM("Autos", this).Show();
            this.Hide();
        }

        private void btnTurnos_Click (object sender, EventArgs e) {
            new MenuABM("Turnos", this).Show();
            this.Hide();
        }

        private void btnRoles_Click (object sender, EventArgs e) {
            new MenuABMRol(this).Show();
            this.Hide();
        }

        private void button1_Click (object sender, EventArgs e) {
            this.Close();
            Login.mostrar();
        }

        private void btnViajes_Click (object sender, EventArgs e) {
            new frmCargaViaje(this).Show();
            this.Hide();
        }

        private void btnEstadisticas_Click (object sender, EventArgs e) {
            new frmEstadistica(this).Show();
            this.Hide();

        }

        private void btnRendicion_Click (object sender, EventArgs e) {
            new frmRendicion(this).Show();
            this.Hide();
        }

        private void btnFacturacion_Click (object sender, EventArgs e) {
            new frmFacturacion(this).Show();
            this.Hide();
        }

    }
}
