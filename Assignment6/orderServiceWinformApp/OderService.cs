using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderServiceWinformApp
{
    public class OrderService
    {
        public List<Order> orders;

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
            orders = orders.Where(x => x.Id != id).ToList();
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
        public string to_string()
        {
            string s="";
            if (orders.Count == 0)
            {
                s+="没有订单\n";
                return s;
            }
            s+="订单列表：\n";
            s+="订单编号\t订单内容\t订单金额\t订单客户\t订单时间\n";
            foreach (Order o in orders)
            {
               s+=o.ToString()+"\n";
            }
            s += "\n";
            return s;
        }
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
                using (System.IO.FileStream fs = new FileStream(name, FileMode.Create))
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
        public bool fetch(string name)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new XmlSerializer(orders.GetType());
                using (FileStream fs = new FileStream(name, FileMode.Open))
                {
                    this.orders = (List<Order>)xmlSerializer.Deserialize(fs);
                }
                Console.WriteLine("读取成功");
                return true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File {e.FileName} is not found!");
                return false;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return false;
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
}
