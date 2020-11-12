using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 문자열
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "C#";


            //이 경우 새로운 string 객체를 생성하여 s1에 다시 할당한다. 즉 메모리가 다르다
            s1 = "C";

            Console.WriteLine("첫번째 : {0}, 두번째 : {1}", s1, "asdf");

            string s2 = "asdfqwer";

            for (int i = 0; i < s2.Length; i++)
            {
                Console.Write(s2[i]);
            }

            //자바에서 StringBuilder와 똑같은 거 같다
            StringBuilder sb = new StringBuilder();
            sb.Append("ok");

            Console.ReadLine();

        }
    }
}
