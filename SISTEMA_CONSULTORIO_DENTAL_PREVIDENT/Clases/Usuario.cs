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
    class Usuario
    {
        SqlConnection cn = new SqlConnection(
                      ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString
                      );
        DataSet ds;
        public string mensaje = "";

        public string mensajeUsu = "";
        public int indice = 0;
        // LSITA DE USUARIO
        public DataSet Listado()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter daListado = new SqlDataAdapter();
                daListado.SelectCommand = new SqlCommand();
                var sql = daListado.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "SP_LISTA_USUARIO";
                cn.Open();
                daListado.Fill(ds, "LISTAUSUARIO");
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }
            return ds;
        }


        public string IniciarSesion(string usu, string contra, string tipo)
        {
            //if (cn.State == ConnectionState.Closed) { cn.Open();}

            try
            {
                ds = new DataSet();
                SqlDataAdapter daUsu = new SqlDataAdapter();
                daUsu.SelectCommand = new SqlCommand();
                var sql = daUsu.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "USPVALIDALOGIN";
                sql.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar, 5)).Value = usu;
                sql.Parameters.Add(new SqlParameter("@CONTRASENA", SqlDbType.VarChar, 4)).Value = contra;
                sql.Parameters.Add(new SqlParameter("@TIPO_USUARIO", SqlDbType.VarChar, 50)).Value = tipo;
                sql.Parameters.Add(new SqlParameter("@MENSAJE", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output;
                sql.Parameters.Add(new SqlParameter("@INDICE", SqlDbType.Int)).Direction = ParameterDirection.Output;
                cn.Open();
                daUsu.SelectCommand.ExecuteNonQuery();
                mensaje = Convert.ToString(sql.Parameters["@MENSAJE"].Value.ToString());
                indice = Convert.ToInt32(sql.Parameters["@INDICE"].Value);
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }
            return mensaje;

        }

        // METODO PARA REGISTRAR LA HORA DE SALIDA
        public void salir(string usuario)
        {
            //if (cn.State == ConnectionState.Closed) { cn.Open(); }

            try
            {
                ds = new DataSet();
                SqlDataAdapter daIngreso = new SqlDataAdapter();
                daIngreso.SelectCommand = new SqlCommand();
                var sql = daIngreso.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "SP_SALIDA";
                sql.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar, 5)).Value = usuario;
                cn.Open();
                daIngreso.SelectCommand.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }

        }

        //REGISTRO DE UUSARIO
        public DataSet Registrar(string codigo, string apellidos, string nombre, string usuario, string password, string tipo_usu, string sexo)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }


            try
            {
                ds = new DataSet();
                SqlDataAdapter daIngreso = new SqlDataAdapter();
                daIngreso.SelectCommand = new SqlCommand();
                var sql = daIngreso.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "SP_INSMOD_USUARIO";
                sql.Parameters.Add(new SqlParameter("@COD_USUARIO", SqlDbType.Char, 7)).Value = codigo;
                sql.Parameters.Add(new SqlParameter("@APELLIDOS", SqlDbType.VarChar, 50)).Value = apellidos;
                sql.Parameters.Add(new SqlParameter("@NOMBRE", SqlDbType.VarChar, 50)).Value = nombre;
                sql.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar, 5)).Value = usuario;
                sql.Parameters.Add(new SqlParameter("@CONTRASENA", SqlDbType.VarChar, 4)).Value = password;
                sql.Parameters.Add(new SqlParameter("@TIPO_USUARIO", SqlDbType.VarChar, 50)).Value = tipo_usu;
                sql.Parameters.Add(new SqlParameter("@SEXO", SqlDbType.Char, 1)).Value = sexo;
                sql.Parameters.Add(new SqlParameter("@ACCION", SqlDbType.Int)).Value = 1;
                daIngreso.SelectCommand.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }
            return ds;
        }
        //REGISTRO DE INTENTOS
        public DataSet Intentos(string usuario, int intento, int estado)
        {
            //if (cn.State == ConnectionState.Closed) { cn.Open(); }

            try
            {
                ds = new DataSet();
                SqlDataAdapter daIngreso = new SqlDataAdapter();
                daIngreso.SelectCommand = new SqlCommand();
                var sql = daIngreso.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "SP_INTENTO";
                sql.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.Char, 5)).Value = usuario;
                sql.Parameters.Add(new SqlParameter("@INTENTO", SqlDbType.Int)).Value = intento;
                sql.Parameters.Add(new SqlParameter("@ESTADO", SqlDbType.Int)).Value = estado;
                cn.Open();
                daIngreso.SelectCommand.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }
            return ds;
        }


        //CAMBIO DE CLAVE
        public string CambiarClave(string usu, string contraAnti, string contraNUeva)
        {
            //if (cn.State == ConnectionState.Closed) { cn.Open();}

            try
            {
                ds = new DataSet();
                SqlDataAdapter daUsu = new SqlDataAdapter();
                daUsu.SelectCommand = new SqlCommand();
                var sql = daUsu.SelectCommand;
                sql.Connection = cn;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "USU_CLAVE";
                sql.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar, 5)).Value = usu;
                sql.Parameters.Add(new SqlParameter("@CLAVE_ANTIGUA", SqlDbType.VarChar, 4)).Value = contraAnti;
                sql.Parameters.Add(new SqlParameter("@CLAVE_NUEVA", SqlDbType.VarChar, 4)).Value = contraNUeva;
                sql.Parameters.Add(new SqlParameter("@MENSAJE", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Output;

                cn.Open();
                daUsu.SelectCommand.ExecuteNonQuery();
                mensajeUsu = Convert.ToString(sql.Parameters["@MENSAJE"].Value.ToString());
                cn.Close();
            }
            catch (Exception e1) { e1.ToString(); }
            return mensajeUsu;

        }
        public void CambiarClave(string p1, string p2)
        {
            throw new NotImplementedException();
        }

    }
}
