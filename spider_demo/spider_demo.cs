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
            this.Text="��ʼץȡҳ��";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            yy.stopSpiderA();
            System.Windows.Forms.Application.DoEvents();
        }
    }
}