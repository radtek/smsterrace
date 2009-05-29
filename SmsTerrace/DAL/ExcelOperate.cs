using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using hz.sms.DBUtility;

namespace SmsTerrace.DAL
{
    public class ExcelOperate
    {
        public NewDbHelperOleDb oleDbHelper;
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                       "Extended Properties=Excel 8.0;" + //HDR=No;IMEX=1\"; 指定扩展属性为 Microsoft Excel 8.0 (97) 9.0 (2000) 10.0 (2002)，并且第一行作为数据返回，且以文本方式读取
                                       "data source=";
        public ExcelOperate()
        {
            string connStrPath = connStr + "Excel.xls";
            oleDbHelper = new NewDbHelperOleDb(connStrPath);
        }
        public ExcelOperate(string path)
        {
            string connStrPath = connStr + path;
            oleDbHelper = new NewDbHelperOleDb(connStrPath);
        }
       public  DataTable GetDataTable(string tableName, string whereStr)
        {
            if (whereStr!=null&&whereStr.Trim().Length>0)
            {
                whereStr = " where " + whereStr;
            }
            else
            {
                whereStr = "";
            }
            return oleDbHelper.GetTable("select * from [" + tableName +"]"+ whereStr);
        }

        public void ToExcel(string path, string tableName, DataTable dt)
        {
            CreateExcelTable(path, tableName, dt);
            AddRows(path, tableName, dt);
        }
        public int AddRows(string path, string tableName, DataTable dt)
        {
            int okNum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string sql2 = "";
                StringBuilder sqlH = new StringBuilder();
                sqlH.Append("INSERT INTO ");
                sqlH.Append(tableName);
                sqlH.Append("(");
                foreach (DataColumn dc in dt.Columns)
                {
                    sqlH.Append(dc.ColumnName);
                    sqlH.Append(",");
                    sql2 += "'" + dr[dc.ColumnName] + "',";
                }
                string sql = sqlH.ToString().TrimEnd(',') + ")values(" + sql2.TrimEnd(',') + ")";
                okNum = oleDbHelper.ExecuteSql(sql);
            }

            return okNum;
        }

        public int CreateExcelTable(string path, string tableName, DataTable dt)
        {
            StringBuilder strB = new StringBuilder();
            strB.Append(" CREATE TABLE ");
            strB.Append(tableName);
            strB.Append("(");
            foreach (DataColumn dc in dt.Columns)
            {
                strB.Append(dc.ColumnName);
                strB.Append(" varchar,");
            }
            string sql = strB.ToString().TrimEnd(',') + ")";
            return oleDbHelper.ExecuteSql(sql);
        }

          
    }
}
