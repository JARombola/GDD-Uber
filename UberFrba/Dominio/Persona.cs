using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba {                    //PARA ENVIAR A LOS FORMS DE MODIFICACION
    public class Persona : IDominio{
        public string nombre {get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string codPost { get; set; }
        public string mail { get; set; }
        public bool habilitado { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int dni { get; set; }
        public int telefono { get; set; }
        public int id { get; set; }
    }
}
