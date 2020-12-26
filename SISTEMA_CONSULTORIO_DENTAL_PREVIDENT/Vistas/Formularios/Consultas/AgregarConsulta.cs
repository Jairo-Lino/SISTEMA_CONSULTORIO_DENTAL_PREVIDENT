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

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Consultas
{
    public partial class AgregarConsulta : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString);
        SqlCommand cmd;
        private Clases.Odontologo Odontologo1 = new Clases.Odontologo();
        private DataTable tabla;
        public AgregarConsulta()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
            dtp_fecha.Text = DateTime.Now.ToShortDateString();
            tabla = Odontologo1.ListaOdontologoCombo();
        }
        private static AgregarConsulta _myForm;

        public static AgregarConsulta MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new AgregarConsulta();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            var f = new Vistas.Formularios.Consultas.ListarConsulta();
            f.ShowDialog();
        }

        private void AgregarConsulta_Load(object sender, EventArgs e)
        {
            if (tabla.Rows.Count > 0)
            {
                cbo_odontologo.DataSource = tabla;
                cbo_odontologo.DisplayMember = "APELLIDOS";
                cbo_odontologo.ValueMember = "ODONTOLOGO_ID";
                txt_codigoOdontologo.Text = cbo_odontologo.SelectedValue.ToString();
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text.Trim().Equals(""))
            {
                txt_id.Focus();
                MessageBox.Show("Seleccionar el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var consulta = new Clases.Consulta(
                DateTime.Parse(dtp_fecha.Text),
                txt_motivo.Text.Trim(),
                txt_consulta.Text.Trim(),
                txt_receta.Text.Trim(),
                txt_diagnostico.Text.Trim(),
                txt_id.Text.Trim(),
                txt_codigoOdontologo.Text.Trim()
                );

                int ultimo_id = consulta.Registrar();
                if (ultimo_id > 0)

                {
                    MessageBox.Show("Consulta registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //pendiente listar en  cliente.ListarClientesDataGridView(Vistas.Cliente.FormListCliente.MyForm.dgv_clientes);

                    SqlConnection con = cn;
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = CommandType.Text.ToString();
                    using (cn)
                    {
                        cn.Open();
                        cmd.CommandText = string.Format(@"UPDATE PAGOS SET" + "[ESTADOATENCION] = @ESTADOATENCION" + " where [PAGO_ID] = @PAGO_ID", cn);
                        cmd.Parameters.AddWithValue("@ESTADOATENCION", "Atendido");
                        cmd.Parameters.AddWithValue("@PAGO_ID", txt_idpago.Text);
                        cmd.ExecuteNonQuery();

                        cn.Close();

                    }


                        limpiar();
                }
                else
                {
                    MessageBox.Show("Error al registrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           



            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var f = new Vistas.Formularios.HIstoriaClinica.Pacientes();
            f.ShowDialog();
        }

        public void limpiar()
        {
            cbo_odontologo.Text = "SELECCIONAR";
            txt_codigoOdontologo.Text = "";
            txt_id.Text = "";
            txt_idpago.Text = "";
            txt_apellidos.Text = "";
            txt_nombre.Text = "";
            txt_motivo.Text = "";
            txt_consulta.Text = "";
            txt_receta.Text = "";
            txt_diagnostico.Text = "";

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
