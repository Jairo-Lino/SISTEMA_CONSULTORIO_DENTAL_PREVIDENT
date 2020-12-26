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
    public partial class FormRegistrarOdontologos : Form
    {
        public FormRegistrarOdontologos()
        {
            InitializeComponent();
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
            else if (txt_dni.Text.Trim().Equals(""))
            {
                txt_dni.Focus();
                MessageBox.Show("Completar Dni", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_dni.Text.Trim().Length != 8)
            {
                txt_dni.Focus();
                MessageBox.Show("Completar Dni de 8 digitos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_direccion.Text.Trim().Equals(""))
            {
                txt_direccion.Focus();
                MessageBox.Show("Completar la direccion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtp_fechaNacimiento.Value.Equals(""))
            {
                dtp_fechaNacimiento.Focus();
                MessageBox.Show("Completar la fecha de nacimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_celular.Text.Trim().Equals(""))
            {
                txt_celular.Focus();
                MessageBox.Show("Completar Celular", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_celular.Text.Trim().Length != 9)
            {
                txt_celular.Focus();
                MessageBox.Show("Completar Celular de 9 digitos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var odontologo = new Clases.Odontologo(
                txt_apellidos.Text.Trim().ToUpper(),
                txt_nombre.Text.Trim().ToUpper(),
                txt_dni.Text.Trim(),
                cbo_genero.Text,
                txt_direccion.Text.Trim(),
                cbo_distrito.SelectedValue.ToString(),
                dtp_fechaNacimiento.Value,
                txt_celular.Text.Trim()
                );

                int ultimo_id = odontologo.Registrar();
                if (ultimo_id > 0)
                {
                    MessageBox.Show("Odontologo registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    odontologo.ListarOdontologosDataGridView(Vistas.Formularios.Odontologos.FormListarOdontologos.MyForm.dgv_odontologos);
                    Limpiar();
                }

                else
                {
                    MessageBox.Show("Error al registrar Odontologo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void FormRegistrarOdontologos_Load(object sender, EventArgs e)
        {
            cbo_genero.SelectedIndex = 0;

            // INSTANCIAR LA CLASE UBIGEO
            var ubigeo = new Clases.Ubigeo();

            var tabla = ubigeo.ListarDepartamentos(); ;

            if (tabla.Rows.Count > 0)
            {
                cbo_departamento.DataSource = tabla;
                cbo_departamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
                cbo_departamento.ValueMember = "DEPARTAMENTO_ID";
            }
        }

        private void cbo_provincia_SelectedValueChanged(object sender, EventArgs e)
        {
            // INSTANCIAR LA CLASE UBIGEO
            var ubigeo = new Clases.Ubigeo();
            var provinciaId = cbo_provincia.SelectedValue.ToString();
            var tabla = ubigeo.ListarDistritosPorProvinciaId(provinciaId);

            if (tabla.Rows.Count > 0)
            {
                cbo_distrito.DataSource = tabla;
                cbo_distrito.DisplayMember = "NOMBRE_DISTRITO";
                cbo_distrito.ValueMember = "DISTRITO_ID";
            }
        }

        private void cbo_departamento_SelectedValueChanged(object sender, EventArgs e)
        {
            // INSTANCIAR LA CLASE UBIGEO
            var ubigeo = new Clases.Ubigeo();
            var departamentoId = cbo_departamento.SelectedValue.ToString();
            var tabla = ubigeo.ListarProvinciasPorDepartamentoId(departamentoId);

            if (tabla.Rows.Count > 0)
            {
                cbo_provincia.DataSource = tabla;
                cbo_provincia.DisplayMember = "NOMBRE_PROVINCIA";
                cbo_provincia.ValueMember = "PROVINCIA_ID";
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void Limpiar()
        {
            txt_apellidos.Text = "";
            txt_nombre.Text = "";
            txt_dni.Text = "";
            cbo_genero.SelectedIndex = 0;
            txt_direccion.Text = "";
            cbo_departamento.SelectedIndex = 0;
            dtp_fechaNacimiento.Value = DateTime.Today;
            txt_celular.Text = "";
            txt_apellidos.Focus();

        }

        private void txt_celular_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }//evalua si es un caracter 
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }//evalua si es un caracter separador 
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_dni_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }//evalua si es un caracter 
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }//evalua si es un caracter separador 
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
