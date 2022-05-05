using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace Homework9
{
    //��һ�������ʳ���ʹ�����ݿ�洢Ӣ�ĵ��ʺ����Ĵ��塣��Winform������������ʾӢ�ĵ��ʵ����Ĵ��壬
    //�û����ڱ༭���������Ӧ��Ӣ�ĵ��ʣ�������Ϻ�س������Ӧ��Ӣ�ĵ��ʽ��бȽϣ�һ������ʾ"��ȷ����������ʾ�����󡱡�
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
            if (e.KeyCode == Keys.Enter)//�жϻس���
            {
                this.button1_Click(sender, e);//������ť�¼�
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

                MySqlDataAdapter data = new MySqlDataAdapter(sql, conn); //ʵ����adapter�Ķ���
                DataSet dt = new DataSet();  //����dataSet
                data.Fill(dt, "table1"); // �����ص����ݼ���Ϊ��������DataSet��
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