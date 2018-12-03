using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace _1611030057付成杰.publicClass
{
    class getSqlConnection
    {
        string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./db_cs_manage.accdb";
        //连接字符串

        OleDbConnection con;

        public OleDbConnection GetCon()
        {
            try
            {
                con = new OleDbConnection(constr);
                con.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());

            }
            return con;
        }
        public void dispose()
        {
            con.Dispose();
        }
    }
}
