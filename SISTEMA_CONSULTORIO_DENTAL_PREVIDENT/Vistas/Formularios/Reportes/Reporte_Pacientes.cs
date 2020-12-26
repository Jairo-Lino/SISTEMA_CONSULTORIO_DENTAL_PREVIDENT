using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Reportes
{
    public partial class Reporte_Pacientes : Form
    {
        public Reporte_Pacientes()
        {
            InitializeComponent();
        }

        private void Reporte_Pacientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPacientes.PACIENTES' Puede moverla o quitarla según sea necesario.
            this.pACIENTESTableAdapter.Fill(this.dataSetPacientes.PACIENTES);

            this.reportViewer1.RefreshReport();
        }
    }
}
