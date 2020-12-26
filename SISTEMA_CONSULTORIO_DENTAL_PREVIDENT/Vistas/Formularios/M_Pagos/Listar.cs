using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.M_Pagos
{
    public partial class Listar : Form
    {
        public Listar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            var pago = new Clases.Pago();
            pago.ListarPagosDataGridView(dgv_pagos);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            var pago = new Clases.Pago();
            if (txt_buscar.Text.Trim().Length > 0)
            {
                pago.BuscarPagoLike(dgv_pagos, txt_buscar.Text.Trim());
            }
            else
            {
                pago.ListarPagosDataGridView(dgv_pagos);
            }
        }
    }
}
