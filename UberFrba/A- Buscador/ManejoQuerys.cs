using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace UberFrba.A__Buscador {
    class ManejoQuerys {                        

        public String concatenarBusquedaConLike(ArrayList columnas, String palabraBuscada) {
            if (columnas.Count>0) {
                StringBuilder resultado = new StringBuilder();
                for (int i=0; i<columnas.Count-1; i++) {
                    resultado.Append(columnas[i] + " like '%"+palabraBuscada+"%' OR ");
                }
                resultado.Append(columnas[columnas.Count -1] +" like '%"+palabraBuscada+"%' ");
                return resultado.ToString();
            }
            return "";
        }

        public String concatenarBusquedaExactaStrings (ArrayList columnasString, String palabraBuscada) {        // HAY PROBLEMA SI SE BUSCA EN UN INT... (PORQUE SE MANDA COMO CHAR Y ROMPE TODO)
            if (columnasString.Count>0) {
                StringBuilder resultado = new StringBuilder();
                for (int i=0; i<columnasString.Count-1; i++) {
                    resultado.Append(columnasString[i] + " = '"+ palabraBuscada+ "' OR ");
                }
                resultado.Append(columnasString[columnasString.Count -1] +" = '"+palabraBuscada+"' ");
                return resultado.ToString();
            }
            return "";
        }

        public String concatenarBusquedaExactaInts (ArrayList columnasInts, String palabraBuscada) {        // HAY PROBLEMA SI SE BUSCA EN UN INT... (PORQUE SE MANDA COMO CHAR Y ROMPE TODO)        
            if (columnasInts.Count>0){
                StringBuilder resultado = new StringBuilder();
                for (int i=0; i<columnasInts.Count-1; i++) {
                    resultado.Append(columnasInts[i] + " = "+ palabraBuscada+ " OR ");
                }
                resultado.Append(columnasInts[columnasInts.Count -1] +" = "+palabraBuscada+" ");
                return resultado.ToString();
            }
            return "";
        }

        public String campos(ArrayList columnasMostrar) {
            StringBuilder resultado = new StringBuilder();
            for (int i=0; i<columnasMostrar.Count-1; i++) {
                resultado.Append(columnasMostrar[i] + ", ");
            }
            resultado.Append(columnasMostrar[columnasMostrar.Count -1] +" ");
            return resultado.ToString();
        }
    }
}
