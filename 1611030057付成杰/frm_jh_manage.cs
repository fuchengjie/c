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
        publicClass.getSqlConnection get;
        OleDbConnection conn;
        OleDbCommand cmd;
        //DataTable dt;
        string selectStr = "select goods_id as 商品编号,emp_name as 操作员名称,goods_name as" +
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

            return "jh-"+strTime;
        }
        public string getTime()
        {
            return DateTime.Now.ToString().Trim();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_in_price.Text.Equals(""))
            {
                MessageBox.Show("请输入进货单价");
                return;
            }
            if (txt_name.Text.Equals(""))
            {
                MessageBox.Show("请输入商品名称");
                return;
            }
            if (txt_num.Text.Equals(""))
            {
                MessageBox.Show("请输入商品数量");
                return;
            }
            if (txt_out_price.Text.Equals(""))
            {
                MessageBox.Show("请输入销售单价");
                    return;
            }

            string nowtime = getTime();
            string id = getID();
            //数据库连接,进货数据库
            string insertstr_jh = "insert into tb_JhGoodsInfo(goods_id,emp_name,goods_name," +
                "goods_num,goods_buy_price,goods_sell_price,goods_time,goods_remark) " +
                "values('" + id + "','" + Frm_login.name + "','" + txt_name.Text.ToString().Trim() + "',"
                + txt_num.Text + "," + Convert.ToInt32(txt_in_price.Text) + "," + Convert.ToInt32(txt_out_price.Text) + ",'" 
                + nowtime
                + "','"
                + txt_remark.Text.ToString().Trim() + "')";

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(insertstr_jh, conn);
            da = new OleDbDataAdapter();
            da.InsertCommand = cmd;
            da.InsertCommand.ExecuteNonQuery();

            da.SelectCommand = new OleDbCommand(selectStr, conn);
            ds = new DataSet();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];
            ds.Dispose();

            cmd.CommandText = selectStr;
            da.SelectCommand = cmd;
            da.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];
            
            //数据库操作，库存数据库
            string insertstr_kc= "insert into tb_KcGoods(goods_id,rep_emp,rep_goods_name," +
                "rep_num,rep_goods_price,rep_sell_price,rep_time,rep_remark) " +
                "values('" + getID() + "','" + Frm_login.name + "','" + txt_name.Text.ToString().Trim() + "',"
                + txt_num.Text + "," + Convert.ToInt32(txt_in_price.Text) + "," + Convert.ToInt32(txt_out_price.Text) + ",'"
                + nowtime
                + "','"
                + txt_remark.Text.ToString().Trim() + "')";
            string updatestr_kc = "update tb_KcGoods set rep_num=rep_num+" + Convert.ToInt32(txt_num.Text)
                + " where rep_goods_name='" + txt_name.Text.ToString().Trim() + "'";
            string select_kc = "select count(*) from tb_KcGoods where rep_goods_name='" + txt_name.Text.ToString().Trim()+"'";

            conn = get.GetCon();
            cmd = new OleDbCommand(select_kc,conn);
            if(Convert.ToInt32(cmd.ExecuteScalar())>0)
            {//如果库存已有，则新增update
                cmd = new OleDbCommand(updatestr_kc, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("增加" + txt_name.Text.ToString().Trim()+
                    "数量" + Convert.ToInt32(txt_num.Text).ToString());


            }
            else
            {
                cmd = new OleDbCommand(insertstr_kc, conn);
                int s=cmd.ExecuteNonQuery();
                MessageBox.Show("插入" + txt_name.Text.ToString().Trim() +
                    "数量" + Convert.ToInt32(txt_num.Text).ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_remark.Clear();
            txt_out_price.Clear();
            txt_num.Clear();
            txt_name.Clear();
            txt_in_price.Clear();

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(selectStr, conn);
            ds = new DataSet();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }

        private void frm_jh_manage_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackColor = Color.LightBlue;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.GridColor = Color.LightBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(selectStr, conn);
            ds = new DataSet();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();

            
            //时间控件动态显示

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
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand("delete from tb_JhGoodsInfo where goods_id='" + str + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(selectStr, get.GetCon());
            ds = new DataSet();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_JhGoodsInfo");
            dataGridView1.DataSource = ds.Tables["tb_JhGoodsInfo"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
            dataGridView1.Update();

            MessageBox.Show("编号:"+ str + "\n商品名称："+name+"\n已删除");
        }

        private void frm_jh_manage_FormClosing(object sender, FormClosingEventArgs e)
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

        
        private static OleDbConnection timer_conn = new publicClass.getSqlConnection().GetCon();
        private static OleDbCommand timer_cmd = new OleDbCommand();
        private void timer1_Tick(object sender, EventArgs e)
        {
            string timer_select_str = "select count(*) from tb_KcGoods where rep_goods_name='" 
                + txt_name.Text.ToString().Trim()
                + "'";
            string in_price = "select rep_goods_price from tb_KcGoods where rep_goods_name='" 
                + txt_name.Text.ToString().Trim() + "'";
            string out_price = "select rep_sell_price from tb_KcGoods where rep_goods_name='"
               + txt_name.Text.ToString().Trim() + "'";

            if (txt_name.Text.ToString().Equals("")==true)
            {
                return;
            }
            else
            {
                timer_cmd.CommandText = timer_select_str;
                timer_cmd.Connection = timer_conn;

                if(Convert.ToInt32(timer_cmd.ExecuteScalar()) >0)
                {
                    timer_cmd.CommandText = in_price;
                    txt_in_price.Text=timer_cmd.ExecuteScalar().ToString();

                    timer_cmd.CommandText = out_price;
                    txt_out_price.Text = timer_cmd.ExecuteScalar().ToString();
                }
                else
                {
                    
                    return;
                }
            }
        }
    }
}
