using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Clases
{
    class Usuariopwd
    {
        SqlConnection cn = new SqlConnection(
              ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString
              );

        SqlCommandBuilder scb;
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        public void listarusuarios(DataGridView data)
        {
            cn.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO", cn);
            comando.Connection = cn;
            comando.ExecuteNonQuery();
            da = new SqlDataAdapter(comando);
            da.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].Width = 60;
            data.Columns[1].Width = 165;
            data.Columns[2].Width = 165;
            data.Columns[3].Width = 90;
            data.Columns[4].Width = 50;
            data.Columns[5].Width = 165;
            data.Columns[6].Width = 100;
            data.Columns[7].Width = 125;

            cn.Close();
        }
        public void modificarestado(DataGridView data1)
        {
            scb = new SqlCommandBuilder(da);
            da.Update(dt);

        }
    }
}
