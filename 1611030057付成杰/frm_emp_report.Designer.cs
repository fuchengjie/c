namespace _1611030057付成杰
{
    partial class frm_emp_report
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
            this.tbEmpInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbcsmanageDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_cs_manageDataSet = new _1611030057付成杰.db_cs_manageDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_EmpInfoTableAdapter = new _1611030057付成杰.db_cs_manageDataSetTableAdapters.tb_EmpInfoTableAdapter();
            this.tb_EmpInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbcsmanageDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_cs_manageDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_EmpInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmpInfoBindingSource
            // 
            this.tbEmpInfoBindingSource.DataMember = "tb_EmpInfo";
            this.tbEmpInfoBindingSource.DataSource = this.dbcsmanageDataSetBindingSource;
            // 
            // dbcsmanageDataSetBindingSource
            // 
            this.dbcsmanageDataSetBindingSource.DataSource = this.db_cs_manageDataSet;
            this.dbcsmanageDataSetBindingSource.Position = 0;
            // 
            // db_cs_manageDataSet
            // 
            this.db_cs_manageDataSet.DataSetName = "db_cs_manageDataSet";
            this.db_cs_manageDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbEmpInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_1611030057付成杰.emp_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(955, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_EmpInfoTableAdapter
            // 
            this.tb_EmpInfoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_EmpInfoBindingSource
            // 
            this.tb_EmpInfoBindingSource.DataMember = "tb_EmpInfo";
            this.tb_EmpInfoBindingSource.DataSource = this.db_cs_manageDataSet;
            // 
            // frm_emp_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_emp_report";
            this.Text = "员工报表";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbcsmanageDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_cs_manageDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_EmpInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private db_cs_manageDataSet db_cs_manageDataSet;
        private System.Windows.Forms.BindingSource dbcsmanageDataSetBindingSource;
        private System.Windows.Forms.BindingSource tbEmpInfoBindingSource;
        private db_cs_manageDataSetTableAdapters.tb_EmpInfoTableAdapter tb_EmpInfoTableAdapter;
        private System.Windows.Forms.BindingSource tb_EmpInfoBindingSource;
    }
}