using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace spider_demo
{
    class WorkThread //工作线程类
    {
        private Url_info url_Info = new Url_info(); //记录目前工作的url信息
        private IListener iListener = null;
        private Boolean IsWork = false;                //目前是否没任务false没任务，true有任务
        public WorkThread(IListener iListener)
        {
            this.iListener = iListener;
        }
        public void startWork(object state)                             //工作线程主函数（未完成函数）
        {
            while (IsWork != true)
            {
                            System.Windows.Forms.Application.DoEvents();            //doEvents
                            if (IsWork == false)                                   //没任务，则向任务队列请求
                            {
                                //IsWork = true; 
                                url_Info = getQueue();
                                    if (url_Info != null)
                                    {
                                                                                               //正在执行任务
                                        DateTime tTmp = DateTime.Now;
                                        url_Info.lastTime = tTmp.ToString();                                  //爬行时间
                                            if (AddUrl(url_Info) == true)
                                            {
                                                GetHtml htm = new GetHtml();
                                                string tmpHtml=htm.GetPage(url_Info.meUrl);                         //GetHtml
                                                HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer(tmpHtml,url_Info.meUrl);      //HtmlAnalyzer
                                                    if (htmlAnalyzer.NewUrl != null)                                           //如果分析出url
                                                    {
                                                            for (int a = 0; a <= htmlAnalyzer.NewUrl.Count - 1; a++)
                                                            {
                                                                Url_info tmp = new Url_info();
                                                                tmp.meUrl = htmlAnalyzer.NewUrl[a].ToString();               //把分析器分析出的url传递给临时对象tmp
                                                                tmp.fromUrl = url_Info.meUrl;                                //来源设定
                                                                tmp.sid = url_Info.sid + 1;                                  //级数+1
                                                                postQueue(tmp);                                              //url信息投递到任务队列
                                                            }
                                                    }
                                                htm.SavePage(tmpHtml,url_Info.meUrl);
                                            }

                                    }
                            }
                            if (iListener.OnCloseWork() == true)
                            {
                                IsWork = true;
                            }

             }
        }
        public Boolean postQueue(Url_info url)//投递任务，投递时传递url来源
        {
            Boolean tmp;
            tmp=iListener.OnPostWork(url);
            return tmp;
        }
        public Url_info getQueue()      //领取任务
        {
            Url_info tmp = iListener.getNewWork();
            return tmp;
        }
        public Boolean AddUrl(Url_info url) //加入已经正被爬行的URL
        {   
            Boolean tmp;
            tmp = iListener.OnAddUrl(url);
            return tmp;
        }

    }
}
