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

namespace UberFrba.Abm_Usuario
{
    public partial class frmAsignarRoles : FormsAdapter           //TODO: verificar que se actualice el menu inicial, si el modificado es JUSTO el rol de la persona
    {
        public frmAsignarRoles(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior = anterior;
            Buscador.getInstancia().cargarUsuarios(cbUsuario);
            Buscador.getInstancia().cargarRoles(listRoles);
        }

        private void cbUsuario_SelectedIndexChanged (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getRolesDeUsuario(@usuario)");
                command.Parameters.AddWithValue("@usuario", cbUsuario.SelectedItem);
                int i = 0;
                while (i++<listRoles.Items.Count) {
                    listRoles.SetItemChecked(i-1, false);               //Desactivo todos los roles
                }
                actualizarRoles(command);                       //Marco los del usuario
                btnOk.Enabled=true;
        }

        private void actualizarRoles (SqlCommand command) {
            SqlDataReader roles = command.ExecuteReader();
            while (roles.Read()) {
                string rol = (string) roles["Rol"];
                int i = 0;
                bool encontrado=false;
                while (!encontrado) {
                    if (listRoles.Items[i].ToString() == rol) {
                        listRoles.SetItemChecked(i, true);
                        encontrado=true;
                    }
                    i++;
                }
            }
            roles.Close();
        }

        private void btnOk_Click (object sender, EventArgs e) {
            int i = 0;
            string accion, rol;
            while (i<listRoles.Items.Count) {
                accion=listRoles.GetItemChecked(i)?"SP_asignarRol":"SP_quitarRol";
                rol = listRoles.Items[i].ToString();
                SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure(accion);
                    command.Parameters.AddWithValue("@usuario", cbUsuario.Text);
                    command.Parameters.AddWithValue("@rol", rol);
                command.ExecuteNonQuery();
                i++;
            }
            MessageBox.Show(null,"Usuario actualizado correctamente","Usuario actualizado",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }
    }
}
