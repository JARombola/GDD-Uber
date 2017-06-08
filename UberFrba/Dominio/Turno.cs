using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dominio {
    public class Turno : IDominio {                 //Interfaz para polimorfismo en metodos del FormAdapter.   
        public decimal inicio { get; set; }                 // Sirve como DataObject para enviar datos de un TURNO entre formularios
        public decimal fin { get; set; }
        public decimal precioBase { get; set; }
        public decimal precioKm { get; set; }
        public string descripcion { get; set; }
        public bool habilitado { get; set; }
        public int id { get; set; }

    }
}
