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

namespace UberFrba.Abm_Usuario {
    public partial class frmCargaRol : FormsAdapter {
        public frmCargaRol (FormsAdapter anterior) {
            InitializeComponent();
            formAnterior=anterior;
        }

        private void btnOk_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_altaRol");
                setearParametros(ref command);
                try {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rol registrado correctamente");
                }
                catch (SqlException x) {
                    MessageBox.Show(x.Message);
                }
                formAnterior.Show();
                this.Close();
        }

        private void setearParametros (ref SqlCommand stored) {
            stored.Parameters.AddRange(new[]{
                new SqlParameter("@rol", txtNombre.Text),
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

        private void button1_Click (object sender, EventArgs e) {
            formAnterior.Show();
            this.Close();
        }

        private void txtNombre_TextChanged (object sender, EventArgs e) {
            if (txtNombre.Text=="") btnOk.Enabled=false;
            else
            btnOk.Enabled=true;
        }
    }
}
