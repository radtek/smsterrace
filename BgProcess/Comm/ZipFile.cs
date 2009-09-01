using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace hz.Comm.zip
{
  public  class ZipFile
    {
        /// <summary>压缩文件夹
        /// 
        /// </summary> 
        /// <param name="file">文件路径</param>
        /// <param name="outputZip">输出路径及名字</param>
      public  void zip(string file, string outputZip)
        {
            if (file[file.Length - 1] != Path.DirectorySeparatorChar)
                file += Path.DirectorySeparatorChar;
            using (  ZipOutputStream s = new ZipOutputStream(File.Create(outputZip)))
            {
            s.SetLevel(6); // 0 - store only to 9 - means best compression
            zip(file, s, file);
            s.Finish();
            s.Close();
            }
        }
        public void zip(string file, string outputZip,string password)
        {
            if (file[file.Length - 1] != Path.DirectorySeparatorChar)
                file += Path.DirectorySeparatorChar;
            using (ZipOutputStream s = new ZipOutputStream(File.Create(outputZip)))
            {
                if (password!=null&&password.Length>0)
                {
                   s.Password = password; 
                }
                
                s.SetLevel(6); // 0 - store only to 9 - means best compression
                zip(file, s, file);
                s.Finish();
                s.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFile">要压缩文件路径</param>
        /// <param name="s">压缩输出流</param>
        /// <param name="staticFile">压缩文件根</param>
        private void zip(string strFile, ZipOutputStream s, string staticFile)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
                strFile += Path.DirectorySeparatorChar;
            Crc32 crc = new Crc32();
            string[] filenames = Directory.GetFileSystemEntries(strFile);
            foreach (string file in filenames)// 遍历所有的文件和目录
            {

                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    zip(file, s, staticFile);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    baseZip(s, staticFile, crc, file, buffer);
                }
            }
        }

        private void baseZip(ZipOutputStream s, string staticFile, Crc32 crc, string file, byte[] buffer)
        {
            string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
            baseZip(s, crc, tempfile,buffer);
        }

        /// <summary>将文件字节数组直接压缩到指定路径
        /// 
        /// </summary>
        /// <param name="zipOutputPath">压缩后路径</param>
        /// <param name="fileByteArray">文件名与文件字节数组</param>
        public void zip(string zipOutputPath, Dictionary<string, byte[]> fileByteArray)
        {
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipOutputPath)))
            {
                foreach (KeyValuePair<string, byte[]> pair in fileByteArray)
                {
                    Crc32 crc = new Crc32();
                    baseZip(s, crc, pair.Key, pair.Value);
                }
                s.Flush();
                s.Close();
            }
        }

      /// <summary>解压
      /// 
      /// </summary>
      /// <param name="sourceFile"></param>
      /// <param name="destinationFile"></param>
      /// <returns></returns>
        public bool UnZip(string sourceFile, string destinationFile)
        {
            bool ret = true;
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(destinationFile);
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != String.Empty)
                        {
                            //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                            if (theEntry.CompressedSize == 0)
                                break;
                            //解压文件到指定的目录
                            directoryName = Path.GetDirectoryName(destinationFile + theEntry.Name);
                            //建立下面的目录和子目录
                            Directory.CreateDirectory(directoryName);

                            using (FileStream streamWriter = File.Create(destinationFile + theEntry.Name))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0) {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else { break; }
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                    s.Close();
                }
            }
            catch (Exception )
            {
                ret = false;
                throw ;
            } 
            return ret;
        }
        /// <summary>解压
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        /// <returns></returns>
        public Dictionary<string ,byte[]> UnZip(string sourceFile)
        {
            bool ret = true;
            Dictionary<string, byte[]> dic = new Dictionary<string, byte[]>();
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                      //  string directoryName = Path.GetDirectoryName(destinationFile);
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != String.Empty)
                        {
                            //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                            if (theEntry.CompressedSize == 0)
                                break;
                            int size = 0;
                            byte[] data = new byte[2048];
                            List<byte> list = new List<byte>();
                            int nll = 0;
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    list.AddRange(data);                                 
                                    nll = data.Length - size;
                                    if (nll > 0)
                                    {
                                        list.RemoveRange(list.Count - nll - 1, nll);
                                    }
                                }
                                else { break; }
                            }
                                dic.Add(theEntry.Name,list.ToArray());
                        }
                    }
                    s.Close();
                }
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }
            return dic;
        }

        /// <summary>加密压缩
        /// 
        /// </summary>
        /// <param name="zipOutputPath"></param>
        /// <param name="fileByteArray"></param>
        /// <param name="password"></param>
        public void zip(string zipOutputPath, Dictionary<string, byte[]> fileByteArray,string password)
        {
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipOutputPath)))
            {
                if (password!=null&&password.Length>0)
                {
                    s.Password = password;
                }         
                foreach (KeyValuePair<string, byte[]> pair in fileByteArray)
                {
                    Crc32 crc = new Crc32();
                    baseZip(s, crc, pair.Key, pair.Value);
                }
                s.Flush();
                s.Close();
            }
        }

        private static void baseZip(ZipOutputStream s, Crc32 crc, string file, byte[] buffer)
        {
            string tempfile = file;

            ZipEntry entry = new ZipEntry(tempfile);
            entry.DateTime = DateTime.Now;
            entry.Size = buffer.LongLength;

            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            s.PutNextEntry(entry);
            s.Write(buffer, 0, buffer.Length);
        }

        /// <summary>将指定字节写入zip流，并指定名称
        /// 
        /// </summary>
        /// <param name="zipOut"></param>
        /// <param name="filePath"></param>
        /// <param name="sbyteFile"></param>
        public static void writeStream(ZipOutputStream zipOut, string filePath, byte[] byteFile)
        {
            ZipEntry z = new ZipEntry(filePath);
            //z.set.setMethod(ZipEntry.DEFLATED);
            zipOut.PutNextEntry(z);
            zipOut.Write(byteFile,0,byteFile.Length);
        }
        /// <summary>压缩文件，并返回压缩后文件字节
        /// 
        /// </summary>
        /// <param name="fileByteArray"></param>
        /// <returns></returns>
        public static byte[] ZipToByte(Dictionary<string, byte[]> fileByteArray)
        {
            string tempFilePath = System.IO.Path.GetTempFileName();
            ZipOutputStream zipOut = new ZipOutputStream(File.OpenWrite(tempFilePath));
            try
            {
                foreach (KeyValuePair<string, byte[]> item in fileByteArray)
                {
                    writeStream(zipOut, item.Key, item.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                zipOut.Close();
            }
            FileStream f = new FileStream(tempFilePath, FileMode.Open);
            byte[] zipFileByte = new byte[f.Length];
            f.Read(zipFileByte, 0, zipFileByte.Length);
            f.Close();
            f.Dispose();
            System.IO.File.Delete(tempFilePath);

            return zipFileByte;
        }

        /// <summary>压缩字符串
        /// 
        /// </summary>
        /// <param name="uncompressedString"></param>
        /// <returns>压缩后的字符串</returns>
   
        public static string Compress(string uncompressedString)
        {
            byte[] bytData = System.Text.Encoding.Unicode.GetBytes(uncompressedString);
            MemoryStream ms = new MemoryStream();
            ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream s = new ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream(ms);
          
            s.Write(bytData, 0, bytData.Length);
            s.Close();
            byte[] compressedData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String(compressedData, 0, compressedData.Length);
        }
        /// <summary>解压字符串 
     /// 
     /// </summary>
     /// <param name="compressedString"></param>
     /// <returns>解压后的字符串</returns>
  
        public static string DeCompress(string compressedString)
        {
            System.Text.StringBuilder uncompressedString = new System.Text.StringBuilder();
            int totalLength = 0;
            byte[] bytInput = System.Convert.FromBase64String(compressedString); ;
            byte[] writeData = new byte[4096];
            Stream s2 = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(new MemoryStream(bytInput));
            while (true)
            {
                int size = s2.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    totalLength += size;
                    uncompressedString.Append(System.Text.Encoding.Unicode.GetString(writeData, 0, size));
                }
                else
                {
                    break;
                }
            }
            s2.Close();
            return uncompressedString.ToString();
        }   

    }
}
