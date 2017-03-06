using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/equal-stacks
    static void Main(String[] args)
    {
        string[] tokens_n1 = Console.ReadLine().Split(' ');
        int n1 = Convert.ToInt32(tokens_n1[0]);
        int n2 = Convert.ToInt32(tokens_n1[1]);
        int n3 = Convert.ToInt32(tokens_n1[2]);
        string[] h1_temp = Console.ReadLine().Split(' ');
        int[] h1 = Array.ConvertAll(h1_temp, Int32.Parse);
        string[] h2_temp = Console.ReadLine().Split(' ');
        int[] h2 = Array.ConvertAll(h2_temp, Int32.Parse);
        string[] h3_temp = Console.ReadLine().Split(' ');
        int[] h3 = Array.ConvertAll(h3_temp, Int32.Parse);

        var cylinders = new Cylinder[3] { new Cylinder(0), new Cylinder(1), new Cylinder(2) };
        Init(cylinders[0], h1);
        Init(cylinders[1], h2);
        Init(cylinders[2], h3);

        int highestIndex = 0;
        while (true)
        {
            highestIndex = FindHighestIndex(cylinders);
            if (highestIndex == -1)
            {
                // at the end all cylinders are equal
                Console.WriteLine(cylinders[0].Height);
                break;
            }

            int element = cylinders[highestIndex].Stack.Pop();
            cylinders[highestIndex].Height -= element;
        }

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif

    }

    private static void Init(Cylinder cylinder, int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            cylinder.Height += arr[i];
            cylinder.Stack.Push(arr[i]);
        }
    }

    // returns -1 when all cylinders are equal
    private static int FindHighestIndex(Cylinder[] cylinders)
    {
        int result = -1;

        // check that all cylinders are not equal
        if (cylinders.Select(x => x.Height).Distinct().Skip(1).Any())
        {
            // find the highest cylinder
            result = cylinders.OrderByDescending(item => item.Height).First().Index;
        }

        return result;
    }

    class Cylinder
    {
        public Cylinder(int index)
        {
            Index = index;
        }

        public int Index { get; private set; }
        public int Height { get; set; }
        public Stack<int> Stack { get; set; } = new Stack<int>();
    }
}
