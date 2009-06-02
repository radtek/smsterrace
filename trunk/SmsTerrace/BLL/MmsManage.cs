using System;
using System.Collections.Generic;
using System.Text;

namespace hz.BLL.mms
{
    internal class MmsManage
    {
        /// <summary>生成mms的xml描述文件
        /// 
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="size">大小</param>
        /// <param name="content">内容</param>
        /// <param name="to">发送号码用"，"分隔</param>
        /// <returns></returns>
        internal string MmsDescToXml(string subject, string size, string[] content, string to)
        {
            StringBuilder f = new StringBuilder();
            string tempStr = "<mms>\r\n<hdr>\r\nSubject: {0}\r\nMessage-type: m-retrieve-conf\r\nFrom: @hz/TYPE=PLMN\r\n"
                + "Date: {1}\r\nMessage-size: {2}\r\nContent-type: application/vnd.wap.multipart.related; type=application/smil; start=presentation-part\r\n"
                + "X-NowMMS-Content-Location: mms.smil\r\n{3}</hdr>\r\n<To>\r\n{4}\r\n</To>\r\n<!-- hdr end  -->\r\n<smil></smil>\r\n</mms>";
            StringBuilder allContent = new StringBuilder();
            foreach (string item in content)
            {
                allContent.AppendFormat("X-NowMMS-Content-Location:{0}\r\n", item);
            }
            string phoneList = to.Replace(",", "\r\n");
            f.AppendFormat(tempStr, subject, DateTime.Now.ToString(), size, allContent.ToString(), phoneList);
            return f.ToString();
        }
        internal  Dictionary<string, byte[]> MmsXmlToDic(string subject,string to,Dictionary<string,byte[]> dic)
        {
            List<string> list=new List<string>();
            int size = 0;
            foreach (KeyValuePair<string, byte[]> item in dic)
            {
                list.Add(item.Key);
                size += item.Value.Length;
            }
           string xml= MmsDescToXml(subject, size.ToString(), list.ToArray(), to);
           byte[] xmlbyte= Encoding.Default.GetBytes(xml);
           dic.Add("mms.xml",xmlbyte);
           return dic;
        }
    }
}
