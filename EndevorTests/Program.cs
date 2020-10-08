using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using BiLinkedList;

namespace EndevorTests
{
    class Program
    {
        static Action<object> Write = (content) => Console.WriteLine(content);
        static void Main(string[] args)
        {
            Write("Beginning...");
            BiLinkedList<int> list = new BiLinkedList<int>();

            list.ToList();

            Console.ReadLine();
        }
    }
}



