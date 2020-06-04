using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Opdracht2
{
    public class Mp3Player
    {    
        // van private naar public, zodat de velden beschikbaar zijn in de class SoundSharp
        public int Id;
        public string Make;
        public string Model;
        public int Mbsize;
        public double Price;
        public int Stock;
        
        // Publiekelijke lijst:
        public static List<Mp3Player> PlayerList = new List<Mp3Player>();
        
        
        // constructor
        public Mp3Player(int id, string make, string model, int mbsize, double price, int stock)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Mbsize = mbsize;
            this.Price = price;
            this.Stock = stock;
        }

        public Mp3Player()
        {
            // Empty
        }

        //public static List<Mp3Player> Init()
        public static void Init()
        {
            // List<Mp3Player> l = new List<Mp3Player>();
            
            // te veel typen:
            Mp3Player m1 = new Mp3Player();
            m1.Id = 1;
            m1.Make = "GET technologies .inc";
            m1.Model = "HF 410";
            m1.Mbsize = 4096;
            m1.Price = 129.95;
            m1.Stock = 500;
            //l.Add(m1);
            // toevoegen aan de lijst die we nodig hebben
            Mp3Player.PlayerList.Add(m1);
            
            // minder typen:
            Mp3Player m2 = new Mp3Player(2, "Far & Loud", "XM 600", 8192, 224.95, 500);
            //l.Add(m2);
            Mp3Player.PlayerList.Add(m2);
            
            Mp3Player m3 = new Mp3Player(3, "Innotivative", "Z3", 512, 79.95, 500);
            //l.Add(m3);
            Mp3Player.PlayerList.Add(m3);
            Mp3Player m4 = new Mp3Player(4, "Resistance S.A.", "3001", 4069, 124.95, 500);
            //l.Add(m4);
            Mp3Player.PlayerList.Add(m4);
            Mp3Player m5 = new Mp3Player(5, "CBA", "NXT volume", 2048, 159.95, 500);
            //l.Add(m5);
            Mp3Player.PlayerList.Add(m5);
            
            //return l;
        }
    } 
    
    
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
                    // lijst vullen
                    Mp3Player.Init();
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
            Console.WriteLine("2. Overzicht voorraad");
            Console.WriteLine("3. Muteer voorraad");
            Console.WriteLine("4. Statistieken");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. Toon menu");
            Console.WriteLine("9. Exit");

            while (true)
            {
                menu = Console.ReadKey();
                //Console.WriteLine(menu.KeyChar);

                switch (menu.KeyChar)
                {
                    case '1':
                        Menu1();
                        break;
                    case '2':
                        Menu2();
                        break;
                    case '3':
                        Menu3();
                        break;
                    case '4':
                        Menu4();
                        break;
                    case '8':
                        ShowMenu();
                        break;
                    case '9':
                        Environment.Exit(1);
                        break;
                }
            }
        }

        public static void Menu1()
        {
            // Aangezien de init is geweest, is de lijst gevuld en dus toegangelijk hier. En omdat de velden publiek zijn
            // kunnen we ze hier aanpassen.
            foreach (Mp3Player m in Mp3Player.PlayerList)
            {
                Console.WriteLine("[{0}] {1} - {2}: {3}Mb @ €{4}", m.Id, m.Make, m.Model, m.Mbsize, m.Price);
            }
        }
        public static void Menu2()
        {
            foreach (Mp3Player m in Mp3Player.PlayerList)
            {
                Console.WriteLine("[{0}] {1}", m.Id, m.Stock);
            }
        }

        public static void Menu3()
        {
            // voer ID in
            // fout: ID kan niet bestaan
            
            int id = 0;
            bool exists = false;
            int mutation = 0;
            Mp3Player temp = new Mp3Player();
            
            Console.WriteLine("Voer een id in:");
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Fout id!");
                Menu3();
            }

            foreach (Mp3Player m in Mp3Player.PlayerList)
            {
                if (m.Id == id)
                {
                    // bestaat!
                    exists = true;
                    temp = m;
                    break;
                }
            }

            if (!exists)
            {
                Console.WriteLine("Ingevoerde id bestaat niet!");
                Menu3();
            }

            // mutatie vragen
            // fout: kan geen nummer zijn.
            Console.WriteLine("Voer mutatie in:");
            try
            {
                mutation = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Foute mutatie");
                Menu3();
            }
            
            // mutatie controleren
            // fout: niet onder de 0.
            if (temp.Stock + mutation < 0)
            {
                Console.WriteLine("Mutatie niet uitgevoerd: voorraad mag niet negatief worden.");
                Menu3();
            }
            
            // mutatie uitvoeren
            // Console.WriteLine("Mutatie: {0}", mutation);
            foreach (Mp3Player m in Mp3Player.PlayerList)
            {
                if (m.Id == id)
                {
                    m.Stock += mutation;
                    break;
                }
            }

            Console.WriteLine("Mutatie uitgevoerd");
        }

        public static void Menu4()
        {
            int totalstock = Mp3Player.PlayerList.Sum(x => x.Stock);
            double totalvalue = Mp3Player.PlayerList.Sum(x => x.Stock * x.Price);
            double avaragevalue = Mp3Player.PlayerList.Average(x => x.Price);
            
            Console.WriteLine("Totaal aantal mp3 spelers in voorraad: {0}", totalstock);
            Console.WriteLine("Totale waarde mp3 spelers in voorraad: €{0}", totalvalue);
            Console.WriteLine("Gemiddelde prijs mp3 speler: €{0}", avaragevalue);
            
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            //List<Mp3Player> Mp3Players = new List<Mp3Player>();
            //Mp3Players = Mp3Player.Init();
            
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