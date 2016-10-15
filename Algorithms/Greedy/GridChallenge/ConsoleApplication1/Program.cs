using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/grid-challenge
    static void Main(String[] args)
    {
        int t = int.Parse(Console.ReadLine());
        int n;

        var testCases = new TestCase[t];

        for (int i = 0; i < t; i++)
        {
            n = int.Parse(Console.ReadLine());
            testCases[i] = new TestCase();
            testCases[i].Length = n;
            testCases[i].InputSet = new List<string>();

            for (int j = 0; j < n; j++)
            {
                testCases[i].InputSet.Add(Console.ReadLine());
            }
        }

        //TestCase[] testCases = TestCase0();
        //TestCase[] testCases = TestCase2();

        PrintResults(testCases);

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    // YES
    private static TestCase[] TestCase0()
    {
        var testCases = new TestCase[1];
        testCases[0] = new TestCase();
        testCases[0].Length = 5;
        testCases[0].InputSet = new List<string>();
        testCases[0].InputSet.Add("ebacd");
        testCases[0].InputSet.Add("fghij");
        testCases[0].InputSet.Add("olmkn");
        testCases[0].InputSet.Add("trpqs");
        testCases[0].InputSet.Add("xywuv");
        return testCases;
    }

    // YES
    // NO
    // YES
    private static TestCase[] TestCase2()
    {
        var testCases = new TestCase[3];
        testCases[0] = new TestCase();
        testCases[0].Length = 3;
        testCases[0].InputSet = new List<string>();
        testCases[0].InputSet.Add("ppp");
        testCases[0].InputSet.Add("ypp");
        testCases[0].InputSet.Add("wyw");

        testCases[1] = new TestCase();
        testCases[1].Length = 5;
        testCases[1].InputSet = new List<string>();
        testCases[1].InputSet.Add("lyivr");
        testCases[1].InputSet.Add("jgfew");
        testCases[1].InputSet.Add("uweor");
        testCases[1].InputSet.Add("qxwyr");
        testCases[1].InputSet.Add("uikjd");

        testCases[2] = new TestCase();
        testCases[2].Length = 1;
        testCases[2].InputSet = new List<string>();
        testCases[2].InputSet.Add("l");

        return testCases;
    }

    static void PrintResults(TestCase[] testCases)
    {
        bool canSwap;
        
        for (int i = 0; i < testCases.Length; i++)
        {
            canSwap = CanSwapGrid(testCases, i);

            if (canSwap)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    private static bool CanSwapGrid(TestCase[] testCases, int testCaseNumber)
    {
        for (int j = 0; j < testCases[testCaseNumber].Length; j++)
        {
            char curMin = (char)127;
            char prevMin = (char)0;

            foreach (string item in testCases[testCaseNumber].InputSet)
            {
                curMin = FindMinCode(item, j);
                if (curMin < prevMin)
                    return false;

                prevMin = curMin;
            }
        }

        return true;
    }

    static char FindMinCode(string input, int minShift)
    {
        char[] sortedArray = input.ToCharArray();
        Array.Sort(sortedArray);

        return sortedArray[minShift];
    }

    class TestCase
    {
        internal int Length { get; set; }
        internal List<string> InputSet { get; set; }
    }
}