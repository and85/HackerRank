using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var n = long.Parse(Console.ReadLine());

            var number = GetNumber(s, n);
            Console.WriteLine(number);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static long GetNumber(string s, long n)
        {
            int initialOccurence = GetAOccurence(s);
            long sCount = n / s.Length;
            int sMod = (int)(n % s.Length);

            var part = s.Substring(0, sMod);
            var sModCount = GetAOccurence(part);

            return initialOccurence * sCount + sModCount;
        }

        private static int GetAOccurence(string s)
        {
            var result = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    result++;
            }

            return result;
        } 
    }
}
