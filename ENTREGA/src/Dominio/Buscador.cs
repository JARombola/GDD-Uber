using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UberFrba.Dominio {
    class Buscador {                                                // Singleton para facilitar las consultas a la base
        private static Buscador instancia{ get; set; }                      // Crea SqlCommands
        public SqlConnection conexion { get; set; }
        private string ESQUEMA = "[MAIDEN]";               

        private Buscador () {                           //Se conecta con la base al ser creado
            String config = ConfigurationManager.AppSettings["configuracionSQL"];
            conexion = new SqlConnection(config);
            try { 
                conexion.Open();
            }
            catch (Exception) {
                MessageBox.Show("Fallo la conexion");
            }
        }

        public static Buscador getInstancia(){
            if (instancia == null) instancia = new Buscador();
            return instancia;
        }

        public SqlCommand getCommandStoredProcedure (string storedProcedure) {                  // Para Procedimientos almacenados
            string query = ESQUEMA + "."+storedProcedure;                                       //Recibe el nombre del SP
            SqlCommand command= this.getCommand(query);
                command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public SqlCommand getCommandFunction (string funcion) {                 // Para funciones escalares
            string query= "SELECT "+ESQUEMA+".";                                //Recibe el nombre de la funcion
                query+=funcion;
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }

        public SqlCommand getCommandFunctionDeTabla (string funcion) {              // Para funciones de TABLA
            string query= "SELECT * From "+ESQUEMA+".";                             // Recibe el nombre de la funcion
                query+=funcion;
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }


        public SqlCommand getCommand(string query) {                        // Para consultas directas (NO SE USA)
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }

        //------------ METODOS AUTOS--------------------------------
        public void cargarMarcas (ComboBox cbMarcas) {                          // Obtiene todas las marcas de autos registradas y los carga en un combobox (se usa en los formularios de AUTOS)
            SqlCommand command= this.getCommandFunctionDeTabla("fx_getMarcas()");
            SqlDataReader marcas = command.ExecuteReader();
            while (marcas.Read()) {
                cbMarcas.Items.Add(marcas.GetString(0));
            }
            marcas.Close();
        }

        //------------ METODOS ROLES--------------------------------
        public void cargarRoles(ComboBox cbRoles){                                      // Obtiene los roles existentes y los carga en un combobox (se usa en los formularios de ROLES)
            SqlCommand command= this.getCommandFunctionDeTabla("fx_getRoles()");
            SqlDataReader datos = command.ExecuteReader();
            while (datos.Read()) {
                cbRoles.Items.Add(datos.GetString(0));
            }
            datos.Close();
        }

        //-------------- METODOS USUARIOS

        internal void cargarUsuarios (ComboBox cbUser) {                                // Obtiene los usuarios existentes y los carga en un combobox(se usa en los formularios de Roles, para asignarle)
            SqlCommand command = this.getCommandFunctionDeTabla("fx_getUsuarios()");
            SqlDataReader usuarios= command.ExecuteReader();
            while (usuarios.Read()) {
                cbUser.Items.Add(usuarios["usuario"]);
            }
            usuarios.Close();
        }

        internal void cargarRoles (CheckedListBox listRoles) {                              // Carga los roles en un listado (se usa en form de Roles)
            SqlCommand command = this.getCommandFunctionDeTabla("fx_getRolesHabilitados()");
            SqlDataReader roles= command.ExecuteReader();
            while (roles.Read()) {
                listRoles.Items.Add(roles.GetString(0));
            }
            roles.Close();
        }

        internal SqlCommand verTodos (string tabla) {                   //TODO: BORRAR ESTOS METODOS
            string query = "SELECT * FROM "+ESQUEMA+"."+tabla;
            SqlCommand command = this.getCommand(query);
            return command;
        }

        internal SqlCommand verTodosHabilitados (string tabla) {
            string query = "SELECT * FROM "+ESQUEMA+"."+tabla+" Where Habilitado = 1";
            SqlCommand command = this.getCommand(query);
            return command;
        }

    }
}
