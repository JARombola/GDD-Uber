﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.A__Buscador;

namespace UberFrba {
    public partial class FormsAdapter : Form {

        protected string TABLA { get; set; }
        protected FormsAdapter formAnterior { get; set; }
        public int ID { get; set; }

        public FormsAdapter () {
            ID = 0;
        }

        protected void ejecutarQuery (SqlCommand command, DataGridView lista) {                            //TODO: Completar listas
            ConfiguradorDG config = new ConfiguradorDG();
            config.completarDataGrid(lista, command);
        }


        protected int deshabilitar (string SP, int id){
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_deshabilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        protected int habilitar (string SP, int id) {
            SqlCommand cmd = Buscador.getInstancia().getCommandStoredProcedure("SP_habilitar"+SP);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        protected Object valor (string texto) {
            if (!String.IsNullOrWhiteSpace(texto)) return texto;
            return DBNull.Value;
        }

        protected void volver () {
            formAnterior.Show();
            Close();
        }

        public virtual void configurar (IDominio elemento) {
        }
        public virtual void cargarDatos (IDominio elemento) {
        }
        public virtual void limpiar () {
        }
    }
}