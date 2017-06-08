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
    public partial class frmModifRol : FormsAdapter           //TODO: verificar que se actualice el menu inicial, si el modificado es JUSTO el rol de la persona
    {
        int rolId;
        public frmModifRol(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior = anterior;
        }

        private void frmModifRol_Load (object sender, EventArgs e) {
            cbRol.Items.Clear();
            Buscador.getInstancia().cargarRoles(cbRol);
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            foreach (int i in listFunciones.CheckedIndices) {
                listFunciones.SetItemCheckState(i, CheckState.Unchecked);
            }
            rolId = obtenerId();
            Boolean habilitado = this.cargarFunciones();
            if (habilitado) { btnDeshabiliar.Enabled=true;
                              btnHabilitar.Enabled=false;
                              listFunciones.Enabled=true;
                              txtNombre.Text=cbRol.SelectedItem.ToString();
                              txtNombre.Enabled=true;
                              btnOk.Visible=true;
            }
            else {  btnDeshabiliar.Enabled=false;
                    btnHabilitar.Enabled=true;
                    listFunciones.Enabled=false;
                    txtNombre.Enabled=false;
                    txtNombre.Text="";
                    btnOk.Visible=false;
            }
        }

        private int obtenerId () {
            SqlCommand obtenerId = Buscador.getInstancia().getCommandFunction("fx_getRolId(@rol)");
                obtenerId.Parameters.AddWithValue("@rol", cbRol.Text);
            return (int)obtenerId.ExecuteScalar();
        }

        private bool cargarFunciones () {
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla("fx_getFuncionalidades(@idRol)");
            command.Parameters.AddWithValue("@idRol",rolId);
            SqlDataReader datos = command.ExecuteReader();
            while (datos.Read()) {
                listFunciones.SetItemChecked(datos.GetInt32(0)-1,true);
            }
            datos.Close();
            command = Buscador.getInstancia().getCommand("Select habilitado from [MAIDEN].Rol where ID = "+rolId);
            Boolean habilitado = (bool)command.ExecuteScalar();
            datos.Close();
            return habilitado;           //devuelve si el rol está habilitado o no, se usa en el form de roles para el boton de habilitar
        }

        private void botonRegistrar (object sender, EventArgs e) {
                listFunciones.Enabled=true;
                btnHabilitar.Enabled=false;
                btnDeshabiliar.Enabled=false;
        }

        private void btnOk_Click (object sender, EventArgs e) {
            SqlCommand storedProcedure;
            storedProcedure = Buscador.getInstancia().getCommandStoredProcedure("SP_modifRol");
            setearParametros(ref storedProcedure);
            try {
                storedProcedure.ExecuteNonQuery();
                MessageBox.Show("Rol modificado correctamente","Rol modificado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(SqlException){                // TODO: Modificar excepcion, mje desde sql
                MessageBox.Show(null,"Ya existe un rol con el nombre \" "+cbRol.Text+"\".\nIntente con uno diferente.","Error de Registro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            limpiar();
        }

        private void setearParametros (ref SqlCommand stored) {
            String funcionalidades = ";";
            foreach (int i in listFunciones.CheckedIndices) {
                funcionalidades+=(i+1)+";";
            }
            stored.Parameters.AddRange(new[]{
                new SqlParameter("@nombreRol", txtNombre.Text),
                new SqlParameter("@idRol", rolId),
                new SqlParameter("@funcionalidades", funcionalidades),
            });
        }

        private void btnDeshabilitar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitarRol");
                command.Parameters.AddWithValue("id", rolId);
            int x = command.ExecuteNonQuery();
            if (x>0) MessageBox.Show("Rol Deshabilitado Correctamente");
            limpiar();
        }

        private void btnHabilitar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitarRol");
                command.Parameters.AddWithValue("id", rolId);
                int x = command.ExecuteNonQuery();
            if (x>0) MessageBox.Show("Rol habilitado Correctamente");
            limpiar();
        }
        public override void limpiar () {
            btnDeshabiliar.Enabled=false;
            btnHabilitar.Enabled = false;
            foreach (int i in listFunciones.CheckedIndices) {
                listFunciones.SetItemCheckState(i, CheckState.Unchecked);
            }
            btnOk.Visible=false;
            cbRol.Text="";
            txtNombre.Text="";
            txtNombre.Enabled=false;
            frmModifRol_Load(null, null);
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }
    }
}
