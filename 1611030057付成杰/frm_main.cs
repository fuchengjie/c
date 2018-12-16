using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1611030057付成杰
{
    public partial class Frm_main : Form
    {
        public Frm_main()
        {
            InitializeComponent();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile("main.jpg");

            //设置定时器
            timer1.Enabled = true;
            timer1.Interval = 1000;

            //状态栏显示
            toolStripStatusLabel1.Text = "当前用户：" + Frm_login.name;
            toolStripStatusLabel2.Text = "用户角色：" + Frm_login.role;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            toolStripStatusLabel3.Text = "当前时间：" + DateTime.Now.ToString("F");
        }

        private void Frm_main_FormClosing(object sender, FormClosingEventArgs e)
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

        private void 基本档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_login.role.Equals("管理员") == false)
            {
                MessageBox.Show("无权限...只有管理员才能进入...");
                return;
            }

            frm_emp_info frm = new frm_emp_info();
            frm.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_passwd_modify frm = new frm_passwd_modify();
            frm.ShowDialog();
            frm.Owner = this;
        }

        private void 商品进货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_jh_manage frm = new frm_jh_manage();
            frm.ShowDialog();
            frm.Owner = this;
        }

        private void 商品销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_sale frm = new Frm_sale();
            frm.ShowDialog();
            frm.Owner = this;
        }

        private void Lbl_user_Click(object sender, EventArgs e)
        {

        }

        private void 销售记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sell_jilu frm = new frm_sell_jilu();
            frm.ShowDialog();
            frm.Owner = this;
        }

        private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_kc frm = new frm_kc();
            frm.ShowDialog();
            frm.Owner = this;

        }

        private void 信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void 员工报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_emp_report frm = new frm_emp_report();
            frm.ShowDialog();
        }

        private void 进货报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_report_jh frm = new frm_report_jh();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        //这个是调用windows的系统锁定，可以注销当前Windows用户，回到登录界面
        [DllImport("user32 ")]
        public static extern bool LockWorkStation();

        private void button4_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }
    }
}
