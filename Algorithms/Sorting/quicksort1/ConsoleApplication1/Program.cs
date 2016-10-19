using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void partition(int[] ar)
    {
        int pivot = ar[0];
        var equal = new List<int>();
        var left = new List<int>();
        var right = new List<int>();

        for (int i = 0; i < ar.Length; i++)
        {
            if (ar[i] == pivot)
                equal.Add(ar[i]);
            else if (ar[i] < pivot)
                left.Add(ar[i]);
            else if (ar[i] > pivot)
                right.Add(ar[i]);
        }

        var resultList = left.Concat(equal).Concat(right);
        Console.WriteLine(string.Join(" ", resultList));
    }
    /* Tail starts here */
    //https://www.hackerrank.com/challenges/quicksort1
    static void Main(String[] args)
    {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        partition(_ar);
    }
}
