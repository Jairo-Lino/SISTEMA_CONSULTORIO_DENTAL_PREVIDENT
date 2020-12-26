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
    public partial class FormActualizarTurnos : Form
    {
        public int turnoId_TEMP = 0;
        public FormActualizarTurnos()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }
        private static FormActualizarTurnos _myForm;

        public static FormActualizarTurnos MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new FormActualizarTurnos();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void FormActualizarTurnos_Load(object sender, EventArgs e)
        {
            cbo_turno.SelectedIndex = 0;
            cbo_horaEntrada.SelectedIndex = 0;
            cbo_horaSalida.SelectedIndex = 0;
        }

        private void FormActualizarTurnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myForm = null;
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
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
                cbo_horaSalida.Text,
                turnoId_TEMP
                );


                bool resultado_emp = turno.Actualizar();
                if (resultado_emp)
                {
                    MessageBox.Show("Turno actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    turno.ListarTurnosDataGridView(Vistas.Formularios.Turnos.FormListarTurnos.MyForm.dgv_turnos);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al actualizar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
