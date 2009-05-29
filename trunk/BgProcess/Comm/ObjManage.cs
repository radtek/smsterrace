using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace hz.sms.Comm
{
   public class ObjManage
    {
      public static  string ObjToString(object obj) {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            // StringReader reader = new StringReader(sb.ToString());
            // StringWriter writer = new StringWriter();

            MemoryStream stream = new MemoryStream();
            XmlWriterSettings setting = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(stream, setting);
            setting.Encoding = new System.Text.UTF8Encoding(false);
            serializer.Serialize(writer, obj);
            writer.Flush();
            string str = Encoding.UTF8.GetString(stream.ToArray());
            return str;
        }
    }
}
