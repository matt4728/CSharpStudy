using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 100, 100, 100 };
            string[] names = new string[10];

            string[,] depts;
            string[,,] cube;

            int[][] arr = new int[3][];

            arr[0] = new int[2];
            arr[1] = new int[3];
            arr[2] = new int[4] { 1, 2, 3, 4 };

            arr[0][1] = 1;
            arr[0][0] = 123;

            printAvg(scores);
        }

        public static void printAvg(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine(sum / arr.Length);
            Console.ReadLine();
        }
    }
}
