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
    class Telefono
    {
        // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);

        // ESTOS SON LAS PROPIEDADES DE LA CLASE

        public int TelefonoId { get; set; }
        public string Operador { get; set; }
        public string Numero { get; set; }
        public int PacienteId { get; set; }

        public Telefono() { }
        public Telefono(int telefonoId)
        {
            this.TelefonoId = telefonoId;
        }
        public Telefono(string operador, string numero, int pacienteId)
        {
            this.Operador = operador;
            this.Numero = numero;
            this.PacienteId = pacienteId;
        }




        public bool Registrar()
        {

            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_TELEFONOS", cn))
                {
                    cmd.Parameters.AddWithValue("@OPERADOR", this.Operador);
                    cmd.Parameters.AddWithValue("@NUMERO", this.Numero);
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

        public DataTable BuscarPorCodigo(int id)
        {
            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_TELEFONOS_POR_PACIENTE_ID", cn))
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
                using (var cmd = new SqlCommand("SP_ELIMINAR_TELEFONO", cn))
                {
                    cmd.Parameters.AddWithValue("@ID", this.TelefonoId);

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
