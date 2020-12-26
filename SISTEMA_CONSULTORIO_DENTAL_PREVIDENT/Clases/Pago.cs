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
    class Pago
    {
        // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);

        // ESTOS SON LAS PROPIEDADES DE LA CLASE
        public int PagoId { get; set; }
        public DateTime FechaPágo { get; set; }
        public decimal Monto { get; set; }
        public string DetallePago { get; set; }
        public string PacienteId { get; set; }
        public string OdontologoId { get; set; }

        // CONSTRUCTOR SIN PARAMETROS
        public Pago()
        {

        }
        //CONSTRUCTOR PARA REGISTRAR
        public Pago(DateTime fechapago, decimal monto, string detallepago, string pacienteid, string odontologoid)
        {
            this.FechaPágo = fechapago;
            this.Monto = monto;
            this.DetallePago = detallepago;
            this.PacienteId = pacienteid;
            this.OdontologoId = odontologoid;
        }
        //CONSTRUCTOR PARA ACTUALIZAR
        public Pago(DateTime fechapago, decimal monto, string detallepago, string pacienteid, string odontologoid, int pagoid)
        {
            this.FechaPágo = fechapago;
            this.Monto = monto;
            this.DetallePago = detallepago;
            this.PacienteId = pacienteid;
            this.OdontologoId = odontologoid;
            this.PagoId = pagoid;
        }
        // CONSTRUCTOR ES PARA ELIMINAR
        public Pago(int _pagoid)
        {
            this.PagoId = _pagoid;
        }
        public int Registrar()
        {
            int ultimo_id = 0;
            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_PAGO", cn))
                {
                    cmd.Parameters.AddWithValue("@FECHAPAGO", this.FechaPágo);
                    cmd.Parameters.AddWithValue("@MONTO", this.Monto);
                    cmd.Parameters.AddWithValue("@DETALLEPAGO", this.DetallePago);
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
        //METODO ACTUALIZAR 
        public bool Actualizar()
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ACTUALIZAR_PAGO", cn))
                {
                    cmd.Parameters.AddWithValue("@FECHAPAGO", this.FechaPágo);
                    cmd.Parameters.AddWithValue("@MONTO", this.Monto);
                    cmd.Parameters.AddWithValue("@DETALLEPAGO", this.DetallePago);
                    cmd.Parameters.AddWithValue("@PACIENTE_ID", this.PacienteId);
                    cmd.Parameters.AddWithValue("@ODONTOLOGO_ID", this.OdontologoId);
                    cmd.Parameters.AddWithValue("@PAGO_ID", this.PagoId);

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
        //-----------ELIMINAR--------------------------------
        public bool Eliminar()
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ELIMINAR_PAGO", cn))
                {
                    cmd.Parameters.AddWithValue("@ID", this.PagoId);

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

        //Listar Pagos
        public DataTable Listar()
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_LISTAR_PAGOS", cn))
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


        public DataTable BuscarPagoPorEstado(string estado)
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_PAGOS_LIKE", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@ESTADO", estado.Trim());
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


        public void BuscarPagoLike(DataGridView dgv, string estado)
        {
            var tabla = this.BuscarPagoPorEstado(estado);
            this.ListarGrid(dgv, tabla);
        }
        public void ListarPagosDataGridView(DataGridView dgv)
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
                    //string numero = tabla.Rows[i][1].ToString();
                    int pagoId = int.Parse(tabla.Rows[i][0].ToString());
                    string paciente = tabla.Rows[i][2].ToString();
                    DateTime fecha = DateTime.Parse(tabla.Rows[i][1].ToString());
                    decimal costo = decimal.Parse(tabla.Rows[i][4].ToString());
                    string detalle = tabla.Rows[i][3].ToString();
                    string estado = tabla.Rows[i][5].ToString();


                    dgv.Rows.Add(
                        pagoId,fecha, paciente,detalle, costo,estado
                        );
                }
            }

        }



    }
}
