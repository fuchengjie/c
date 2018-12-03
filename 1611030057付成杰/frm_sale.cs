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
        publicClass.getSqlConnection get;
        OleDbConnection conn;
        OleDbCommand cmd;
        //DataTable dt;
        //string conststr = "select sale_id as 商品编号,goods_name as 商品名称,emp_name as 员工名称," +
        //    "sale_goods_num as 销售数量,sale_goods_time as 销售时间,sale_price as 销售单价,sale_remark" +
        //    " as 备注 from tb_SellGoods";

        string select_str = "select goods_id as 商品编号,rep_emp as 进货人,rep_goods_name as 商品名称," +
            "rep_num as 库存数量,rep_goods_price as 进货单价,rep_sell_price as 销售价格,rep_time as" +
            " 进货时间,rep_remark as 备注 from tb_KcGoods";

        //string select_str = "select sale_id as 销售编号,goods_name as 商品名称,emp_name as 员工名称," +
        //"sale_goods_num as 销售数量,sale_goods_num as 销售时间,sale_remark as 备注" +
        //" from tb_SellGoods";

        public Frm_sale()
        {
            InitializeComponent();
        }

        private void frm_sale_Load(object sender, EventArgs e)
        {
            //窗体的属性
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.BackColor = Color.LightBlue;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.GridColor = Color.LightBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(select_str, conn);
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };

            da.Fill(ds, "tb_SellGoods");
            dataGridView1.DataSource = ds.Tables["tb_SellGoods"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
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

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(str, conn);
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };

            da.Fill(ds, "tb_KcGoods");
            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();

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
            if(txt_name.Text.Equals("")||txt_num.Text.Equals(""))
            {
                MessageBox.Show("商品数量或名称未输入");
                return;
            }
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();

            string str_select = "select count(*) from tb_KcGoods where rep_goods_name='" +
                txt_name.Text.Trim() + "'";
            cmd = new OleDbCommand(str_select, conn);
            if(Convert.ToInt32(cmd.ExecuteScalar())<=0)
            {
                MessageBox.Show("仓库中没有此商品！！！");
                cmd.Dispose();
                return;
            }
            
            string update_str = "update tb_KcGoods set rep_num=rep_num-"
                + Convert.ToInt32(txt_num.Text.Trim()) + " where rep_goods_name='" +
                txt_name.Text.Trim() + "'";

            
            cmd = new OleDbCommand(update_str, conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = select_str;
            ds = new DataSet();
            da = new OleDbDataAdapter
            {
                SelectCommand = cmd
            };
            da.Fill(ds, "tb_KcGoods");

            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];
            string id = GetID();
            string time = GetTime();
            string str = "insert into tb_SellGoods(sale_id,goods_name,emp_name,sale_goods_num," +
                "sale_goods_time,sale_remark) values('" + id + "','" + txt_name.Text.Trim() +
                "','" + Frm_login.name + "'," + txt_num.Text.Trim() + ",'" + time + "','" + txt_mark.Text.Trim() +
                "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();

            MessageBox.Show("销售商品：" + txt_name.Text + "\n数量：" + txt_num.Text + "\n成功！");
            //关闭资源
            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }

        private void Frm_sale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (da != null)
            {
                da.Dispose();
            }
            if (conn != null)
            {
                conn.Dispose();
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
