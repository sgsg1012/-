using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Order_management_system
{
    [Serializable]
    public class Order 
    {
        private string id;
        private string content;
        private string amount;
        private string customer;
        private string time;

        public Order() { }
        public Order(string id,string content,string amount,string customer)
        {
            this.id = id;
            this.content = content;
            this.amount = amount;
            this.customer = customer;
            this.time = DateTime.Now.ToString();
        }

        public string Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        public string Amount { get => amount; set => amount = value; }
        public string Customer { get => customer; set => customer = value; }
        public string Time { get => time; set => time = value; }
        public string Time2 { get => time; set => time = value; }

        public override bool Equals(object obj)
        {
            Order odr = obj as Order;
            return odr != null && odr.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Id);
        }
        private string Format12(string s)
        {
            while (s.Length < 16)
            {
                s += ' ';
            }
            return s;
        }
        public override string ToString()
        {
            return Format12(Id) + Format12(Content)+ Format12(Amount) 
                + Format12(Customer)  + Format12(time);
        }
    }
    public class OrderService
    {
        public List<Order> orders;
        private int num = 0;
        private int Num { get => this.num; set => this.num = value; }

        public OrderService()
        {
            this.orders = new List<Order>();
        }
        public bool find(string id)
        {
            foreach (Order o in orders)
            {
                if (o.Id == id) return true;
            }
            return false;
        }
        public void add(Order order)
        {
            this.orders.Add(order);
        }
        public void delete(string id)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == id) { orders.RemoveAt(i); }
            }
        }
        public void modify(string id, string content, string amount, string customer)
        {
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    order.Content = content;
                    order.Amount = amount;
                    order.Customer = customer;
                    order.Time = DateTime.Now.ToString();
                }
            }
        }
        public void print()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("没有订单\n");
                return;
            }
            Console.WriteLine("订单列表：");
            Console.WriteLine("订单编号\t订单内容\t订单金额\t订单客户\t订单时间");
            foreach (Order o in orders)
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine();
        }
        //op==1 id op==2 content op==3 amount op==4 customer op==5 time
        public void query(Dictionary<string, string> args)
        {
            IEnumerable<Order> q = from od in orders orderby Convert.ToDouble(od.Amount) select od;
            foreach (var arg in args)
            {
                if (arg.Value == "") continue;
                if (arg.Key == "id")
                {
                    q = (from od in q where od.Id == arg.Value select od);
                }
                else if (arg.Key == "content")
                {

                    q = (from od in q where od.Content == arg.Value select od);
                }
                else if (arg.Key == "amount")
                {
                    q = (from od in q where od.Amount == arg.Value select od);
                }
                else if (arg.Key == "customer")
                {
                    q = (from od in q where od.Customer == arg.Value select od);
                }
                else if (arg.Key == "time")
                {
                    q = (from od in q where od.Time == arg.Value select od);
                }
            }
            Console.WriteLine("搜索结果");
            Console.WriteLine("编号\t\t订单内容\t\t订单金额\t\t客户\t\t订单时间");
            foreach (Order od in q)
            {
                Console.WriteLine(od.ToString());
            }
            Console.WriteLine();
        }
        public void sort(System.Comparison<Order> f)
        {
            this.orders.Sort(f);
            print();
        }
        public void save(string name)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(orders.GetType());
                using (FileStream fs = new FileStream(name, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orders);
                }
                Console.WriteLine("保存成功");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File {e.FileName} is not found!");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }
        public void fetch(string name)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(orders.GetType());
                using (FileStream fs = new FileStream(name, FileMode.Open))
                {
                    this.orders = (List<Order>)xmlSerializer.Deserialize(fs);
                }
                Console.WriteLine("读取成功");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File {e.FileName} is not found!");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }


        }
        public int getMaxId()
        {
            int num = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                num = Math.Max(num, Convert.ToInt32(orders[i].Id));
            }
            return num;
        }
    }

    class Program
    {
        //static int id = 0;
        //static OrderService os = new OrderService();
        //static void Menu()
        //{
        //    Console.WriteLine("欢迎使用订单管理系统!");
        //    Console.WriteLine("*********************************");
        //    Console.WriteLine("**********1--添加订单************");
        //    Console.WriteLine("**********2--删除订单************");
        //    Console.WriteLine("**********3--修改订单************");
        //    Console.WriteLine("**********4--查询订单************");
        //    Console.WriteLine("**********5--输出订单************");
        //    Console.WriteLine("**********6--订单排序************");
        //    Console.WriteLine("**********7--保存订单************");
        //    Console.WriteLine("**********8--读取订单************");
        //    Console.WriteLine("**********0--退出程序************");
        //    Console.WriteLine("*********************************");
        //    Console.WriteLine();
        //}
        //static int read()
        //{
        //    try
        //    {
        //        int op = Convert.ToInt32(Console.ReadLine().Trim());
        //        return op;
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}
        //static void add()
        //{
        //    Console.WriteLine("请输入订单内容");
        //    string content = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入订单金额");
        //    string amount = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入订单客户");
        //    string customer = Console.ReadLine().Trim();
        //    Order od = new Order(id.ToString(), content, amount, customer);
        //    id++;
        //    os.add(od);
        //    Console.WriteLine("添加成功");
        //}
        //static void delete()
        //{
        //    Console.WriteLine("请输入删除订单编号");
        //    string id = Console.ReadLine().Trim();
        //    if (!os.find(id))
        //    {
        //        Console.WriteLine("删除失败,无此订单");
        //    }
        //    else
        //    {
        //        os.delete(id);
        //        Console.WriteLine("删除成功");
        //    }
        //}
        //static void modify()
        //{
        //    Console.WriteLine("请输入修改订单编号");
        //    string id = Console.ReadLine().Trim();
        //    if (!os.find(id))
        //    {
        //        Console.WriteLine("修改失败,无此订单");
        //    }
        //    else
        //    {
        //        Console.WriteLine("请输入订单内容");
        //        string content = Console.ReadLine().Trim();
        //        Console.WriteLine("请输入订单金额");
        //        string amount = Console.ReadLine().Trim();
        //        Console.WriteLine("请输入订单客户");
        //        string customer = Console.ReadLine().Trim();
        //        os.modify(id, content, amount, customer);
        //        Console.WriteLine("修改成功");
        //    }
        //}
        //static void searcch()
        //{
        //    Dictionary<string, string> args = new Dictionary<string, string>();
        //    Console.WriteLine("请输入查询订单编号(不做要求的话直接回车)");
        //    args["id"] = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入查询订单内容(不做要求的话直接回车)");
        //    args["content"] = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入查询订单金额(不做要求的话直接回车)");
        //    args["amount"] = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入查询订单客户(不做要求的话直接回车)");
        //    args["customer"] = Console.ReadLine().Trim();
        //    Console.WriteLine("请输入查询订单时间(不做要求的话直接回车)");
        //    args["time"] = Console.ReadLine().Trim();
        //    os.query(args);
        //}
        //static void sort()
        //{
        //    Console.WriteLine("1--按照订单编号降序");
        //    Console.WriteLine("2--按照订单金额升序");
        //    Console.WriteLine("3--按照订单金额降序");
        //    int op = read();
        //    if (op == 1)
        //    {
        //        os.sort((x, y) =>
        //        {
        //            if (Convert.ToInt32(x.Id) < Convert.ToInt32(y.Id)) return 1;
        //            else return -1;
        //        });
        //    }
        //    else if (op == 2)
        //    {
        //        os.sort((x, y) =>
        //        {
        //            if (Convert.ToDouble(x.Amount) > Convert.ToDouble(y.Amount)) return 1;
        //            else return -1;
        //        });
        //    }
        //    else if (op == 3)
        //    {
        //        os.sort((x, y) =>
        //        {
        //            if (Convert.ToDouble(x.Amount) < Convert.ToDouble(y.Amount)) return 1;
        //            else return -1;
        //        });
        //    }
        //    else
        //    {
        //        Console.WriteLine("wrong operation!!!");
        //    }

        //}
        static void Main(string[] args)
        {
            //Menu();
            //while (true)
            //{
            //    int op = read();
            //    if (op == 1) add();
            //    else if (op == 2) delete();
            //    else if (op == 3) modify();
            //    else if (op == 4) searcch();
            //    else if (op == 5) os.print();
            //    else if (op == 6) sort();
            //    else if (op == 7)//保存
            //    {
            //        Console.WriteLine("请输入文件名");
            //        string name = Console.ReadLine().Trim();
            //        os.save(name);
            //    }
            //    else if (op == 8)//读取
            //    {
            //        Console.WriteLine("请输入文件名");
            //        string name = Console.ReadLine().Trim();
            //        os.fetch(name);
            //        id = os.getMaxId() + 1;
            //    }
            //    else if (op == 0)
            //    {
            //        Console.WriteLine("exit");
            //        //exit(0);
            //        Environment.Exit(0);
            //    }
            //    else
            //    {
            //        Console.WriteLine("wrong operation!!!");
            //    }
            //    Console.ReadKey();
            //    Console.Clear();
            //    Menu();
            //}
        }
    }
}
