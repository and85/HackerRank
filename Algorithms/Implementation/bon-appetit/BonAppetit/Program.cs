using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    // https://www.hackerrank.com/challenges/bon-appetit
    static void Main(String[] args)
    {
        string[] firstLine = Console.ReadLine().Split(' ');
        int n = int.Parse(firstLine[0]);
        int k = int.Parse(firstLine[1]);
        int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int charged = int.Parse(Console.ReadLine());

        int actual = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (i == k) continue;
            actual += prices[i];
        }

        actual /= 2;

        if (actual != charged)
            Console.WriteLine(charged - actual);
        else
            Console.WriteLine("Bon Appetit");
    }
}