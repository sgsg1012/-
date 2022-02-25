using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void calculate()
        {
            Console.WriteLine("请输入两个操作数:");
            int a = 0, b = 0;
            string val = Console.ReadLine().Trim();
            //Console.Write(val);
            if (val.Contains(" "))
            {
                int len = val.Length;
                int i = 0;
                string a_str = "", b_str = "";
                while (i < len && val[i] != ' ') { a_str += val[i]; i++; }
                i++;
                while (i < len && val[i] != ' ') { b_str += val[i]; i++; }
                try
                {
                    a = int.Parse(a_str);
                    b = int.Parse(b_str);
                }
                catch
                {
                    Console.WriteLine("输入非法");
                    Console.ReadKey();
                    return;
                }

            }
            else
            {
                try { a = int.Parse(val); }
                catch
                {
                    Console.WriteLine("输入非法");
                    Console.ReadKey();
                    return;
                }

                val = Console.ReadLine().Trim();
                try { b = int.Parse(val); }
                catch
                {
                    Console.WriteLine("输入非法");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine($"a={a}\tb={b}");

            Console.WriteLine("请输入运算符(仅支持四则运算)");
            string op_str = Console.ReadLine().Trim();
            char op = op_str[0];
            int res = 0;
            switch (op)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    if(b==0)
                    {
                        Console.WriteLine("除数不能为0");
                        return;
                    }
                    res = a / b;
                    break;
                default:
                    Console.WriteLine("请输入加减乘除运算符");
                    return;
                    break;
            }
            Console.WriteLine($"运算结果为:{a} {op} {b} = {res}");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                calculate();
                Console.WriteLine("按0继续计算，否则退出");
                string c = Console.ReadLine().Trim();
                if (c != "0") break;
            }
            Console.WriteLine("程序结束");
            Console.ReadKey();
            return;
        }
    }
}
