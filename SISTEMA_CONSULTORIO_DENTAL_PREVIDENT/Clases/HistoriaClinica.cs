using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Clases
{
    class HistoriaClinica
    {
        // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);


        // ESTOS SON LAS PROPIEDADES DE LA CLASE

        public int HclinicaId { get; set; }
        public string Antecedente { get; set; }
        public int PacienteId { get; set; }

        public HistoriaClinica() { }
        public HistoriaClinica(int hclinicaId)
        {
            this.HclinicaId = hclinicaId;
        }
        public HistoriaClinica(string antecedente, int pacienteId)
        {
            this.Antecedente = antecedente;
            this.PacienteId = pacienteId;
        }
        public HistoriaClinica(string antecedente, int pacienteId, int hclinicaId)
        {
            this.Antecedente = antecedente;
            this.PacienteId = pacienteId;
            this.HclinicaId = hclinicaId;
        }
        public bool Registrar()
        {

            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_HCLINICA", cn))
                {
                    cmd.Parameters.AddWithValue("@ANTECEDENTE_PERSONAL", this.Antecedente);
                    cmd.Parameters.AddWithValue("@PACIENTE_ID", this.PacienteId);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int r = cmd.ExecuteNonQuery();
                    cn.Close();

                    if (r == 1)
                    {
                        return true;
                    }
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return false;

        }

        public bool Actualizar()
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ACTUALIZAR_HISTORIACLINICA", cn))
                {
                    cmd.Parameters.AddWithValue("@ANTECEDENTE_PERSONAL", this.Antecedente);
                    cmd.Parameters.AddWithValue("@PACIENTE_ID", this.PacienteId);
                    cmd.Parameters.AddWithValue("@NUMERO_HISTORIA", this.HclinicaId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int r = cmd.ExecuteNonQuery();
                    cn.Close();

                    if (r == 1)
                    {
                        return true;
                    }
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return false;

        }

        public DataTable BuscarPorCodigo(int id)
        {
            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_HCLINICA_POR_PACIENTE_ID", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@ID", id);
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

        public bool Eliminar()
        {

            try
            {
                using (var cmd = new SqlCommand("SP_ELIMINAR_HCLINICA", cn))
                {
                    cmd.Parameters.AddWithValue("@ID", this.HclinicaId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int r = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (r == 1)
                    {
                        return true;
                    }
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return false;
        }

    }
}
