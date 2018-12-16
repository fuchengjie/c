using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace _1611030057付成杰.publicClass
{
    class getSqlConnection
    {
        public static string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data " +
            "Source=./db_cs_manage.accdb";
        //连接字符串
        public static OleDbConnection conn =new OleDbConnection(constr);
        public static DataSet ds=new DataSet();
        public static OleDbDataAdapter da=new OleDbDataAdapter();
        public static OleDbCommand cmd=new OleDbCommand();
        public static DataTable dt=new DataTable();
        public OleDbConnection GetCon()
        {
            try
            {
                conn = new OleDbConnection(constr);
                conn.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());

            }
            return conn;
        }
        public void dispose()
        {
            conn.Dispose();
        }
    }
}
