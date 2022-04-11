using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceWinformApp
{
    public class PassDataWinFormEventArgs : EventArgs
    {

        public PassDataWinFormEventArgs()
        {
            //
        }
        public PassDataWinFormEventArgs(string id, string content, string amount,string customer)
        {
            this.id = id;
            this.content = content;
            this.amount = amount;
            this.customer = customer;
        }

        private string id;
        private string content;
        private string amount;
        private string customer;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }

    }
}
