using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace spider_demo
{
    class WorkThread //�����߳���
    {
        private Url_info url_Info = new Url_info(); //��¼Ŀǰ������url��Ϣ
        private IListener iListener = null;
        private Boolean IsWork = false;                //Ŀǰ�Ƿ�û����falseû����true������
        public WorkThread(IListener iListener)
        {
            this.iListener = iListener;
        }
        public void startWork(object state)                             //�����߳���������δ��ɺ�����
        {
            while (IsWork != true)
            {
                            System.Windows.Forms.Application.DoEvents();            //doEvents
                            if (IsWork == false)                                   //û�������������������
                            {
                                //IsWork = true; 
                                url_Info = getQueue();
                                    if (url_Info != null)
                                    {
                                                                                               //����ִ������
                                        DateTime tTmp = DateTime.Now;
                                        url_Info.lastTime = tTmp.ToString();                                  //����ʱ��
                                            if (AddUrl(url_Info) == true)
                                            {
                                                GetHtml htm = new GetHtml();
                                                string tmpHtml=htm.GetPage(url_Info.meUrl);                         //GetHtml
                                                HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer(tmpHtml,url_Info.meUrl);      //HtmlAnalyzer
                                                    if (htmlAnalyzer.NewUrl != null)                                           //���������url
                                                    {
                                                            for (int a = 0; a <= htmlAnalyzer.NewUrl.Count - 1; a++)
                                                            {
                                                                Url_info tmp = new Url_info();
                                                                tmp.meUrl = htmlAnalyzer.NewUrl[a].ToString();               //�ѷ�������������url���ݸ���ʱ����tmp
                                                                tmp.fromUrl = url_Info.meUrl;                                //��Դ�趨
                                                                tmp.sid = url_Info.sid + 1;                                  //����+1
                                                                postQueue(tmp);                                              //url��ϢͶ�ݵ��������
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
        public Boolean postQueue(Url_info url)//Ͷ������Ͷ��ʱ����url��Դ
        {
            Boolean tmp;
            tmp=iListener.OnPostWork(url);
            return tmp;
        }
        public Url_info getQueue()      //��ȡ����
        {
            Url_info tmp = iListener.getNewWork();
            return tmp;
        }
        public Boolean AddUrl(Url_info url) //�����Ѿ��������е�URL
        {   
            Boolean tmp;
            tmp = iListener.OnAddUrl(url);
            return tmp;
        }

    }
}
