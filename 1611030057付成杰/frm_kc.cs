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
    public partial class frm_kc : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        publicClass.getSqlConnection get;
        OleDbConnection conn;
        OleDbCommand cmd;
        //DataTable dt;
        string conststr = "select goods_id as 商品编号,rep_emp as 进货人,rep_goods_name as 商品名称," +
            "rep_num as 库存数量,rep_goods_price as 进货单价,rep_sell_price as 销售价格,rep_time as" +
            " 进货时间,rep_remark as 备注 from tb_KcGoods";

        public frm_kc()
        {
            InitializeComponent();
        }

        private void frm_kc_Load(object sender, EventArgs e)
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
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_KcGoods");
            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = conststr + " where rep_goods_name='" + textBox1.Text.Trim() + "'";

            get = new publicClass.getSqlConnection();
            conn = get.GetCon();
            cmd = new OleDbCommand(str, conn);
            ds = new DataSet();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_KcGoods");
            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }

        private void frm_kc_FormClosing(object sender, FormClosingEventArgs e)
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
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "tb_KcGoods");
            dataGridView1.DataSource = ds.Tables["tb_KcGoods"];

            conn.Dispose();
            cmd.Dispose();
            da.Dispose();
            ds.Dispose();
        }
    }
}
