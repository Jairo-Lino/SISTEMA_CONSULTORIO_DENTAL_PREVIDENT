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

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Turnos
{
    public partial class FormRegistrarTurnos : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);
        SqlCommand cmd;
        public FormRegistrarTurnos()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_dni.Text.Trim().Equals(""))
            {
                txt_dni.Focus();
                MessageBox.Show("Completar Dni de 8 digitos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //BUSQUEDA POR DNI
            }
            else
            {
                //SqlConnection miconexion = new SqlConnection(Conexion.conexion);
                SqlConnection conexion = cn;
                //conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from ODONTOLOGOS where DNI= @DNI", conexion);
                cmd.Parameters.AddWithValue("@DNI", txt_dni.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Representa un set de comandos que es utilizado para llenar un DataSet
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                //Representa un caché (un espacio) en memoria de los datos.
                DataSet ds = new DataSet("ODONTOLOGOS");

                //Arreglo de byte en donde se almacenara la foto en bytes
                byte[] MyData = new byte[0];

                //Llenamosel DataSet con la tabla. ESTUDIANTE es nombre de la tabla
                dp.Fill(ds, "ODONTOLOGOS");
                //Si dni existe ejecutara la consulta
                if (ds.Tables["ODONTOLOGOS"].Rows.Count > 0)
                {
                    //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                    DataRow myRow = ds.Tables["ODONTOLOGOS"].Rows[0];

                    txt_apellidos.Text = myRow["APELLIDOS"].ToString();
                    txt_nombre.Text = myRow["NOMBRE"].ToString();
                    txt_dni.Text = myRow["DNI"].ToString();
                    txt_codigoOdontologo.Text = myRow["ODONTOLOGO_ID"].ToString();

                    //txt_codigoOdontologo.Enabled = false;
                    //txt_nombre.Enabled = false;
                    txt_nombre.Focus();
                    txt_dni.Text = "";
                    //txt_apellidos.Enabled = false;
                    //txt_dni.Enabled = false;
                }
                //Si dni no existe mandara mensajillo
                else
                {
                    MessageBox.Show("EL DNI INGRESADO NO EXISTE - DIGITE UN DNI VÁLIDO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //txt_codigoOdontologo.Enabled = false;
                    //txt_dni.Enabled = true;
                    //txt_nombre.Enabled = false;
                    txt_dni.Focus();
                    txt_dni.Text = "";
                    //txt_apellidos.Enabled = false;
                    //txt_dni.Enabled = false;
                }
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_apellidos.Text.Trim().Equals(""))
            {
                txt_apellidos.Focus();
                MessageBox.Show("Completar Apellidos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_nombre.Text.Trim().Equals(""))
            {
                txt_nombre.Focus();
                MessageBox.Show("Completar Nombre", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtp_fecha.Value.Equals(""))
            {
                dtp_fecha.Focus();
                MessageBox.Show("Completar la fecha", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var turno = new Clases.Turno(
                txt_apellidos.Text.Trim().ToUpper(),
                txt_nombre.Text.Trim().ToUpper(),
                cbo_turno.Text,
                dtp_fecha.Value,
                cbo_horaEntrada.Text,
                cbo_horaSalida.Text
                );


                int ultimo_id = turno.Registrar();
                if (ultimo_id > 0)
                {
                    MessageBox.Show("Turno registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    turno.ListarTurnosDataGridView(Vistas.Formularios.Turnos.FormListarTurnos.MyForm.dgv_turnos);
                    Limpiar();
                }

                else
                {
                    MessageBox.Show("Error al registrar Turno", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void FormRegistrarTurnos_Load(object sender, EventArgs e)
        {
            cbo_turno.SelectedIndex = 0;
            cbo_horaEntrada.SelectedIndex = 0;
            cbo_horaSalida.SelectedIndex = 0;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            txt_apellidos.Text = "";
            txt_nombre.Text = "";
            cbo_turno.SelectedIndex = 0;
            dtp_fecha.Value = DateTime.Today;
            cbo_horaEntrada.SelectedIndex = 0;
            cbo_horaSalida.SelectedIndex = 0;
            cbo_turno.Focus();

        }
    }
}
