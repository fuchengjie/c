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
        private void frm_passwd_modify_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;

            //密码样式
            txt_new_passwd.PasswordChar = '*';
            txt_old_passwd.PasswordChar = '*';
            txt_old_passwd.Focus();
        }
        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_old_passwd.Text.Trim().Equals(Frm_login.passwd) == false)
            {
                MessageBox.Show("原密码错误！请重新输入");
                return;
            }

            if (txt_new_passwd.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入新密码！");
                return;
            }
            
            string sqlstr =
                "update tb_EmpInfo set emp_login_passwd=@txt_new_passwd where emp_login_name=@name";

            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("@txt_new_passwd",txt_new_passwd.Text.Trim()),
                new OleDbParameter("@name",Frm_login.name)
            };

            //修改密码
            OleDbConnection conn = new OleDbConnection(Frm_login.connectStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = sqlstr;
            cmd.Connection = conn;
            cmd.Parameters.Add(parameters);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("密码修改成功");
                return;
            }
            else
            {
                MessageBox.Show("密码修改失败，请联系程序制作者...");
                return;
            }

        }
    }
}
