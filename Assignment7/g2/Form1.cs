using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace g2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pattern = @"^\d{17}(?:\d|X)$";
            if(!Regex.IsMatch(id, pattern))
            {
                this.label2.Text = "身份证号格式错误!";
                return;
            }
            string birth = id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();

            int[] arr_weight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };     // 加权数组
            string[] id_last = { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };   // 校验数组
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += arr_weight[i] * int.Parse(id[i].ToString());
            }
            int result = sum % 11;  // 实际校验位的值

            if (Regex.IsMatch(id, pattern))                     // 18位格式检查
            {
                if (DateTime.TryParse(birth, out time))          // 出生日期检查
                {
                    if (id_last[result] == id[17].ToString())   // 校验位检查
                    {
                        this.label2.Text="身份证号格式正确!";
                    }
                    else
                    {
                        this.label2.Text="最后一位校验错误!";
                    }
                }
                else
                {
                    this.label2.Text="出生日期验证失败!";
                }
            }
            else
            {
                this.label2.Text="身份证号格式错误!";
            }

        }
    }
}
