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

namespace UberFrba.Abm_Rol
{
    public partial class frmModifRoles : FormsAdapter
    {
        int rolId;
        public frmModifRoles(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior = anterior;
        }

        private void frmModifRol_Load (object sender, EventArgs e) {
            cbRol.Items.Clear();
            Buscador.getInstancia().cargarRoles(cbRol);
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            rolId = obtenerId();
            Boolean habilitado = Buscador.getInstancia().cargarFunciones(rolId, listFunciones);
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

        private void botonRegistrar (object sender, EventArgs e) {
                listFunciones.Enabled=true;
                btnHabilitar.Enabled=false;
                btnDeshabiliar.Enabled=false;
        }

        private void btnOk_Click (object sender, EventArgs e) {
            SqlCommand storedProcedure;
            storedProcedure = Buscador.getInstancia().getCommandStoredProcedure("SP_modificarRol");
            setearParametros(ref storedProcedure);
            try {
                int x = storedProcedure.ExecuteNonQuery();
                MessageBox.Show("Actualizado: "+x.ToString());
            }
            catch(SqlException){
                MessageBox.Show(null,"Ya existe un rol con el nombre \" "+cbRol.Text+"\".\nIntente con uno diferente.","Error de Registro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            limpiar();
        }

        private void setearParametros (ref SqlCommand stored) {
            stored.Parameters.AddRange(new[]{
                new SqlParameter("@rol", txtNombre.Text),
                new SqlParameter("@id", rolId),
                new SqlParameter("@clientes", listFunciones.GetItemChecked(0)),
                new SqlParameter("@choferes", listFunciones.GetItemChecked(1)),
                new SqlParameter("@autos", listFunciones.GetItemChecked(2)),
                new SqlParameter("@roles", listFunciones.GetItemChecked(3)),
                new SqlParameter("@turnos", listFunciones.GetItemChecked(4)),
                new SqlParameter("@viajes", listFunciones.GetItemChecked(5)),
                new SqlParameter("@facturacion", listFunciones.GetItemChecked(6)),
                new SqlParameter("@rendicion", listFunciones.GetItemChecked(7)),
                new SqlParameter("@estadisticas", listFunciones.GetItemChecked(8))
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
            formAnterior.Show();
            this.Close();
        }
    }
}
