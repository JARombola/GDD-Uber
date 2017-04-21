using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.A__Buscador {
    class ConfiguradorDG {
        public ConfiguradorDG (){}

        public void completarDataGrid (DataGridView dataGrid, SqlCommand query) {
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query);
            adapter.Fill(tabla);
            dataGrid.DataSource = tabla;
        }


    }
}
