using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using hz.sms.Comm;
using hz.sms.Model;
using SmsTerrace.DAL;
using SmsTerrace.Model;

namespace SmsTerrace.BLL
{
    class SmsOperate
    {
        private 接收记录Manage moDAL = new 接收记录Manage();
        private 短信记录Manage smsDAL = new 短信记录Manage();
        public int ToExcel(string path, string tableName,DataTable dt)
        {
            ExcelOperate eo = new ExcelOperate(path);
            eo.ToExcel(path, tableName, dt);
            return 1;
        }
        

        public DataTable FromExcel(string path,string tableName)
        {

            try
            {
                if (path == null || path.Trim().Length < 1)
                {
                    return null;
                }
                ExcelOperate eo = new ExcelOperate(path);
                ArrayList listName = eo.oleDbHelper.GetSheetNameList();
                if (tableName == null || tableName.Trim().Length < 1)
                {
                    tableName = listName[0].ToString();
                }
                return eo.GetDataTable(tableName, "");
            }
            catch (Exception ex)
            {
                Log.Error("导入文件时",ex.ToString());
                return null;
            }
        }

        public DataTable GetMoInfo(string whereStr)
        {
            return moDAL.GetList(whereStr).Tables[0];
        }
        public void AddMoInfo(接收记录 moDeal)
        {
            moDAL.Add(moDeal);
        }
        /// <summary>短信记录获得
        /// 
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
     public  DataTable GetSmsInfo(string whereStr)
        {
            return smsDAL.GetList(whereStr).Tables[0];
        }
        public 短信记录 GetModel(int id)
        {
            return smsDAL.GetModel(id);
        }

        public void AddSmsInfo(短信记录 model)
        {
            smsDAL.Add(model);
        }

        public void Updata(短信记录 model)
        {
            smsDAL.Update(model);
        }
    }
}
