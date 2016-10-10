using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    // https://www.hackerrank.com/challenges/sparse-arrays
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());

        string[] strings = new string[n];
        for (int i = 0; i < n; i++)
        {
            strings[i] = Console.ReadLine();
        }

        int q = int.Parse(Console.ReadLine());

        string[] queries = new string[q];
        for (int i = 0; i < q; i++)
        {
            queries[i] = Console.ReadLine();
        }

        foreach (int item in GetEntriesNumber(strings, queries))
        {
            Console.WriteLine(item);
        }

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static List<int> GetEntriesNumber(string[] strings, string[] queries)
    {
        var resultList = new List<int>();

        var stringsCount = new Dictionary<string, int>();
        foreach (string item in strings)
        {
            if (stringsCount.ContainsKey(item))
                stringsCount[item]++;
            else
                stringsCount.Add(item, 1);
        }

        foreach (string item in queries)
        {
            if (stringsCount.ContainsKey(item))
                resultList.Add(stringsCount[item]);
            else
                resultList.Add(0);
        }

        return resultList;
    }
}