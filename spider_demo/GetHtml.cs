using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
//using System.Security.Cryptography;
using CRC;
namespace spider_demo
{
    class GetHtml　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//页面抓取类
    {
        private const string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";   //设置页面请求者的头部消息
        private string PageCode = null;                                   //页面编码
        public string SavePage(string htmPage,string url)                                        //保存页面文件
        {
            string filename = null;
            Crc32 CRC32 = new Crc32();
            CRC32.Reset();
            byte[] BYTE = Encoding.Default.GetBytes(url);
            CRC32.Crc(BYTE);
            filename = CRC32.Value.ToString();
            //filename = md5TOstr(url);
            FileInfo f1 = new FileInfo("moreUrl.txt");                                          //保存页面的文件名及URL到文件
            lock(f1.GetType())
            {            
            StreamWriter w1 = f1.AppendText();
            w1.WriteLine(url+ "(" + filename  +")" );
            w1.Close();
            //FileInfo f = new FileInfo("html\\"+ filename + ".html");
            StreamWriter w = null;
            if (PageCode != null)
            {
                 w = new StreamWriter("html\\" + filename + ".html", false,Encoding.GetEncoding(PageCode));
            }
            else
            {
                 w = new StreamWriter("html\\" + filename + ".html", false, Encoding.Default);
            }
            w.Write(htmPage);
            w.Close();
            }
            return filename;
        }
        private string GetCharType(string tmp1)                                                  //获取页面编码
        {
            string tmp = "";
            tmp = tmp1;
            int a = tmp.IndexOf("charset=") + 8;
            tmp = tmp.Substring(a, tmp.Length - a);
            return tmp;
        }
        public string GetPage(string url)                                                       //获取页面内容
        {
            string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            string pagehtml;
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            try
            {
                response = request.GetResponse();
                stream = response.GetResponseStream();            
                if ((response.ContentType!=null)&&(response.ContentType.IndexOf("charset") != -1))    //处理页面编码，页面有设置则按设置，否则按系统默认编码
                {
                    //MessageBox.Show(response.ContentType.ToString());
                    PageCode=GetCharType(response.ContentType.ToString());
                    reader = new StreamReader(stream, System.Text.Encoding.GetEncoding(PageCode));
               }
               else
                {
                    reader = new StreamReader(stream, System.Text.Encoding.Default);
                }
                //MessageBox.Show(PageCode + "\r\n" + System.Text.Encoding.Default.ToString());
                pagehtml = reader.ReadToEnd();
                }
            catch
            {
                pagehtml = "页面无法访问或出现其他异常错误";
            }

                return pagehtml;
                //response.Close;
                //stream.Close;
                //reader.Close;
        }
        //public string md5TOstr(string bStr)
        //{
        //    MD5CryptoServiceProvider provider1 = new MD5CryptoServiceProvider();
        //    return BitConverter.ToString(provider1.ComputeHash(Encoding.Default.GetBytes(bStr))).Replace("-", "").ToUpper();
        //}
    }
}
