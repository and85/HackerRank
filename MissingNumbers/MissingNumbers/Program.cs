using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static int[] MissedNumbers(int n, int[] a, int m, int[] b)
    {
        var missedNumbers = new List<int>();

        Dictionary<int, int>  cacheA = CreateCache(a);
        Dictionary<int, int> cacheB = CreateCache(b);

        foreach (int key in cacheB.Select(x => x.Key))
        {
            if (!cacheA.ContainsKey(key))
            {
                missedNumbers.Add(key);
            }
            else
            {
                if (cacheB[key] != cacheA[key])
                    missedNumbers.Add(key);
            }
        }

        return missedNumbers.OrderBy(x => x).ToArray();
    }

    private static  Dictionary<int, int> CreateCache(int[] array)
    {
        var resultCache = new Dictionary<int, int>();
        foreach (int key in array)
        {
            if (resultCache.ContainsKey(key))
                resultCache[key]++;
            else
                resultCache.Add(key, 1);
        }

        return resultCache;
    }

    static void Main(String[] args)
    {

        int n = int.Parse(Console.ReadLine());

        int[] a = Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray();

        int m = int.Parse(Console.ReadLine());

        int[] b = Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray();

        //int n = 10;
        //int m = 13;

        //int[] a = "203 204 205 206 207 208 203 204 205 206"
        //            .Split(' ')
        //            .Select(x => int.Parse(x))
        //            .ToArray();

        //int[] b = "203 204 204 205 206 207 205 208 203 206 205 206 204"
        //            .Split(' ')
        //            .Select(x => int.Parse(x))
        //            .ToArray();

        int[] result = MissedNumbers(n, a, m, b);

        Console.WriteLine(string.Join(" ", result));
    }
}