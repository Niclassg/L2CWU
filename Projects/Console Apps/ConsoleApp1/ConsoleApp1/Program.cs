using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            DateTime time;

            Console.WriteLine("What is your name? ");
            name = Console.ReadLine();
            time = DateTime.Now;
            Console.WriteLine($"Hello {name}, the time is now: {time.Date} at {time.TimeOfDay}");
        }
    }
}
