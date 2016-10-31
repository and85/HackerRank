using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/time-conversion
    static void Main(String[] args)
    {
        string time = Console.ReadLine();
        DateTime dateTime = DateTime.Parse(time, CultureInfo.InvariantCulture);
        string result = dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

        Console.WriteLine(result);
    }
}
