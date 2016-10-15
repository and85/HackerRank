using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution1
{
    //https://www.hackerrank.com/challenges/king-richards-knights  
    static void Main1(String[] args)
    {
        //int n;
        //List<Tuple<int, int, int>> commands;
        //List<int> knights;
        //ReadInput(out n, out commands, out knights);

        int n;
        List<long> knights;
        List<Tuple<int, int, int>> commands;
        TestCase0(out n, out knights, out commands);

        //int n;
        //List<Tuple<int, int, int>> commands;
        //List<long> knights;
        //ReadFromFile(out n, out commands, out knights);

        var positiosMap = new Dictionary<long, long>();

        PrintMatrix(n, positiosMap);

        foreach (var command in commands)
        {
            RotateMatrix(n, command, positiosMap);
            PrintMatrix(n, positiosMap);
            Console.ReadLine();
        }

        

        //int counterMinor = 0;
        //int counter = 0;
        //foreach (var command in commands)
        //{
        //    if (counterMinor == 100)
        //    {
        //        Console.Write("Completed %:");
        //        Console.WriteLine((double)counter / commands.Count * 100);
        //        counterMinor = 0;
        //    }

        //    RotateMatrix(n, command, positiosMap);
        //    counterMinor++;
        //    counter++;
        //}

        //Console.ReadLine();

        //string resultFile = @"D:\Projects\!GIT\HackerRank\KingRichardsKnights\testCases\output.txt";
        //if (File.Exists(resultFile))
        //    File.Delete(resultFile);

        Tuple<int, int> position;
        foreach (int knight in knights)
        {
            position = GetKnightPosition(knight, positiosMap, n);
            string resultLine = $"{ position.Item1} {position.Item2}";
            Console.WriteLine(resultLine);

            //using (StreamWriter file = new StreamWriter(resultFile, true))
            //{
            //    file.WriteLine(resultLine);
            //}
        }

        //PrintMatrix(battleField);
        //Console.WriteLine("END");
        //Console.ReadLine();
    }

    private static void ReadFromFile(out int n, out List<Tuple<int, int, int>> commands, out List<long> knights)
    {
        n = 0;
        string line;
        commands = new List<Tuple<int, int, int>>();
        knights = new List<long>();
        using (StreamReader file = 
            new StreamReader(@"D:\Projects\!GIT\HackerRank\KingRichardsKnights\testCases\input02.txt"))
        {
            n = int.Parse(file.ReadLine());
            int s = int.Parse(file.ReadLine());

            for (int i = 0; i < s; i++)
            {
                string[] command = file.ReadLine().Split(' ');
                commands.Add(new Tuple<int, int, int>(
                    int.Parse(command[0]),
                    int.Parse(command[1]),
                    int.Parse(command[2])));
            }

            int l = int.Parse(file.ReadLine());
            for (int i = 0; i < l; i++)
            {
                knights.Add(long.Parse(file.ReadLine()));
            }
        }
    }

    private static void TestCase0(out int n, out List<long> knights, out List<Tuple<int, int, int>> commands)
    {
        n = 7;
        int s = 4;
        int l = 7;
        knights = new List<long>() { 0, 6, 9, 11, 24, 25, 48 };
        commands = new List<Tuple<int, int, int>>();
        commands.Add(new Tuple<int, int, int>(1, 2, 4));
        commands.Add(new Tuple<int, int, int>(2, 3, 3));
        commands.Add(new Tuple<int, int, int>(3, 4, 1));
        commands.Add(new Tuple<int, int, int>(3, 4, 0));
    }

    private static void ReadInput(out int n, out List<Tuple<int, int, int>> commands, out List<int> knights)
    {
        n = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        commands = new List<Tuple<int, int, int>>();
        for (int i = 0; i < s; i++)
        {
            string command = Console.ReadLine();
            int[] commandsArray = command
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            commands.Add(new Tuple<int, int, int>
                (commandsArray[0], commandsArray[1], commandsArray[2]));
        }
        int l = int.Parse(Console.ReadLine());
        knights = new List<int>();
        for (int i = 0; i < l; i++)
        {
            knights.Add(int.Parse(Console.ReadLine()));
        }
    }

    private static void Initialise(int n, long[,] battleField)
    {
        for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            battleField[i, j] = i * n + j;
    }

    // O(n2) time complaxity, O(n) space complexity. Optimize?
    static void RotateMatrix(int n, Tuple<int, int, int> command, Dictionary<long, long> positiosMap)
    {
        //TODO: in fact I think we need to rotate only one knight who was chosen for a battle

        int row = command.Item1 - 1;
        int column = command.Item2 - 1;
        int borderRow = row + command.Item3;
        int borderColumn = column + command.Item3;

        int k, p = 0;
        long knight = 0, newPosition, oldPosition = 0;
        for (int i = row; i <= borderRow; i++)
        {
            k = 0;
            for (int j = column; j <= borderColumn; j++)
            {
                oldPosition = EncodePosition(borderRow - k, column + p, n);

                if (positiosMap.ContainsKey(oldPosition))
                {
                    knight = WhoIsAtPosition(oldPosition, positiosMap);
                }
                else
                    knight = oldPosition;

                newPosition = EncodePosition(i, j, n);

                if (positiosMap.ContainsKey(knight))
                    positiosMap[knight] = newPosition;
                else
                    positiosMap.Add(knight, newPosition);

                k++;
            }
            p++;
        }
    }

    static long WhoIsAtPosition(long position, Dictionary<long, long> positiosMap)
    {
        if (!positiosMap.Any(x => x.Value == position))
            return position;

        return positiosMap.First(x => x.Value == position).Key;
    }

    static long EncodePosition(int row, int column, int length)
    {
        return row * length + column;
    }

    static Tuple<int, int> DecodePosition(long value, int length)
    {
        long row = value / length + 1;
        long column = value % length + 1;

        return new Tuple<int, int>((int)row, (int)column);
    }

    // O(1)
    static Tuple<int, int> GetKnightPosition(long knight, Dictionary<long, long> positiosMap, int length)
    {
        if (positiosMap.ContainsKey(knight))
            return DecodePosition(positiosMap[knight], length);

        return DecodePosition(knight, length);
    }

    static void PrintMatrix(int n, Dictionary<long, long> positiosMap)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                long position = EncodePosition(i, j, n);
                long knight = WhoIsAtPosition(position, positiosMap);
                Console.Write(Convert.ToString(knight).PadRight(3));
            }

            Console.WriteLine();
        }

        Console.WriteLine("---------------------------------------");
    }
}