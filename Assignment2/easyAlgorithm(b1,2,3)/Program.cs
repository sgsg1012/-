using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyAlgorithm_b1_2_3_
{
    class Program
    {
        static int max(int a,int b)
        {
            if (a > b) return a;
            return b;
        }
        static int min(int a,int b)
        {
            if (a > b) return b;
            return a;
        }
        static void getPrimeFactor()
        {
            Console.WriteLine("求所给整数的所有质因子程序");
            Console.WriteLine("请输入一个整数");
            string val = Console.ReadLine().Trim();
            int x = 0;
            try
            {
                x = int.Parse(val);
            }
            catch
            {
                Console.WriteLine("输入非法");
            }
            for (int i=2;i<=x/i;i++)
            {
                if (x % i == 0) Console.Write($"{i} ");
                while (x % i == 0) x /= i;
            }
            if(x>1) Console.Write($"{x} ");
            Console.WriteLine();
        }
        static void processingArray()
        {
            Console.WriteLine("求一个整数数组的最大值、最小值、平均值和数组元素的和");
            Console.WriteLine("请在一行中输入数组，数字之间用空格隔开");
            string val = Console.ReadLine().Trim();
            if(val=="")
            {
                Console.WriteLine("数组为空");
                return;
            }
            string[] strArr = val.Split(' ');
            int len = strArr.Length;
            int[] arr = new int[len];
            try
            {
                for (int i = 0; i < len; i++)
                {
                    arr[i] = int.Parse(strArr[i]);
                }
                int mx = arr[0], mn = arr[0], sum = 0;
                for (int i = 0; i < len; i++)
                {
                    mx = max(mx, arr[i]);
                    mn = min(mn, arr[i]);
                    sum += arr[i];
                }
                double avg = (double)sum / (double)len;
                Console.Write($"最大值为：{mx}\n最小值为：{mn}\n" +
                    $"数组元素的和为：{sum}\n数组平均值为：{avg}\n");
            }
            catch
            {
                Console.WriteLine("输入非法");
            }
        }
        static void getPrime(int n)
        {
            Console.WriteLine("筛质数(100以内)");
            Console.WriteLine();
            bool[] st = new bool[n+1];
            for (int i = 2; i <= n; i++) st[i] = true;
            for(int i=2;i*i<=n;i++)
            {
                if (!st[i]) continue;
                for (int j = i + i; j <= n; j += i) st[j] = false;
            }
            for(int i=2;i<=n;i++)
            {
                if (st[i]) Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            getPrimeFactor();
            Console.WriteLine();
            processingArray();
            Console.WriteLine();
            int x = 100;
            getPrime(x);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
