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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace spider_demo
{
    public partial class spider_demo : Form
    {
        public spider_demo()
        {
            InitializeComponent();
        }
        spider yy = new spider();
        private void button1_Click(object sender, EventArgs e)
        {
            
            yy.startSpider();
            this.Text="开始抓取页面";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            yy.stopSpiderA();
            System.Windows.Forms.Application.DoEvents();
        }
    }
}