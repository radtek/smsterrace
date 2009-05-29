using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace hz.sms.Comm
{
  public static class WinAPI
    {   
        /// <summary>为当前程序打开控制台
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern bool AllocConsole();

        /// <summary>释放控制台
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern bool FreeConsole();

        /// <summary>显示窗口
        /// 
        /// </summary>
        /// <param name="a">窗口句柄</param>
        /// <param name="b">窗口显示状态，0:隐藏,4:恢复</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int ShowWindow(int a, int b);

        /// <summary>设置控制台句柄
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern int SetConsoleCtrlHandler(int a, bool b);

        /// <summary>获取窗口句柄
      /// 
      /// </summary>
      /// <param name="a">窗口句柄</param>
        /// <param name="b">与句柄窗口关系,2:同级窗口</param>
      /// <returns>非0为成功</returns>
        [DllImport("user32")]
        public static extern int GetWindow(int a, int b);

      /// <summary>查找窗口句柄
      /// 
      /// </summary>
      /// <param name="a">类</param>
      /// <param name="b">窗口标题</param>
      /// <returns>句柄</returns>
       [DllImport("user32")]
      public static extern int FindWindow(string a, string b);

      /// <summary>获取控制台标题，缺少信息
      /// 
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns></returns>
      [DllImport("user32")]
      public static extern int GetConsoleTitle(string a, string b);  


    }
}
