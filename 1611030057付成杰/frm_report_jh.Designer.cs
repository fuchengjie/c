namespace _1611030057付成杰
{
    partial class frm_report_jh
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
            this.db_cs_manageDataSet = new _1611030057付成杰.db_cs_manageDataSet();
            this.tb_JhGoodsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_JhGoodsInfoTableAdapter = new _1611030057付成杰.db_cs_manageDataSetTableAdapters.tb_JhGoodsInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.db_cs_manageDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_JhGoodsInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tb_JhGoodsInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_1611030057付成杰.publicClass.jh.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1261, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // db_cs_manageDataSet
            // 
            this.db_cs_manageDataSet.DataSetName = "db_cs_manageDataSet";
            this.db_cs_manageDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_JhGoodsInfoBindingSource
            // 
            this.tb_JhGoodsInfoBindingSource.DataMember = "tb_JhGoodsInfo";
            this.tb_JhGoodsInfoBindingSource.DataSource = this.db_cs_manageDataSet;
            // 
            // tb_JhGoodsInfoTableAdapter
            // 
            this.tb_JhGoodsInfoTableAdapter.ClearBeforeFill = true;
            // 
            // frm_report_jh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_report_jh";
            this.Text = "进货报表";
            this.Load += new System.EventHandler(this.frm_report_jh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_cs_manageDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_JhGoodsInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_JhGoodsInfoBindingSource;
        private db_cs_manageDataSet db_cs_manageDataSet;
        private db_cs_manageDataSetTableAdapters.tb_JhGoodsInfoTableAdapter tb_JhGoodsInfoTableAdapter;
    }
}