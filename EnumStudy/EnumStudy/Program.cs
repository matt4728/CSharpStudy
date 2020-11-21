using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumStudy
{
    public enum Type
    {
        CSharp,
        Java,
        Python,

    }

    [Flags]
    enum Border
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.CSharp;

            int check = (int)type;
            
            if (type == Type.CSharp)
            {
                Console.WriteLine("CSharp!!!");
            }

            Border border = Border.Bottom | Border.Top;

            if (border.HasFlag(Border.Bottom))
            {
                Console.WriteLine("아래 보더 적용됨");
            }

            if ((border & Border.Left) != 0)
            {
                Console.WriteLine("왼쪽 보더 적용됨");
            }
            Console.ReadLine();

        }
    }
}
