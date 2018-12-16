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
    public partial class Frm_login : Form
    {
        public static string name = "";
        public static string role = "";
        public static string passwd = "";

        //连接字符串
        public static string connectStr =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./db_cs_manage.accdb";

        public Frm_login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            this.BackgroundImage = Image.FromFile("login.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            btn_ok.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_id.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (txt_passwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            string sqlstr =
                "select count(*) from tb_EmpInfo where emp_login_name=@id and emp_login_passwd=@pwd";

            OleDbConnection conn = new OleDbConnection(Frm_login.connectStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlstr
            };
            OleDbParameter[] parmeter = new OleDbParameter[]
            {
                new OleDbParameter("@id", txt_id.Text.Trim()),
                new OleDbParameter("@pwd", txt_passwd.Text.Trim())
            };
            cmd.Parameters.AddRange(parmeter);

            if ((int)cmd.ExecuteScalar() > 0)
            {
                cmd.CommandText =
                    "select emp_role from tb_EmpInfo where emp_login_name=@id and emp_login_passwd=@pwd";
                //得到用户角色
                role = cmd.ExecuteScalar().ToString();
                name = txt_id.Text.Trim();
                passwd = txt_passwd.Text.Trim();

                //打开主界面
                Frm_main frm = new Frm_main();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！请重试");
                return;
            }
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
               == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
