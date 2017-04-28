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
    public partial class frmRoles : Form
    {
        string[] funciones = {"clientes", "choferes","autos","roles","turnos","viajes","facturacion","rendicion","estadisticas"};
        bool modificacion = false;
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmModifRol_Load (object sender, EventArgs e) {
            Buscador.getInstancia().cargarRoles(cbRol);
        }

        private void cbRol_SelectedIndexChanged (object sender, EventArgs e) {
            btnOk.Text="Modificar";
            Buscador.getInstancia().cargarFunciones(cbRol.Text, listFunciones);
            btnOk.Visible=true;
            btnbaja.Enabled=true;
            modificacion=true;
        }

        private void botonRegistrar (object sender, EventArgs e) {
            btnOk.Text="Registrar";
            btnbaja.Enabled=false;
            foreach (int i in listFunciones.CheckedIndices) {
                listFunciones.SetItemCheckState(i, CheckState.Unchecked);
            }
            btnOk.Visible=true;
            modificacion=false;
        }

        private void btnOk_Click (object sender, EventArgs e) {
            SqlCommand storedProcedure;
            if (modificacion) storedProcedure = Buscador.getInstancia().getCommandStoredProcedure("SP_modificarRol");
            else storedProcedure = Buscador.getInstancia().getCommandStoredProcedure("SP_altaRol");
            setearParametros(ref storedProcedure);
            int x = storedProcedure.ExecuteNonQuery();
            MessageBox.Show("Actualizado: "+x.ToString());
        }

        private void setearParametros (ref SqlCommand stored) {
            stored.Parameters.AddRange(new[]{
                new SqlParameter("@rol", cbRol.Text),
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

        private void btnbaja_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("bajaRol");
                command.Parameters.AddWithValue("rol", cbRol.Text);
            int x = command.ExecuteNonQuery();
            if (x>0) MessageBox.Show("Rol Eliminado Correctamente");
        }

    }
}
