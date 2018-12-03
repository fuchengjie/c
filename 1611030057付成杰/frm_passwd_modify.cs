using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _1611030057付成杰
{
    public partial class frm_passwd_modify : Form
    {
        public frm_passwd_modify()
        {
            InitializeComponent();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_old_passwd.Text.Trim().Equals(Frm_login.passwd) == false)
            {
                MessageBox.Show("原密码错误！");
                return;
            }

            if (txt_new_passwd.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入新密码！");
                return;
            }
            string sqlstr = "update tb_EmpInfo set emp_login_passwd='"+txt_new_passwd.Text.Trim()+"'"
                +"where emp_login_name='"+Frm_login.name+"'";
            try
            {
                publicClass.getSqlConnection get = new publicClass.getSqlConnection();
                OleDbConnection conn = get.GetCon();
                OleDbCommand cmd = new OleDbCommand(sqlstr,conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("密码修改成功");
                this.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void frm_passwd_modify_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
    }
}
