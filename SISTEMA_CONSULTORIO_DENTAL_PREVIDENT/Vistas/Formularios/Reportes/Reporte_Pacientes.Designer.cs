namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Reportes
{
    partial class Reporte_Pacientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetPacientes = new SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.DataSetPacientes();
            this.pACIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pACIENTESTableAdapter = new SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.DataSetPacientesTableAdapters.PACIENTESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACIENTESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.pACIENTESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Reportes.ReportPaciente.r" +
    "dlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(812, 518);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetPacientes
            // 
            this.dataSetPacientes.DataSetName = "DataSetPacientes";
            this.dataSetPacientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pACIENTESBindingSource
            // 
            this.pACIENTESBindingSource.DataMember = "PACIENTES";
            this.pACIENTESBindingSource.DataSource = this.dataSetPacientes;
            // 
            // pACIENTESTableAdapter
            // 
            this.pACIENTESTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_Pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 518);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Reporte_Pacientes";
            this.Text = "Reporte_Pacientes";
            this.Load += new System.EventHandler(this.Reporte_Pacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACIENTESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetPacientes dataSetPacientes;
        private System.Windows.Forms.BindingSource pACIENTESBindingSource;
        private DataSetPacientesTableAdapters.PACIENTESTableAdapter pACIENTESTableAdapter;
    }
}