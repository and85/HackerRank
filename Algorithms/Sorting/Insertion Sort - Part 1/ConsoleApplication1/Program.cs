using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void insertionSort(int[] ar)
    {
        int rightmost = ar[ar.Length - 1];

        for (int i = ar.Length - 2; i >= 0; i--)
        {
            if (ar[i] > rightmost)
            {
                ar[i + 1] = ar[i];
                Console.WriteLine(string.Join(" ", ar));
            }

            if (ar[i] <= rightmost)
            {
                ar[i + 1] = rightmost;
                Console.WriteLine(string.Join(" ", ar));
                return;
            }
            
        }

        ar[0] = rightmost;
        Console.WriteLine(string.Join(" ", ar));
    }
    /* Tail starts here */
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

        int _ar_size = 5;
        int[] _ar = new int[_ar_size];
        _ar[0] = 2;
        _ar[1] = 4;
        _ar[2] = 6;
        _ar[3] = 8;
        _ar[4] = 1;

        insertionSort(_ar);
    }
}