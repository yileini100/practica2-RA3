namespace capaPresentacion.Reportes
{
    partial class frm_rpt_huesped
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
            this.splistarhuespedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReservaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Reserva = new capaPresentacion.Reportes.DataSet_Reserva();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_listar_huespedTableAdapter = new capaPresentacion.Reportes.DataSet_ReservaTableAdapters.sp_listar_huespedTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splistarhuespedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReservaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reserva)).BeginInit();
            this.SuspendLayout();
            // 
            // splistarhuespedBindingSource
            // 
            this.splistarhuespedBindingSource.DataMember = "sp_listar_huesped";
            this.splistarhuespedBindingSource.DataSource = this.dataSetReservaBindingSource;
            // 
            // dataSetReservaBindingSource
            // 
            this.dataSetReservaBindingSource.DataSource = this.dataSet_Reserva;
            this.dataSetReservaBindingSource.Position = 0;
            // 
            // dataSet_Reserva
            // 
            this.dataSet_Reserva.DataSetName = "DataSet_Reserva";
            this.dataSet_Reserva.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Huesped";
            reportDataSource1.Value = this.splistarhuespedBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "capaPresentacion.Reportes.Rpt_huesped.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_listar_huespedTableAdapter
            // 
            this.sp_listar_huespedTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(12, 40);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 2;
            this.txt_p1.Visible = false;
            // 
            // frm_rpt_huesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_rpt_huesped";
            this.Text = "frm_rpt_huesped";
            this.Load += new System.EventHandler(this.frm_rpt_huesped_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splistarhuespedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReservaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource splistarhuespedBindingSource;
        private System.Windows.Forms.BindingSource dataSetReservaBindingSource;
        private DataSet_Reserva dataSet_Reserva;
        private DataSet_ReservaTableAdapters.sp_listar_huespedTableAdapter sp_listar_huespedTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
    }
}