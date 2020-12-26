using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Consultas
{
    public partial class ListarConsulta : Form
    {
        public ListarConsulta()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }
        private static ListarConsulta _myForm;

        public static ListarConsulta MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new ListarConsulta();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListarConsulta_Load(object sender, EventArgs e)
        {
            var consulta = new Clases.Consulta();
            consulta.ListarPacientesDataGridView(dgv_consulta);
        }

        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {
            var consulta = new Clases.Consulta();
            if (txt_buscador.Text.Trim().Length > 0)
            {
                consulta.BuscarPacienteLike(dgv_consulta, txt_buscador.Text.Trim());
            }
            else
            {
                consulta.ListarPacientesDataGridView(dgv_consulta);
            }
        }

        private void dgv_consulta_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgv_consulta.Rows[e.RowIndex];
                txt_consulta.Text = dgv_consulta.CurrentRow.Cells[3].Value.ToString();
                txt_receta.Text = dgv_consulta.CurrentRow.Cells[4].Value.ToString();
                txt_diagnostico.Text = dgv_consulta.CurrentRow.Cells[5].Value.ToString();
                txt_nombreCompleto.Text = dgv_consulta.CurrentRow.Cells[6].Value.ToString();
                
            }
            catch (SqlException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
