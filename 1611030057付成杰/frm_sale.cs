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
    public partial class Frm_sale : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        OleDbConnection conn;
        OleDbCommand cmd;

        string select_str =
            "select goods_id as 商品编号,rep_emp as 进货人,rep_goods_name as 商品名称," +
            "rep_num as 库存数量,rep_goods_price as 进货单价,rep_sell_price as 销售价格,rep_time as" +
            " 进货时间,rep_remark as 备注 from tb_KcGoods";



        public Frm_sale()
        {
            InitializeComponent();
        }

        private void frm_sale_Load(object sender, EventArgs e)
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

            //窗体的属性
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.BackColor = Color.LightBlue;

            //dgv属性
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.GridColor = Color.LightBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            cmd.CommandText = select_str;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_SellGoods");
            dataGridView1.DataSource = ds.Tables["tb_SellGoods"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_mark.Clear();
            txt_name.Clear();
            txt_num.Clear();

        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string str = select_str + " where rep_goods_name='" + txt_name.Text.Trim() + "'";

            cmd.CommandText = str;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_KcGoods");
            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];
        }
        public string GetID()
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

            return "xs-" + strTime;
        }
        public string GetTime()
        {
            return DateTime.Now.ToString().Trim();
        }

        private void Btn_xiaoshou_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim().Length == 0 ||
                txt_num.Text.Trim().Length == 0)
            {
                MessageBox.Show("商品数量或名称未输入");
                return;
            }


            string str_select =
                "select count(*) from tb_KcGoods where rep_goods_name='" +
                txt_name.Text.Trim() + "'";
            cmd = new OleDbCommand(str_select, conn);
            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("仓库中没有此商品！！！");
                return;
            }

            //string update_str = 
            //    "update tb_KcGoods set rep_num=rep_num-"
            //    + txt_num.Text.Trim() + " where rep_goods_name='" +
            //    txt_name.Text.Trim() + "'";
            string update_str =
                "update tb_KcGoods set rep_num=rep_num-@txt_num where rep_goods_name=@txt_name";
            OleDbParameter[] parameters_update = new OleDbParameter[]
            {
                new OleDbParameter("@txt_num",txt_num.Text.Trim()),
                new OleDbParameter("@txt_name",txt_name.Text.Trim())
            };
            cmd.CommandText = update_str;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters_update);
            cmd.ExecuteNonQuery();

            cmd.CommandText = select_str;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_KcGoods");

            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];

            //插入销售记录
            string id = GetID();
            string time = GetTime();
            string str =
                "insert into tb_SellGoods(sale_id,goods_name,emp_name,sale_goods_num," +
                "sale_goods_time,sale_remark) values(@id,@txt_name,@login_name,@txt_num,@time,@txt_mark)";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("@id",id),
                new OleDbParameter("@txt_name",txt_name.Text.Trim()),
                new OleDbParameter("@login_name",Frm_login.name),
                new OleDbParameter("@xt_num",txt_num.Text.Trim()),
                new OleDbParameter("@time",time),
                new OleDbParameter("@txt_mark",txt_mark.Text.Trim())
            };
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();

            MessageBox.Show("销售商品：" + txt_name.Text + "\n数量：" + txt_num.Text + "\n成功！");

        }

        private void Frm_sale_FormClosing(object sender, FormClosingEventArgs e)
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
