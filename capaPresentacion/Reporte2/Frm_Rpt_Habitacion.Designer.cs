namespace capaPresentacion.Reporte2
{
    partial class Frm_Rpt_Habitacion
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
            this.dataSet_habitacion = new capaPresentacion.Reporte2.DataSet_habitacion();
            this.splistarhabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_listar_habitacionTableAdapter = new capaPresentacion.Reporte2.DataSet_habitacionTableAdapters.sp_listar_habitacionTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_habitacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splistarhabitacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "habitacion";
            reportDataSource1.Value = this.splistarhabitacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "capaPresentacion.Reporte2.Rpt_habitacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_habitacion
            // 
            this.dataSet_habitacion.DataSetName = "DataSet_habitacion";
            this.dataSet_habitacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splistarhabitacionBindingSource
            // 
            this.splistarhabitacionBindingSource.DataMember = "sp_listar_habitacion";
            this.splistarhabitacionBindingSource.DataSource = this.dataSet_habitacion;
            // 
            // sp_listar_habitacionTableAdapter
            // 
            this.sp_listar_habitacionTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(12, 35);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(110, 20);
            this.txt_p1.TabIndex = 1;
            this.txt_p1.Visible = false;
            // 
            // Frm_Rpt_Habitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Habitacion";
            this.Text = "Reporte de Habitación";
            this.Load += new System.EventHandler(this.Frm_Rpt_Habitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_habitacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splistarhabitacionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource splistarhabitacionBindingSource;
        private DataSet_habitacion dataSet_habitacion;
        private DataSet_habitacionTableAdapters.sp_listar_habitacionTableAdapter sp_listar_habitacionTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
    }
}