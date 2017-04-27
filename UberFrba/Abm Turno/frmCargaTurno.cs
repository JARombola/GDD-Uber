using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;

namespace UberFrba.Abm_Turno {
    public partial class frmCargaTurno : CargasAdapter {
        public frmCargaTurno (Form anterior) {
            InitializeComponent();
            frmAnterior = anterior;
        }

        private void btnAceptar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("[ASD].SP_altaTurno");
                command.Parameters.AddWithValue("@inicio", horaInicio.Value);
                command.Parameters.AddWithValue("@fin", horaFin.Value);
                command.Parameters.AddWithValue("@precioBase", precioBase.Value);
                command.Parameters.AddWithValue("@precioKm", precioKm.Value);
                command.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                command.Parameters.AddWithValue("@habilitado", chkHabilitado.Checked);
                command.ExecuteNonQuery();
            MessageBox.Show("Guardado");
        }
    }
}
