using System;
using System.Collections.Generic;

namespace nap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PeliInfot();
            PeliTervehdys();

            // Lista
            List<int> arvausLista = new List<int>();

            while (true)
            {
                // Muuttujat
                int arvaukset = 1,
                    pienempi = 0,
                    suurempi = 0;
                int voittavaNumero,
                    arvausInt;
                string arvausStr;

                // Random
                Random random = new Random();
                voittavaNumero = random.Next(1, 101);

                // Pelin aloitus
                Console.Write("Arvaa numero 1-100 väliltä >> ");
                arvausStr = Console.ReadLine();
                // Tarkistus, että käytetään vain numeroita
                if (!int.TryParse(arvausStr, out arvausInt))
                {
                    VariViesti(ConsoleColor.Red, "Hei pliis, käytä vain lukuja.");
                    Console.WriteLine();
                    continue;
                }
                arvausInt = Convert.ToInt16(arvausStr);
                // Lisää listalle
                arvausLista.Add(arvausInt);

                // Kysymyslooppi
                while (arvausInt != voittavaNumero)
                {
                    while (arvausInt < voittavaNumero)
                    {
                        VariViesti(ConsoleColor.Red, "Väärin, luku on suurempi kuin arvaus.");
                        Console.Write("\nArvaa uudestaan >> ");
                        arvausStr = Console.ReadLine();
                        // Tarkistus, että käytetään vain numeroita
                        if (!int.TryParse(arvausStr, out arvausInt))
                        {
                            VariViesti(ConsoleColor.Red, "Hei pliis, käytä vain lukuja.");
                            Console.WriteLine();
                            continue;
                        }
                        arvausInt = Convert.ToInt16(arvausStr);
                        // Yritykset
                        ++arvaukset;
                        ++pienempi;
                        // Lisää listalle
                        arvausLista.Add(arvausInt);
                    }
                    while (arvausInt > voittavaNumero)
                    {
                        VariViesti(ConsoleColor.Red, "Väärin, luku on pienempi kuin arvaus.");
                        Console.Write("\nArvaa uudestaan >> ");
                        arvausStr = Console.ReadLine();
                        // Tarkistus, että käytetään vain numeroita
                        if (!int.TryParse(arvausStr, out arvausInt))
                        {
                            VariViesti(ConsoleColor.Red, "Hei pliis, käytä vain lukuja.");
                            Console.WriteLine();
                            continue;
                        }
                        arvausInt = Convert.ToInt16(arvausStr);
                        // Yritykset
                        ++arvaukset;
                        ++suurempi;
                        // Lisää listalle
                        arvausLista.Add(arvausInt);
                    }
                }

                // Pelin lopetus
                Console.WriteLine();
                VariViesti(ConsoleColor.Green, "Oikein, olet päihittänyt mahtavan numerovelhon!");
                Console.WriteLine();
                VariViesti(ConsoleColor.DarkYellow, "Statistiikka:");
                Console.WriteLine();
                Console.WriteLine("Arvasit {0} kertaa. Oikea numero oli kuin olikin {1}!", arvaukset, voittavaNumero);
                Console.WriteLine();
                // Lista
                for (int i = 0; i < arvausLista.Count; i++)
                {
                    Console.WriteLine("Arvauksesi numero {0} oli: {1}", i + 1, arvausLista[i]);
                }
                Console.WriteLine();

                // Uusi peli?
                VariViesti(ConsoleColor.Yellow, "Haluatko pelata uudestaan? [K vai E]");
                string uusiPeli = Console.ReadLine().ToUpper();
                if (uusiPeli == "K")
                {
                    continue;
                }
                else if (uusiPeli == "E")
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        // Pelin esittely funktio
        static void PeliInfot()
        {
            // Muuttujat
            string pelinNimi = "Numeronarvauspeli";
            string pelinVersio = "1.0 Beta";
            string pelinTekija = "Ari Leskinen";

            // Tekstin väri
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Esittely
            Console.WriteLine("{0} v. {1}, luonut: {2}", pelinNimi, pelinVersio, pelinTekija);
            Console.WriteLine();

            // Tekstin värin nollaus
            Console.ResetColor();
        }

        // Pelitervehdys funktio
        static void PeliTervehdys()
        {
            // Pelaajan nimi
            VariViesti(ConsoleColor.Yellow, "Mikä on nimesi?");
            string pelaajanNimi = Console.ReadLine();
            Console.WriteLine();

            // Tervehdys
            VariViesti(ConsoleColor.Yellow, "Heippa " + pelaajanNimi + "! Aloitetaan peli...");
            Console.WriteLine();
        }

        // Teksin värin muunnin funktio
        static void VariViesti(ConsoleColor vari, string viesti)
        {
            // Tekstin väri
            Console.ForegroundColor = vari;

            // Viesti
            Console.WriteLine(viesti);

            // Tekstin värin nollaus
            Console.ResetColor();
        }
    }
}
