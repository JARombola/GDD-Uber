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
    public partial class frmAltaUsuario : FormsAdapter {
        public frmAltaUsuario (FormsAdapter anterior) {
            InitializeComponent();
            formAnterior = anterior;
        }

        private void button1_Click (object sender, EventArgs e) {
            if (txtUsuario.Text!="" && txtPass.Text!="") {
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaUsuario");
                command.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                command.Parameters.AddWithValue("@pass", txtPass.Text);
                try {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Usuario registrado correctamente", "Registro correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException error) {
                    if (error.Number == 2627) MessageBox.Show("Nombre de usuario ya existente", "Error registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("El nombre de usuario o contraseña se encuentran vacíos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void exit (object sender, FormClosedEventArgs e) {
            base.cerrar(sender, e);
        }

    }
}
