using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/the-time-in-words
    // splution taken from https://github.com/dalves/hackerrank/blob/master/2015-03-14_Spring_CodeSprint/the-time-in-words.py
    static void Main(String[] args)
    {
        int h = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());

        string[] minutes = new string[]
        {
            "one minute",
            "two minutes",
            "three minutes",
            "four minutes",
            "five minutes",
            "six minutes",
            "seven minutes",
            "eight minutes",
            "nine minutes",
            "ten minutes",
            "eleven minutes",
            "twelve minutes",
            "thirteen minutes",
            "fourteen minutes",
            "quarter",
            "sixteen minutes",
            "seventeen minutes",
            "eighteen minutes",
            "nineteen minutes",
            "twenty minutes",
            "twenty one minutes",
            "twenty two minutes",
            "twenty three minutes",
            "twenty four minutes",
            "twenty five minutes",
            "twenty six minutes",
            "twenty seven minutes",
            "twenty eight minutes",
            "twenty nine minutes",
            "half"
        };

        string[] hours = new string[]
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve"
        };

        if (m == 0)
            Console.WriteLine(hours[h - 1] + " o' clock");
        else if (m <= 30)
            Console.WriteLine(minutes[m - 1] + " past " + hours[h - 1]);
        else
            Console.WriteLine(minutes[60 - m - 1] + " to " + hours[h]);

    }
}
