using System;


namespace EndevorTests
{
    class Program
    {
        static Action<object> Write = (content) => Console.WriteLine(content);
        static void Main(string[] args)
        {
            Write("Beginning...");
            UniLinkedList<int> list = new UniLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            var t = list.GetAllData();

            foreach (int item in t)
            {
                Write(item);
            }

            Console.ReadLine();
        }
    }
}



