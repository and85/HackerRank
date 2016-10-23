using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/simple-text-editor
    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        string[] command;

        for (int i = 0; i < q; i++)
        {
            command = Console.ReadLine().Split(' ');
            switch (command[0])
            {
                case "1":
                    Append(command[1]);
                    break;
                case "2":
                    Delete(Convert.ToInt32(command[1]));
                    break;
                case "3":
                    Print(Convert.ToInt32(command[1]));
                    break;
                case "4":
                    Undo();
                    break;
            }
        }
    }

    static string _internalString = string.Empty;
    static Stack<string> _internalStates = new Stack<string>();

    static void Append(string w)
    {
        _internalStates.Push(_internalString);
        _internalString += w;
    }

    static void Delete(int k)
    {
        _internalStates.Push(_internalString);
        _internalString = _internalString.Remove(_internalString.Length - k);
    }

    static void Print(int k)
    {
        Console.WriteLine(_internalString[k - 1]);
    }

    static void Undo()
    {
        _internalString = _internalStates.Pop();
    }
}