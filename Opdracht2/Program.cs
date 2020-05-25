using System;
using System.Security.Cryptography;

namespace Opdracht2
{
    public static class SoundSharp
    {
        public enum Status
        {
            OK,
            NietOK,
            Onbekend
        }

        private const string MainPassword = "";
        private const int MaxTries = 3;

        public static Status LogIn()
        {
            int tries = 1;
            while (tries <= MaxTries)
            {
                if (tries > 1)
                {
                    Console.WriteLine("Poging {0} van {1}", tries, MaxTries);
                }

                if (tries == MaxTries)
                {
                    Console.WriteLine("LET OP: Laatste poging!");
                }
                
                Console.WriteLine("Wachtwoord?");
                string pass = Console.ReadLine();

                if (pass == MainPassword)
                {
                    return Status.OK;
                }
                else
                {
                    tries++;
                }
                
            }
            
            return Status.Onbekend;
        }

        public static void ShowMenu()
        {
            ConsoleKeyInfo menu = new ConsoleKeyInfo();
            
            Console.Clear();

            Console.WriteLine("ShoundSharp MainMenu");
            Console.WriteLine();
            Console.WriteLine("1. Overzicht mp3 spelers");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
            Console.WriteLine("9. Exit");

            while (true)
            {
                menu = Console.ReadKey();
                //Console.WriteLine(menu.KeyChar);

                switch (menu.KeyChar)
                {
                    case '9':
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Naam?");
            string name = Console.ReadLine();
            
            SoundSharp.Status status = SoundSharp.LogIn();

            Console.Clear();
            
            switch (status)
            {
                case SoundSharp.Status.OK:
                    Console.WriteLine("Welkom bij SoundSharp {0}", name);
                    SoundSharp.ShowMenu();
                    break;
                case SoundSharp.Status.NietOK:
                    Console.WriteLine("Wachtwoord fout!");
                    break;
                case SoundSharp.Status.Onbekend:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}