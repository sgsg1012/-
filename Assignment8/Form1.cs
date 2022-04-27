using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//允许线程间操作

            string search_url = "https://www.baidu.com/baidu?wd=" + textBox1.Text;
            //建立线程1
           
            Thread thread1 = new Thread(delegate ()
            {
                string result = searchWithBaidu(search_url).Substring(0,200);
                this.textBox2.Text = result;
            });
            thread1.IsBackground = true;//线程1后台运行
            //建立线程2
            Thread thread2 = new Thread(delegate ()
            {
                string result = searchWithBaidu(search_url).Substring(0,200);
                this.textBox3.Text = result;
            });
            thread2.IsBackground = true;//线程2也后台运行

            thread1.Start();
            thread2.Start();
        }
        private string searchWithBaidu(string search_url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            return webClient.DownloadString(search_url);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}