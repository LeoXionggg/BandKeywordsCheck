//====================================================================
// Copyright (c) 2006.8.10-2006.8.13 King (yy8354@tom.com) All rights reserved.
// QQ:5088300
// ���ڱ�����Ŀ������ʾSpider�Ĺ������̣�����ڸ�������ֻ��ʵ�ֹ��ܣ������κ��Ż������ʺ���ҵʹ�á�
// �������MyRegexNamespace������ʹ����������������ΪThe Regulator 2.0������ɣ����ܾ���һ��ȡURL��������ʽ��
// DEMOֻ��windows2003��ҵ���½��й����ԣ���������VS.NET2005
// ���ڱ�������url�Ϸ��Լ�ⲿ��ʹ����.NET 2.0��֧�ֵ������,������.NET 1.1���б����޸Ĳ��ִ���
// ��������Ŀ¼�µ�yy.txtΪ��ʼ����url��ַ��ÿ��urlΪһ��
// ��������Ŀ¼�����ɵ�more.txtΪ������¼�����������е�url��ҳ�汣����ļ���
// ��������Ŀ¼�µ�\htmlĿ¼Ϊ���й���ҳ�汣��λ��
// ��ӭ�κ������κ���ʽ��ʽ�����޸ģ����뱣������Ϣ
//====================================================================
//�������˼·�ɲο���
//���˿������������GOOGLE��̳
//http://groups.google.com/group/sosou?lnk=oa&hl=zh-CN
//����BLOG
//http://blog.sina.com.cn/u/1249533702
//====================================================================



using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using CRC;
namespace spider_demo
{
    class Url_info              //url��Ϣ
    {
        public string meUrl = null;  //url��ַ
        public string fromUrl=null;  //��URL��Դ�����Ϊһ��URL��Ϊ��
        public string lastTime=null;//������ʱ��
        public int sid = 0;         //������������fromUrl��Ϊ�վ���fromUrl��sid+1�͵����Լ���sid��

    }
    class spider:IListener     //���̸߳������������������߳�
    {
        private Queue workQueue=new Queue() ;               //�������У��߳�ȡ���񣬷��������¼
        private Hashtable lastUrlTable = new Hashtable();   //�Ѿ����й���URL�������Ϣ KEYΪUrl_info.meUrl��VALUEΪUrl_info��װ��
        private static int threads = 100;                    //������󲢷��߳�����
        private Thread[] getWork=new Thread[threads];       //���������̶߳�������
        private Boolean OnCloseFlag = false;                //ֹͣ�������
        public spider()                                     //���������߳�
        {

            LoadList("yy.txt");                                 //��ȡ��ַ�б�
            //for (int a = 0;a <= threads - 1; a++)
            //{
            //    WorkThread workThread = new WorkThread(this);
            //    getWork[a] = new Thread(workThread.startWork);
            //}


        }
        public Boolean startSpider()          //��ȡ����url�����������߳��߳�
        {

            //ThreadPool.SetMinThreads(threads / 2, threads / 2);
            for (int a = 0; a <= threads - 1; a++)
            {
                WorkThread workThread = new WorkThread(this);

                //ThreadPool.UnsafeQueueUserWorkItem(new WaitCallback(workThread.startWork),workThread);  
                ThreadPool.QueueUserWorkItem(new WaitCallback(workThread.startWork));
                //if (getWork[a]!=null)
                //{
                //    if (getWork[a].ThreadState.ToString() == "Unstarted")
                //    {
                //        getWork[a].Start();
                //    }
                //}
                //else
                //{
                //    return false;
                //}
            }
            return true;
        }
        //public void stopSpider()          //ֹͣ�����߳�
        //{
        //    Thread.Sleep(10);
        //    for (int a = 0; a <= threads - 1; a++)
        //    {
        //        if (getWork[a] != null)
        //        {
        //            getWork[a].Join();
        //        }
        //        getWork[a] = null;
        //    }
        //    System.Windows.Forms.Application.DoEvents();
                
        //}

        public void stopSpiderA()          //ֹͣ�����߳�
        {
            
            OnCloseFlag = true;
            Thread.Sleep(20);
            for (int a = 0; a <= threads - 1; a++)
            {
                if (getWork[a] != null)
                {   
                    getWork[a].Join(10);
                    getWork[a].Abort();
                }
                getWork[a] = null;
            }
            MessageBox.Show("abort Threads");
        }
        private Boolean LoadList(string filepath)                            ��//���س�ʼ�������
        {
            StreamReader sr = null;
            ArrayList Ayl = new ArrayList();
               try 
            {   
                sr = File.OpenText(filepath);
                string read = null;
                  while ((read = sr.ReadLine()) != null)
                 {
                        Ayl.Add(read);
                 }
            }
               catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
               finally
            {
                   if (sr != null)
                    sr.Close();
                   if (Ayl != null)
                    {
                        if (Ayl.Count != 0)
                        {
                            for (int a = 0; a <= Ayl.Count-1; a++)
                            {
                                Url_info url = new Url_info();
                                url.meUrl = Ayl[a].ToString();
                                url.fromUrl = null;
                                url.sid = 0;
                                workQueue.Enqueue(url);
                            }
                        }
                    }
            }
            return true;
        }
        public Url_info getNewWork()������������������������������������������//ȡ�����������ͷһ���գң̣����Ӷ�����ɾ��
        {
            Url_info tmp = null;
             lock(workQueue)
            { 
               if (workQueue.Count != 0)
               {
                   tmp = (Url_info)workQueue.Dequeue();
               }
             }
            return tmp;
        }
        public Boolean OnPostWork(Url_info url)                                //Ͷ��������գң�
        {
            lock (lastUrlTable)
            {
                Crc32 CRC32 = new Crc32();
                CRC32.Reset();
                byte[] BYTE = Encoding.Default.GetBytes(url.meUrl);
                CRC32.Crc(BYTE);
                string tmp = CRC32.Value.ToString();

                if (lastUrlTable.Contains(tmp) != true)                  //���url�Ƿ��Ѿ�����
                {
                    workQueue.Enqueue(url); ����������������������������//�����������
                                       
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean OnAddUrl(Url_info url)
        {

            lock (lastUrlTable)
            {
                Crc32 CRC32 = new Crc32();
                CRC32.Reset();
                byte[] BYTE = Encoding.Default.GetBytes(url.meUrl);
                CRC32.Crc(BYTE);
                string tmp = CRC32.Value.ToString();

                if (lastUrlTable.Contains(tmp) != true)                  //���url�Ƿ��Ѿ�����
                {
                    lastUrlTable.Add(tmp, url);       ��������������������//����Hashtbale              
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
        public Boolean OnCloseWork()
        {   
            return OnCloseFlag;
        }

    }
}
