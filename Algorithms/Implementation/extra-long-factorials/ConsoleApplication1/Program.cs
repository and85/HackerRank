using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication1
{
    // https://www.hackerrank.com/challenges/extra-long-factorials
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string factorial = GetFactorial(n);
            Console.WriteLine(factorial);
        }

        static string GetFactorial(int n)
        {
            BigInteger factorial = n;
            for (int i = n-1; i >= 1; i--)
            {
                factorial *= i;
            }

            return factorial.ToString();
        }
    }
}
