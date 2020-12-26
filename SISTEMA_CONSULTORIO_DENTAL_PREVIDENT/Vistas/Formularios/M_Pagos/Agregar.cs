using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.M_Pagos
{
    public partial class Agregar : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);
        SqlCommand cmd;
        private Clases.Odontologo Odontologo1 = new Clases.Odontologo();
        private Clases.Servicios servicios1 = new Clases.Servicios();
        private DataTable tabla;
        private DataTable tabla1;
        public Agregar()
        {
            InitializeComponent();
            dtp_fecha.Text = DateTime.Now.ToShortDateString();
            tabla = Odontologo1.ListaOdontologoCombo();
            tabla1 = servicios1.ListaServiciosCombo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //BUSQUEDA POR DNI
                if (cbo_busqueda.Text == "DNI")
                {
                    //SqlConnection miconexion = new SqlConnection(Conexion.conexion);
                    SqlConnection conexion = cn;
                    //conexion.Open();
                    SqlCommand cmd = new SqlCommand("select * from PACIENTES where DNI= @Clave", conexion);
                    cmd.Parameters.AddWithValue("@Clave", txt_busqueda.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    //Representa un set de comandos que es utilizado para llenar un DataSet
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    //Representa un caché (un espacio) en memoria de los datos.
                    DataSet ds = new DataSet("PACIENTES");

                    //Arreglo de byte en donde se almacenara la foto en bytes
                    byte[] MyData = new byte[0];


                    //Llenamosel DataSet con la tabla. ESTUDIANTE es nombre de la tabla
                    dp.Fill(ds, "PACIENTES");

                    //Si dni existe ejecutara la consulta
                    if (ds.Tables["PACIENTES"].Rows.Count > 0)
                    {
                        //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                        DataRow myRow = ds.Tables["PACIENTES"].Rows[0];

                        txt_apellidos.Text = myRow["APELLIDOS"].ToString();
                        txt_nombre.Text = myRow["NOMBRE"].ToString();
                        txt_dni.Text = myRow["DNI"].ToString();
                        cbo_genero.Text = myRow["GENERO"].ToString();
                        txt_direccion.Text = myRow["DIRECCION"].ToString();
                        txt_codigoPaciente.Text = myRow["PACIENTE_ID"].ToString();

                        txt_codigoPaciente.Enabled = false;
                        txt_busqueda.Enabled = true;
                        cbo_busqueda.Enabled = true;
                        txt_nombre.Enabled = false;
                        txt_nombre.Focus();
                        txt_apellidos.Enabled = false;
                        txt_dni.Enabled = false;
                        txt_direccion.Enabled = false;
                        cbo_genero.Enabled = false;
                    }
                    //Si dni no existe mandara mensajillo
                    else
                    {
                        MessageBox.Show("El DNI ingresado NO EXISTE - Digite un DNI Valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt_codigoPaciente.Enabled = false;
                        txt_busqueda.Enabled = true;
                        cbo_busqueda.Enabled = true;
                        txt_nombre.Enabled = false;
                        txt_busqueda.Focus();
                        txt_busqueda.Text="";
                        txt_apellidos.Enabled = false;
                        txt_dni.Enabled = false;
                        txt_direccion.Enabled = false;
                        cbo_genero.Enabled = false;
                    }

                }

                //BUSQUEDA POR HISTORIA CLINICA
                if (cbo_busqueda.Text == "HISTORIA CLINICA")
                {
                    //SqlConnection miconexion = new SqlConnection(Conexion.conexion);
                    //SqlConnection cn = Clases.ConexionBD.ObtnerCOnexion();
                    //cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from PACIENTES where PACIENTE_ID= @Clave", cn);
                    cmd.Parameters.AddWithValue("@Clave", txt_busqueda.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    //Representa un set de comandos que es utilizado para llenar un DataSet
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    //Representa un caché (un espacio) en memoria de los datos.
                    DataSet ds = new DataSet("PACIENTES");

                    //Arreglo de byte en donde se almacenara la foto en bytes
                    byte[] MyData = new byte[0];


                    //Llenamosel DataSet con la tabla. ESTUDIANTE es nombre de la tabla
                    dp.Fill(ds, "PACIENTES");

                    //Si dni existe ejecutara la consulta
                    if (ds.Tables["PACIENTES"].Rows.Count > 0)
                    {
                        //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                        DataRow myRow = ds.Tables["PACIENTES"].Rows[0];

                        txt_apellidos.Text = myRow["APELLIDOS"].ToString();
                        txt_nombre.Text = myRow["NOMBRE"].ToString();
                        txt_dni.Text = myRow["DNI"].ToString();
                        cbo_genero.Text = myRow["GENERO"].ToString();
                        txt_direccion.Text = myRow["DIRECCION"].ToString();
                        txt_codigoPaciente.Text = myRow["PACIENTE_ID"].ToString();

                        txt_codigoPaciente.Enabled = false;
                        txt_busqueda.Enabled = true;
                        cbo_busqueda.Enabled = true;
                        txt_nombre.Enabled = false;
                        txt_nombre.Focus();
                        txt_apellidos.Enabled = false;
                        txt_dni.Enabled = false;
                        txt_direccion.Enabled = false;
                        cbo_genero.Enabled = false;
                    }
                    //Si dni no existe mandara mensajillo
                    else
                    {
                        MessageBox.Show("La Historia Clinica ingresados NO EXISTEN - Digite Historia Clinica", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        txt_codigoPaciente.Enabled = false;
                        txt_busqueda.Enabled = true;
                        cbo_busqueda.Enabled = true;
                        txt_nombre.Enabled = false;
                        txt_busqueda.Focus();
                        txt_busqueda.Text = "";
                        txt_apellidos.Enabled = false;
                        txt_dni.Enabled = false;
                        txt_direccion.Enabled = false;
                        cbo_genero.Enabled = false;
                    }
                }
            }
        }

        private void cbo_busqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_busqueda.Text == "DNI")
            {
                txt_busqueda.Focus();
            }
            else if (cbo_busqueda.Text == "HISTORIA CLINICA")
            {
                txt_busqueda.Focus();
            }
        }

        private void cbo_odontologo_Click(object sender, EventArgs e)
        {
            if (tabla.Rows.Count > 0)
            {
                cbo_odontologo.DataSource = tabla;
                cbo_odontologo.DisplayMember = "APELLIDOS";
                cbo_odontologo.ValueMember = "ODONTOLOGO_ID";
            }
        }
        private void cbo_odontologo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_nombreOdo.Text = cbo_odontologo.SelectedItem.ToString();
            cmd = new SqlCommand("SELECT * FROM ODONTOLOGOS where APELLIDOS ='" + cbo_odontologo.Text + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_codigoOdontologo.Text = cbo_odontologo.SelectedValue.ToString();
                string apellidos = (string)dr["APELLIDOS"].ToString();
                txt_apellidosOdo.Text = apellidos;
                string nombre = (string)dr["NOMBRE"].ToString();
                txt_nombreOdo.Text = nombre;
                string dni = (string)dr["DNI"].ToString();
                txt_dniOdo.Text = dni;
                string genero = (string)dr["GENERO"].ToString();
                txt_generoOdo.Text = genero;
            }
            cn.Close();
        }

        private void cbo_ServicioNombre_Click(object sender, EventArgs e)
        {
            if (tabla1.Rows.Count > 0)
            {
                cbo_ServicioNombre.DataSource = tabla1;
                cbo_ServicioNombre.DisplayMember = "NOMBRE";
                cbo_ServicioNombre.ValueMember = "SERVICIO_ID";
            }
        }

        private void cbo_ServicioNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_codigoOdontologo.Text = cbo_odontologo.SelectedItem.ToString();
            cmd = new SqlCommand("SELECT * FROM SERVICIOS where NOMBRE ='" + cbo_ServicioNombre.Text + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_codigoservicio.Text = cbo_ServicioNombre.SelectedValue.ToString();
                string precio = (string)dr["PRECIO"].ToString();
                txt_precio.Text = precio;
            }
            cn.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (cbo_ServicioNombre.Text.Trim().Equals(""))
            {
                cbo_ServicioNombre.Focus();
                MessageBox.Show("Seleccionar el Nombre del Servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_precio.Text.Trim().Equals(""))
            {
                txt_precio.Focus();
                MessageBox.Show("Completar El precio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int numero_filas = dgv_servicios.Rows.Count;
                if (numero_filas == 0)
                {
                    AgregarServicio();
                    CalcularTotal();
                    this.txt_precio.Clear();
                }
                else
                {
                    bool existe = false;
                    string numero = cbo_ServicioNombre.Text;

                    for (int i = 0; i < numero_filas; i++)
                    {
                        if (numero.Equals(dgv_servicios.Rows[i].Cells[1].Value.ToString()))
                        {
                            existe = true;
                            break;
                        }
                    }

                    if (existe)
                    {
                        MessageBox.Show("Este servicio ya fue agregado");
                    }
                    else
                    {
                        AgregarServicio();
                        CalcularTotal();
                    }


                }
            }
        }

        private void AgregarServicio()
        {
            string servicio = cbo_ServicioNombre.Text;
            string precio = txt_precio.Text;
            dgv_servicios.Rows.Add(servicio, precio, "Eliminar", 0);
            cbo_ServicioNombre.Text = string.Empty;
        }

        private void dgv_servicios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (dgv_servicios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {

                    DialogResult res = MessageBox.Show("Deseas Eliminar El Servicio", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                       
                            //ELIMINAR DEL DATAGRIDVIEW
                            dgv_servicios.Rows.RemoveAt(e.RowIndex);
                            CalcularTotal();
                            this.txt_precio.Clear();
                    }

                }


            }
        }


        public void CalcularTotal()
        {
             Decimal total=0;
            for (int i = 0; i < dgv_servicios.Rows.Count; i++)
            {   
                total += Convert.ToDecimal(dgv_servicios.Rows[i].Cells[1].Value.ToString());
            }
            txt_total.Text = total.ToString();

        }


        private void txt_calcularvuelto_Click(object sender, EventArgs e)
        {
            Double n1 = 0, n2=0, resta;

            n1 = n1 + Convert.ToDouble(txt_total.Text);
            n2 = n2 + Convert.ToDouble(txt_monto.Text);
            resta = n2 - n1;
            txt_vuelto.Text = Convert.ToString(resta+",00");
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            //BOTON REGISTRAR PAGO
            if (cbo_busqueda.Text.Trim().Equals("SELECCIONAR"))
            {
                cbo_busqueda.Focus();
                MessageBox.Show("Seleccionar el Paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbo_odontologo.Text.Trim().Equals("SELECCIONAR"))
            {
                cbo_odontologo.Focus();
                MessageBox.Show("Seleccionar el Odontólogo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbo_ServicioNombre.Text.Trim().Equals("SELECCIONAR"))
            {
                cbo_ServicioNombre.Focus();
                MessageBox.Show("Seleccionar algún servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string nombreservicio;
                int numero_filas = dgv_servicios.Rows.Count;
                for (int i = 0; i < numero_filas; i++)
                {
                    nombreservicio = dgv_servicios.Rows[i].Cells[0].Value.ToString();
               
                var pago = new Clases.Pago(
                DateTime.Parse(dtp_fecha.Text),
                decimal.Parse(txt_total.Text.Trim()),
                nombreservicio,
                txt_codigoPaciente.Text.Trim(),
                txt_codigoOdontologo.Text.Trim()
                ) ;

                int ultimo_id = pago.Registrar();
                if (ultimo_id > 0)

                {
                    MessageBox.Show("Pago registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //pendiente listar en  cliente.ListarClientesDataGridView(Vistas.Cliente.FormListCliente.MyForm.dgv_clientes);

                    DialogResult r = MessageBox.Show("Desea Ingresar Otra Consulta", "MENSAJE",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (r == DialogResult.OK)
                        {
                            cbo_odontologo.Text = "SELECCIONAR";
                            txt_codigoOdontologo.Text = "";
                            txt_apellidosOdo.Text = "";
                            txt_nombreOdo.Text = "";
                            txt_dniOdo.Text = "";
                            txt_generoOdo.Text = "";
                            cbo_ServicioNombre.Text = "SELECCIONAR";
                            txt_codigoservicio.Text = "";
                            while (dgv_servicios.RowCount > 0)
                            {

                                dgv_servicios.Rows.Remove(dgv_servicios.CurrentRow);

                            }

                        }
                        else
                        {
                            limpiar();
                        }

                }
                else
                {
                    MessageBox.Show("Error al registrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }

            }

        }




      public void limpiar()
        {
            cbo_busqueda.Text = "SELECCIONAR";
            txt_busqueda.Text = "";
            txt_codigoPaciente.Text = "";
            txt_dni.Text = "";
            txt_apellidos.Text = "";
            txt_nombre.Text = "";
            cbo_genero.Text = "";
            txt_direccion.Text = "";
            cbo_odontologo.Text = "SELECCIONAR";
            txt_codigoOdontologo.Text = "";
            txt_apellidosOdo.Text = "";
            txt_nombreOdo.Text = "";
            txt_dniOdo.Text = "";
            txt_generoOdo.Text = "";
            cbo_ServicioNombre.Text = "SELECCIONAR";
            txt_precio.Text = "";
            txt_codigoservicio.Text = "";
            while (dgv_servicios.RowCount > 0)
            {

                dgv_servicios.Rows.Remove(dgv_servicios.CurrentRow);

            }
            txt_total.Text = "";
            txt_monto.Text = "";
            txt_vuelto.Text = "";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Realmente deseas cancelar", "MENSAJE",
        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.OK)
            {
                Close();
            }
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }
    }

}
