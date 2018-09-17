//====================================================================
// Copyright (c) 2006.8.10-2006.8.13 King (yy8354@tom.com) All rights reserved.
// QQ:5088300
// 由于本程序目的是演示Spider的工作流程，因此在各个方面只求实现功能，并无任何优化，不适合商业使用。
// 本程序除MyRegexNamespace以外无使用其他组件，该组件为The Regulator 2.0编译而成，功能就是一个取URL的正则表达式。
// DEMO只在windows2003企业版下进行过测试，开发环境VS.NET2005
// 由于本程序在url合法性检测部分使用了.NET 2.0才支持的类或函数,如需在.NET 1.1运行必须修改部分代码
// 程序运行目录下的yy.txt为初始爬行url地址，每个url为一行
// 程序运行目录下生成的more.txt为工作记录，保存了爬行的url及页面保存的文件名
// 程序运行目录下的\html目录为爬行过的页面保存位置
// 欢迎任何人以任何形式方式进行修改，但请保留此信息
//====================================================================
//程序设计思路可参考：
//本人开辟搜索主题的GOOGLE论坛
//http://groups.google.com/group/sosou?lnk=oa&hl=zh-CN
//本人BLOG
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
    class Url_info              //url信息
    {
        public string meUrl = null;  //url地址
        public string fromUrl=null;  //此URL来源，如果为一级URL则为空
        public string lastTime=null;//最后访问时间
        public int sid = 0;         //层数，程序检测fromUrl不为空就找fromUrl的sid+1就等于自己的sid了

    }
    class spider:IListener     //主线程负责启动多其他并发线程
    {
        private Queue workQueue=new Queue() ;               //工作队列，线程取任务，发布任务记录
        private Hashtable lastUrlTable = new Hashtable();   //已经爬行过的URL及相关信息 KEY为Url_info.meUrl，VALUE为Url_info类装箱
        private static int threads = 100;                    //设置最大并发线程数量
        private Thread[] getWork=new Thread[threads];       //建立工作线程对象数组
        private Boolean OnCloseFlag = false;                //停止工作标记
        public spider()                                     //创建工作线程
        {

            LoadList("yy.txt");                                 //读取地址列表
            //for (int a = 0;a <= threads - 1; a++)
            //{
            //    WorkThread workThread = new WorkThread(this);
            //    getWork[a] = new Thread(workThread.startWork);
            //}


        }
        public Boolean startSpider()          //读取爬行url，启动所有线程线程
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
        //public void stopSpider()          //停止所有线程
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

        public void stopSpiderA()          //停止所有线程
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
        private Boolean LoadList(string filepath)                            　//加载初始任务队列
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
        public Url_info getNewWork()　　　　　　　　　　　　　　　　　　　　　//取的任务队列里头一个ＵＲＬ，并从队列里删除
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
        public Boolean OnPostWork(Url_info url)                                //投递新任务ＵＲＬ
        {
            lock (lastUrlTable)
            {
                Crc32 CRC32 = new Crc32();
                CRC32.Reset();
                byte[] BYTE = Encoding.Default.GetBytes(url.meUrl);
                CRC32.Crc(BYTE);
                string tmp = CRC32.Value.ToString();

                if (lastUrlTable.Contains(tmp) != true)                  //检查url是否已经爬过
                {
                    workQueue.Enqueue(url); 　　　　　　　　　　　　　　//加入任务队列
                                       
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

                if (lastUrlTable.Contains(tmp) != true)                  //检查url是否已经爬过
                {
                    lastUrlTable.Add(tmp, url);       　　　　　　　　　　//加入Hashtbale              
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
