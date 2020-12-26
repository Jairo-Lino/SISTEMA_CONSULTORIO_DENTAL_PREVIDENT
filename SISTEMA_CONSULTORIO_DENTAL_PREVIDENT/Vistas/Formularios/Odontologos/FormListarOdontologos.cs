using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Odontologos
{
    public partial class FormListarOdontologos : Form
    {
        public FormListarOdontologos()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }  
        }
        private static FormListarOdontologos _myForm;

        public static FormListarOdontologos MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new FormListarOdontologos();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void FormListarOdontologos_Load(object sender, EventArgs e)
        {
            var odontologo = new Clases.Odontologo();
            odontologo.ListarOdontologosDataGridView(dgv_odontologos);
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            var odontologo = new Clases.Odontologo();
            if (txt_buscar.Text.Trim().Length > 0)
            {
                odontologo.BuscarOdontologoLike(dgv_odontologos, txt_buscar.Text.Trim());
            }
            else
            {
                odontologo.ListarOdontologosDataGridView(dgv_odontologos);
            }
        }

        private void dgv_odontologos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_odontologos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    var f = new FormActualizarOdontologos();
                    f.Show();
                    var odontologo = new Clases.Odontologo();

                    int odontologo_id = int.Parse(dgv_odontologos.Rows[e.RowIndex].Cells[6].Value.ToString());

                    var tabla_odontologo = odontologo.BuscarPorCodigo(odontologo_id);

                    if (tabla_odontologo.Rows.Count == 1)
                    {
                        FormActualizarOdontologos.MyForm.txt_apellidos.Text = tabla_odontologo.Rows[0]["APELLIDOS"].ToString();
                        FormActualizarOdontologos.MyForm.txt_nombre.Text = tabla_odontologo.Rows[0]["NOMBRE"].ToString();
                        FormActualizarOdontologos.MyForm.txt_dni.Text = tabla_odontologo.Rows[0]["DNI"].ToString();
                        FormActualizarOdontologos.MyForm.cbo_genero.Text = tabla_odontologo.Rows[0]["GENERO"].ToString();
                        FormActualizarOdontologos.MyForm.txt_direccion.Text = tabla_odontologo.Rows[0]["DIRECCION"].ToString();
                        FormActualizarOdontologos.MyForm.dtp_fechaNacimiento.Text = tabla_odontologo.Rows[0]["FECHA_NACIMIENTO"].ToString();
                        FormActualizarOdontologos.MyForm.txt_celular.Text = tabla_odontologo.Rows[0]["CELULAR"].ToString();

                        FormActualizarOdontologos.MyForm.cbo_departamento.SelectedValue = tabla_odontologo.Rows[0]["DEPARTAMENTO_ID"].ToString();
                        FormActualizarOdontologos.MyForm.cbo_provincia.SelectedValue = tabla_odontologo.Rows[0]["PROVINCIA_ID"].ToString();
                        FormActualizarOdontologos.MyForm.cbo_distrito.SelectedValue = tabla_odontologo.Rows[0]["DISTRITO_ID"].ToString();


                        FormActualizarOdontologos.MyForm.odontologoId_TEMP = odontologo_id;
                    }

                }
                if (dgv_odontologos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int odontologo_id = int.Parse(dgv_odontologos.Rows[e.RowIndex].Cells[6].Value.ToString());

                    DialogResult res = MessageBox.Show("Deseas eliminar este Odontologo?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        var odontologo = new Clases.Odontologo(odontologo_id);
                        if (odontologo.Eliminar())
                        {
                            // ELIMINAR DE DATAGRIDVIEW Y DE LA BASE DE DATOS
                            dgv_odontologos.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                    }

                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new Vistas.Formularios.Odontologos.FormRegistrarOdontologos();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
