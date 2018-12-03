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
        publicClass.getSqlConnection get;
        OleDbConnection conn;
        OleDbCommand cmd;
        //DataTable dt;
        string conststr = "select sale_id as 商品编号,goods_name as 商品名称,emp_name as 员工名称," +
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

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(conststr, conn);
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
            string str = conststr+" where goods_name='"+textBox1.Text.Trim()+"'";
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(str, conn);
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

        private void frm_sell_jilu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(conststr, conn);
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
    }
}
