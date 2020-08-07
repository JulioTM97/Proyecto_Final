namespace Proyecto_Final.Presentacion
{
    partial class FrmReporteMateriasPendiente
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
            this.dataSetMateriasPendientes = new Proyecto_Final.DataSetMateriasPendientes();
            this.materiasPendientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasPendientesTableAdapter = new Proyecto_Final.DataSetMateriasPendientesTableAdapters.MateriasPendientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMateriasPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasPendientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.materiasPendientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_Final.Presentacion.ReporteMateriasPendientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetMateriasPendientes
            // 
            this.dataSetMateriasPendientes.DataSetName = "DataSetMateriasPendientes";
            this.dataSetMateriasPendientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materiasPendientesBindingSource
            // 
            this.materiasPendientesBindingSource.DataMember = "MateriasPendientes";
            this.materiasPendientesBindingSource.DataSource = this.dataSetMateriasPendientes;
            // 
            // materiasPendientesTableAdapter
            // 
            this.materiasPendientesTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteMateriasPendiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteMateriasPendiente";
            this.Text = "FrmReporteMateriasPendiente";
            this.Load += new System.EventHandler(this.FrmReporteMateriasPendiente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMateriasPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasPendientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetMateriasPendientes dataSetMateriasPendientes;
        private System.Windows.Forms.BindingSource materiasPendientesBindingSource;
        private DataSetMateriasPendientesTableAdapters.MateriasPendientesTableAdapter materiasPendientesTableAdapter;
    }
}