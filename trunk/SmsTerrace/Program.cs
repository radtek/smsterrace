using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmsTerrace.UI;
using System.Runtime.InteropServices;

namespace SmsTerrace
{
    static class Program
    {
        public static string[] paramList ;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] paramList)
        {

            Program.paramList = paramList;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SmsFrm());
           // Application.Run(new Form1());
        }

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        static void hide()
        {
            int sign = Application.CommonAppDataRegistry.GetHashCode();
            Console.Title = "我被隐藏" + sign; //为控制台窗体指定一个标题，便于定位和区分
            IntPtr a = FindWindow("ConsoleWindowClass", "我被隐藏" + sign);
            if (a != IntPtr.Zero)
                ShowWindow(a, 0); 
           
        }
            
    }
}