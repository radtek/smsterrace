using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace hz.Processor.Comm
{
    class FileManage
    {
        public void CreateFile(string filePathName, byte[] con)
        {

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(filePathName)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePathName));
            }
            using (FileStream fs = File.Create(filePathName))
            {
                fs.Write(con, 0, con.Length);
                fs.Flush();
                fs.Close();
            }
        }

       
    }
}
