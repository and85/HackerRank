using System;
using System.Collections.Generic;
using System.IO;
// https://www.hackerrank.com/challenges/insertionsort2
class Solution
{
    // Part 1
    //static void insertionSort(int[] ar)
    //{
    //    int rightmost = ar[ar.Length - 1];

    //    for (int i = ar.Length - 2; i >= 0; i--)
    //    {
    //        if (ar[i] > rightmost)
    //        {
    //            ar[i + 1] = ar[i];
    //            Console.WriteLine(string.Join(" ", ar));
    //        }

    //        if (ar[i] <= rightmost)
    //        {
    //            ar[i + 1] = rightmost;
    //            Console.WriteLine(string.Join(" ", ar));
    //            return;
    //        }

    //    }

    //    ar[0] = rightmost;
    //    Console.WriteLine(string.Join(" ", ar));
    //}

    static void insertionSort(int[] ar)
    {
        for (int i = 1; i < ar.Length; i++)
        {
            int element = ar[i];
            bool replaced = false;

            for (int j = i - 1; j >= 0; j--)
            {
                if (ar[j] > element)
                {
                    ar[j + 1] = ar[j];
                }

                if (ar[j] <= element)
                {
                    ar[j + 1] = element;
                    replaced = true;
                    break;
                }
            }

            if (!replaced)
                ar[0] = element;

            Console.WriteLine(string.Join(" ", ar));
        }

    }
    static void Main(String[] args)
    {

        //int _ar_size;
        //_ar_size = Convert.ToInt32(Console.ReadLine());
        //int[] _ar = new int[_ar_size];
        //String elements = Console.ReadLine();
        //String[] split_elements = elements.Split(' ');
        //for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        //{
        //    _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        //}
        int _ar_size = 9;
        int[] _ar = new int[_ar_size];
        _ar[0] = 9;
        _ar[1] = 8;
        _ar[2] = 6;
        _ar[3] = 7;
        _ar[4] = 3;
        _ar[5] = 5;
        _ar[6] = 4;
        _ar[7] = 1;
        _ar[8] = 2;

        insertionSort(_ar);
    }
}
