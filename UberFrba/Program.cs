using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Usuario;
using UberFrba.Abm_Turno;
using UberFrba.Listado_Estadistico;
using UberFrba.Menues;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;
using System.Threading;
using System.Globalization;
using UberFrba.Dominio;

namespace UberFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Buscador.getInstancia();            //Inicializa la instancia, establece la conexion con la Base
   //     Application.Run(new frmListaAutos(new FormsAdapter()));
       //     Application.Run(new frmCargaTurno(new FormsAdapter()));
    //     Application.Run(new frmListaChoferes(new FormsAdapter()));
      //      Application.Run(new frmListaClientes(new FormsAdapter()));
//            Application.Run(new frmEstadistica());
        //      Application.Run(new frmModifRoles());
         // Application.Run(new frmCargaRol(new FormsAdapter()));

        //     Application.Run(new frmListaTurnos(new FormsAdapter()));
            //   Application.Run(new frmCargaCliente(new FormsAdapter()));
      //      Application.Run(new frmCargaAuto(new FormsAdapter()));      
              //  Application.Run(new Login());
           // Application.Run(new frmCargaViaje(new FormsAdapter()));
                Application.Run(new MenuInicial("admin"));
           //   Application.Run(new frmRendicion(new FormsAdapter()));

        }
    }
}
