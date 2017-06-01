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
            String errores = errorCampos();
            if (errores == null) {
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaUsuario");
                command.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                command.Parameters.AddWithValue("@pass", txtPass.Text);
                try {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Usuario registrado correctamente", "Registro correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException error) {
                    switch (error.Number) {
                        case 2627: MessageBox.Show("El nombre de usuario ya se encuentra en uso", "Usuario existente", MessageBoxButtons.OK, MessageBoxIcon.Error);    //Violacion de restriccion UNIQUE 
                            break;
                        case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    }
               }
            }
            else MessageBox.Show(errores,"Error de registro",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public override string errorCampos () {
            String errores = null;
            if (String.IsNullOrWhiteSpace(txtUsuario.Text)) errores+= "- Nombre de usuario vacío\n";
            if (String.IsNullOrWhiteSpace(txtPass.Text)) errores+= "- Contraseña vacía\n";
            return errores;
        }

        private void button2_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

    }
}
