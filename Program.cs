using System;
using TimePeriodTime;

namespace TimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t = new Time(23,2);
            Time t2 = new Time("20:21:23");
            Time t3 = Time.Parse("20:25:22");
            Console.WriteLine(t);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(t3>t2);
            Console.WriteLine(t3<t2);
            Console.WriteLine(t3>=t2);
            Console.WriteLine(t3<=t2);
            Console.WriteLine(t3.CompareTo(t2));
            TimePeriod t4 = new TimePeriod(222,22,2);
            Console.WriteLine(t4);
        
        }
    }
}
