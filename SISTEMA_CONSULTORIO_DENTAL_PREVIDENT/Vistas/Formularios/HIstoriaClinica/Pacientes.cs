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

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.HIstoriaClinica
{
    public partial class Pacientes : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);
        SqlCommand cmd;
        private Clases.Odontologo Odontologo1 = new Clases.Odontologo();
        private DataTable tabla;
        public Pacientes()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
            tabla = Odontologo1.ListaOdontologoCombo();
        }
        private static Pacientes _myForm;

        public static Pacientes MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new Pacientes();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            //var pago = new Clases.Pago();
            //pago.ListarPacientesporCodigoOdontologoDataGridView(txt_codigoOdo)(dgv_pacientes);
          
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            SqlConnection con = cn;
            SqlDataAdapter ada = new SqlDataAdapter("SP_LISTAR_PACIENTES_POR_ODONTOLOGO 1", con);
            DataSet ds = new DataSet();
                ada.Fill(ds);
            dgv_pacientes.DataSource = ds.Tables[0];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_pacientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgv_pacientes.Rows[e.RowIndex];
                Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_idpago.Text = dgv_pacientes.CurrentRow.Cells[0].Value.ToString();
                Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_id.Text = dgv_pacientes.CurrentRow.Cells[1].Value.ToString();
                Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_apellidos.Text = dgv_pacientes.CurrentRow.Cells[2].Value.ToString();
                Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_nombre.Text = dgv_pacientes.CurrentRow.Cells[3].Value.ToString();
                Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_motivo.Text = dgv_pacientes.CurrentRow.Cells[4].Value.ToString();
            }
            catch (SqlException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
            }
        }

        private void dgv_pacientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    DataGridViewRow fila = dgv_pacientes.Rows[e.RowIndex];
            //    Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_idpago.Text = dgv_pacientes.CurrentRow.Cells[0].Value.ToString();
            //    Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_id.Text = dgv_pacientes.CurrentRow.Cells[1].Value.ToString();
            //    Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_apellidos.Text = dgv_pacientes.CurrentRow.Cells[2].Value.ToString();
            //    Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_nombre.Text = dgv_pacientes.CurrentRow.Cells[3].Value.ToString();
            //    Vistas.Formularios.Consultas.AgregarConsulta.MyForm.txt_motivo.Text = dgv_pacientes.CurrentRow.Cells[4].Value.ToString();
            //}
            //catch (SqlException ae)
            //{
            //    System.Windows.Forms.MessageBox.Show(ae.Message);
            //}
        }
    }
}
