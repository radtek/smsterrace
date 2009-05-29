using System;
using System.Collections.Generic;
using System.Text;
using log4net;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
//[assembly: log4net.Config.DOMConfigurator(ConfigFile = @"D:\My Documents\Visual Studio 2005\Projects\0760华录\0760华录\bin\Debug\0760华录.exe.config", Watch = true)]
namespace hz.sms.DAL
{

    public class BaseService
    {
        public static readonly ILog log = LogManager.GetLogger("AllLog");
    }
}
