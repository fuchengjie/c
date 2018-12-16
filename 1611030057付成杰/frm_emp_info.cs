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
    public partial class frm_emp_info : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        OleDbConnection conn;
        OleDbCommand cmd;

        public static string newPasswd;
        string conststr =
            "select emp_name as 姓名,emp_login_name as 登录名," +
            "emp_login_passwd as 登录密码,emp_role as 用户角色,emp_phone as 联系电话" +
            " from tb_EmpInfo";
        public frm_emp_info()
        {
            InitializeComponent();
        }
        private void Frm_emp_info_Load(object sender, EventArgs e)
        {
            //打开数据库连接，初始化对象
            try
            {
                conn = new OleDbConnection(Frm_login.connectStr);
                conn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = conn;
                ds = new DataSet();
                da = new OleDbDataAdapter();

            }
            catch (Exception ee)
            {
                MessageBox.Show("有错误！\n提醒：" + ee.ToString());
            }


            //datagridview样式
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.GridColor = Color.LightBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //窗体的属性
            this.BackColor = Color.LightBlue;
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //datagridview填充
            cmd.CommandText = conststr;
            cmd.Connection = conn;
            da.SelectCommand = cmd;
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
        }
        private void Qingkong()
        {
            //清空文本框的内容
            txt_login_name.Clear();
            txt_login_passwd.Clear();
            txt_name.Clear();
            txt_phone.Clear();
        }
        private void Btn_qingkong_Click(object sender, EventArgs e)
        {
            Qingkong();

            //填充dgv控件
            cmd.CommandText = conststr;
            cmd.Connection = conn;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户名字未输入");
                return;
            }
            if (txt_login_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户登录名未输入");
                return;
            }
            if (txt_phone.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户电话未输入");
                return;
            }
            if (txt_login_passwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户密码未输入");
                return;
            }

            //查询该登录名是否已经存在，如果是则提示重新输入，反之继续
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText =
                "select count(*) from tb_EmpInfo where emp_login_name=@emp_login_name";
            OleDbParameter pSelect =
                new OleDbParameter("@emp_login_name", txt_login_name.Text.Trim());
            cmd.Parameters.Clear();
            cmd.Parameters.Add(pSelect);
            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("该登录名已经存在，请重新输入");
                return;
            }

            //开始添加用户
            string str_insert =
                "insert into tb_EmpInfo(emp_name,emp_login_name,emp_login_passwd,emp_role,emp_phone) " +
                "values(@name,@login_name,@login_passwd,@role,@phone)";

            OleDbParameter[] parameter = new OleDbParameter[]
            {
                new OleDbParameter("@name",txt_name.Text.Trim()),
                new OleDbParameter("@login_name",txt_login_name.Text.Trim()),
                new OleDbParameter("@login_passwd",txt_login_passwd.Text.Trim()),
                new OleDbParameter("@role",txt_role.SelectedItem.ToString().Trim()),
                new OleDbParameter("@phone",txt_phone.Text.Trim())
            };

            cmd.CommandText = str_insert;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameter);
            if (cmd.ExecuteNonQuery() == 1)
            {
                //提示信息
                MessageBox.Show("添加" + txt_name.Text.Trim() + "成功！");
            }
            else
            {
                MessageBox.Show("添加" + txt_name.Text.Trim() + "失败！请联系程序制作者...");
            }

            //更新datagridview控件
            cmd.CommandText = conststr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //得到要删除的用户登录名
            string login_name = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();

            OleDbParameter paremeter = new OleDbParameter("@login_name", login_name);
            cmd.CommandText = "delete from tb_empInfo where emp_login_name=@login_name";
            cmd.Connection = conn;
            cmd.Parameters.Add(paremeter);
            if (cmd.ExecuteNonQuery() == 1)
            {
                //提示信息
                MessageBox.Show("删除" + login_name + "成功");
            }
            else
            {
                MessageBox.Show("添加" + txt_name.Text.Trim() + "失败！请联系程序制作者...");
            }

            //填充datagridview控件
            cmd.CommandText = conststr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (txt_login_name.Text.Trim().Length == 0 &&
                txt_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入姓名或用户登录名！或者只输入其中一个即可");
                return;
            }

            if (txt_login_name.Text.Trim().Length > 0)
            {
                string sql =
                    conststr + " where emp_login_name=@txt_login_name";

                OleDbParameter parameter =
                    new OleDbParameter("@txt_login_name", txt_login_name.Text.Trim());

                //显示在dgv控件上
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(parameter);
                ds.Clear();
                da.Fill(ds, "tb_EmpInfo");
                dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
            }
            else if (txt_name.Text.Trim().Length > 0)
            {
                string sql = conststr + " where emp_name=@txt_name";

                OleDbParameter parameter =
                    new OleDbParameter("@txt_name", txt_name.Text.Trim());

                //显示在dgv控件上
                cmd.Connection = conn;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(parameter);
                ds.Clear();
                da.Fill(ds, "tb_EmpInfo");
                dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frm_mima frm = new frm_mima();
            frm.ShowDialog();

            string str = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            string sqlStr =
                "update tb_EmpInfo set emp_login_passwd=@newPasswd where emp_login_name=@str";

            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("@newPasswd",newPasswd),
                new OleDbParameter("@str",str)
            };

            cmd.CommandText = sqlStr;
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string admin = "select count(*) from tb_EmpInfo where emp_role='管理员'";
            string normal = "select count(*) from tb_EmpInfo where emp_role='普通员工'";

            //填充管理员人数
            cmd.Connection = conn;
            cmd.CommandText = admin;
            txt_admin_num.Text = cmd.ExecuteScalar().ToString();

            //填充普通用户人数
            cmd.Connection = conn;
            cmd.CommandText = normal;
            txt_normal_num.Text = cmd.ExecuteScalar().ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void Frm_emp_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (da != null)
            {
                da.Dispose();
            }
            if (ds != null)
            {
                ds.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
    }
}
