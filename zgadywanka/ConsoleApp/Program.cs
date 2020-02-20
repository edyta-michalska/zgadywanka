using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("gra za dużo za malo");

            //1. komputer losuje
            #region losowanie //dodanie zwijania częsci 
            var los = new Random(); //tworze obiekt typu random
            int wylosowana = los.Next(1, 100 + 1);
#if DEBUG

            Console.WriteLine(wylosowana);
#endif   
            Console.WriteLine("wylosowalem liczbe od 1 do 100. \nOdgadnij ja.");  // \n przerzuca do kolejnej linii reszte tekstu taki enter
            #endregion


            //dopóki nie odgadniete
            bool odgadniete = false;
            while (! odgadniete)
            {
                //2. czlowiek proponuje

                Console.Write("podaj swoja propozycje: ");
                int propozycja = int.Parse(Console.ReadLine());


                //3.komputer ocenia

                if (propozycja < wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("za malo");
                    Console.ResetColor();
                }

                else
                    if (propozycja > wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Za dużo");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("trafiono");
                    Console.ResetColor();
                    odgadniete = true;

                    Console.WriteLine("koniec gry.");
                }

                
            }
    }   }    
}

