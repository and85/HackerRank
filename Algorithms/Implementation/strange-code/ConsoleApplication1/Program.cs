using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/strange-code
    static void Main(String[] args)
    {
        long t = long.Parse(Console.ReadLine());

        long beginingIndex = 0;
        long iteration = 0;
        FindFirstElementInCycle(t, ref beginingIndex, ref iteration);

        long beginingValue = 3;
        for (long i = 1; i < iteration; i++)
        {
            beginingValue = beginingValue * 2;
        }

        long result = beginingValue - (t - beginingIndex);
        Console.WriteLine(result);

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    private static void FindFirstElementInCycle(long t, ref long beginingIndex, ref long iteration)
    {
        long step = 0;

        for (long i = 1; i <= t; i = i + step)
        {
            beginingIndex = i;

            if (i == 1)
                step = 3;
            else
                step *= 2;

            iteration++;
        }
    }
}
