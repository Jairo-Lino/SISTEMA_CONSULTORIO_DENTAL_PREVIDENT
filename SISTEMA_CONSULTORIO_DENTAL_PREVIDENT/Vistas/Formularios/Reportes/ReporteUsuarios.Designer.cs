namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Reportes
{
    partial class ReporteUsuarios
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
            this.dataSetUsuarios = new SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.DataSetUsuarios();
            this.dataSetUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USUARIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetUsuariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uSUARIOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uSUARIOTableAdapter = new SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.DataSetUsuariosTableAdapters.USUARIOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USUARIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.uSUARIOBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.Reportes.ReportUsuarios.r" +
    "dlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 468);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetUsuarios
            // 
            this.dataSetUsuarios.DataSetName = "DataSetUsuarios";
            this.dataSetUsuarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetUsuariosBindingSource
            // 
            this.dataSetUsuariosBindingSource.DataSource = this.dataSetUsuarios;
            this.dataSetUsuariosBindingSource.Position = 0;
            // 
            // USUARIOBindingSource
            // 
            this.USUARIOBindingSource.DataMember = "USUARIO";
            this.USUARIOBindingSource.DataSource = this.dataSetUsuarios;
            // 
            // dataSetUsuariosBindingSource1
            // 
            this.dataSetUsuariosBindingSource1.DataSource = this.dataSetUsuarios;
            this.dataSetUsuariosBindingSource1.Position = 0;
            // 
            // uSUARIOBindingSource1
            // 
            this.uSUARIOBindingSource1.DataMember = "USUARIO";
            this.uSUARIOBindingSource1.DataSource = this.dataSetUsuariosBindingSource1;
            // 
            // uSUARIOTableAdapter
            // 
            this.uSUARIOTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteUsuarios";
            this.Text = "ReporteConsultas";
            this.Load += new System.EventHandler(this.ReporteUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USUARIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetUsuariosBindingSource;
        private DataSetUsuarios dataSetUsuarios;
        private System.Windows.Forms.BindingSource USUARIOBindingSource;
        private System.Windows.Forms.BindingSource dataSetUsuariosBindingSource1;
        private System.Windows.Forms.BindingSource uSUARIOBindingSource1;
        private DataSetUsuariosTableAdapters.USUARIOTableAdapter uSUARIOTableAdapter;
    }
}