using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dominio {
    public class Auto : IDominio {          //Interfaz para polimorfismo en metodos del FormAdapter.
        public string marca { get; set; }               // Sirve como DataObject para enviar datos de un AUTO entre formularios
        public string modelo { get; set; }
        public string patente { get; set; }
        public string licencia { get; set; }
        public string rodado { get; set; }
        public int id { get; set; }
        public bool habilitado { get; set; }
        public int choferID { get; set; }
        public string choferNombre { get; set; }
        public int turnoID { get; set; }
        public string turnoDescripcion { get; set; }
    }
}
