using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.A__Buscador {
    class Buscador {
        private static Buscador instancia{ get; set; }
        private SqlConnection conexion;
        private string DATOS_USUARIO = "user id=gd; password=gd2017";
        private string BASE = "database=Animales; ";
 

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

        private String obtenerDireccionBD () {
            StreamReader file = new StreamReader(@"..\..\configBD.txt");
            String linea = file.ReadLine();
            int inicioURL=linea.IndexOf("=")+1;
            linea = linea.Substring(inicioURL, linea.Length-inicioURL);
            linea = linea.Trim();
        return linea;
        }

        public static Buscador getInstancia(){
            if (instancia == null) instancia = new Buscador();
            return instancia;
        }

        public void ejecutarQuery (string query, DataGridView dataGrid) {
            SqlCommand command= new SqlCommand(query, conexion);
            ConfiguradorDG config = new ConfiguradorDG();
            config.completarDataGrid(dataGrid, command);
           // return data;
        }
    }
}
