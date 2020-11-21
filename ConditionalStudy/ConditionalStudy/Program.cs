using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            if (a > 10)
            {
                Console.WriteLine("a는 10 이상");
            }
            else
            {
                Console.WriteLine("a는 10 미만");
            }

            switch (a)
            {
                case 10:
                    Console.WriteLine("a는 10");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            Console.ReadLine();
        }
    }
}
