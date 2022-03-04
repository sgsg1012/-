using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Factory_Pattern
{
    // 抽象产品
    public abstract class Shape
    {
        public bool legal = true;
        public abstract double getArea();
        public abstract bool judge();
    }

    //具体产品-长方形
    public class Rectangle : Shape
    {
        double a, b;
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
            base.legal = this.judge();
        }
        public override double getArea()
        {
            if (!legal)
            {
                Console.WriteLine("形状不合法");
                return 0;
            }
            return a * b;
        }

        public override bool judge()
        {
            if (a <= 0 || b <= 0) return false;
            return true;
        }
    }

    //具体产品-正方形
    public class Square : Shape
    {
        double x;
        public Square(double x)
        {
            this.x = x;
            legal = this.judge();
        }
        public override double getArea()
        {
            if (!legal)
            {
                Console.WriteLine("形状不合法");
                return 0;
            }
            return x * x;
        }

        public override bool judge()
        {
            return x > 0;
        }
    }

    //具体产品-三角形
    public class Triangle : Shape
    {
        double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            legal = this.judge();
        }
        public override double getArea()
        {
            if (!legal)
            {
                Console.WriteLine("形状不合法");
                return 0;
            }
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        }

        public override bool judge()
        {
            if (a <= 0 || b <= 0 || c <= 0) return false;
            if (a + b <= c || a + c <= b || b + c <= a) return false;
            return true;
        }
    }
    public class Factory
    {
        public static string type1 = "Rectangle";
        public static string type2 = "Square";
        public static string type3 = "Triangle";
        public static Shape GetProduct(string arg)
        {
            Shape product = null;
            arg = arg.Trim();
            string []args = arg.Split(' ');

            string type = args[0];
            if(type==type1)
            {
                try {
                    double a = Convert.ToDouble(args[1]);
                    double b = Convert.ToDouble(args[2]);
                    product = new Rectangle(a, b);
                }
                catch {
                    Console.WriteLine("参数错误");
                }
                
            }
            else if(type==type2)
            {
                try
                {
                    double a = Convert.ToDouble(args[1]);
                    product = new Square(a);
                }
                catch
                {
                    Console.WriteLine("参数错误");
                }
            }
            else if(type==type3)
            {
                try
                {
                    double a = Convert.ToDouble(args[1]);
                    double b = Convert.ToDouble(args[2]);
                    double c = Convert.ToDouble(args[3]);
                    product = new Triangle(a, b,c);
                }
                catch
                {
                    Console.WriteLine("参数错误");
                }
            }
            else
            {
                Console.WriteLine("错误类型");
            }
            return product;
        }

    }

    class Program
    {
        static string[] types = { "Rectangle", "Square", "Triangle" };
        static Random rd = new Random();
        static Shape randomAShape()
        {
            string arg = "";
            int idx = rd.Next(types.Length);
            arg += types[idx];
            double a = rd.NextDouble()+rd.Next(0,99);
            double b = rd.NextDouble() + rd.Next(0, 99);
            double c = rd.NextDouble() + rd.Next(0, 99);
            arg += $" {a} {b} {c}";
            Console.Write($"{arg}\t");
            return Factory.GetProduct(arg);

        }
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                Shape s = randomAShape();
                double area = s.getArea();
                Console.WriteLine($"面积：    {area}");
                sum += area;
            }
            Console.WriteLine();
            Console.WriteLine($"总面积： {sum}");
            Console.ReadKey();
        }
    }
}
