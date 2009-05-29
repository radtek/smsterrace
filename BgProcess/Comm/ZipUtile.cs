using System;
using System.Collections.Generic;
using System.Text;
using java.util.zip;
using java.io;
using com.ms.vjsharp.@struct;
using System.IO;
namespace hz.sms.Comm
{
    /// <summary>此类为调用j#的zip包实现的zip压缩
    /// 
    /// </summary>
    public class ZipUtile
    {
        /// <summary>将指定字节写入zip流，并指定名称
        /// 
        /// </summary>
        /// <param name="zipOut"></param>
        /// <param name="filePath"></param>
        /// <param name="sbyteFile"></param>
        public static void writeStream(ZipOutputStream zipOut, string filePath, sbyte[] sbyteFile)
        {
            ZipEntry z = new ZipEntry(filePath);
            z.setMethod(ZipEntry.DEFLATED);
            zipOut.putNextEntry(z);
            zipOut.write(sbyteFile);
        }
        /// <summary>拷贝流
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void CopyStream(java.io.InputStream from, java.io.OutputStream to)
        {
            sbyte[] buffer = new sbyte[8192];
            int got;
            while ((got = from.read(buffer, 0, buffer.Length)) > 0)
                to.write(buffer, 0, got);
        }
        /// <summary>将流写入zip流，并指定流文件名文件
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="filePath"></param>
        public static void writeStream(ZipOutputStream to, java.io.InputStream from, string filePath)
        {
            ZipEntry z = new ZipEntry(filePath);
            z.setMethod(ZipEntry.DEFLATED);
            to.putNextEntry(z);
            CopyStream(from, to);
        }
        /// <summary>将一个文件压缩到指定zip流
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="filePath"></param>
        public static void writeStream(ZipOutputStream to, string filePath)
        {
            ZipEntry z = new ZipEntry(filePath.Remove(0, System.IO.Path.GetPathRoot(filePath).Length));
            z.setMethod(ZipEntry.DEFLATED);
            to.putNextEntry(z);
            FileInputStream inputStream = new FileInputStream(filePath);
            try
            {
                CopyStream(inputStream, to);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                inputStream.close();
            }
        }
        public static void ZipToFile(string zipName, params string[] fileName)
        {
            ZipOutputStream zipOut = new ZipOutputStream(new java.io.FileOutputStream(zipName));
            try
            {
                foreach (string item in fileName)
                {
                    writeStream(zipOut, item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                zipOut.close();
            }
        }
        /// <summary>压缩文件，并返回压缩后文件字节
        /// 
        /// </summary>
        /// <param name="fileByteArray"></param>
        /// <returns></returns>
        public static byte[] ZipToByte(Dictionary<string, byte[]> fileByteArray)
        {
            string tempFilePath = System.IO.Path.GetTempFileName();
            ZipOutputStream zipOut = new ZipOutputStream(new java.io.FileOutputStream(tempFilePath));
            try
            {
                foreach (KeyValuePair<string, byte[]> item in fileByteArray)
                {
                    writeStream(zipOut, item.Key, ToSByte(item.Value));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                zipOut.close();
            }
            FileStream f = new FileStream(tempFilePath, FileMode.Open);
            byte[] zipFileByte = new byte[f.Length];
            f.Read(zipFileByte, 0, zipFileByte.Length);
            f.Close();
            f.Dispose();
            System.IO.File.Delete(tempFilePath);

            return zipFileByte;
        }
        public static void ZipToFile(string zipName, Dictionary<string, byte[]> fileByteArray)
        {
            ZipOutputStream zipOut = new ZipOutputStream(new java.io.FileOutputStream(zipName));
            try
            {
                foreach (KeyValuePair<string, byte[]> item in fileByteArray)
                {
                    writeStream(zipOut, item.Key, ToSByte(item.Value));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                zipOut.close();
            }
        }
        public static sbyte[] ToSByte(byte[] values)
        {
            sbyte[] newSbytes = new sbyte[values.Length];
            Buffer.BlockCopy(values, 0, newSbytes, 0, newSbytes.Length);
            return newSbytes;
        }
        public static byte[] ToByte(sbyte[] values)
        {
            byte[] newbytes = new byte[values.Length];
            Buffer.BlockCopy(values, 0, newbytes, 0, newbytes.Length);
            return newbytes;
        }
    
    #region 字符串压缩
		 

        public static sbyte[] CompressStrToSbyte(string s)
        {
            Deflater f = new Deflater(Deflater.BEST_COMPRESSION);

            sbyte[] data = JavaStructMarshalHelper.convertToByteArray(s);
            f.setInput(data);
            f.finish();

            ByteArrayOutputStream o = new ByteArrayOutputStream(data.Length);
            try
            {
                sbyte[] buf = new sbyte[1024];
                while (!f.finished())
                {
                    int got = f.deflate(buf);
                    o.write(buf, 0, got);
                }
            }
            finally
            {
                o.close();
            }
            return o.toByteArray();
        }
        /// <summary>压缩字符串，有中文乱码问题！
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CompressString(string s)
        {
            sbyte[] strSbyte = CompressStrToSbyte(s);
            return System.Convert.ToBase64String(ToByte(strSbyte));
        }
        /// <summary>解压字符串，有中文乱码问题！
        /// 
        /// </summary>
        /// <param name="byteString"></param>
        /// <returns></returns>
        public static string DecompressString(string byteString)
        {
            byte[] bytInput = System.Convert.FromBase64String(byteString);
            string s = DecompressSbyteTOStr(ToSByte(bytInput));
            // byte[]  bs=System.Text.Encoding.GetEncoding("GB2312").GetBytes(s);//System.Text.Encoding.Convert(System.Text.Encoding.ASCII,System.Text.Encoding.UTF8,bs);
            // string rs=System.Text.Encoding.UTF8.GetString(bs);
            return ChangeEncoding(s);
        }
        public static string ChangeEncoding(string str)
        {
            Console.WriteLine(Encoding.Default.BodyName);
            byte[] temp = Encoding.Default.GetBytes(str);
            temp = Encoding.Convert(Encoding.Default, Encoding.GetEncoding("gb2312"), temp);
            return Encoding.Unicode.GetString(temp);
        }
        public static string ChangeEncoding(Encoding from, Encoding to, string str)
        {
            byte[] temp = Encoding.Default.GetBytes(str);
            temp = Encoding.Convert(from, to, temp);
            return to.GetString(temp);
        }
        public static string DecompressSbyteTOStr(sbyte[] s)
        {
            Inflater f = new Inflater();
            f.setInput(s);

            ByteArrayOutputStream o = new ByteArrayOutputStream(s.Length);
            try
            {
                sbyte[] buf = new sbyte[1024];
                while (!f.finished())
                {
                    int got = f.inflate(buf);
                    o.write(buf, 0, got);
                }
            }
            finally
            {
                o.close();
            }
            // return  System.Text.Encoding.UTF8.GetString(ToByte(o.toByteArray()));
            return JavaStructMarshalHelper.convertToString(o.toByteArray());
        }
    #endregion

    }
}
