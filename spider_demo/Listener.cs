using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace spider_demo
{
     interface IListener                          //��Ϣ�ӿ�
    {
         Boolean OnCloseWork();
         Url_info getNewWork();         ������������//��ȡ�����¼�
         Boolean OnPostWork(Url_info url);       //Ͷ���������¼�
         Boolean OnAddUrl(Url_info url);            //�������ڱ����еģգң̵�Hasbtable
    }
}
