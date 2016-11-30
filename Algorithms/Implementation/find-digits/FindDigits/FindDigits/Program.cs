using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDigits
{
    // https://www.hackerrank.com/challenges/find-digits
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int counter = 0;
                string str = n.ToString();
                foreach (var digit in str)
                {
                    var curDigit = int.Parse(digit.ToString());
                    if (curDigit != 0 && (n % curDigit == 0))
                        counter++;
                }

                Console.WriteLine(counter);
            }
        }
    }
}
