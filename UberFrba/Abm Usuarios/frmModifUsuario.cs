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
using UberFrba.Dominio;

namespace UberFrba.Abm_Usuarios {
    public partial class frmModifUsuario : FormsAdapter {

        public frmModifUsuario (FormsAdapter anterior) {
            InitializeComponent();
            Buscador.getInstancia().cargarUsuarios(cbUsuario);
            formAnterior=anterior;
        }

        private void button1_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_modifPass");
                command.Parameters.AddWithValue("@usuario", cbUsuario.Text);
                command.Parameters.AddWithValue("@pass", txtPass.Text);

                int x = command.ExecuteNonQuery();
                MessageBox.Show("Usuario Modificado correctamente");
        }

        private void cbUsuario_SelectedIndexChanged (object sender, EventArgs e) {
            btnModif.Enabled=true;
            btnEliminar.Enabled=true;
        }

        private void btnEliminar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_eliminarUsuario");
                command.Parameters.AddWithValue("@usuario", cbUsuario.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Usuario eliminado correctamente");
            cbUsuario.Items.Clear();
            Buscador.getInstancia().cargarUsuarios(cbUsuario);
        }

        private void button2_Click (object sender, EventArgs e) {
            base.volver();
        }
    }
}
