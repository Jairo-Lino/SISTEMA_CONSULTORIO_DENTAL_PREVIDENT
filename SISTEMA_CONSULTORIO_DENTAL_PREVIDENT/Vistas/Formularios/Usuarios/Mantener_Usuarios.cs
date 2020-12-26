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
using System.Globalization;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios
{
    public partial class Mantener_Usuarios : Form
    {
        SqlConnection cn = new SqlConnection(
                     ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString
                     );
        // SqlConnection cn = Clases.ConexionBD.ObtnerCOnexion();
        Clases.Usuario objUsu = new Clases.Usuario();
        public Mantener_Usuarios()
        {
            InitializeComponent();
            txtPwd.isPassword = true;

            if (_myForm == null)
            {
                _myForm = this;
            }
        }

        //  metodo para grabar usuario
        private static Mantener_Usuarios _myForm;
        public static Mantener_Usuarios MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new Mantener_Usuarios();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        // MÉTODO PARA GRABAR EL USUARIO
        private void registro()
        {
            try
            {
                {

                }

                if (txtApellidos.Text != "" & txtNombre.Text != "" & txtPwd.Text != "" & txtUsu.Text != "" & cbo_sexo.Text != "" & cbo_tipoUsuario.Text != "")
                {
                  objUsu.Registrar("", txtApellidos.Text.ToUpper(), txtNombre.Text.ToUpper(), txtUsu.Text.ToUpper(), txtPwd.Text.ToUpper(), cbo_tipoUsuario.Text.ToString(), cbo_sexo.Text.ToString());
                  MessageBox.Show("USUARIO REGISTRADO", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    listarUsuarios();
                    limpiar();

                }
                else
                {
                    MessageBox.Show("LLENAR TODOS LOS CAMPOS", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void limpiar()
        {
            cbo_tipoUsuario.Text = "SELECCIONAR";
            cbo_sexo.Text = "SELECCIONAR";
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtUsu.Text = "";
            txtPwd.Text = "";
            //txtNombre.Focus();
            /*cbo_tipoUsuario.SelectedIndex = 0;*/
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            registro();
        }

        private void Mantener_Usuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            listarUsuarios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void listarUsuarios()
        {
            //int n1 = 1, suma;
            //para que se mueltre el ultimo id registrado
            //String UltimoID = (@"select count(*) from USUARIO;");
            //para que nos muestra el total de usuario,activos e inactivos 
            String total = (@"select count(*) from USUARIO");
            String activos = (@"SELECT count(ESTADO) FROM USUARIO WHERE ESTADO=1");
            String inactivos = (@"SELECT count(ESTADO) FROM USUARIO WHERE ESTADO=0");
            SqlConnection conexion = cn;
            {
                conexion.Open();
                //SqlCommand cmdUltimo = new SqlCommand(UltimoID, conexion);
                SqlCommand cmd = new SqlCommand(total, conexion);
                SqlCommand cmd1 = new SqlCommand(activos, conexion);
                SqlCommand cmd2 = new SqlCommand(inactivos, conexion);

                int UltimoId = Convert.ToInt32(cmd.ExecuteScalar());
                int maxId = Convert.ToInt32(cmd.ExecuteScalar());
                int maxId1 = Convert.ToInt32(cmd1.ExecuteScalar());
                int maxId2 = Convert.ToInt32(cmd2.ExecuteScalar());
                //suma = n1 + UltimoId;


                //txt_id.Text = suma.ToString();
                TotalUsuarios.Text = maxId.ToString();
                UsuariosActivos.Text = maxId1.ToString();
                UsuariosInactivos.Text = maxId2.ToString();
                conexion.Close();
            }
            SqlConnection con = cn;
            btn_Agregar.Enabled = true;
            SqlDataAdapter ada = new SqlDataAdapter("Select * from USUARIO order by COD_USUARIO", con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dgv_usuarios.DataSource = ds.Tables[0];

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            //AQUI
            if (dgv_usuarios.Rows.Count > 0)
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("Por favor, selecciona un usuario que desea modificar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool estado;
                    {
                        SqlConnection con = cn;
                        con.Open();

                        string id = txt_id.Text;
                        string apellidos = txtApellidos.Text.Trim();
                        string nombre = txtNombre.Text.Trim();
                        string usuario = txtUsu.Text.Trim();
                        string contraseña = txtPwd.Text.Trim();
                        string tipo_usuario = cbo_tipoUsuario.SelectedItem.ToString();
                        string sexo = cbo_sexo.SelectedItem.ToString();
                        if (bunifuCheckbox1.Checked)
                        {
                            estado = true;
                        }
                        else
                        {
                            estado = false;
                        }
                        
                            DialogResult resultado = MessageBox.Show("¿Estas seguro de editar este usuario?", "Borrar Registro",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (resultado == DialogResult.Yes)
                            {

                                string consulta = @"UPDATE USUARIO Set
                                APELLIDOS = @apellidos, NOMBRE = @nombre, USUARIO =@usuario, CONTRASENA = @contraseña, TIPO_USUARIO = @tipousuario, SEXO = @sexo, ESTADO= @estado Where COD_USUARIO=@id";

                                SqlCommand cmd = new SqlCommand(consulta, con);


                                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@usuario", usuario);
                                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                                cmd.Parameters.AddWithValue("@tipousuario", tipo_usuario);
                                cmd.Parameters.AddWithValue("@sexo", sexo);
                                cmd.Parameters.AddWithValue("@estado", estado);
                                cmd.Parameters.AddWithValue("@id", id);


                                int cant;

                                cant = cmd.ExecuteNonQuery();
                                if (cant == 1)
                                {
                                    MessageBox.Show("USUARIO EDITADO CORRECTAMENTE", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                    con.Close();
                                listarUsuarios();
                                limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("NO SE ACTUALIZÓ", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("USTED CANCELÓ LA OPERACIÓN", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor,lista los usuarios y selecciona una fila que desea Modificar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPwd_OnValueChanged(object sender, EventArgs e)
        {
            foreach (var ctl in txtPwd.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = 4;
                }
            }
        }
        private void txtUsu_OnValueChanged(object sender, EventArgs e)
        {
            foreach (var ctl in txtUsu.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = 5;
                }
            }
        }

        private void dgv_usuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_Agregar.Enabled = false;
            try
            {
                DataGridViewRow fila = dgv_usuarios.Rows[e.RowIndex];
                txt_id.Text = dgv_usuarios.CurrentRow.Cells[0].Value.ToString();
                txtApellidos.Text = dgv_usuarios.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgv_usuarios.CurrentRow.Cells[2].Value.ToString();
                txtUsu.Text = dgv_usuarios.CurrentRow.Cells[3].Value.ToString();
                txtPwd.isPassword = true;
                txtPwd.Text = dgv_usuarios.CurrentRow.Cells[4].Value.ToString();
                cbo_tipoUsuario.SelectedItem = dgv_usuarios.CurrentRow.Cells[5].Value.ToString();
                cbo_sexo.SelectedItem = dgv_usuarios.CurrentRow.Cells[6].Value.ToString();
                bool estado = Convert.ToBoolean(fila.Cells[8].Value);
                if (estado == true)
                {
                    bunifuCheckbox1.Checked = true;
                }
                else
                {
                    bunifuCheckbox1.Checked = false;
                }
            }
            catch (SqlException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
            }
        }

        private void ocultar_contra_Click(object sender, EventArgs e)
        {
            txtPwd.isPassword = false;
            ocultar_contra.Visible = true;
            visualizar_contra.Visible = false;
        }

        private void ocultar_contra_Click_1(object sender, EventArgs e)
        {
            txtPwd.isPassword = true;
            ocultar_contra.Visible = false;
            visualizar_contra.Visible = true;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgv_usuarios.Rows.Count > 0)
                {
                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Por favor, selecciona un usuario que desea eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string id = txt_id.Text;
                        DialogResult res = MessageBox.Show("¿Estas seguro de eliminar este usuario?", "Borrar Registro",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (res == DialogResult.Yes)
                        {
                            SqlConnection con = cn;
                            con.Open();
                            string consulta = "DELETE FROM USUARIO WHERE COD_USUARIO=@id";
                            SqlCommand cmd = new SqlCommand(consulta, con);

                            cmd.Parameters.AddWithValue("@id", id);
                            int cant;

                            cant = cmd.ExecuteNonQuery();
                            if (cant == 1)
                            {
                                MessageBox.Show("USUARIO ELIMINADO CORRECTAMENTE", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                //objUsu.listareliminarrusuarios(dgv_usuarios);
                                con.Close();
                            listarUsuarios();
                            limpiar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usted canceló la operación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Por favor, lista los usuarios y selecciona una fila que desea eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = false;
            if (txt_buscar.Text == "")
            {
                MessageBox.Show("Por favor, escriba el nombre del usuario para buscarlo", "SISTEMA.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                SqlConnection con = cn;
                con.Open();
                string buscar = ConvertirEnMayuscula(txt_buscar.Text);
                string consulta = "select * from usuario where NOMBRE = @nombre";
                SqlCommand cmd = new SqlCommand(consulta, con);
                //cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", buscar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_usuarios.DataSource = dt;
                con.Close();
            }
        }
        private static string ConvertirEnMayuscula(string texto)
        {
            string str = "";
            str = CultureInfo.CurrentCulture.TextInfo.ToUpper(texto);
            return str;
        }

    }
}