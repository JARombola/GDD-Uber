using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba {
    public class ListadosAdapter : Form{
    
        public void limpiar(ArrayList cajasTexto){
            foreach(TextBox t in cajasTexto){
                t.Clear();  
            }
        }

        public Boolean quiereBuscar (String palabra, ref Boolean agregarOR, ref String query) {
            if (!string.IsNullOrEmpty(palabra)) {
                if (agregarOR) query+=" OR ";
                agregarOR=true;
                return true;
            }
            return false;
        }

    }
}
