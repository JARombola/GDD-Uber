﻿using System;
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
using UberFrba.A__Buscador;

namespace UberFrba.Menues {
    public partial class Login : Form {
        public Login () {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged (object sender, EventArgs e) {
            if (checkBox1.Checked) txtPass.UseSystemPasswordChar=false;
            else txtPass.UseSystemPasswordChar=true ;
        }

        private void btnValidar_Click (object sender, EventArgs e) {            //Verifica Usuario y Contraseña
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_login");
            command.Parameters.AddRange(new[]{
                new SqlParameter("@usuario",txtUser.Text),
                new SqlParameter("@password",txtPass.Text),
            });
            try {
                int restantes =(int) command.ExecuteScalar();           // Devuelve la cantidad de intentos restantes del usuario
                if (restantes == 3) iniciarSesion();                // Pass ok!, inicia sesion
                else {
                    if (restantes>0) {                              // Pass mal, le quedan X intentos
                        actualizarLabelIntentos(restantes);
                    }
                    else {
                        lblIntentos.Text="USUARIO DESHABILITADO: "+txtUser.Text;   //Pass mal, no le quedan intentos (=0)
                        lblIntentos.Visible=true;
                    }
                    }
            }
            catch (SqlException error) {            //No existia el usuario
                MessageBox.Show(error.Message);
                lblIntentos.Visible=false;
            }
        }

        private void actualizarLabelIntentos (int restantes) {          //Actualiza el label con la cantidad de intentos restantes
            MessageBox.Show("Intentos Restantes:"+restantes, "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblIntentos.Text="- Intentos restantes: "+restantes;
            lblIntentos.Visible=true;
        }

        private void iniciarSesion () {
            verificarRoles();
        }

        private void verificarRoles () {
            SqlDataReader roles = obtenerRoles();
            ArrayList nombresRoles = new ArrayList();
            while (roles.Read()) {
                nombresRoles.Add(roles.GetString(0));           //Obtiene el nombre de cada Rol del usuario
            }
            roles.Close();

            if (nombresRoles.Count>1) {                         // Si hay mas de un rol, el usuario elige en el proximo form
                consultarRol(nombresRoles);
            }
            else 
                new MenuInicial((string) nombresRoles[0]).Show();          // 1 solo rol => Se inicia con ese 
            this.Hide();
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
       
    }
}
