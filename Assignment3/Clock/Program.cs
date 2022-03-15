using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace Clock
{
    /*
     * 闹钟
     * 功能：tick 整分报时 闹钟
     * 
     * 闹钟的设置有两种形式
     * 1、输入闹钟时间点
     * 2、输入倒计时，闹钟会在响应时间段后响铃
     */
    class Clock{
        
        private ArrayList alarms;
        private ArrayList times;

        public Clock(){
            alarms=new ArrayList(0);
            times = new ArrayList(0);
            Console.WriteLine("闹钟实例化");
        }
        public void addAlarm(DateTime t){
            alarms.Add(t);
        }
        public void addTimes(string s)
        {
            times.Add(s);
        }
        public event Action<DateTime> onTick;
        public event Action<DateTime> timeKeeper;
        public event Action<DateTime> onAlarm;

        private void tick(DateTime t)
        {
            onTick(t);
        }
        private void alarm(DateTime t)
        {
            onAlarm(t);
        } 

        private void timeKeep(DateTime t)
        {
            timeKeeper(t);
        }

        public void run(){
            Console.WriteLine("闹钟启动");
            for(int i = 0; i < times.Count; i++)
            {
                string s = (string)times[i];
                char c = s[s.Length - 1];
                s = s.Substring(0, s.Length - 1);
                int num = Convert.ToInt32(s);
                if (c == 'h')
                {
                    addAlarm(DateTime.Now.AddHours(num));
                }
                else if (c == 'm')
                {
                    addAlarm(DateTime.Now.AddMinutes(num));
                }
                else if (c == 's')
                {
                    addAlarm(DateTime.Now.AddSeconds(num));
                }
                else
                {
                    Console.WriteLine("输入格式错误");
                }
            }
            alarms.Sort();
            DateTime cur=DateTime.Now;
            while(true){
                tick(cur);
                if(alarms.Count>0 && cur>=(DateTime)alarms[0]){
                    alarm(cur);
                    alarms.RemoveAt(0);

                }
                if ( cur.Second == 0)
                {
                    timeKeep(cur);
                }
                Thread.Sleep(1000);
                cur=DateTime.Now;    
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Clock clk = new Clock();
            Console.WriteLine("欢迎使用本闹钟");
            Console.WriteLine("本闹钟具有整分报时和闹钟功能");
            Console.WriteLine("请按行输入您的闹钟时间");
            Console.WriteLine("您可以输入一个时间点表示响铃时间，格式为(hh:mm:ss)");
            Console.WriteLine("也可以输入一个数字加单位表示您想闹钟在多长时间后提醒您" +
                "，格式为(1h)或者(1m)或者(1s),1可以为任何正整数,当然，不要大于int");

            Console.WriteLine("输入-1启动闹钟");
            string s = Console.ReadLine().Trim();
            while (s != "-1")
            {
               try 
                {
                    if (s.Contains(':'))
                    {
                        clk.addAlarm(DateTime.ParseExact(s, "hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        char c = s[s.Length - 1];
                        s = s.Substring(0, s.Length - 1);
                        int num = Convert.ToInt32(s);
                        if(c!='h'&&c!='m'&&c!='s') Console.WriteLine("输入格式错误");
                        else clk.addTimes(s+c);
                    }
                }
                catch
                {
                    Console.WriteLine("输入格式错误");
                }
                s = Console.ReadLine().Trim();
            }
            clk.onTick += (DateTime t) => Console.WriteLine("tick\t"+t);
            clk.onAlarm+= (DateTime t) => Console.WriteLine("闹钟\t\t"+t);
            clk.timeKeeper+= (DateTime t) => Console.WriteLine("整分报时\t"+t);
            clk.run();
            

            Console.ReadKey();
        }
    }
}
