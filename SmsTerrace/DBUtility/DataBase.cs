using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace hz.sms.DBUtility
{
    /// <summary>
    /// DataBase 的摘要说明。
    /// </summary>  
    /// <summary>
    /// 数据库连接类型
    /// </summary>
    public class DataBase
    {
        private string url = "";
        public string Url
        {
            get { return url; }

        }
        OleDbConnection oledbconn;
        DataSet ds;
        OleDbDataAdapter adapter;
        private static DataBase instanse = null;
        // 连接数据源
        public DataBase()
        {
            url = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Application.StartupPath+"\\book.mdb;Persist Security Info=True";
        }

        public static DataBase DbCon()
        {
            if (instanse == null)
            {
                instanse = new DataBase();
            }
            return instanse;
        }
        /// <summary>
        /// 根据SQL查询返回DataSet对象，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet returnDS(string sql)
        {

            ds = new DataSet();
            try
            {
                oledbconn = new OleDbConnection(url);
                oledbconn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, oledbconn);
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(ds, "tempTable");
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                oledbconn.Close();
            }
            return ds;
        }
        /// <summary>
        /// 对数据库的增，删，改的操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>是否成功</returns>
        public bool OperateDB(string sql)
        {
            bool succeed = false;
            int cnt = 0;
            try
            {
                oledbconn = new OleDbConnection(url);
                oledbconn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, oledbconn);
                cnt = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            
                throw (e);
            }
            finally
            {
                if (cnt >= 0)
                {
                    succeed = true;
                }
                oledbconn.Close();
            }

            return succeed;
        }

        /// <summary>
        /// 获得该SQL查询返回的第一行第一列的值，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>返回的第一行第一列的值</returns>
        public string getValue(string sql)
        {
            string str = null;
            try
            {
                oledbconn = new OleDbConnection(url);
                oledbconn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, oledbconn);
                object obj=cmd.ExecuteScalar();
                 if (obj == null)
                {
                    str = null;
                }
                else
                {
                    str = obj.ToString();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                oledbconn.Close();
            }
            return str;
        }

        /// <summary>
        ///  获得该SQL查询返回DataTable，如果没有查询到则返回NULL
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public DataTable getTable(string sql)
        {
            DataTable tb = null;
            DataSet ds = this.returnDS(sql);
            if (ds != null)
            {
                tb = ds.Tables["tempTable"];
            }

            return tb;
        }
    }
}