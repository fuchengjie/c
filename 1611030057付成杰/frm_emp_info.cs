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
using _1611030057付成杰.publicClass;


namespace _1611030057付成杰
{
    public partial class frm_emp_info : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        publicClass.getSqlConnection get;
        OleDbConnection conn ;
        OleDbCommand cmd;
        DataTable dt;
        string conststr = "select emp_name as 姓名,emp_login_name as 登录名," +
                "emp_login_passwd as 登录密码,emp_role as 用户角色,emp_phone as 联系电话" +
                " from tb_EmpInfo";
        public frm_emp_info()
        {
            InitializeComponent();
        }
        private void Qingkong()
        {//清空文本框的内容
            txt_login_name.Clear() ;
            txt_login_passwd.Clear() ;
            txt_name.Clear() ;
            txt_phone.Clear();           
        }
        private void Btn_qingkong_Click(object sender, EventArgs e)
        {
            Qingkong();

            string str = conststr;
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand()
            {
                CommandText = str,
                Connection = conn
            };
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };

            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Equals(""))
            {
                MessageBox.Show("用户名字未输入");
                return;
            }
            if (txt_login_name.Text.Equals(""))
            {
                MessageBox.Show("用户登录名未输入");
                return;
            }
            
            if (txt_phone.Text.Equals(""))
            {
                MessageBox.Show("用户电话未输入");
                return;
            }
            
            if (txt_login_passwd.Text.Equals(""))
            {
                MessageBox.Show("用户密码未输入");
                return;
            }

                        
            string str_insert = "insert into tb_EmpInfo(emp_name,emp_login_name,emp_login_passwd,emp_role,emp_phone) " +
                "values('" +
                txt_name.Text.Trim()+"','"+
                txt_login_name.Text.Trim()+"','"+
                txt_login_passwd.Text.Trim()+ "','" +
                txt_role.SelectedItem.ToString().Trim()+"','" +
                txt_phone.Text.Trim()+"'"+
                ")";

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand
            {
                Connection = conn,
                CommandText = str_insert
            };
            cmd.ExecuteNonQuery();

            //更新cmd的SQL语句
            cmd.CommandText = conststr;

            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };

            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];
            
            cmd.Dispose();            
            da.Dispose();
            ds.Dispose();
            MessageBox.Show("添加成功!");
            //dataGridView1.Update();
        }

        private void Frm_emp_info_Load(object sender, EventArgs e)
        {
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

            //获取数据
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand
            {
                CommandText = conststr,
                Connection = conn
            };
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd                
            };
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];

            //释放资源
            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }
        public static string newPasswd;
        private void Button3_Click(object sender, EventArgs e)
        {
            string str = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand
            {
                CommandText = "delete from tb_empInfo where emp_login_name='" + str + "'",
                Connection = conn
            };
            cmd.ExecuteNonQuery();


            cmd.CommandText = conststr;
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };
            da.Fill(ds, "tb_EmpInfo");
            dataGridView1.DataSource = ds.Tables["tb_EmpInfo"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
            dataGridView1.Update();

            MessageBox.Show("删除" + str + "成功");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (txt_login_name.Text.Equals("") && txt_name.Text.Equals(""))
            {
                MessageBox.Show("请输入姓名或用户登录名！");
                return;
            }

            if (txt_login_name.Text.Equals("")==false)
            {
                string sql = conststr+" where emp_login_name='"
                            + txt_login_name.Text.Trim()
                            + "'";

                get = new publicClass.getSqlConnection();
                conn = get.GetCon();

                cmd = new OleDbCommand
                {
                    CommandText = sql,
                    Connection = conn
                };
                da = new OleDbDataAdapter
                {
                    SelectCommand = cmd
                };
                //da.SelectCommand.ExecuteNonQuery();
                ds = new DataSet();
                da.Fill(ds, "tb_EmpInfo");
                dt = ds.Tables["tb_EmpInfo"];

                
                dataGridView1.DataSource = dt;

                cmd.Dispose();
                ds.Dispose();
                dt.Dispose();
                conn.Dispose();
            }
            else
            {
                string sql = conststr+ " where emp_name='"
                            + txt_name.Text.Trim()
                            + "'";

                get = new publicClass.getSqlConnection();
                conn = get.GetCon();

                cmd = new OleDbCommand(sql, conn);
                da = new OleDbDataAdapter(sql, conn);
                //da.SelectCommand.ExecuteNonQuery();
                ds = new DataSet();
                da.Fill(ds, "tb_EmpInfo");
                dt = ds.Tables["tb_EmpInfo"];

                dataGridView1.DataSource = dt;
            }
        }

        private void Frm_emp_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (da != null)
            {
                da.Dispose();

            }
            if (dt != null)
            {
                dt.Dispose();

            }
            if (conn != null)
            {
                conn.Dispose();

            }
            if (ds!=null)
            {
                ds.Dispose();

            }
            if (cmd != null)
            {
                cmd.Dispose();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frm_mima frm = new frm_mima();
            frm.ShowDialog();

            string str = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            string sqlstr = "update tb_EmpInfo set emp_login_passwd='" + newPasswd + "' where emp_login_name" +
                "='" + str + "'";
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand
            {
                CommandText = sqlstr,
                Connection = conn
            };
            cmd.ExecuteNonQuery();

            conn.Dispose();
            cmd.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            string admin = "select count(*) from tb_EmpInfo where emp_role='管理员'";
            string normal = "select count(*) from tb_EmpInfo where emp_role='普通员工'";

            cmd = new OleDbCommand(admin, conn);
            txt_admin_num.Text = cmd.ExecuteScalar().ToString();
            cmd.CommandText = normal;
            txt_normal_num.Text = cmd.ExecuteScalar().ToString();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
