using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace _1611030057付成杰
{
    public partial class frm_emp_report : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        OleDbConnection conn;
        OleDbCommand cmd;
        DataTable dt;
        string str = "select emp_name as 姓名,emp_login_name as 登录名,"+
                "emp_login_passwd as 登录密码,emp_role as 用户角色,emp_phone as 联系电话" +
                " from tb_EmpInfo";
        public frm_emp_report()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.BackColor = Color.LightBlue;


            // TODO: 这行代码将数据加载到表“db_cs_manageDataSet.tb_EmpInfo”中。您可以根据需要移动或删除它。
            this.tb_EmpInfoTableAdapter.Fill(this.db_cs_manageDataSet.tb_EmpInfo);
            //// TODO: 这行代码将数据加载到表“db_cs_manageDataSet.tb_EmpInfo”中。您可以根据需要移动或删除它。
            this.tb_EmpInfoTableAdapter.Fill(this.db_cs_manageDataSet.tb_EmpInfo);
            this.reportViewer1.RefreshReport();

            //reportViewer1.LocalReport.DataSources.Clear();

            //publicClass.getSqlConnection get = new publicClass.getSqlConnection();
            //conn = get.GetCon();
            //cmd = new OleDbCommand(str, conn);
            //da = new OleDbDataAdapter
            //{
            //    SelectCommand = cmd
            //};
            //ds = new DataSet();
            //da.Fill(ds);
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ds", ds.Tables["tb_EmpInfo"]));
            //reportViewer1.RefreshReport();

        }
    }
}
