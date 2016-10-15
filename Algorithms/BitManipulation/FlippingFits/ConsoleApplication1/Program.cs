using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    //https://www.hackerrank.com/challenges/flipping-bits
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        uint[] arr = new uint[n];
        for (int i = 0; i < n; i++)
            arr[i] = uint.Parse(Console.ReadLine());

        foreach (uint item in FlipBits(arr))
            Console.WriteLine(item);

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static List<uint> FlipBits(uint[] arr)
    {
        var resultList = new List<uint>();

        uint bitMask = 0xffffffff;
        for (int i = 0; i < arr.Length; i++)
        {
            resultList.Add(arr[i] ^ bitMask);
        }

        return resultList;
    }
}