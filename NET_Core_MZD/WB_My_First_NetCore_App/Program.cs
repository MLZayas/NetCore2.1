using System;

namespace WB_My_First_NetCore_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Kabel!");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
