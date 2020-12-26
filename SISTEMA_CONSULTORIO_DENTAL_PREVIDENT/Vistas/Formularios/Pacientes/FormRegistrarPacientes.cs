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

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Pacientes
{
    public partial class FormRegistrarPacientes : Form
    {
        SqlConnection cn = new SqlConnection(
                       ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString
                       );
        public FormRegistrarPacientes()
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
            else if (txt_observaciones.Text.Trim().Equals(""))
            {
                txt_observaciones.Focus();
                MessageBox.Show("Completar la observacion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dgv_telefonos.Rows.Count == 0)
            {
                MessageBox.Show("Ingresar al menos un telefono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var paciente = new Clases.Paciente(
                txt_apellidos.Text.Trim().ToUpper(),
                txt_nombre.Text.Trim().ToUpper(),
                txt_dni.Text.Trim(),
                cbo_genero.Text,
                cbo_estadoCivil.Text,
                txt_direccion.Text.Trim(),
                cbo_distrito.SelectedValue.ToString(),
                dtp_fechaNacimiento.Value,
                txt_observaciones.Text.Trim().ToUpper()
                );


                int ultimo_id = paciente.Registrar();
                if (ultimo_id > 0)
                {
                    int numero_filas = dgv_telefonos.Rows.Count;
                    for (int i = 0; i < numero_filas; i++)
                    {
                        string operador = dgv_telefonos.Rows[i].Cells[0].Value.ToString();
                        string numero = dgv_telefonos.Rows[i].Cells[1].Value.ToString();
                        int paciente_id = ultimo_id;
                        var telefono = new Clases.Telefono(operador, numero, paciente_id);
                        var resultado = telefono.Registrar();

                        if (!resultado)
                        {
                            MessageBox.Show("Error al registrar telefono", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //REGISTRA LA HISTORIA CLINICA
                    var historia_clinica = new Clases.HistoriaClinica(
                    txt_AntecedentePersonal.Text.Trim(),
                    ultimo_id
                    );
                    bool resultado_HC = historia_clinica.Registrar();

                    if (!resultado_HC)
                    {
                        MessageBox.Show("Error al registrar la Historia Clinica del Paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Paciente registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    paciente.ListarPacientesDataGridView(Vistas.Formularios.Pacientes.FormListarPacientes.MyForm.dgv_pacientes);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al registrar paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }

        private void FormRegistrarPacientes_Load(object sender, EventArgs e)
        {
            MostrarUltimoHC();
            cbo_genero.SelectedIndex = 0;
            cbo_estadoCivil.SelectedIndex = 0;
            cbo_operador.SelectedIndex = 0;


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

        private void AgregarTelefonos()
        {
            string operador = cbo_operador.Text;
            string numero = txt_numero.Text;
            dgv_telefonos.Rows.Add(operador, numero, "Eliminar", 0);
            txt_numero.Text = string.Empty;
            txt_numero.Focus();
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

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_numero.Text.Trim().Equals(""))
            {
                txt_numero.Focus();
                MessageBox.Show("Completar Numero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_numero.Text.Trim().Length != 9)
            {
                txt_numero.Focus();
                MessageBox.Show("Completar Numero de 9 digistos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int numero_filas = dgv_telefonos.Rows.Count;
                if (numero_filas == 0)
                {
                    AgregarTelefonos();
                }
                else
                {
                    bool existe = false;
                    string numero = txt_numero.Text;

                    for (int i = 0; i < numero_filas; i++)
                    {
                        if (numero.Equals(dgv_telefonos.Rows[i].Cells[1].Value.ToString()))
                        {
                            existe = true;
                            break;
                        }
                    }

                    if (existe)
                    {
                        MessageBox.Show("Este telefono ya fue agregado");
                    }
                    else
                    {
                        AgregarTelefonos();
                    }


                }
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

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void limpiar()
        {
            txt_apellidos.Text = "";
            txt_nombre.Text = "";
            txt_dni.Text = "";
            cbo_genero.SelectedIndex = 0;
            cbo_estadoCivil.SelectedIndex = 0;
            txt_direccion.Text = "";
            cbo_departamento.SelectedIndex = 0;
            dtp_fechaNacimiento.Value = DateTime.Today;
            txt_observaciones.Text = "";
            while (dgv_telefonos.RowCount > 0)
            {

                dgv_telefonos.Rows.Remove(dgv_telefonos.CurrentRow);

            }
            txt_apellidos.Focus();
            MostrarUltimoHC();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarUltimoHC()
        {
            int n1 = 1, suma;
            //para que se mueltre el ultimo id registrado
            String UltimoID = ("SELECT MAX(NUMERO_HISTORIA) AS id FROM HISTORIALCLINICA");
            SqlConnection conexion = cn;
            {
                conexion.Open();
                SqlCommand cmdUltimo = new SqlCommand(UltimoID, conexion);

                int UltimoId = Convert.ToInt32(cmdUltimo.ExecuteScalar());
                suma = n1 + UltimoId;
                txt_numeroHC.Text = suma.ToString();
                conexion.Close();
            }


        }

        private void cbo_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
