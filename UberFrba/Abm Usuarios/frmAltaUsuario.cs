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
                int x = command.ExecuteNonQuery();
                if (x==1) MessageBox.Show("Usuario registrado correctamente", "Registro correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El nombre de usuario o contraseña se encuentran vacíos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

    }
}
