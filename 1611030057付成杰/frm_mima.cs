using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1611030057付成杰
{
    public partial class frm_mima : Form
    {
        public frm_mima()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_new_passwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入新密码！");
                return;
            }

            frm_emp_info.newPasswd = txt_new_passwd.Text.Trim();
            MessageBox.Show("密码修改成功！");
            this.Close();
        }

        private void Frm_mima_FormClosed(object sender, FormClosedEventArgs e)
        {
            return;
        }

        private void Frm_mima_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }

        private void Frm_mima_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
    }
}
