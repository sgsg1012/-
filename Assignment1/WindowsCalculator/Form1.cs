using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        char op = '+';
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a_str = this.input1.Text;
            string b_str = this.input2.Text;

            int a, b;
            int res=0;

            try {
                a = int.Parse(a_str);
                b = int.Parse(b_str);
            }
            catch {
                MessageBox.Show("操作数不合法", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            switch (op)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    if(b==0)
                    {
                        MessageBox.Show("除数不能为0", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    res = a / b;
                    break;
                default:

                    break;
            }
            this.resLabel.Text = res.ToString();

        }

        

        private void input1_TextChanged(object sender, EventArgs e)
        {

        }

        private void input2_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }
        private void add_CheckedChanged_1(object sender, EventArgs e)
        {
            op = '+';
        }

        private void sub_CheckedChanged(object sender, EventArgs e)
        {
            op = '-';
        }

        private void multi_CheckedChanged(object sender, EventArgs e)
        {
            op = '*';
        }

        private void div_CheckedChanged(object sender, EventArgs e)
        {
            op = '/';
        }
    }
}
