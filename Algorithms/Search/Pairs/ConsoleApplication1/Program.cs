using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // https://www.hackerrank.com/challenges/pairs
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            int n = int.Parse(firstLine.Split(' ')[0]);
            int k = int.Parse(firstLine.Split(' ')[1]);
            string[] array_string = Console.ReadLine().Split(' ');
            int[] array = Array.ConvertAll(array_string, Int32.Parse);

#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        static int pairs(int[] a, int k)
        {

            return 0;
        }
    }
}
