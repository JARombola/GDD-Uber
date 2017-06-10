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
                MessageBox.Show("Rol registrado correctamente","Rol Registrado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (SqlException x) {
                MessageBox.Show(x.Message,"Error de registro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            formAnterior.Show();
            this.Close();
        }

        private void setearParametros (ref SqlCommand stored) {             // Se serializan las funcionalidades según Base de Datos:
            String funcionalidades = ";";                                   // ;ID1;ID2;ID3;ID4;...;IDN;
            foreach (int i in listFunciones.CheckedIndices) {
                funcionalidades+=(i+1)+";";
            }
            stored.Parameters.AddRange(new[]{
                new SqlParameter("@rol", txtNombre.Text),
                new SqlParameter("@funcionalidades", funcionalidades)
            });
        }

        private void button1_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void txtNombre_TextChanged (object sender, EventArgs e) {
            if (txtNombre.Text=="") btnOk.Enabled=false;
            else btnOk.Enabled=true;
        }
}
}
