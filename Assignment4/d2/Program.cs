using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int [] arr = new int[100];
            for(int i=0;i<100;i++)
            {
                arr[i] = rd.Next(0, 1000);
            }
            Console.WriteLine("排序前");
            for (int i = 0; i < 100; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("排序后");
            var q = from a in arr orderby a descending select a;
            foreach(int a in q)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine("和");
            int sum = q.Sum(a=>a);
            Console.WriteLine(sum);
            Console.WriteLine("平均数");
            double aveg = q.Average(a => a);
            Console.WriteLine(aveg);
            Console.ReadKey();
        }
    }
}
