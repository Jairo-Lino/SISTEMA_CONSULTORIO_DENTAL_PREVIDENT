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
    class Consulta
    {
        // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);

        // ESTOS SON LAS PROPIEDADES DE LA CLASE

        public int ConsultaId { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Motivo { get; set; }
        public string ConsultaPaciente { get; set; }
        public string Receta { get; set; }
        public string Diagnostico { get; set; }
        public string PacienteId { get; set; }
        public string OdontologoId { get; set; }

        // CONSTRUCTOR SIN PARAMETROS
        public Consulta()
        {

        }
        //CONSTRUCTOR PARA REGISTRAR
        public Consulta(DateTime fechaconsulta, string motivo, string consultapaciente, string receta, string diagnostico, string pacienteid, string odontologoid)
        {
            this.FechaConsulta = fechaconsulta;
            this.Motivo = motivo;
            this.ConsultaPaciente = consultapaciente;
            this.Receta = receta;
            this.Diagnostico = diagnostico;
            this.PacienteId = pacienteid;
            this.OdontologoId = odontologoid;
        }

        public int Registrar()
        {
            int ultimo_id = 0;
            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_CONSULTA", cn))
                {
                    cmd.Parameters.AddWithValue("@FECHACONSULTA", this.FechaConsulta);
                    cmd.Parameters.AddWithValue("@MOTIVO", this.Motivo);
                    cmd.Parameters.AddWithValue("@CONSULTA", this.ConsultaPaciente);
                    cmd.Parameters.AddWithValue("@RECETA", this.Receta);
                    cmd.Parameters.AddWithValue("@DIAGNOSTICO", this.Diagnostico);
                    cmd.Parameters.AddWithValue("@PACIENTE_ID", this.PacienteId);
                    cmd.Parameters.AddWithValue("@ODONTOLOGO_ID", this.OdontologoId);
                    cmd.Parameters.Add("@ULTIMO_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    ultimo_id = Convert.ToInt32(cmd.Parameters["@ULTIMO_ID"].Value.ToString());

                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return ultimo_id;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return ultimo_id;
        }
        //LISTAR CONSULTA
        public DataTable Listar()
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_LISTAR_CONSULTAS", cn))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tabla);
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return tabla;

            }
            return tabla;
        }

        public DataTable BuscarConsultaPorApellido(string apellidos)
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_LISTAR_CONSULTAS_POR_PACIENTE", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@APELLIDOS", apellidos.Trim().ToUpper());
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tabla);
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return tabla;

            }
            return tabla;

        }

        public void BuscarPacienteLike(DataGridView dgv, string apellidos)
        {
            var tabla = this.BuscarConsultaPorApellido(apellidos);
            this.ListarGrid(dgv, tabla);
        }

        public void ListarPacientesDataGridView(DataGridView dgv)
        {

            var tabla = this.Listar();
            this.ListarGrid(dgv, tabla);

        }
        private void ListarGrid(DataGridView dgv, DataTable tabla)
        {

            var numero_filas = tabla.Rows.Count;
            if (numero_filas > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numero_filas; i++)
                {
                    DateTime fecha = DateTime.Parse(tabla.Rows[i][0].ToString());
                    string motivo = tabla.Rows[i][1].ToString();
                    string atendidoPor = tabla.Rows[i][2].ToString() + " " + tabla.Rows[i][8].ToString();
                    string consulta = tabla.Rows[i][3].ToString();
                    string receta = tabla.Rows[i][4].ToString();
                    string diagnostico = tabla.Rows[i][5].ToString();
                    string nombre_completo = tabla.Rows[i][6].ToString() + " " + tabla.Rows[i][7].ToString();
                    dgv.Rows.Add(
                        fecha, motivo, atendidoPor, consulta, receta, diagnostico, nombre_completo
                        );
                }
            }

        }

    }
}
