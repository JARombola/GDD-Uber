using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;
using UberFrba.Dominio;

namespace UberFrba.Facturacion
{
    public partial class frmFacturacion : FormsAdapter
    {
        private bool buscaCliente { get; set; }
        private int idCliente{get;set;}

        public frmFacturacion(FormsAdapter anterior)
        {
            InitializeComponent();
            formAnterior=anterior;
        }

        private void btnChofer_Click (object sender, EventArgs e) {
            frmListaClientes listaClientes = new frmListaClientes(this);
                listaClientes.formSiguiente=this;
                listaClientes.soloHabilitados=true;
                buscaCliente = true;
                listaClientes.Show();
                this.Hide();
        }

        public override void configurar (IDominio elemento) {
            Persona cliente = (Persona) elemento;
                idCliente = cliente.id;
                txtCliente.Text = (cliente.nombre +" "+ cliente.apellido);
                toolTip1.SetToolTip(txtCliente, String.Format("{0} {1}\n -DNI: {2}\n-Direccion: {3}\n-Telefono: {4}", cliente.nombre, cliente.apellido, cliente.dni, cliente.direccion, cliente.telefono));
        }

        private void btnFacturar_Click (object sender, EventArgs e) {
            SqlCommand command = Buscador.getInstancia().getCommandStoredProcedure("SP_Facturacion");
                command.Parameters.AddRange(new[]{
                        new SqlParameter("@idCliente",idCliente),
                        new SqlParameter("@fecha",fecha.Value),
                    }
                );
                try {
                    ejecutarQuery(command, dgListado);
                }
                catch (SqlException error) {
                    MessageBox.Show(error.Message, "Error de facturacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

        }

        private void frmFacturacion_Load (object sender, EventArgs e) {
            fecha.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Inicio"]);
        }

        }
}
