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

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Principal
{
    public partial class Logueo : Form
    {
        Clases.Usuario objUsu = new Clases.Usuario();
             SqlConnection cn = new SqlConnection(
                 ConfigurationManager.ConnectionStrings["cs_proyecto"].ConnectionString
                 );

        int cont = 0;
        int estado = 0;
        public Logueo()
        {
            InitializeComponent();
            txtUsuario.Focus();

        }
        //METODO SOBRE LOGIN(ACCESO)
        private void Acceso()
        {
            try
            {

                objUsu.IniciarSesion(txtUsuario.Text.ToUpperInvariant(), txtPassword.Text.ToUpper(), cbo_tipousuariologin.Text.Trim());
                MessageBox.Show(objUsu.mensaje, "PREVIDENT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                //PASANDO VALORES PARA REGISTRO DE INTENTOS                
                cont = 0;
                estado = 1;
                intentos();

                // LLAMANDO A FORMULARIO PRINCIPAL
                Vistas.Principal.Menu_Principal menu = new Vistas.Principal.Menu_Principal();
            }
            catch (Exception e) { e.ToString(); }
        }
        //METODO PARA INTENTOS
        private void intentos()
        {
            try
            {
                objUsu.Intentos(txtUsuario.Text, Convert.ToInt32(cont), Convert.ToInt32(estado));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void validar()
        {

            try
            {
                if (txtUsuario.Text != "")
                {
                    objUsu.IniciarSesion(txtUsuario.Text, txtPassword.Text.ToUpper(), cbo_tipousuariologin.Text.Trim());

                    if (txtPassword.Text != "")
                    {

                        if (objUsu.mensaje == "EL USUARIO NO EXISTE.")
                        {
                            MessageBox.Show(objUsu.mensaje, "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtUsuario.HintText = "Usuario";
                            txtPassword.HintText = "Contraseña";
                            cbo_tipousuariologin.SelectedIndex = 0;
                            txtUsuario.Focus();

                        }
                        else if (objUsu.mensaje == "LA CONTRASEÑA NO CORRESPONDE.")
                        {
                            MessageBox.Show(objUsu.mensaje, "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtPassword.HintText = "Contraseña";
                            txtPassword.Focus();
                            cont++;
                            estado = 1;
                            objUsu.Intentos(txtUsuario.Text.ToUpper(), cont, estado);

                        }
                        else if (objUsu.mensaje == "LA CUENTA DE USUARIO ESTA BLOQUEADA.")
                        {
                            MessageBox.Show(objUsu.mensaje + " COMUNÍCATE CON EL ADMINISTRADOR", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtUsuario.HintText = "Usuario";
                            txtPassword.HintText = "Contraseña";
                            txtUsuario.Focus();
                            cont++;

                            cont = 0;
                            objUsu.Intentos(txtUsuario.Text.ToUpper(), cont, 0);


                            //btnClave.Enabled = true;
                            //BtnRegistro.Enabled = false;

                        }
                        else if (objUsu.mensaje == "BIENVENIDO AL SISTEMA.")
                        {

                            Acceso();
                            cont = 0;
                            estado = 1;
                            objUsu.Intentos(txtUsuario.Text, Convert.ToInt32(cont), Convert.ToInt32(estado));

                            if (cbo_tipousuariologin.Text == "ADMINISTRADOR")
                            {
                                Vistas.Principal.Form_Bienvenida inicia = new Vistas.Principal.Form_Bienvenida();
                                inicia.Show();
                                inicia.NombreUsuario.Text = txtUsuario.Text;
                                inicia.label4.Text = txtUsuario.Text;
                                inicia.label5.Text = cbo_tipousuariologin.Text;
                                this.Hide();
                            }
                            else if (cbo_tipousuariologin.Text == "ADMISIONISTA")
                            {
                                Vistas.Principal.Form_Bienvenida inicia = new Vistas.Principal.Form_Bienvenida();
                                inicia.Show();
                                inicia.NombreUsuario.Text = txtUsuario.Text;
                                inicia.label4.Text = txtUsuario.Text;
                                inicia.label5.Text = cbo_tipousuariologin.Text;
                                this.Hide();
                            }
                            else if (cbo_tipousuariologin.Text == "ODONTOLOGO")
                            {
                                Vistas.Principal.Form_Bienvenida inicia = new Vistas.Principal.Form_Bienvenida();
                                inicia.Show();
                                inicia.NombreUsuario.Text = txtUsuario.Text;
                                inicia.label4.Text = txtUsuario.Text;
                                inicia.label5.Text = cbo_tipousuariologin.Text;
                                this.Hide();
                            }

                        }
                        else
                        {

                            MessageBox.Show(objUsu.mensaje + "HA OCURRIDO UN ERROR", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtUsuario.HintText = "Usuario";
                            txtPassword.HintText = "Contraseña";
                            txtUsuario.Focus();

                        }


                        if (cont > 2)
                        {
                            MessageBox.Show("SE CUMPLIO SUS TRES INTENTOS SE BLOQUEARÁ TU CUENTA, GRACIAS...", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            cont = 0;
                            estado = 0;
                            intentos();
                            this.Dispose();
                        }


                    }
                    else
                    {
                        MessageBox.Show("INGRESE CONTRASEÑA", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPassword.Focus();

                    }

                }
                else
                {
                    MessageBox.Show("INGRESE EL USUARIO", "SISTEMA DE LOGIN.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtUsuario.Focus();

                }

            }
            catch (Exception e)
            {
                e.ToString();
            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("DESEAS SALIR DE LA VENTANA", "MENSAJE",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                btn_salir.Enabled = false;
            }
            else
            {
                btn_salir.Enabled = true;
            }
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

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (this.cbo_tipousuariologin.Text == "SELECCIONAR")
            {
                MessageBox.Show("Seleccione Tipo de Usuario", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            validar();
           
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                btn_salir.Enabled = false;
            }
            else
            {
                btn_salir.Enabled = true;
            }
        }

    }
}
