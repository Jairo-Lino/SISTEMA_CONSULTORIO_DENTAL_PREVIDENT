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
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
            PersonalizarDiseño();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }
        private static Menu_Principal _myForm;

        public static Menu_Principal MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new Menu_Principal();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }
        private void PersonalizarDiseño()
        {
            panelUsuariosSubmenu.Visible = false;
            panelOdontologosSubmenu.Visible = false;
            panelPacientesSubmenu.Visible = false;
            panelHCSubmenu.Visible = false;
            panelTurnosSubmenu.Visible = false;
            panelPagosSubmenu.Visible = false;
            panelReportesSubmenu.Visible = false;
        }
        private void OcultarSubMenu()
        {
            if (panelUsuariosSubmenu.Visible == true)
                panelUsuariosSubmenu.Visible = false;
            if (panelOdontologosSubmenu.Visible == true)
                panelOdontologosSubmenu.Visible = false;
            if (panelPacientesSubmenu.Visible == true)
                panelPacientesSubmenu.Visible = false;
            if (panelHCSubmenu.Visible == true)
                panelHCSubmenu.Visible = false;
            if (panelTurnosSubmenu.Visible == true)
                panelTurnosSubmenu.Visible = false;
            if (panelPagosSubmenu.Visible == true)
                panelPagosSubmenu.Visible = false;
            if (panelReportesSubmenu.Visible == true)
                panelReportesSubmenu.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false) {
                OcultarSubMenu();
                subMenu.Visible = true;
            }  else {
                subMenu.Visible = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = DateTime.Now.ToString("F");
        }

        private void IconMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IconRestaurar.Visible = true;
            IconMaximizar.Visible = false;
        }

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            IconRestaurar.Visible = false;
            IconMaximizar.Visible = true;
        }

        private void IconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("DESEAS CERRAR LA APLICACIÓN", "MENSAJE",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 58;

            }
            else
            {
                MenuVertical.Width = 250;
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

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelUsuariosSubmenu);
        }

        private void btn_MantUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Mantener_Usuarios());
            OcultarSubMenu();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿ESTÁS SEGURO DE CERRAR LA SESIÓN?", "MENSAJE",
          MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.OK)
            {
                Logueo frm = new Logueo();
                frm.Show();
                this.Close();
            }

        }

        private void btn_RegistrarPaciente_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Pacientes.FormRegistrarPacientes());
            OcultarSubMenu();
        }

        private void btn_ListarPaciente_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Pacientes.FormListarPacientes());
            OcultarSubMenu();
        }

        private void btn_Odontólogos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelOdontologosSubmenu);
        }

        private void btn_RegistrarOdontologo_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Odontologos.FormRegistrarOdontologos());
            OcultarSubMenu();
        }

        private void btn_ListarOdontologo_Click(object sender, EventArgs e)
        {
           AbrirFormInPanel(new Vistas.Formularios.Odontologos.FormListarOdontologos());
            OcultarSubMenu();
        }

        private void btn_Pacientes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelPacientesSubmenu);
        }

        private void btn_HC_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelHCSubmenu);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Consultas.ListarConsulta());
            OcultarSubMenu();
        }

        private void btn_Pagos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelPagosSubmenu);
        }

        private void btn_Turnos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelTurnosSubmenu);
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelReportesSubmenu);
        }

        private void btn_RegistrarPagos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.M_Pagos.Agregar());
            OcultarSubMenu();
        }

        private void btn_VerPagos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.M_Pagos.Listar());
            OcultarSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Turnos.FormRegistrarTurnos());
            OcultarSubMenu();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Turnos.FormListarTurnos());
            OcultarSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Reportes.Reporte_Pacientes());
            OcultarSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vistas.Formularios.Reportes.ReporteUsuarios());
            OcultarSubMenu();
        }
    }
}
