using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/countingsort2
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

        int[] sorted = Sort(arr, n);
        foreach (int element in sorted)
        {
            Console.Write(element + " ");
        }
    }

    static int[] Sort(int[] unsorted, int n)
    {
        int[] sorted = new int[unsorted.Length];

        int[] entries = new int[100];

        for (int i = 0; i < n; i++)
        {
            entries[unsorted[i]]++;
        }

        for (var i = 1; i < entries.Length; i++)
        {
            entries[i] += entries[i - 1];
        }

        for (var i = unsorted.Length - 1; i >= 0; i--)
        {
            sorted[--entries[unsorted[i]]] = unsorted[i];
        }

        return sorted;
    }
}