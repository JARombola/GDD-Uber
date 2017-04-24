using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class frmCargaCliente : ModifAdapter
    {
        public frmCargaCliente()
        {
            InitializeComponent();
        }

        public override void cargarDatosModificacion (IDominio unaPersona) {
            Persona persona = (Persona) unaPersona;
            //TODO: Cargar textbox con los datos que vengan de la ventana de seleccion

        }
    }
}
