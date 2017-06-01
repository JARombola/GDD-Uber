﻿using System;
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
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;

namespace UberFrba.Abm_Automovil {             
    public partial class frmCargaAuto : FormsAdapter {
        bool buscaChofer = false, buscaTurno = false;
        int idChofer, idTurno;
        
        public frmCargaAuto (Form anterior) {
            InitializeComponent();
            formAnterior = (FormsAdapter) anterior;
            Buscador.getInstancia().cargarMarcas(cbMarca);
        }


        public override void configurar (IDominio objeto) {
            if (buscaTurno) {
                Turno turno = (Turno) objeto;
                txtTurno.Text = turno.descripcion;
                idTurno = turno.id;
                buscaTurno=false;
            }
            else if (buscaChofer) {
               Persona chofer = (Persona) objeto;
               txtChofer.Text = chofer.nombre + " " + chofer.apellido;
               idChofer = chofer.id;
               buscaChofer=false;}
          else {                      //Si llego a configurar y no habia buscado chofer ni turno => Queria modificar un auto
                this.Text="Modificación Auto";
                btnAceptar.Text = "Modificar";
                Auto autito = (Auto) objeto;
                btnHabilitacion.Text = autito.habilitado?"Deshabilitar":"Habilitar";
                btnHabilitacion.Visible=true;
                btnClear.Visible=false;
                cargarDatos(autito);
           }
        }

        public override void cargarDatos (IDominio unAuto) {
            Auto auto = (Auto) unAuto;
            cbMarca.Text = auto.marca;
            txtModelo.Text = auto.modelo;
            txtPatente.Text = auto.patente;
            if (auto.choferID != -1) {
                idChofer = auto.choferID;
                txtChofer.Text = auto.choferNombre;
            }
            if (auto.turnoID!=-1) {
                idTurno = auto.turnoID;
                txtTurno.Text=auto.turnoDescripcion;
            }   
            ID = auto.id;
            if (!auto.habilitado) ID*=-1;               //Solo importa para la habilitacion/deshabilitacion... Si <0 => Deshabilitado,  
        }                                                                              //        >0 => Habilitado
        

        private void btnAceptar_Click (object sender, EventArgs e) {
            String errorDatos = errorCampos();
            if (errorDatos == null) {
                try {
                    if (ID==-1) registrarAuto();          //NO hay un ID asociado ====> Es un registro. SINO, sería una modificacion
                    else modificarAuto();
                    limpiar();
                }
                catch (SqlException error) {
                    switch (error.Number) {
                        case 2627: MessageBox.Show("La Patente ya se encuentra registrada", "Patente Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);    //Violacion de restriccion UNIQUE 
                            break;
                        case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;        //ERROR de conversion de datos
                    }
                }
            } else MessageBox.Show(errorDatos, "Error Datos", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        public override string errorCampos () {
            String errores = null;
            int asd;
            if (String.IsNullOrWhiteSpace(cbMarca.Text)) errores+="- Debe seleccionar una 'Marca'\n";
            if (String.IsNullOrWhiteSpace(txtModelo.Text)) errores+="- El campo 'Modelo' no puede estar vacío \n";
            if (!int.TryParse(txtPatente.Text, out asd)) errores+="- El campo 'Patente' no puede estar vacío \n";
            if (String.IsNullOrWhiteSpace(txtChofer.Text)) errores+="- Debe seleccionar un 'Chofer'\n";
            if (String.IsNullOrWhiteSpace(txtTurno.Text)) errores+="- Debe seleccionar un 'Turno'\n";
            return errores;
        }

        private void registrarAuto () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_altaAuto");
            setParametros(ref cmd);
            cmd.ExecuteNonQuery();
        }

        private void modificarAuto () {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_modifAuto");
            setParametros(ref cmd);
            cmd.Parameters.AddWithValue("@id", Math.Abs(ID));
            cmd.ExecuteNonQuery();
        }


        private void setParametros (ref SqlCommand command) {
            command.Parameters.AddRange(new[]
                    {new SqlParameter("@marca",cbMarca.Text),
                     new SqlParameter("@modelo",txtModelo.Text),
                     new SqlParameter("@patente",txtPatente.Text),
                     new SqlParameter("@chofer",idChofer),
                     new SqlParameter("@turno",idTurno)});
        }

        private void btnHabilitacion_Click (object sender, EventArgs e) {
            SqlCommand command;
            if (ID<0)           //Deshabilitado => Hay que habilitar
                command = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitarAuto");
            else command = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitarAuto");
            command.Parameters.AddWithValue("@id", Math.Abs(ID));
            int resultado = command.ExecuteNonQuery();
            MessageBox.Show("Actualizados: "+resultado);
            volver();
        }

        private void btnBuscChofer_Click (object sender, EventArgs e) {
            frmListaChoferes listaChoferes = new frmListaChoferes(this);
            listaChoferes.soloHabilitados=true;
            buscaChofer=true;
            listaChoferes.formSiguiente=this;
            listaChoferes.Show();
            this.Hide();
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            base.volver();
        }

        private void button1_Click (object sender, EventArgs e) {
            frmListaTurnos listaTurnos = new frmListaTurnos(this);
            listaTurnos.soloHabilitados = true;
            buscaTurno = true;
            listaTurnos.formSiguiente=this;
            listaTurnos.Show();
            this.Hide();
        }

        public override void limpiar () {
            cbMarca.ResetText();
            txtModelo.ResetText();
            txtPatente.ResetText();
            txtChofer.ResetText();
            txtTurno.ResetText();
        }

        private void btnClean_Click (object sender, EventArgs e) {
            limpiar();
        }

    }
}
