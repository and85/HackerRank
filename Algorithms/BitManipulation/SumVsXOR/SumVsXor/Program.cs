using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/sum-vs-xor
    static void Main(String[] args)
    {
        long n = Convert.ToInt64(Console.ReadLine());

        long zeroCount = 0;

        for (long i = 1; i > 0 && i < n; i = i << 1)
            zeroCount += ((n & i) == 0) ? 1 : 0;

        Console.WriteLine(Math.Pow(2, zeroCount));
    }
}
