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
    public partial class frm_jh_manage : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        OleDbConnection conn;
        OleDbCommand cmd;
        string selectStr =
            "select goods_id as 商品编号,emp_name as 操作员名称,goods_name as" +
            " 商品名称,goods_num as 商品数量,goods_buy_price as 进货单价,goods_sell_price as 销售单价," +
            "goods_time as 进货时间,goods_remark as 备注 from tb_JhGoodsInfo";
        public frm_jh_manage()
        {
            InitializeComponent();

            timer1.Enabled = true;
            timer1.Interval = 200;
        }
        public string getID()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int minminute = DateTime.Now.Millisecond;

            string strTime = null;
            strTime = year.ToString();
            strTime += month >= 10 ? month.ToString() : "0" + month.ToString();
            strTime += day >= 10 ? day.ToString() : "0" + day.ToString();
            strTime += hour >= 10 ? hour.ToString() : "0" + hour.ToString();
            strTime += second >= 10 ? second.ToString() : "0" + second.ToString();
            strTime += minute >= 10 ? minute.ToString() : "0" + minute.ToString();
            strTime += minminute >= 10 ? minminute.ToString() : "0" + minminute.ToString();

            return "jh-" + strTime;
        }
        public string getTime()
        {
            return DateTime.Now.ToString().Trim();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_in_price.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入进货单价");
                return;
            }
            if (txt_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入商品名称");
                return;
            }
            if (txt_num.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入商品数量");
                return;
            }
            if (txt_out_price.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入销售单价");
                return;
            }

            //进货记录
            string nowtime = getTime();
            string id = getID();

            string insertstr_jh =
                "insert into tb_JhGoodsInfo(goods_id,emp_name,goods_name," +
                "goods_num,goods_buy_price,goods_sell_price,goods_time,goods_remark) " +
                "values(@id,@login_name,@txt_name,@txt_num,@txt_in_price,@txt_out_price,@nowtime,@txt_remark)";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("@id",id),
                new OleDbParameter("@login_name",Frm_login.name),
                new OleDbParameter("@txt_name",txt_name.Text.Trim()),
                new OleDbParameter("@txt_num",txt_num.Text.Trim()),
                new OleDbParameter("@txt_in_price",txt_in_price.Text.Trim()),
                new OleDbParameter("@txt_out_price",txt_out_price.Text.Trim()),
                new OleDbParameter("@nowtime",nowtime),
                new OleDbParameter("@txt_remark",txt_remark.Text.Trim())
            };
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            cmd.CommandText = insertstr_jh;
            cmd.ExecuteNonQuery();

            //重新填充dgv
            cmd.CommandText = selectStr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];



            string insertstr_kc =
                "insert into tb_KcGoods(goods_id,rep_emp,rep_goods_name," +
                "rep_num,rep_goods_price,rep_sell_price,rep_time,rep_remark) " +
                "values(@id,@name,@txt_name,@txt_num,@txt_in_price,@txt_out_price,@nowtime,@remark)";
            string updatestr_kc =
                "update tb_KcGoods set rep_num=rep_num+" + txt_num.Text.Trim()
                + " where rep_goods_name='" + txt_name.Text.Trim() + "'";
            string select_kc =
                "select count(*) from tb_KcGoods where rep_goods_name='" + txt_name.Text.Trim() + "'";

            cmd.CommandText = select_kc;
            if ((int)cmd.ExecuteScalar() > 0)
            {   //如果库存已有，则新增update
                cmd.CommandText = updatestr_kc;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("增加" + txt_name.Text.Trim() +
                    "\n数量" + txt_num.Text);
                }
                else
                {
                    MessageBox.Show("添加出错！请联系程序制作者");
                }

            }
            else
            {//否则将新增记录
                OleDbParameter[] parameters_kc = new OleDbParameter[]
                {
                new OleDbParameter("@id",getID()),
                new OleDbParameter("@name",Frm_login.name),
                new OleDbParameter("@txt_name",txt_name.Text.Trim()),
                new OleDbParameter("@txt_num",txt_num.Text.Trim()),
                new OleDbParameter("@txt_in_price",txt_in_price.Text.Trim()),
                new OleDbParameter("@txt_out_price",txt_out_price.Text.Trim()),
                new OleDbParameter("@nowtime",nowtime),
                new OleDbParameter("@remark",txt_remark.Text.Trim())
                };
                cmd.CommandText = insertstr_kc;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters_kc);
                if ((int)cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("插入" + txt_name.Text.ToString().Trim() +
                   "数量" + Convert.ToInt32(txt_num.Text).ToString());
                }
                else
                {
                    MessageBox.Show("添加出错！请联系程序制作者");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_remark.Clear();
            txt_out_price.Clear();
            txt_num.Clear();
            txt_name.Clear();
            txt_in_price.Clear();

            cmd.CommandText = selectStr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];
        }

        private void frm_jh_manage_Load(object sender, EventArgs e)
        {
            //dgv样式
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackColor = Color.LightBlue;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.GridColor = Color.LightBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            try
            {
                conn = new OleDbConnection(Frm_login.connectStr);
                cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                ds = new DataSet();
                da = new OleDbDataAdapter();
            }
            catch (Exception ee)
            {
                MessageBox.Show("错误提醒" + ee.ToString());
            }

            //dgv显示
            cmd.CommandText = selectStr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
               == DialogResult.OK)
            {

            }
            else
            {
                return;
            }

            string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            cmd.CommandText = "delete from tb_JhGoodsInfo where goods_id=@id";
            OleDbParameter parameter = new OleDbParameter("@id", str);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(parameter);
            if ((int)cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("编号:" + str + "\n商品名称：" + name + "\n已删除");
            }
            else
            {
                MessageBox.Show("程序出错！请联系程序制作者");
            }

            cmd.CommandText = selectStr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];
        }


        private void timer1_Tick(object sender, EventArgs e)
        {//定时器
            //根据输入的名称，来自动填充价格框
            string timer_select_str =
                "select count(*) from tb_KcGoods where rep_goods_name=@txt_name";
            string in_price =
                "select rep_goods_price from tb_KcGoods where rep_goods_name=@txt_name";
            string out_price =
                "select rep_sell_price from tb_KcGoods where rep_goods_name=@txt_name";


            OleDbParameter parameter = new OleDbParameter("@txt_name", txt_name.Text.Trim());
            cmd.Parameters.Clear();
            cmd.Parameters.Add(parameter);
            if (txt_name.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                cmd.CommandText = timer_select_str;

                //如果数据库中存在此商品
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    //填充
                    cmd.CommandText = in_price;
                    txt_in_price.Text = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = out_price;
                    txt_out_price.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    return;
                }
            }
        }

        private void frm_jh_manage_FormClosing(object sender, FormClosingEventArgs e)
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
