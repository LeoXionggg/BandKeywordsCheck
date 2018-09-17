using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Windows.Forms;
using MyRegexNamespace;
namespace spider_demo
{
    class HtmlAnalyzer��������������������������������������������//��������
    {
        public ArrayList NewUrl=new ArrayList();                 //��������url��ַ������
        WebRegexClass myRegex = new WebRegexClass();            //����õ�hrefȡ��������ʽ
        private UriKind uriKind = UriKind.Absolute;            //����URI
        public HtmlAnalyzer(string htmlPage,string url)     //ֱ���ڹ��캯��������������δ��ɺ�����
        {
            //Uri trueUrl = new Uri();
            MatchCollection  m=myRegex.Matches(htmlPage);
            if (m.Count > 1)
            {
                for (int a = 0; a <= m.Count - 1; a++)
                {
                    string tmp = m[a].Value.ToString();
                    if (tmp != null)
                    {
                        if ((HtmlType(url) == true)&& (tmp.IndexOf("http://")==-1))              //�Ƿ�Ϊ����·��������������������url��ַ������Խ���ƴ��                                                                                                 
                        {   string urlTmp=null;
                            urlTmp = url.Substring(0, url.LastIndexOf("/"));
                            tmp = urlTmp + tmp;
                        }
                        if ((HtmlType(tmp) == true) && (tmp.IndexOf("http://")==-1))
                        {
                            tmp = url + "/" + tmp;
                        }
                        if ((tmp.IndexOf("http://")==0)&&(Uri.IsWellFormedUriString(tmp,uriKind)==true))
                        {
                            NewUrl.Add(tmp);
                        }
                    }

                }
            }
        }
        private Boolean HtmlType(string url)                                                  //�ж�ҳ���Ƿ�Ϸ�������Ϸ���Ϊtrue
        {
            Boolean tmp = false;
                if (url.IndexOf(".php") >0)
                {
                    tmp=true;
                }
                if (url.IndexOf(".asp") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".aspx") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".jsp") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".cgi") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".php") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".htm") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".html") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".xml") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf(".perl") > 0)
                {
                    tmp = true;
                }
                if (url.IndexOf("?") > 0)
                {
                    tmp = true;
                }
                return tmp;
        }
    }
}
