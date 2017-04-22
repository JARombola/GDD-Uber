using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.A__Buscador {
    class Buscador {
        private static Buscador instancia{ get; set; }
        public SqlConnection conexion { get; set; }
        private string DATOS_USUARIO = "user id=gd; password=gd2017";
        private string BASE = "database=GD1C2017; ";
        private string ESQUEMA = "[ASD]";               //TODO: modificar nombre esquema
 

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
            SqlCommand command= this.getCommand(storedProcedure);
                command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public SqlCommand getCommandFunction (string funcion) {
            string query= "SELECT * FROM "+ESQUEMA+".";
                query+=funcion;
            SqlCommand command= new SqlCommand(query, conexion);
              //  command.CommandType = CommandType.TableDirect;
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
    }
}
