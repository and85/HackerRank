using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int Partition(int[] input, int low, int high)
    {
        int pivot = input[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (input[j] <= pivot)
            {
                i++;
                Swap(input, i, j);
            }
        }
        Swap(input, i + 1, high);

        foreach (int element in input)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();

        return i + 1;
    }

    static void Swap(int[] ar, int i, int j)
    {
        int temp = ar[i];
        ar[i] = ar[j];
        ar[j] = temp;
    }

    static void QuickSortImpl(int[] ar, int low, int high)
    {
        int pivot_index = 0;

        if (low < high)
        {
            pivot_index = Partition(ar, low, high);
            QuickSortImpl(ar, low, pivot_index - 1);
            QuickSortImpl(ar, pivot_index + 1, high);
        }
    }

    static void quickSort(int[] ar)
    {
        int low = 0;
        int high = ar.Length - 1;

        QuickSortImpl(ar, low, high);
    }
    // https://www.hackerrank.com/challenges/quicksort3
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

        quickSort(_ar);

        
    }
}