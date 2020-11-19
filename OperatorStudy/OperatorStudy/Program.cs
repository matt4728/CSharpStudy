using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;

            a = a + 10;
            a += 10;

            a = a - 10;
            a -= 10;

            a++;
            a--;

            int b = a > 10 ? 20 : 15;

            int c = 2 << 5;

            int? i = null;

        }
    }
}
