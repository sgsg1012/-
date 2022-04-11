using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceWinformApp
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
        public Order(string id, string content, string amount, string customer)
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
            if (s == null) return "                   ";
            while (s.Length < 16)
            {
                s += ' ';
            }
            return s;
        }
        public override string ToString()
        {
            return Format12(Id) + Format12(Content) + Format12(Amount)
                + Format12(Customer) + Format12(time);
        }
    }
}
