using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace _1611030057付成杰.publicClass
{
    class tb_ThGoodsMethod
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataReader qlddr;
        public int tb_ThGoodsAdd(tb_ThGoodsInfo tbChGood)
        {//添加退货信息
            
            int flag=0;
            try
            {
                string str_add = "insert into tb_ThGoodsInfo values(";
                str_add += "'"+tbChGood.ThGoodsID1+"','"+tbChGood.KcID1+"','"+tbChGood.GoodsId1+"',";
                str_add += "'" + tbChGood.ThGoodsNum1 + ",'" + tbChGood.EmpID + "','" + tbChGood.ThGoodsName1 + "',";
                str_add += "'" + tbChGood.ThHasPay1 + "," + tbChGood.ThNeedprice1 + ",'" + tbChGood.ThGoodsResult1 + "')";
                getSqlConnection getSql = new getSqlConnection();
                conn = getSql.GetCon();
                cmd = new OleDbCommand(str_add, conn);
                flag = cmd.ExecuteNonQuery();
                conn.Dispose();
                return flag;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return -1;
            }
            
        }

        public int tb_ThGoodsUpdate(tb_ThGoodsInfo tbChGood)
        {//修改退货信息
            int flag = 0;
            try
            {
                string str_add = "update tb_ThGoodsInfo set ";
                str_add += "the_goods_id='" + tbChGood.ThGoodsID1 + "',rep_id='" + tbChGood.KcID1 + "',";
                str_add += ",goods_id='" + tbChGood.GoodsId1 + "sale_id='"
                    + tbChGood.SellID1
                    + "',emp_id='" + tbChGood.EmpID + "'the_goods_name='"
                    + tbChGood.ThGoodsName1
                    + "',the_goods_num=" + tbChGood.ThGoodsNum1;
                str_add += "the_goods_time='" + tbChGood.ThGoodsTime1 + "'the_goods_price="
                    + tbChGood.ThGoodsPrice1
                    + "the_need_pay=" + tbChGood.ThNeedprice1 + "the_has_pay=" + tbChGood.ThHasPay1
                    + "the_goods_results='" + tbChGood.ThGoodsResult1 + "' where the_goods_id='"
                    + tbChGood.ThGoodsID1 + "'";

                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new OleDbCommand(str_add, conn);
                flag = cmd.ExecuteNonQuery();
                conn.Dispose();
                return flag;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }


        public string tb_ThGoodsID()
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

            return "TH-" + strTime;
                
        }
        public void tb_ThGoodsFind(object data)
        {
            int count = 0;
            string str = null;
            try
            {
                str = "select * from tb_ThGoodsInfo ";
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new OleDbCommand(str, conn);
                int ii = 0;
                qlddr = cmd.ExecuteReader();
                while (qlddr.Read())
                {
                    ii++;
                }
                qlddr.Close();
                System.Windows.Forms.DataGridView dv = (DataGridView)data;

                if (ii != 0)
                {
                    int i = 0;
                    dv.RowCount = ii;
                    qlddr = cmd.ExecuteReader();
                    while (qlddr.Read())
                    {
                        dv[0, i].Value = qlddr[0].ToString();
                        dv[1, i].Value = qlddr[5].ToString();
                        dv[2, i].Value = qlddr[8].ToString();
                        dv[3, i].Value = qlddr[6].ToString();
                        i++;
                    }
                    qlddr.Close();
                }
                else
                {
                    if (dv.RowCount != 0)
                    {
                        int i = 0;
                        do
                        {
                            dv[0, i].Value = "";
                            dv[1, i].Value = "";
                            dv[2, i].Value = "";
                            dv[3, i].Value = "";
                            i++;
                        } while (i < dv.RowCount);
                    }
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void filltProd(object objTreeView,object obimage)
        {
            try
            {
                getSqlConnection get = new getSqlConnection();
                conn = get.GetCon();
                string str = "select * from tb_SellGoods";
                cmd = new OleDbCommand(str, conn);
                qlddr = cmd.ExecuteReader();

                if (objTreeView.GetType().ToString() == "System.Windows.Forms.TreeView")
                {
                    System.Windows.Forms.ImageList imlist = (System.Windows.Forms.ImageList)obimage;
                    System.Windows.Forms.TreeView tv = (System.Windows.Forms.TreeView)objTreeView;
                    tv.Nodes.Clear();
                    tv.ImageList = imlist;

                    System.Windows.Forms.TreeNode tn = tv.Nodes.Add("A", "商品销售信息", 0, 1);
                    while(qlddr.Read())
                    {
                        TreeNode newNode = new TreeNode(qlddr[0].ToString(), 0, 1);
                        newNode.Nodes.Add("A", qlddr[4].ToString(), 0, 1);
                        tn.Nodes.Add(newNode);                
                    }
                    qlddr.Close();
                    tv.ExpandAll();


                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


    }
}
