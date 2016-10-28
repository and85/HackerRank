using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/countingsort1
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(split_elements[i]);
        }

        PrintCount(arr, n);
    }

    static void PrintCount(int[] arr, int n)
    {
        int[] entries = new int[100];

        for (int i = 0; i < n; i++)
        {
            entries[arr[i]]++;
        }

        foreach (int item in entries)
            Console.Write(item + " ");
    }
}