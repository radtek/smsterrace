using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using hz.sms.Comm;

namespace hz.sms.Comm1
{
    
    internal class Log
    {

        public static string FilePath = getFilePath; //存放日志的目录
        public static string FileName = "";

        public static string getFilePath
        {
            get
            {
                string logPath = ConfigurationManager.AppSettings["logPath"];
                if (logPath == null || logPath.Trim().Length < 1)
                {
                    logPath = @"log\";
                    ConsoleWriteLine("日志路径为空，使用默认路径:log\\");
                }
                return logPath;
            }
        }

        public static string LogLevel = ConfigurationManager.AppSettings["LogLevel"]; //输出级别
        public static bool EnabledConsole = true; //是否向控制台输出
        public static bool EnabledQueue = false; //是否向消息队列输出
        public static int ErrorCount;
        public delegate void LogWriteStart(string local, string txt);
        public static event LogWriteStart DebugWriteStart ;
        public static event LogWriteStart InfoWriteStart ;
        public static event LogWriteStart WarningWriteStart ;
        public static event LogWriteStart ErrorWriteStart ;
        public static event LogWriteStart ConsoleWriteStart ;
        public static event LogWriteStart WriteToFileStart;

        public  static void ConsoleWriteLine(string str)
       {
           if (ConsoleWriteStart!=null)
            {
                ConsoleWriteStart("",str);
            }
            try
            {
                Console.WriteLine(str);
            }
            catch (Exception)
            {
            }
          
        }

        static int getLogLevel()
        {
            if (LogLevel == null || LogLevel.Trim().Length < 1)
            {
                return 1;
            }
            int lev = 1;
            switch (LogLevel.Trim().ToLower())
            {
                case "debug": lev = 1;
                    break;
                case "info": lev = 2;
                    break;
                case "warning": lev = 3;
                    break;
                case "error": lev = 4;
                    break;
                default: lev = 1;
                    break;
            }
            return lev;
        }

        private static void WriteTextToFile(string txt)
        {
            try
            {
                //string logPath = ConfigurationManager.AppSettings["logPath"];
                //if (logPath == null || logPath.Trim().Length < 1)
                //{
                //    logPath = @"log\";
                //    Console.WriteLine("日志路径为空，使用默认路径:log\\");
                //}
                //FilePath = logPath;
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string pathStr = FilePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                FileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (EnabledConsole)
                {
                    try
                    {
                        Console.WriteLine(txt);
                    }
                    catch (Exception)
                    {
                    }
                }
                if (EnabledQueue)
                {
                    QueueManage.SendQueue(QueueManage.SendQueuePath,txt);
                }
                if (WriteToFileStart != null)
                {
                    WriteToFileStart("",txt);
                }

                File.AppendAllText(pathStr, txt);
            }
            catch (Exception e)
            {
                try
                {
                    Console.WriteLine("日志写入异常！" + e.ToString());
                }
                catch (Exception)
                {
                }
                
                //throw;
            }

        }


        public static void WriteLog(string txt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(txt);
            sb.Append("\r\n");
            WriteTextToFile(sb.ToString());
        }
        public static void WriteLog(string txt, string prefixed)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(prefixed);
            sb.Append(txt);
           sb.Append("\r\n");
            WriteTextToFile(sb.ToString());
        }
        /// <summary>debug级别日志记录
        /// 
        /// </summary>
        /// <param name="txt">内容</param>
        public static void Debug(string txt)
        {
            Debug("信息", @txt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="local">事件地点</param>
        /// <param name="txt"></param>
        public static void Debug(string local, string txt)
        {
            if (DebugWriteStart != null)
            {
                DebugWriteStart(local, txt);
            }
            if (getLogLevel() > 1)
            {
                return;
            }
            string ps = ("[" + DateTime.Now + "]\tDebug\t" + local + ":");
            WriteLog(txt, ps);

        }
        /// <summary>Info级别日志记录
        /// 
        /// </summary>
        /// <param name="txt">内容</param>
        public static void Info(string txt)
        {
            Info("信息", @txt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="local">事件地点</param>
        /// <param name="txt"></param>
        public static void Info(string local, string txt)
        {
            if (InfoWriteStart != null)
            {
                InfoWriteStart(local, txt);
            }
            if (getLogLevel() > 2)
            {
                return;
            }
            string ps = ("[" + DateTime.Now + "]\tInfo\t" + local + ":");
            WriteLog(txt, ps);
        }

        /// <summary>警告级别日志
        /// 
        /// </summary>
        /// <param name="txt"></param>
        public static void Warning(string txt)
        {
            Warning("信息", @txt);
        }
        /// <summary>警告级别日志
        /// 
        /// </summary>
        /// <param name="local">事件地点</param>
        /// <param name="txt"></param>
        public static void Warning(string local, string txt)
        {
            if (WarningWriteStart != null)
            {
                WarningWriteStart(local, txt);
            }
            if (getLogLevel() > 3)
            {
                return;
            }
            string ps = ("[" + DateTime.Now + "]\tWarning\t" + local + ":");
            WriteLog(txt, ps);
        }
        /// <summary>错误级别日志
        /// 
        /// </summary>
        /// <param name="txt"></param>
        public static void Error(string txt)
        {
            Error("信息", @txt);
        }
        /// <summary>错误级别日志
        /// 
        /// </summary>
        /// <param name="local">事件地点</param>
        /// <param name="txt"></param>
        public static void Error(string local, string txt)
        {
            if (ErrorWriteStart != null)
            {
                ErrorWriteStart(local, txt);
            }
            if (getLogLevel() > 4)
            {
                return;
            }
            ErrorCount++;
            string ps = ("[" + DateTime.Now + "]\tError\t" + local + ":");
            WriteLog(txt, ps);
        }

    /*
      public void dd()
        {
            File.AppendAllText(@Path, "", System.Text.Encoding.Default);
            string strOldText = File.ReadAllText(@Path, System.Text.Encoding.Default);
            File.WriteAllText(@Path, "'" + DateTime.Now.ToString() + "'\t'zhangsan'\t'Login.aspx'\t'登录B'\r\n", System.Text.Encoding.Default);
            File.AppendAllText(@Path, strOldText, System.Text.Encoding.Default);
        }
     */
    }
}
