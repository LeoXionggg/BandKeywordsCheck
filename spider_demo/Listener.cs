using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace spider_demo
{
     interface IListener                          //消息接口
    {
         Boolean OnCloseWork();
         Url_info getNewWork();         　　　　　　//获取任务事件
         Boolean OnPostWork(Url_info url);       //投递新任务事件
         Boolean OnAddUrl(Url_info url);            //加入正在被爬行的ＵＲＬ到Hasbtable
    }
}
