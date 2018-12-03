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
        public Frm_login()
        {
            InitializeComponent();this.CenterToScreen();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            
            

            this.MaximizeBox = false;

            this.BackgroundImage = Image.FromFile("login.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImageLayout = ImageLayout.Center;


            btn_ok.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if(txt_id.Text=="")
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (txt_passwd.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            string sqlstr = "select count(*) from tb_EmpInfo where emp_login_name='" + txt_id.Text
                + "'" + " and emp_login_passwd='" + txt_passwd.Text + "'";
            publicClass.getSqlConnection get = new publicClass.getSqlConnection();
            OleDbConnection conn = get.GetCon();
            OleDbCommand cmd = new OleDbCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlstr
            };
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                //得到用户名
                name = txt_id.Text.Trim();
                passwd = txt_passwd.Text.Trim();

                cmd.CommandText= "select emp_role from tb_EmpInfo where emp_login_name='" + txt_id.Text
                + "'" + " and emp_login_passwd='" + txt_passwd.Text + "'";

                //得到用户角色
                role = cmd.ExecuteScalar().ToString();
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
            
        }
    }
}
