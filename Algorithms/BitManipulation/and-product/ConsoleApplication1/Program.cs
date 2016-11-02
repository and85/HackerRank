using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    // https://www.hackerrank.com/challenges/and-product
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        long a;
        long b;
        long sum;
        string input;
        

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            a = long.Parse(input.Split(' ')[0]);
            b = long.Parse(input.Split(' ')[1]);

            //sum = Enumerable.Range(a, b - a).Aggregate((x, y) => y &= x);
            if (a == b)
            {
                sum = a;
            }
            else
            {
                sum = a;

                for (long j = a + 1; j < b; j = j + 2)
                {
                    sum &= j;
                    if (sum == 0)
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }

    static bool IsPowerOfTwo(long x)
    {
        return (x & (x - 1)) == 0;
    }
}