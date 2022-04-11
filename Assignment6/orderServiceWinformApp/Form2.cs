using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderServiceWinformApp
{
    public partial class Form2 : Form
    {
        //添加一个委托
        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||textBox2.Text== "" || textBox3.Text== "" || textBox4.Text== "")
            {
                MessageBox.Show("不能为空值");
                return;
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            PassDataBetweenForm(this, args);

            this.Dispose();
        }
    }
}
