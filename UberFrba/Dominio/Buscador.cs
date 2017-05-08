using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Dominio {
    class Buscador {
        private static Buscador instancia{ get; set; }
        public SqlConnection conexion { get; set; }
        private string DATOS_USUARIO = "user id=gd; password=gd2017";
        private string BASE = "database=GD1C2017; ";
        private string ESQUEMA = "[MAIDEN]";               //TODO: modificar nombre esquema
 

        private Buscador () {
  //        string direccion = obtenerDireccionBD();
            String config = "server=LocalHost\\SQLSERVER2012; "+ BASE+DATOS_USUARIO;
            conexion = new SqlConnection(config);
            try { 
                conexion.Open();
               MessageBox.Show("CONEXION OK!");
            }
            catch (Exception ex) {
                MessageBox.Show("Fallo la conexion");
            }
        }

        public static Buscador getInstancia(){
            if (instancia == null) instancia = new Buscador();
            return instancia;
        }

        public SqlCommand getCommandStoredProcedure (string storedProcedure) {
            string query = ESQUEMA + "."+storedProcedure;
            SqlCommand command= this.getCommand(query);
                command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public SqlCommand getCommandFunction (string funcion) {
            string query= "SELECT "+ESQUEMA+".";
                query+=funcion;
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }

        public SqlCommand getCommandFunctionDeTabla (string funcion) {
            string query= "SELECT * From "+ESQUEMA+".";
                query+=funcion;
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }


        public SqlCommand getCommand(string query) {
            SqlCommand command= new SqlCommand(query, conexion);
            return command;
        }

        private String obtenerDireccionBD () {              //LEER ARCHIVO DE CONFIGURACION...
            StreamReader file = new StreamReader(@"..\..\configBD.txt");
            String linea = file.ReadLine();
            int inicioURL=linea.IndexOf("=")+1;
            linea = linea.Substring(inicioURL, linea.Length-inicioURL);
            linea = linea.Trim();
            return linea;
        }


        //------------ METODOS AUTOS--------------------------------
        public void cargarMarcas (ComboBox cbMarcas) {      
            String query = "SELECT Distinct Marca FROM "+ESQUEMA+".Autos order by 1";
            SqlCommand command= this.getCommand(query);
            SqlDataReader marcas = command.ExecuteReader();
            while (marcas.Read()) {
                cbMarcas.Items.Add(marcas.GetString(0));
            }
            marcas.Close();
        }

        //------------ METODOS ROLES--------------------------------
        public void cargarRoles(ComboBox cbRoles){
            String query = "SELECT Rol FROM "+ESQUEMA+".Roles order by 1";
            SqlCommand command= this.getCommand(query);
            SqlDataReader datos = command.ExecuteReader();
            while (datos.Read()) {
                cbRoles.Items.Add(datos.GetString(0));
            }
            datos.Close();
        }

        public Boolean cargarFunciones (int rolId, CheckedListBox listaFunciones) {
            String query = "SELECT * FROM "+ESQUEMA+".Roles where ID = '"+rolId+"'";
            SqlCommand command= this.getCommand(query);
            SqlDataReader datos = command.ExecuteReader();
            datos.Read();
            int i;
            for(i=1 ; i<datos.FieldCount-2;i++){        
                listaFunciones.SetItemChecked(i-1, datos.GetBoolean(i)) ;
            }
            Boolean habilitado = datos.GetBoolean(i);
            datos.Close();
            return habilitado;           //devuelve si el rol está habilitado o no, se usa en el form de roles para el boton de habilitar
        }

        //-------------- METODOS USUARIOS

        internal void cargarUsuarios (ComboBox cbUser) {
            string query = "Select usuario From "+ESQUEMA+".Usuarios";
            SqlCommand command = this.getCommand(query);
            SqlDataReader usuarios= command.ExecuteReader();
            while (usuarios.Read()) {
                cbUser.Items.Add(usuarios["usuario"]);
            }
            usuarios.Close();
        }

        internal void cargarRoles (CheckedListBox listRoles) {
            string query = "Select Rol From "+ESQUEMA+".Roles order by 1";
            SqlCommand command = this.getCommand(query);
            SqlDataReader roles= command.ExecuteReader();
            while (roles.Read()) {
                listRoles.Items.Add(roles.GetString(0));
            }
            roles.Close();
        }



        internal SqlCommand verTodos (string tabla) {
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
