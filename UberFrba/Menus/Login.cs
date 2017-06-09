using System;
using System.Collections;
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

namespace UberFrba.Menues {
    public partial class Login : Form {

        private static Form singleton;

        public Login () {               //se hace Singleton para poder volver a mostrarlo cuando el usuario sale de su cuenta
            InitializeComponent();
            if (singleton==null) singleton = this;
        }

        private void btnValidar_Click (object sender, EventArgs e) {
            if (!(string.IsNullOrWhiteSpace(txtPass.Text) || String.IsNullOrWhiteSpace(txtUser.Text))) {
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_login");
                command.Parameters.AddRange(new[]{
                    new SqlParameter("@usuario",txtUser.Text),
                    new SqlParameter("@password",txtPass.Text),
                });
                try {
                    int restantes =(int) command.ExecuteScalar();           // Devuelve la cantidad de intentos restantes del usuario
                    if (restantes == 3) iniciarSesion();                // Pass ok y restantes = 3 (si tenia menos, se le reiniciaron por ponerla bien)
                    else {
                        if (restantes>0) {                              // Pass mal, le quedan X intentos
                            actualizarLabelIntentos(restantes);
                        }
                        else {                                              // Esta bloqueado, tiene 0 intentos restantes 
                            lblIntentos.Text="USUARIO DESHABILITADO: "+txtUser.Text;
                            lblIntentos.Visible=true;
                        }
                    }
                }
                catch (SqlException error) {
                    if (error.Number == 51000) MessageBox.Show(error.Message, "Error de logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);      //Usuario inexistente
                    else MessageBox.Show("Error de logueo.\nConsulte al administrador", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblIntentos.Visible=false;

                }
            }
            else MessageBox.Show("El nombre de usuario y contraseña no pueden estar estar vacios", "Error de logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void actualizarLabelIntentos (int restantes) {          //Actualiza el label con la cantidad de intentos restantes
            MessageBox.Show("Intentos Restantes:"+restantes, "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblIntentos.Text="- Intentos restantes: "+restantes;
            lblIntentos.Visible=true;
        }

        private void iniciarSesion () {                     //Controla los roles del usuario
            SqlDataReader roles = obtenerRoles();                   // Obtiene los roles
            ArrayList nombresRoles = new ArrayList();
            while (roles.Read()) {
                nombresRoles.Add(roles.GetString(0));           //Obtiene el nombre de cada Rol del usuario y lo agrega a un array.
            }
            roles.Close();
            if (nombresRoles.Count==0) MessageBox.Show("El usuario no tiene ningun rol asignado.\nNo podrá ingresar al sistema.", "Usuario sin roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                limpiar();
                if (nombresRoles.Count>1) consultarRol(nombresRoles);                     // Si hay mas de un rol, el usuario elige en el proximo form
                else new MenuInicial((string) nombresRoles[0]).Show() ;          // 1 solo rol => Se inicia con ese 
                this.Hide();
            }
        }
   
        private void consultarRol(ArrayList roles)                //En el proximo rol se le consulta con cual iniciar sesion
        {
           new menuRoles(roles).Show();
        }

        private SqlDataReader obtenerRoles(){               //Devuelve el DatReader con los roles del usuario
            SqlCommand commandRol = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getRolesDeUsuario(@usuario)");
                commandRol.Parameters.AddWithValue("@usuario", txtUser.Text);
            SqlDataReader rolesReader = commandRol.ExecuteReader();
            return rolesReader;
        }


        private void checkBox1_CheckedChanged (object sender, EventArgs e) {
            if (checkPass.Checked) txtPass.UseSystemPasswordChar=false;
            else txtPass.UseSystemPasswordChar=true;
        }

        public static void mostrar () {
            singleton.Show();
        }

        private void limpiar () {
            txtUser.Text="";
            txtPass.Text="";
            lblIntentos.Visible=false;
            checkPass.Checked=false;
        }
    }
}
