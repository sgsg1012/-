using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyOOP
{
    // 抽象类
    public abstract class Shape
    {
        public bool legal = true;
        public abstract double getArea();
        public abstract bool judge();
    }
    // 长方形
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
            if(!legal)
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
    //正方形
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
    //三角形
    public class Triangle : Shape
    {
        double a, b, c;
        public Triangle(double a, double b , double c)
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

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(1, 2);
            Console.WriteLine(rec.getArea());

            Square s = new Square(99);
            Console.WriteLine(s.getArea());

            Triangle tri1 = new Triangle(3,4,5);
            Console.WriteLine(tri1.getArea());
            
            Console.ReadKey();
        }
    }
}
