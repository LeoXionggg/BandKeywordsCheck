using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BandKeywordsCheck
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }


        private Queue<clsKeyword> workQueue = new Queue<clsKeyword>();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            //LoadKeywords();

            string[] arr = tbxKW.Lines;
            List<string> ls = new List<string>();
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                string s = arr[i].Trim();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    lbCurrentNo.Text = (i + 1).ToString();
                    lbCurrent.Text = s;
                    if (CheckKeyword(s))
                    {
                        tbxResult.AppendText(s + Environment.NewLine);
                        ls.Add(s);
                    } 
                }
                Application.DoEvents();
            }

            lbCurrent.Text = "【完成】";

            //ls.ForEach(s => tbxResult.AppendText(s + Environment.NewLine));

        }

        private void LoadKeywords()
        {
            string[] arr = tbxKW.Lines;
             
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                string s = arr[i].Trim();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    workQueue.Enqueue(new clsKeyword(s));
                }
            }
        }

        public clsKeyword GetNewWork()　 //取的任务队列里头一个kw，并从队列里删除
        {
            clsKeyword tmp = null;
            lock (workQueue)
            {
                if (workQueue.Count != 0)
                {
                    tmp = (clsKeyword)workQueue.Dequeue();
                }
            }
            return tmp;
        }

        private bool CheckKeyword(string kw)
        {
            bool rv = false;
            string txtweb = getwebcode2(kw);
            //tbxResult.Text = txtweb;
            if (txtweb.IndexOf("Do you like it?") >0) 
            {
                rv = true;
            }

            return rv;
        }


        private string GetWebContent(string kw)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null; 
             //try { 
                request = (HttpWebRequest)HttpWebRequest.Create("http://www.artigifts.com/search?model=0&expand=1&keyword=" + kw);
                request.Method = "get";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.AllowAutoRedirect = true;
                request.Referer = "http://www.artigifts.com/search?model=0&expand=1&keyword=bracelet";
                //request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                request.KeepAlive = true;//建立持久性连接
                                         //整数据
                //string postData = "";
                //ASCIIEncoding encoding = new ASCIIEncoding();
                //byte[] bytepostData = encoding.GetBytes(postData);
                //request.ContentLength = bytepostData.Length;

                ////发送数据  using结束代码段释放
                //using (Stream requestStm = request.GetRequestStream())
                //{
                //    requestStm.Write(bytepostData, 0, bytepostData.Length);
                //}

                //响应
                response = (HttpWebResponse)request.GetResponse();
                //container = request.CookieContainer;
                //var c = request.CookieContainer.GetCookies(request.RequestUri);
                //response.Cookies = container.GetCookies(request.RequestUri);

                string text = string.Empty;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    text = redStm.ReadToEnd();
                }

                return text;
            //}
            //catch (Exception ex)
            //{
            //    return "";
            //}

        }

        public static string getwebcode2(string kw)
        {
            string url = "http://www.artigifts.com/search?model=0&expand=1&keyword=" + kw;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //request.Method = "GET ";
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string SourceCode = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return SourceCode;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbxKW_TextChanged(object sender, EventArgs e)
        {
            lbCountKW.Text = "Count:" + tbxKW.Lines.Length;
        }

        private void tbxResult_TextChanged(object sender, EventArgs e)
        {
            lbCountResult.Text = "Count:" + tbxResult.Lines.Length;
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            lbCountKW.Text = "Count:" + tbxKW.Lines.Length;
            lbCountResult.Text = "Count:" + tbxResult.Lines.Length;
        }
    }
}
