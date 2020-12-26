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
    class Turno
    {    // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);

        // ESTOS SON LAS PROPIEDADES DE LA CLASE
        public int TurnoId { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Turnoo { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }


        // CONSTRUCTOR SIN PARAMETROS
        public Turno()
        {

        }
        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA REGISTRAR
        public Turno(string _apellidos, string _nombre,
                string _turnoo, DateTime _fecha, string _hora_entrada, string _hora_salida)
        {

            this.Apellidos = _apellidos;
            this.Nombre = _nombre;
            this.Turnoo = _turnoo;
            this.Fecha = _fecha;
            this.HoraEntrada = _hora_entrada;
            this.HoraSalida = _hora_salida;
        }

        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA ACTUALIZAR
        public Turno(string _apellidos, string _nombre,
                string _turnoo, DateTime _fecha, string _hora_entrada, string _hora_salida,
                int _turno_id)
        {

            this.Apellidos = _apellidos;
            this.Nombre = _nombre;
            this.Turnoo = _turnoo;
            this.Fecha = _fecha;
            this.HoraEntrada = _hora_entrada;
            this.HoraSalida = _hora_salida;
            this.TurnoId = _turno_id;

        }
        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA ELIMINAR
        public Turno(int _turno_id)
        {
            this.TurnoId = _turno_id;
        }

        public int Registrar()
        {
            int ultimo_id = 0;
            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_TURNO", cn))
                {
                    cmd.Parameters.AddWithValue("@APELLIDOS", this.Apellidos);
                    cmd.Parameters.AddWithValue("@NOMBRE", this.Nombre);
                    cmd.Parameters.AddWithValue("@TURNOO", this.Turnoo);
                    cmd.Parameters.AddWithValue("@FECHA", this.Fecha);
                    cmd.Parameters.AddWithValue("@HORA_ENTRADA", this.HoraEntrada);
                    cmd.Parameters.AddWithValue("@HORA_SALIDA", this.HoraSalida);
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

        public bool Actualizar()
        {

            try
            {
                using (var cmd = new SqlCommand("SP_ACTUALIZAR_TURNO", cn))
                {
                    cmd.Parameters.AddWithValue("@APELLIDOS", this.Apellidos);
                    cmd.Parameters.AddWithValue("@NOMBRE", this.Nombre);
                    cmd.Parameters.AddWithValue("@TURNOO", this.Turnoo);
                    cmd.Parameters.AddWithValue("@FECHA", this.Fecha);
                    cmd.Parameters.AddWithValue("@HORA_ENTRADA", this.HoraEntrada);
                    cmd.Parameters.AddWithValue("@HORA_SALIDA", this.HoraSalida);
                    cmd.Parameters.AddWithValue("@TURNO_ID", this.TurnoId);

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

        public bool Eliminar()
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ELIMINAR_TURNO", cn))
                {
                    cmd.Parameters.AddWithValue("@ID", this.TurnoId);
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

        public DataTable Listar()
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_LISTAR_TURNOS", cn))
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

        public DataTable BuscarTurnoPorApellidos(string apellidos)
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_TURNOS_LIKE", cn))
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

        public DataTable BuscarPorCodigo(int id)
        {
            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_TURNOS_POR_ID", cn))
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


        public void BuscarTurnoLike(DataGridView dgv, string nombre)
        {
            var tabla = this.BuscarTurnoPorApellidos(nombre);
            this.ListarGrid(dgv, tabla);
        }

        public void ListarTurnosDataGridView(DataGridView dgv)
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

                    string nombre_completo = tabla.Rows[i][1].ToString() + " " + tabla.Rows[i][2].ToString();
                    string turnoo = tabla.Rows[i][3].ToString();
                    string fecha = Convert.ToDateTime(tabla.Rows[i][4].ToString()).ToString("dddd, dd MMMM yyyy");
                    //DateTime fecha = DateTime.Parse(tabla.Rows[i][4].ToString());
                    string hora_entrada = tabla.Rows[i][5].ToString();
                    string hora_salida = tabla.Rows[i][6].ToString();
                    int turnoId = int.Parse(tabla.Rows[i][0].ToString());

                    dgv.Rows.Add(
                        nombre_completo, turnoo, fecha, hora_entrada, hora_salida, "Editar", "Eliminar", turnoId
                        );
                }
            }

        }





    }
}
