using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_linked_list
{
    //链表节点
    public class Node<T>{
        public Node<T> Next{get;set;}
        public T Data{get;set;}

        public Node(T t){
            Next=null;
            Data=t;
        }
    }

    //泛型链表类
    public class GenericList<T>{
        private Node<T> head;
        private Node<T> tail;

        public GenericList(){
            tail=head=null;
        }

        public Node<T> Head{
            get => head;
        }

        public void Add(T t){
            Node<T> p=new Node<T>(t);
            if(tail==null){
                head=tail=p;
            }
            else{
                tail.Next=p;
                tail=p;
            }
        }

        static public void forEach(GenericList<T> list,Action<T> f){
            for(Node<T> t=list.Head;t!=null;t=t.Next){
                f(t.Data);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intList=new GenericList<int>();
            for(int i=0;i<10;i++) intList.Add(i);
            //打印链表
            Console.WriteLine("打印链表");
            GenericList<int>.forEach(intList,x=>Console.Write(x+" "));
            Console.WriteLine();
            Console.WriteLine();
            //最大值
            int mx=-1;
            GenericList<int>.forEach(intList,x=>mx=Math.Max(mx,x));
            Console.WriteLine($"最大值为{mx}");
            Console.WriteLine();
            //最小值
            int mn=100;
            GenericList<int>.forEach(intList,x=>mn=Math.Min(mn,x));
            Console.WriteLine($"最小值为{mn}");
            Console.WriteLine();
            //求和
            int sum=0;
            GenericList<int>.forEach(intList,x=>sum+=x);
            Console.WriteLine($"和为{sum}");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
