using System;
using System.Linq;
class Solution
{
    static int GetNumberOfWords(string input)
    {
        if (string.IsNullOrEmpty(input.Trim()))
            return 0;
        
        return input.Count(x => x.ToString() == x.ToString().ToUpper()) + 1;
    }

    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(GetNumberOfWords(s));
    }
}
