using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dominio {
    public class Auto : IDominio {          //PARA POLIMORFISMO Y REUTILIZACION EN LOS FORMS DE CARGA/MODIF
        public string marca { get; set; }
        public string modelo { get; set; }
        public string patente { get; set; }
        public string licencia { get; set; }
        public string rodado { get; set; }
        public int id { get; set; }
        public bool habilitado { get; set; }
        public int choferID { get; set; }
        public string choferNombre { get; set; }
    }
}
