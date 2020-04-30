namespace Proyecto_Final
{
    partial class FrmReporteCalificaciones
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
            this.DataSetCalificaciones = new Proyecto_Final.DataSetCalificaciones();
            this.usp_Presentacion_ImprimirCalificacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_Presentacion_ImprimirCalificacionesTableAdapter = new Proyecto_Final.DataSetCalificacionesTableAdapters.usp_Presentacion_ImprimirCalificacionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCalificaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_Presentacion_ImprimirCalificacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCalificacionesrdlc";
            reportDataSource1.Value = this.usp_Presentacion_ImprimirCalificacionesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_Final.Presentacion.ReporteCalificaciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(697, 418);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetCalificaciones
            // 
            this.DataSetCalificaciones.DataSetName = "DataSetCalificaciones";
            this.DataSetCalificaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usp_Presentacion_ImprimirCalificacionesBindingSource
            // 
            this.usp_Presentacion_ImprimirCalificacionesBindingSource.DataMember = "usp_Presentacion_ImprimirCalificaciones";
            this.usp_Presentacion_ImprimirCalificacionesBindingSource.DataSource = this.DataSetCalificaciones;
            // 
            // usp_Presentacion_ImprimirCalificacionesTableAdapter
            // 
            this.usp_Presentacion_ImprimirCalificacionesTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 418);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCalificaciones";
            this.Text = "FrmReporteCalificaciones";
            this.Load += new System.EventHandler(this.FrmReporteCalificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCalificaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_Presentacion_ImprimirCalificacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_Presentacion_ImprimirCalificacionesBindingSource;
        private DataSetCalificaciones DataSetCalificaciones;
        private DataSetCalificacionesTableAdapters.usp_Presentacion_ImprimirCalificacionesTableAdapter usp_Presentacion_ImprimirCalificacionesTableAdapter;
    }
}