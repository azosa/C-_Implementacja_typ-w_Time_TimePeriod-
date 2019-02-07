using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_TIME
{

    class Program
    {

       
        static void Main(string[] args)
        {
            Time t1 = new Time(43);
            Console.WriteLine(t1);
            Time t2;
            t2 = t1;
            Console.WriteLine(t2);
            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(t1 == t2);
            Time t3 = new Time("06:30:09");
            Time t4 = new Time(2, 30, 00);
            Console.WriteLine(t4.ToString());
            Console.WriteLine(t4.Plus(t3));
            TimePeriod p = new TimePeriod("06:30:09");
            TimePeriod t = new TimePeriod(7200);
            Console.WriteLine(t3+p);
            Console.ReadKey();
      
        }
    }
}
