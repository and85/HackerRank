//#define CONSOLE
//#define TESTCASE0
#define READFROMFILE
//#define CONSOLEOUTPUT
#define FILEOUTPUT

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    //  
    static void Main(String[] args)
    {
#if (CONSOLE)
        int n;
        List<Tuple<int, int, int>> commands;
        List<int> knights;
        ReadConsole(out n, out commands, out knights);
#endif
#if (TESTCASE0)
        int n;
        List<long> knights;
        List<Tuple<int, int, int>> commands;
        TestCase0(out n, out knights, out commands);
#endif
#if (READFROMFILE)
        int n;
        List<Tuple<int, int, int>> commands;
        List<long> knights;
        ReadFromFile(out n, out commands, out knights);
#endif
#if FILEOUTPUT
        string resultFile = @"D:\Projects\!GIT\HackerRank\KingRichardsKnights\testCases\output.txt";
        if (File.Exists(resultFile))
            File.Delete(resultFile);
#endif
#if FILEOUTPUT
        using (StreamWriter file = new StreamWriter(resultFile, true))
        {
#endif
            var result = new List<string>();
            long lastPosition, previousPosition;
            Tuple<int, int> finalPosition;
            int row, column;
            string resultLine;
            int counter = 0;
            string cacheKey = "";
            foreach (int knight in knights)
            {
                Dictionary<string, long> cache = new Dictionary<string, long>();

                lastPosition = knight;
                previousPosition = knight;
                foreach (Tuple<int, int, int> command in commands)
                {
                    cacheKey = $"{previousPosition};{command.Item1};{command.Item2};{command.Item3}";
                    if (cache.ContainsKey(cacheKey))
                        lastPosition = cache[cacheKey];
                    else
                    {
                        lastPosition = MoveKnight(lastPosition, n, command);
                        cache.Add(cacheKey, lastPosition);
                    }

                    previousPosition = lastPosition;
                }

                finalPosition = DecodePosition(lastPosition, n);
                row = finalPosition.Item1 + 1;
                column = finalPosition.Item2 + 1;
                resultLine = $"{row} {column}";
                result.Add(resultLine);
                counter++;
            }
#if CONSOLEOUTPUT
            Console.WriteLine(string.Join(Environment.NewLine, result));
#endif
#if FILEOUTPUT
            file.WriteLine(string.Join(Environment.NewLine, result));
        }
#endif
    }

    private static long MoveKnight(long knightPosition, int length, Tuple<int, int, int> command)
    {
        int firstRow = command.Item1 - 1;
        int firstColumn = command.Item2 - 1;
        int borderRow = firstRow + command.Item3;
        int borderColumn = firstColumn + command.Item3;

        Tuple<int, int> oldPosition = DecodePosition(knightPosition, length);

        // rotate knight only if it's inside a range
        if (!IsInRange(firstRow, firstColumn, borderRow, borderColumn, oldPosition))
            return knightPosition;

        Tuple<int, int> position = DecodePosition(knightPosition, length);
        int newColumn = borderRow - position.Item1 + firstColumn;
        int newRow = position.Item2 - firstColumn + firstRow;

        long newPosition = EncodePosition(newRow, newColumn, length);
        return newPosition;
        //return newRow * length + newColumn;
    }

    private static bool IsInRange(int firstRow, int firstColumn, int borderRow, int borderColumn, Tuple<int, int> oldPosition)
    {
        return oldPosition.Item1 >= firstRow
                    && oldPosition.Item1 <= borderRow
                    && oldPosition.Item2 >= firstColumn
                    && oldPosition.Item2 <= borderColumn;
    }

    static Tuple<int, int> DecodePosition(long value, int length)
    {
        long row = value / length;
        long column = value % length;

        return new Tuple<int, int>((int)row, (int)column);
    }

    static long EncodePosition(int row, int column, int length)
    {
        return row * length + column;
    }

    private static void ReadFromFile(out int n, out List<Tuple<int, int, int>> commands, out List<long> knights)
    {
        n = 0;
        string line;
        commands = new List<Tuple<int, int, int>>();
        knights = new List<long>();
        using (StreamReader file =
            new StreamReader(@"D:\Projects\!GIT\HackerRank\KingRichardsKnights\testCases\input04.txt"))
        {
            n = int.Parse(file.ReadLine());
            int s = int.Parse(file.ReadLine());

            var buffer = new List<string>();

            for (int i = 0; i < s; i++)
            {
                string command = file.ReadLine();
                GetUnqueCommands(commands, buffer, command);
            }

            foreach (string item in buffer)
                AddCommand(commands, item);

            int l = int.Parse(file.ReadLine());
            for (int i = 0; i < l; i++)
            {
                knights.Add(long.Parse(file.ReadLine()));
            }
        }
    }

    private static void GetUnqueCommands(List<Tuple<int, int, int>> commands, List<string> buffer, string command)
    {
        if (buffer.Count > 0 && !buffer.Contains(command))
        {
            foreach (string item in buffer)
                AddCommand(commands, item);

            buffer.Clear();
        }
        buffer.Add(command);

        if (buffer.Count == 4)
            buffer.Clear();
    }

    private static void AddCommand(List<Tuple<int, int, int>> commands, string command)
    {
        string[] commandArray = command.Split(' ');
        commands.Add(new Tuple<int, int, int>(
            int.Parse(commandArray[0]),
            int.Parse(commandArray[1]),
            int.Parse(commandArray[2])));
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

    private static void ReadConsole(out int n, out List<Tuple<int, int, int>> commands, out List<int> knights)
    {
        n = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        commands = new List<Tuple<int, int, int>>();
        var buffer = new List<string>();
        for (int i = 0; i < s; i++)
        {
            string command = Console.ReadLine();

            GetUnqueCommands(commands, buffer, command);
        }

        foreach (string item in buffer)
            AddCommand(commands, item);

        int l = int.Parse(Console.ReadLine());
        knights = new List<int>();
        for (int i = 0; i < l; i++)
        {
            knights.Add(int.Parse(Console.ReadLine()));
        }
    }
}