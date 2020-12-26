using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Pacientes
{
    public partial class FormListarPacientes : Form
    {
        public FormListarPacientes()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }
        private static FormListarPacientes _myForm;

        public static FormListarPacientes MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new FormListarPacientes();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void FormListarPacientes_Load(object sender, EventArgs e)
        {
            var paciente = new Clases.Paciente();
            paciente.ListarPacientesDataGridView(dgv_pacientes);
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            var paciente = new Clases.Paciente();
            if (txt_buscar.Text.Trim().Length > 0)
            {
                paciente.BuscarPacienteLike(dgv_pacientes, txt_buscar.Text.Trim());
            }
            else
            {
                paciente.ListarPacientesDataGridView(dgv_pacientes);
            }
        }

        private void dgv_pacientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_pacientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    var f = new FormActualizarPacientes();
                    f.Show();

                    var paciente = new Clases.Paciente();

                    int paciente_id = int.Parse(dgv_pacientes.Rows[e.RowIndex].Cells[6].Value.ToString());

                    var tabla_paciente = paciente.BuscarPorCodigo(paciente_id);

                    if (tabla_paciente.Rows.Count == 1)
                    {
                        FormActualizarPacientes.MyForm.txt_apellidos.Text = tabla_paciente.Rows[0]["APELLIDOS"].ToString();
                        FormActualizarPacientes.MyForm.txt_nombre.Text = tabla_paciente.Rows[0]["NOMBRE"].ToString();
                        FormActualizarPacientes.MyForm.txt_dni.Text = tabla_paciente.Rows[0]["DNI"].ToString();
                        FormActualizarPacientes.MyForm.cbo_genero.Text = tabla_paciente.Rows[0]["GENERO"].ToString();
                        FormActualizarPacientes.MyForm.cbo_estadoCivil.Text = tabla_paciente.Rows[0]["ESTADO_CIVIL"].ToString();
                        FormActualizarPacientes.MyForm.txt_direccion.Text = tabla_paciente.Rows[0]["DIRECCION"].ToString();
                        FormActualizarPacientes.MyForm.dtp_fechaNacimiento.Text = tabla_paciente.Rows[0]["FECHA_NACIMIENTO"].ToString();
                        FormActualizarPacientes.MyForm.txt_observaciones.Text = tabla_paciente.Rows[0]["OBSERVACIONES"].ToString();

                        FormActualizarPacientes.MyForm.cbo_departamento.SelectedValue = tabla_paciente.Rows[0]["DEPARTAMENTO_ID"].ToString();
                        FormActualizarPacientes.MyForm.cbo_provincia.SelectedValue = tabla_paciente.Rows[0]["PROVINCIA_ID"].ToString();
                        FormActualizarPacientes.MyForm.cbo_distrito.SelectedValue = tabla_paciente.Rows[0]["DISTRITO_ID"].ToString();


                        var telefono = new Clases.Telefono();
                        var tabla_telefonos = telefono.BuscarPorCodigo(paciente_id);
                        var numero_filas = tabla_telefonos.Rows.Count;
                        if (numero_filas > 0)
                        {
                            for (int i = 0; i < numero_filas; i++)
                            {
                                int telefono_id = int.Parse(tabla_telefonos.Rows[i][0].ToString());
                                string operador = tabla_telefonos.Rows[i][1].ToString();
                                string numero = tabla_telefonos.Rows[i][2].ToString();

                                FormActualizarPacientes.MyForm.dgv_telefonos.Rows.Add(
                                     operador, numero, "Eliminar", paciente_id, telefono_id
                                    );
                                //listar el número de LA HISTORIA CLINICA
                                var historia_clinica = new Clases.HistoriaClinica();
                                var tabla_historia_clinica = historia_clinica.BuscarPorCodigo(paciente_id);

                                FormActualizarPacientes.MyForm.txt_numeroHC.Text = tabla_historia_clinica.Rows[0]["NUMERO_HISTORIA"].ToString();
                                FormActualizarPacientes.MyForm.txt_AntecedentePersonal.Text = tabla_historia_clinica.Rows[0]["ANTECEDENTE_PERSONAL"].ToString();
                            }
                        }
                        FormActualizarPacientes.MyForm.pacienteId_TEMP = paciente_id;
                    }

                }
                if (dgv_pacientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int paciente_id = int.Parse(dgv_pacientes.Rows[e.RowIndex].Cells[6].Value.ToString());

                    DialogResult res = MessageBox.Show("Deseas eliminar este Paciente?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        var paciente = new Clases.Paciente(paciente_id);
                        if (paciente.Eliminar())
                        {
                            // ELIMINAR DE DATAGRIDVIEW Y DE LA BASE DE DATOS
                            dgv_pacientes.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                    }

                }

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new Vistas.Formularios.Pacientes.FormRegistrarPacientes();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
