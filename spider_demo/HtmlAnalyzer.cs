using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Windows.Forms;
using MyRegexNamespace;
namespace spider_demo
{
    class HtmlAnalyzer　　　　　　　　　　　　　　　　　　　　　　//分析器类
    {
        public ArrayList NewUrl=new ArrayList();                 //分析出的url地址的数组
        WebRegexClass myRegex = new WebRegexClass();            //编译好的href取出正则表达式
        private UriKind uriKind = UriKind.Absolute;            //绝对URI
        public HtmlAnalyzer(string htmlPage,string url)     //直接在构造函数中启动分析（未完成函数）
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
                        if ((HtmlType(url) == true)&& (tmp.IndexOf("http://")==-1))              //是否为绝对路径，如果不是则分析出父url地址，与相对进行拼接                                                                                                 
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
        private Boolean HtmlType(string url)                                                  //判断页面是否合法，如果合法则为true
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
