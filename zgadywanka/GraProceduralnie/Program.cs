using System;
using System.Diagnostics;

namespace GraProceduralnie
{
    class Program

    {
        const string zaduzo = "za duzo";
        const string zamalo = "za mało";
        const string trafiono = "trafiono";

        static void Main(string[] args)
        {
            Console.WriteLine("gra za dużo za malo");
            int a = WczytajLiczbe("podaj dolny zakres losowania: ");
            int b = WczytajLiczbe("podaj gorny zakres losowania : ");
            
            int wylosowana = Losuj(a, b);
#if DEBUG

            Console.WriteLine(wylosowana);
#endif
            int licznik = 0;
            var stoper = new Stopwatch();
            stoper.Start();
            while (true)
            {
                licznik++; // licznik += 1; //licznik = licznik + 1;
                int propozycja = WczytajLiczbe("podaj swoja propozycje lub x aby zakonczyc: ");

                string wynik = Ocena(wylosowana, propozycja);
                Console.WriteLine(wynik);
                if (wynik == trafiono)
                    break;
            }
            stoper.Stop();
            Console.WriteLine($"liczba ruchow = {licznik}");
            Console.WriteLine($"czas gry = {stoper.Elapsed}");
            Console.WriteLine("koniec gry");

        }
        /// <summary>
        /// losuje liczbe z podanego zakresu wlacznie
        /// </summary>
        /// <param name="min">dolne ograniczenie</param>
        /// <param name="max">gorne ograniczenie</param>
        /// <returns></returns>
        static int WczytajLiczbe(string prompt = "")
        {
            bool poprawnie = false;

            int wynik = 0;

            do
            {
                Console.Write(prompt);

                string wczytano = Console.ReadLine();
                if (wczytano == "X" || wczytano == "x")
                    Environment.Exit(0);


                try
                {
                    wynik = int.Parse(wczytano);
                    poprawnie = true;
                }

                catch (FormatException)
                {
                    Console.WriteLine("niepoprawny zapis liczby. sprobuj jeszcze raz");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("przekroczony zakres");
                }

                catch (Exception)
                {
                    Console.WriteLine("nieznany blad");
                }
            }
            while (!poprawnie);

            return wynik;
        }

        static int Losuj(int min = 1, int max = 100)
        {
            var min1 = Math.Min(min, max);
            var max1 = Math.Max(min, max);

            var rnd = new Random();
            var Los = rnd.Next(min1, max1 + 1);

            return Los;
        }


        static string Ocena(int wylosowana, int propozycja)
        {
            if(wylosowana < propozycja)
            {
                return zaduzo;
            }
            else if (wylosowana > propozycja)
            {
                return zamalo;
            }
            else 
            {
                return trafiono;
            }
        }


    }
}
