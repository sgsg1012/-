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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a_str = this.input1.Text;
            string b_str = this.input2.Text;
            string op_str = this.comboBox1.Text;
            char op = '+';

            int a, b;
            int res=0;

            try {
                a = int.Parse(a_str);
                b = int.Parse(b_str);
                op = op_str[0];
            }
            catch {
                MessageBox.Show("操作数或操作符不合法", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
