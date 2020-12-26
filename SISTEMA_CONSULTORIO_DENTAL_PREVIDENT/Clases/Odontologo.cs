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
    class Odontologo
    {
        // CONEXION
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);

        // ESTOS SON LAS PROPIEDADES DE LA CLASE
        public int OdontologoId { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string DistritoId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }


        // CONSTRUCTOR SIN PARAMETROS
        public Odontologo()
        {

        }
        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA REGISTRAR
        public Odontologo(string _apellidos, string _nombre,
                string _dni, string _genero, string _direccion,
                string _distrito_id, DateTime _fecha_nacimiento, string _celular)
        {

            this.Apellidos = _apellidos;
            this.Nombre = _nombre;
            this.Dni = _dni;
            this.Genero = _genero;
            this.Direccion = _direccion;
            this.DistritoId = _distrito_id;
            this.FechaNacimiento = _fecha_nacimiento;
            this.Celular = _celular;
        }

        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA ACTUALIZAR
        public Odontologo(string _apellidos, string _nombre,
                string _dni, string _genero, string _direccion,
                string _distrito_id, DateTime _fecha_nacimiento, string _celular,
                int _odontologo_id)
        {

            this.Apellidos = _apellidos;
            this.Nombre = _nombre;
            this.Dni = _dni;
            this.Genero = _genero;
            this.Direccion = _direccion;
            this.DistritoId = _distrito_id;
            this.FechaNacimiento = _fecha_nacimiento;
            this.Celular = _celular;
            this.OdontologoId = _odontologo_id;

        }
        // ESTO ES UN CONSTRUCTOR CON PARAMETROS
        // CONSTRUCTOR ES PARA ELIMINAR
        public Odontologo(int _odontologo_id)
        {
            this.OdontologoId = _odontologo_id;
        }

        public int Registrar()
        {
            int ultimo_id = 0;
            try
            {
                using (var cmd = new SqlCommand("SP_REGISTRAR_ODONTOLOGO", cn))
                {
                    cmd.Parameters.AddWithValue("@APELLIDOS", this.Apellidos);
                    cmd.Parameters.AddWithValue("@NOMBRE", this.Nombre);
                    cmd.Parameters.AddWithValue("@DNI", this.Dni);
                    cmd.Parameters.AddWithValue("@GENERO", this.Genero);
                    cmd.Parameters.AddWithValue("@DIRECCION", this.Direccion);
                    cmd.Parameters.AddWithValue("@DISTRITO_ID", this.DistritoId);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", this.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CELULAR", this.Celular);
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
                using (var cmd = new SqlCommand("SP_ACTUALIZAR_ODONTOLOGO", cn))
                {
                    cmd.Parameters.AddWithValue("@APELLIDOS", this.Apellidos);
                    cmd.Parameters.AddWithValue("@NOMBRE", this.Nombre);
                    cmd.Parameters.AddWithValue("@DNI", this.Dni);
                    cmd.Parameters.AddWithValue("@GENERO", this.Genero);
                    cmd.Parameters.AddWithValue("@DIRECCION", this.Direccion);
                    cmd.Parameters.AddWithValue("@DISTRITO_ID", this.DistritoId);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", this.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CELULAR", this.Celular);
                    cmd.Parameters.AddWithValue("@ODONTOLOGO_ID", this.OdontologoId);

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
                using (var cmd = new SqlCommand("SP_ELIMINAR_ODONTOLOGO", cn))
                {
                    cmd.Parameters.AddWithValue("@ID", this.OdontologoId);
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
                using (var adaptador = new SqlDataAdapter("SP_LISTAR_ODONTOLOGOS", cn))
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

        public DataTable BuscarOdontologoPorNombre(string nombre)
        {

            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_ODONTOLOGOS_LIKE", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@NOMBRE", nombre.Trim().ToUpper());
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

        //public DataTable ListarPacientesPorOdontologo(string id)
        //{

        //    //INSTANCIANDO A LA CLASE DATATABLE
        //    var tabla = new DataTable();
        //    //DataTable tabla = new DataTable();
        //    try
        //    {
        //        //CREANDO UNA INSTANCIA DE LA CLASE
        //        // SQLDATAADAPTER
        //        using (var adaptador = new SqlDataAdapter("SP_LISTAR_PACIENTES_POR_ODONTOLOGO", cn))
        //        {
        //            adaptador.SelectCommand.Parameters.AddWithValue("@ODONTOLOGO_ID", id.Trim());
        //            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            adaptador.Fill(tabla);
        //        }

        //    }
        //    catch (SqlException e)
        //    {
        //        System.Windows.Forms.MessageBox.Show(e.Message);
        //        return tabla;

        //    }
        //    return tabla;

        //}
        public DataTable BuscarPorCodigo(int id)
        {
            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR_ODONTOLOGOS_POR_ID", cn))
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

        public DataTable ListaOdontologoCombo()
        {
            //INSTANCIANDO A LA CLASE DATATABLE
            var tabla = new DataTable();
            //DataTable tabla = new DataTable();
            try
            {
                //CREANDO UNA INSTANCIA DE LA CLASE
                SqlConnection con = cn;
                // SQLDATAADAPTER
                using (var adaptador = new SqlDataAdapter("SELECT * FROM ODONTOLOGOS order by NOMBRE", con))
                {
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
        public void BuscarOdontologoLike(DataGridView dgv, string nombre)
        {
            var tabla = this.BuscarOdontologoPorNombre(nombre);
            this.ListarGrid(dgv, tabla);
        }

        public void ListarOdontologosDataGridView(DataGridView dgv)
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

                    string nombre_completo = tabla.Rows[i][2].ToString() + " " + tabla.Rows[i][1].ToString();
                    string dni = tabla.Rows[i][3].ToString();
                    string genero = tabla.Rows[i][4].ToString();
                    string distrito = tabla.Rows[i][5].ToString();
                    int odontologoId = int.Parse(tabla.Rows[i][0].ToString());

                    dgv.Rows.Add(
                        nombre_completo, dni, genero, distrito, "Editar", "Eliminar", odontologoId
                        );
                }
            }

        }
    }
}
