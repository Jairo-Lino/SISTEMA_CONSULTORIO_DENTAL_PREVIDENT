using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Turnos
{
    public partial class FormListarTurnos : Form
    {
        public FormListarTurnos()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }
        private static FormListarTurnos _myForm;

        public static FormListarTurnos MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new FormListarTurnos();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void FormListarTurnos_Load(object sender, EventArgs e)
        {
            var turno = new Clases.Turno();
            turno.ListarTurnosDataGridView(dgv_turnos);
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            var turno = new Clases.Turno();
            if (txt_buscar.Text.Trim().Length > 0)
            {
                turno.BuscarTurnoLike(dgv_turnos, txt_buscar.Text.Trim());
            }
            else
            {
                turno.ListarTurnosDataGridView(dgv_turnos);
            }
        }

        private void dgv_turnos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_turnos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    var f = new FormActualizarTurnos();
                    f.Show();

                    var turno = new Clases.Turno();

                    int turno_id = int.Parse(dgv_turnos.Rows[e.RowIndex].Cells[7].Value.ToString());

                    var tabla_turno = turno.BuscarPorCodigo(turno_id);

                    if (tabla_turno.Rows.Count == 1)
                    {
                        FormActualizarTurnos.MyForm.txt_apellidos.Text = tabla_turno.Rows[0]["APELLIDOS"].ToString();
                        FormActualizarTurnos.MyForm.txt_nombre.Text = tabla_turno.Rows[0]["NOMBRE"].ToString();
                        FormActualizarTurnos.MyForm.cbo_turno.Text = tabla_turno.Rows[0]["TURNOO"].ToString();
                        FormActualizarTurnos.MyForm.dtp_fecha.Text = tabla_turno.Rows[0]["FECHA"].ToString();
                        FormActualizarTurnos.MyForm.cbo_horaEntrada.Text = tabla_turno.Rows[0]["HORA_ENTRADA"].ToString();
                        FormActualizarTurnos.MyForm.cbo_horaSalida.Text = tabla_turno.Rows[0]["HORA_SALIDA"].ToString();

                        FormActualizarTurnos.MyForm.turnoId_TEMP = turno_id;
                    }

                }
                if (dgv_turnos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int turno_id = int.Parse(dgv_turnos.Rows[e.RowIndex].Cells[7].Value.ToString());

                    DialogResult res = MessageBox.Show("Deseas eliminar este Turno?", "Mensaje",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        var turno = new Clases.Turno(turno_id);
                        if (turno.Eliminar())
                        {
                            // ELIMINAR DE DATAGRIDVIEW Y DE LA BASE DE DATOS
                            dgv_turnos.Rows.RemoveAt(e.RowIndex);
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
            var f = new Vistas.Formularios.Turnos.FormRegistrarTurnos();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}