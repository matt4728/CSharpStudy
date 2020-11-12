using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 변수_및_상수
{
    class Value
    {
        int a;
        int b;
        const int c = 1234;
        readonly int d;
        public Value(int a, int b)
        {
            this.a = a;
            this.b = b;
            d = 12345;
        }

        public void sum(int a, int b)
        {
            // error
            //int localVal;
            Console.WriteLine(a + b);
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Value v = new Value(1, 2);
            v.sum(123, 234);
        }
    }
}
