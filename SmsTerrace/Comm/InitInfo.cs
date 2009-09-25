using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;
using  System.IO;
namespace HzTerrace.Comm
{
    internal class InitInfo
    {

        static InitInfo()
        {
            InitSendTimeout();
        }

        #region Service
        /*
        public static readonly string USER_ID = getUSER_ID; //用户名

        public static string getUSER_ID
        {
            get
            {
                string userId = ConfigurationManager.AppSettings["userId"];
                if (userId == null || userId.Trim().Length < 1)
                {
                    throw new Exception("用户名为空！初始化用户名失败");
                }
                return userId;
            }
        }

        public static readonly string PWD = getPWD;    //密码

        public static string getPWD
        {
            get
            {
                string pwd = ConfigurationManager.AppSettings["pwd"];
                if (pwd == null || pwd.Trim().Length < 1)
                {
                    throw new Exception("密码为空！初始化用户密码失败");
                }
                return pwd;
            }
        }

        public static readonly string ADDRESS = getADDRESS;    //网关地址

        public static string getADDRESS
        {
            get
            {
                string address = ConfigurationManager.AppSettings["address"];
                if (address == null || address.Trim().Length < 1)
                {
                    throw new Exception("网关地址为空！初始化网关地址失败");
                }
                return address;
            }
        }

        public static readonly string CHANNEL_NUM = getCHANNEL_NUM;   //通道号

        public static string getCHANNEL_NUM
        {
            get
            {
                string channelNum = ConfigurationManager.OpenExeConfiguration("西安电信_模板.exe").AppSettings.Settings["channelNum"].Value;
                if (channelNum == null || channelNum.Trim().Length < 1)
                {
                    throw new Exception("通道号为空！初始化通道号失败");
                }
                return channelNum;
            }
        }

        public static readonly int MAX_COUNT = getMAX_COUNT; //每次读取数据最大条数

        public static int getMAX_COUNT
        {
            get
            {
                string maxCount = ConfigurationManager.AppSettings["maxCount"];
                if (maxCount == null || maxCount.Trim().Length < 1)
                {
                    maxCount = "100";
                    Log.Info("初始化maxCount配置", "maxCount为空，设置其为默认值100");
                }
                int i = 100;
                if (int.TryParse(maxCount, out  i))
                {
                    return i;
                }
                else
                {
                    throw new Exception("maxCount初始化失败!");
                }
            }
        }

        public static readonly int SCANNING_INTERVAL = getSCANNING_INTERVAL; //数据扫描间隔

        public static int getSCANNING_INTERVAL
        {
            get
            {
                string scanningInterval = ConfigurationManager.AppSettings["scanningInterval"];
                if (scanningInterval == null || scanningInterval.Trim().Length < 1)
                {
                    scanningInterval = "3000";
                    Log.Info("scanningInterval初始化", "scanningInterval为空，设置其为默认值3000");
                }
                int i = 3000;
                if (int.TryParse(scanningInterval, out  i))
                {
                    return i;
                }
                else
                {
                    throw new Exception("scanningInterval初始化失败!");
                }
            }
        }

        public static readonly string MONITOR_PHOTO = getMONITOR_PHOTO; //监视电话

        public static string getMONITOR_PHOTO
        {
            get
            {
                string monitorPhoto = ConfigurationManager.AppSettings["monitorPhoto"];
                if (monitorPhoto == null || monitorPhoto.Trim().Length < 1)
                {
                    return "";
                }
                return monitorPhoto;
            }
        }

        public static readonly int TIMER_EVENT_COUNT = getTIMER_EVENT_COUNT; //timer时间并发数
        public static int getTIMER_EVENT_COUNT
        {
            get
            {
                string timerEventCount = ConfigurationManager.AppSettings["timerEventCount"];
                if (timerEventCount == null || timerEventCount.Trim().Length < 1)
                {
                    timerEventCount = "1";
                    Log.Info("timerEventCount初始化", "timerEventCount为空，设置其为默认值3000");
                }
                int i = 1;
                if (int.TryParse(timerEventCount, out  i))
                {
                    return i;
                }
                else
                {
                    throw new Exception("timerEventCount初始化失败!");
                }
            }
        }

        */
        #endregion

        #region client


        static XmlDocument InitXmlInfo(string path)
        {
            XmlDocument xml = new XmlDocument();
            if (File.Exists(path))
            {
                xml.Load(path);
                return xml;
            }
            return null;
        }

        static XmlDocument xmlDoc;

        static public XmlDocument XmlDoc
        {
            get
            {
                if (xmlDoc == null)
                {
                    xmlDoc = InitXmlInfo("service.config");
                }
                return xmlDoc;
            }
        }
        static int mmsMaxSize;
        public static int MMS_MAX_SIZE
        {
            get
            {
                if (mmsMaxSize > 0 && mmsMaxSize < 102401)
                {
                    return mmsMaxSize;
                }
                if (XmlDoc == null)
                {
                    return 1024 * 50;
                }
                else
                {
                    //  XmlNodeList nodeList = XmlDoc.SelectNodes("");
                    //  string val =int.Parse(nodeList[0].Attributes["value"].Value);
                    string mmsSizeStr = ConfigurationManager.AppSettings["mmsMaxSize"];
                    if (mmsSizeStr == null)
                    {
                        return 1024 * 50;
                    }
                    int mmsSize = int.Parse(mmsSizeStr);
                    if (mmsSize > 100 || mmsSize < 1)
                    {
                        mmsSize = 50 * 1024;
                    }
                    else
                    {
                        mmsSize = mmsSize * 1024;
                    }
                    mmsMaxSize = mmsSize;
                    return mmsMaxSize;
                }
            }
        }
        static private int sendTimeout;

        static internal int SendTimeout
        {
            get { return sendTimeout; }
        }

        static int InitSendTimeout()
        {
            string sendto = ConfigurationManager.AppSettings["SendTimeout"];
            try
            {
                sendTimeout = (int.Parse(sendto)) * 1000;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取SendTimeout失败，采用默认值30：" + ex.ToString());
                sendTimeout = 30 * 1000;
            }
            return sendTimeout;
        }

        static public System.Drawing.Image LandBg()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["LandBg"];
                if (string.IsNullOrEmpty(path))
                {
                    return null;
                }
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        static public string GetLandTopTxt()
        {
            string str = ConfigurationManager.AppSettings["LandTopTxt"];
            return str;
        }
        static public string GetLandBottomTxt()
        {
            string str = ConfigurationManager.AppSettings["LandBottomTxt"];
            return str;
        }

        #endregion

    }
}
