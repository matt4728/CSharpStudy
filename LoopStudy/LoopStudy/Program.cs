using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
                Console.WriteLine("Loop {0}", i);
            }

            foreach (var item in arr)
            {
                Console.Write("{0}\t", item);
            }

            int j = 1;

            while (j <= 10)
            {
                Console.WriteLine("{0}", j);
                j++;
            }

            Console.WriteLine();
            j = 1;
            while (++j <= 10)
            {
                Console.WriteLine("{0}", j);
            }

            j = 1;
            do
            {
                Console.WriteLine(j);
                j++;
            } while (j <= 10);

            Console.ReadLine();
        }
    }
}
