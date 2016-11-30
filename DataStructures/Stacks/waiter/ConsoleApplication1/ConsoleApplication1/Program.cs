using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // https://www.hackerrank.com/challenges/waiter
    class Program
    {
        static void Main(string[] args)
        {
            int q;
            string secondLine;
            ReadFromConsole(out q, out secondLine);

            var a = new Stack<int>[q + 1];
            var b = new Stack<int>[q + 1];
            Init(q, a, b);

            foreach (var plate in secondLine.Split(' '))
            {
                a[0].Push(int.Parse(plate));
            }

            var primes = GetPrimes(q);
            MovePlates(q, a, b, primes);

            PrintResult(b, q, a);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static List<int> GetPrimes(int q)
        {
            var resultPrimes = new List<int>(q);
            int i = 2;
            while (resultPrimes.Count < q)
            {
                while (!IsPrime(i))
                    i++;

                resultPrimes.Add(i);
                i++;
            }
            return resultPrimes;
        }

        private static void ReadFromConsole(out int q, out string secondLine)
        {
            string firstLine = Console.ReadLine();
            int n = int.Parse(firstLine.Split(' ')[0]);
            q = int.Parse(firstLine.Split(' ')[1]);
            secondLine = Console.ReadLine();
        }

        private static void MovePlates(int q, Stack<int>[] a, Stack<int>[] b, List<int> primes)
        {
            for (int i = 1; i <= q; i++)
            {
                Stack<int> currentStack = a[i - 1];
                while (currentStack.Count != 0)
                {
                    int currentPlate = currentStack.Pop();
                    if (IsInteger((double)currentPlate / primes[i - 1]))
                        b[i].Push(currentPlate);
                    else
                        a[i].Push(currentPlate);
                }
            }
        }

        private static void PrintResult(Stack<int>[] b, int q, Stack<int>[] a)
        {
            for (int i = 0; i <= q; i++)
            {
                while (b[i].Count != 0)
                    Console.WriteLine(b[i].Pop());
            }

            for (int i = 0; i <= q; i++)
            {
                while (a[i].Count != 0)
                    Console.WriteLine(a[i].Pop());
            }
        }

        private static void Init(int q, Stack<int>[] a, Stack<int>[] b)
        {
            for (int i = 0; i <= q; i++)
            {
                a[i] = new Stack<int>();
                b[i] = new Stack<int>();
            }
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static bool IsInteger(double d)
        {
            return d % 1 == 0;
        }
    }
}
