using System;

namespace Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat is je naam?");
            string name = Console.ReadLine();
            Console.WriteLine("Welkom bij SoundSharp {0}", name);
        }
    }
}