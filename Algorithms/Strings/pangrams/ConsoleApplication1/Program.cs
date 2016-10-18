using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        string input = Console.ReadLine();
        if (IsPangram(input))
            Console.WriteLine("pangram");
        else
            Console.WriteLine("not pangram");

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static bool IsPangram(string input)
    {
        const byte NumberOfLetters = 26;
        var uniqueLetters = new BitArray(NumberOfLetters);
        byte index = 0;
        byte aIndex = 97;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ' ')
                continue;

            byte symbol = Convert.ToByte(Char.ToLower(input[i]));
            index = Convert.ToByte(symbol - aIndex);
            uniqueLetters.Set(index, true);            
        }

        int numberOfSetBits =  
            (from bool m in uniqueLetters where m select m).Count();

        if (numberOfSetBits == NumberOfLetters)
            return true;
        else
            return false;
    }
}