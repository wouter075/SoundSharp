using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Opdracht2
{
    public class Mp3Player
    {
        private int Id;
        private string Make;
        private string Model;
        private int Mbsize;
        private double Price;
        
        // constructor
        public Mp3Player(int id, string make, string model, int mbsize, double price)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Mbsize = mbsize;
            this.Price = price;
        }

        public Mp3Player()
        {
            // Empty
        }

        public static List<Mp3Player> Init()
        {
            List<Mp3Player> l = new List<Mp3Player>();
            
            // te veel typen:
            Mp3Player m1 = new Mp3Player();
            m1.Id = 1;
            m1.Make = "GET technologies .inc";
            m1.Model = "HF 410";
            m1.Mbsize = 4096;
            m1.Price = 129.95;
            l.Add(m1);
            
            // minder typen:
            Mp3Player m2 = new Mp3Player(2, "Far & Loud", "XM 600", 8192, 224.95);
            l.Add(m2);
            
            Mp3Player m3 = new Mp3Player(3, "Innotivative", "Z3", 512, 79.95);
            l.Add(m3);
            Mp3Player m4 = new Mp3Player(4, "Resistance S.A.", "3001", 4069, 124.95);
            l.Add(m4);
            Mp3Player m5 = new Mp3Player(5, "CBA", "NXT volume", 2048, 159.95);
            l.Add(m5);
            
            return l;
        }
    } 
    
    
    public static class SoundSharp
    {
        public static List<Mp3Player> Mp3Players = new List<Mp3Player>();

                
        
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

        public static void Menu1()
        {
            
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