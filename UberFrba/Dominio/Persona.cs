using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba {
      public class Persona : IDominio {                    //Interfaz para polimorfismo en metodos del FormAdapter.   
        public string nombre { get; set; }                   // Sirve como DataObject para enviar datos de una PERSONA (chofer/cliente) entre formularios
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int piso { get; set; }
        public string dpto { get; set; }
        public string localidad { get; set; }
        public string mail { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public bool habilitado { get; set; }
        public int id { get; set; }
    }
}
