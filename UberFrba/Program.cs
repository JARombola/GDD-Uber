using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Listado_Estadistico;

namespace UberFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmListAutomoviles(new ListadosAdapter()));
     //       Application.Run(new frmListaChoferes(new ListadosAdapter()));
    //        Application.Run(new frmListaClientes(new ListadosAdapter()));
//            Application.Run(new frmEstadistica());
   //          Application.Run(new frmRoles());
      //       Application.Run(new frmListaTurnos(new ListadosAdapter()));
//            Application.Run(new frmCargaPersona("Cliente"));
   //         Application.Run(new frmCargaAutos());
        }
    }
}
