using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/largest-rectangle
    // solution taken from http://www.geeksforgeeks.org/largest-rectangle-under-histogram/
    // lets consider an example: 1 3 2 1 2
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        string elements = Console.ReadLine();
        string[] split_elements = elements.Split(' ');
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Convert.ToInt32(split_elements[i]);
        }

        int result = FindTheLargestRectangle(array, n);
        Console.WriteLine(result);
    }

    static int FindTheLargestRectangle(int[] hist, int n)
    {
        // Create an empty stack. The stack holds indexes of hist[] array
        // The bars stored in stack are always in increasing order of their
        // heights.
        Stack<int> s = new Stack<int>();

        int max_area = 0; // Initalize max area
        int tp;  // To store top of stack
        int area_with_top; // To store area with top bar as the smallest bar

        // Run through all bars of given histogram
        int i = 0;
        while (i < n)
        {
            // If this bar is higher than the bar on top stack, push it to stack
            if (s.Count == 0 || hist[s.Peek()] <= hist[i])
                s.Push(i++);

            // If this bar is lower than top of stack, then calculate area of rectangle 
            // with stack top as the smallest (or minimum height) bar. 'i' is 
            // 'right index' for the top and element before top in stack is 'left index'
            else
            {
                tp = s.Peek();  // store the top index
                s.Pop();  // pop the top

                // Calculate the area with hist[tp] stack as smallest bar
                area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

                // update max area, if needed
                if (max_area < area_with_top)
                    max_area = area_with_top;
            }
        }

        // Now pop the remaining bars from stack and calculate area with every
        // popped bar as the smallest bar
        while (s.Count > 0)
        {
            tp = s.Peek();
            s.Pop();
            area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

            if (max_area < area_with_top)
                max_area = area_with_top;
        }

        return max_area;
    }
}