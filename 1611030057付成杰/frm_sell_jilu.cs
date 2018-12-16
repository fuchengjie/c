using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1611030057付成杰
{
    public partial class frm_sell_jilu : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        OleDbConnection conn;
        OleDbCommand cmd;
        string conststr =
            "select sale_id as 商品编号,goods_name as 商品名称,emp_name as 员工名称," +
            "sale_goods_num as 销售数量,sale_goods_time as 销售时间,sale_remark" +
            " as 备注 from tb_SellGoods";

        public frm_sell_jilu()
        {
            InitializeComponent();
        }

        private void frm_sell_jilu_Load(object sender, EventArgs e)
        {
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

            //建立连接，创建对象
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
                MessageBox.Show("程序出错了" + ee.ToString());
            }

            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_SellGoods");
            dataGridView1.DataSource = ds.Tables["tb_SellGoods"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = conststr + " where goods_name='" + textBox1.Text.Trim() + "'";
            cmd.CommandText = str;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_SellGoods");
            dataGridView1.DataSource = ds.Tables["tb_SellGoods"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = conststr;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds, "tb_SellGoods");
            dataGridView1.DataSource = ds.Tables["tb_SellGoods"];

        }
        private void frm_sell_jilu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (da != null)
            {
                da.Dispose();
            }
            if (conn.State == ConnectionState.Open)
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
