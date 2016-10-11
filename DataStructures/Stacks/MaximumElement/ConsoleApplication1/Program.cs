using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    private static Stack<long> _stack = new Stack<long>();
    private static Stack<long> _maxStack = new Stack<long>();

    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var commands = new List<string>();
        for (int i = 0; i < n; i++)
            commands.Add(Console.ReadLine());

        string[] command;
        long element;
        foreach (string item in commands)
        {
            command = item.Split(' ');

            switch (command[0])
            {
                case "1":
                    element = long.Parse(command[1]);
                    Push(element);
                    break;
                case "2":
                    Remove();
                    break;
                case "3":
                    Console.WriteLine(GetMax());
                    break;
                default:
                    break;
            }
        }

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static void Push(long x)
    {
        _stack.Push(x);

        if (_maxStack.Count == 0 || x >= _maxStack.Peek())
        {
            _maxStack.Push(x);
        }
    }

    static void Remove()
    {
        long x = _stack.Pop();

        if (x == _maxStack.Peek())
            _maxStack.Pop();
    }

    static long GetMax()
    {
        return _maxStack.Peek();
    }
}