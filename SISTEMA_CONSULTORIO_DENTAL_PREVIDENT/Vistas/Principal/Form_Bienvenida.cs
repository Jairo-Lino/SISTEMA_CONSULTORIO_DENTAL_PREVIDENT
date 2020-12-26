using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Principal
{
    public partial class Form_Bienvenida : Form
    {
        public Form_Bienvenida()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.01;
            {
                bunifuCircleProgressbar1.Value += 1;
                bunifuCircleProgressbar1.Text = bunifuCircleProgressbar1.Value.ToString();
                if (bunifuCircleProgressbar1.Value == 100)
                {
                    timer1.Stop();
                    timer2.Start();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                if (label5.Text == "ADMINISTRADOR")
                {
                    Vistas.Principal.Form_Bienvenida bienvenida = new Vistas.Principal.Form_Bienvenida();
                    bienvenida.Close();
                    Vistas.Principal.Menu_Principal menuprincipal = new Vistas.Principal.Menu_Principal();
                    menuprincipal.Show();
                    menuprincipal.lblusuario.Text = "Usuario: " + label4.Text + "  *** " + " Cargo: " + label5.Text.ToString();
                }
                else if (label5.Text == "ADMISIONISTA")
                {
                    Vistas.Principal.Menu_Admisionista menuadmisionista = new Vistas.Principal.Menu_Admisionista();
                    menuadmisionista.Show();
                    menuadmisionista.lblusuario.Text = "Usuario: " + label4.Text + "  *** " + " Cargo: " + label5.Text.ToString();
                }
                else if (label5.Text == "ODONTOLOGO")
                {
                    Vistas.Principal.Menu_Odontologo menuodontologo = new Vistas.Principal.Menu_Odontologo();
                    menuodontologo.Show();
                    menuodontologo.lblusuario.Text = "Usuario: " + label4.Text + "  *** " + " Cargo: " + label5.Text.ToString();
                }

            }
        }

        private void Form_Bienvenida_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            bunifuCircleProgressbar1.Value = 0;
            timer1.Start();
        }
    }
}
