using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int q = int.Parse(Console.ReadLine());

        var queue = new MyQueue();
        string command;
        string[] arguments;
        for (int i = 0; i < q; i++)
        {
            command = Console.ReadLine();
            arguments = command.Split(' ');
            switch (arguments[0])
            {
                case "1":
                    queue.Enqueue(long.Parse(arguments[1]));
                    break;
                case "2":
                    queue.Dequeue();
                    break;
                case "3":
                    queue.Print();
                    break;
            }
        }

        Console.WriteLine("END");
        Console.ReadLine();
    }

    class MyQueue
    {
        

        Stack<long> _stack1 = new Stack<long>();
        Stack<long> _stack2 = new Stack<long>();

        public void Enqueue(long x)
        {
            _stack1.Push(x);
        }

        public void Dequeue()
        {
            if (_stack2.Count > 0)
            {
                _stack2.Pop();
                return;
            }

            while (_stack1.Count > 0)
                _stack2.Push(_stack1.Pop());

            _stack2.Pop();
        }

        public void Print()
        {
            if (_stack2.Count > 0)
            {
                Console.WriteLine(_stack2.Peek());
                return;
            }

            while (_stack1.Count > 0)
                _stack2.Push(_stack1.Pop());

            Console.WriteLine(_stack2.Peek());
        }
    }
}