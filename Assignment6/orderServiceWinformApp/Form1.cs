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
    public partial class Form1 : Form
    {
        OrderService os=new OrderService();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = new BindingList<Order>(os.orders);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(os.to_string());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    string id = (string)rows[0].Cells["id"].Value;//推荐
                    os.delete(id);
                    dataGridView1.DataSource = new BindingList<Order>(os.orders);
                }
            }
            else
            {
                MessageBox.Show("请先选中一行");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.PassDataBetweenForm += new Form2.PassDataBetweenFormHandler(FrmChild_PassDataBetweenForm);
            frm.ShowDialog();
        }
        private void FrmChild_PassDataBetweenForm(object sender, PassDataWinFormEventArgs e)
        {
            os.add(new Order(e.Id, e.Content, e.Amount, e.Customer));
            dataGridView1.DataSource = new BindingList<Order>(os.orders);
            //MessageBox.Show("添加成功");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //导入
            bool tag=os.fetch("data.txt");
            dataGridView1.DataSource = new BindingList<Order>(os.orders);
            if (tag) MessageBox.Show("导入成功");
            else MessageBox.Show("导入失败，文件不存在");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //导出
            os.save("data.txt");
            MessageBox.Show("导出成功");
        }
    }
}
