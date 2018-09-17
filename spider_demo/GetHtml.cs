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
    class GetHtml��������������������������������������������������������������������������������//ҳ��ץȡ��
    {
        private const string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";   //����ҳ�������ߵ�ͷ����Ϣ
        private string PageCode = null;                                   //ҳ�����
        public string SavePage(string htmPage,string url)                                        //����ҳ���ļ�
        {
            string filename = null;
            Crc32 CRC32 = new Crc32();
            CRC32.Reset();
            byte[] BYTE = Encoding.Default.GetBytes(url);
            CRC32.Crc(BYTE);
            filename = CRC32.Value.ToString();
            //filename = md5TOstr(url);
            FileInfo f1 = new FileInfo("moreUrl.txt");                                          //����ҳ����ļ�����URL���ļ�
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
        private string GetCharType(string tmp1)                                                  //��ȡҳ�����
        {
            string tmp = "";
            tmp = tmp1;
            int a = tmp.IndexOf("charset=") + 8;
            tmp = tmp.Substring(a, tmp.Length - a);
            return tmp;
        }
        public string GetPage(string url)                                                       //��ȡҳ������
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
                if ((response.ContentType!=null)&&(response.ContentType.IndexOf("charset") != -1))    //����ҳ����룬ҳ�������������ã�����ϵͳĬ�ϱ���
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
                pagehtml = "ҳ���޷����ʻ���������쳣����";
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
