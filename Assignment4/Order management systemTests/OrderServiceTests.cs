using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order_management_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management_system.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void findTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            bool tag1 = os.find("111");
            bool tag2 = os.find("222");
            Assert.IsTrue(tag1);
            Assert.IsFalse(tag2);
        }

        [TestMethod()]
        public void addTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            Assert.IsTrue(os.find("111"));
        }

        [TestMethod()]
        public void deleteTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            Assert.IsTrue(os.find("111"));
            os.delete("111");
            Assert.IsFalse(os.find("111"));
        }

        [TestMethod()]
        public void modifyTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            Assert.IsTrue(os.find("111"));
            os.modify("111", "222", "222", "222");
        }

        [TestMethod()]
        public void printTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            os.print();
        }

        [TestMethod()]
        public void queryTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            os.query(new Dictionary<string, string>());
        }

        [TestMethod()]
        public void sortTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            os.sort((x, y) =>
            {
                if (Convert.ToDouble(x.Amount) < Convert.ToDouble(y.Amount)) return 1;
                else return -1;
            });
        }

        [TestMethod()]
        public void saveTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            os.save("fff");
        }

        [TestMethod()]
        public void fetchTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            os.fetch("fff");
        }

        [TestMethod()]
        public void getMaxIdTest()
        {
            OrderService os = new OrderService();
            os.add(new Order("111", "111", "111", "111"));
            Assert.AreEqual(111, os.getMaxId());
        }
    }
}