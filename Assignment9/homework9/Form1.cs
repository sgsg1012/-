using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace Homework9
{
    //做一个背单词程序，使用数据库存储英文单词和中文词义。在Winform界面上依次显示英文单词的中文词义，
    //用户可在编辑框中输入对应的英文单词，输入完毕后回车可与对应的英文单词进行比较，一致则显示"正确”，否则显示“错误”。
    public partial class Form1 : Form
    {
        public List<string> english = new List<string>();
        public List<string> chinese = new List<string>();
        public int word_id = 0;
 
        public DataTable datable;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.button1_Click(sender, e);//触发按钮事件
            }
        }

        private void Connection()
        {
            try
            {
                string s = "data source=localhost;database=words;user id=root;password=123456;pooling=true;charset=utf8;";
                string sql = "select * from vocabulary ";
                MySqlConnection conn = new MySqlConnection(s);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();

                MySqlDataAdapter data = new MySqlDataAdapter(sql, conn); //实例化adapter的对象
                DataSet dt = new DataSet();  //创建dataSet
                data.Fill(dt, "table1"); // 将返回的数据集作为“表”填入DataSet中
                datable = dt.Tables["table1"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string answer = textBox1.Text;
            if(answer == english[word_id])
            {
                label6.Text = "Correct answer";
            }
            else
            {
                label6.Text = "Wrong answer";
            }
            label5.Text = english[word_id];

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            Connection();      
           
            foreach (DataRow row in datable.Rows)
            {
                english.Add(row["English"].ToString());
                chinese.Add(row["Chinese"].ToString());
            }
            label2.Text = chinese[word_id];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            word_id = (word_id+1)%english.Count();
            label2.Text = chinese[word_id];
            textBox1.Clear();
            label5.Text = null;
            label6.Text= null;
        }
    }
}