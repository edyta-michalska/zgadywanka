using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("gra za dużo za malo");
            //1. komputer losuje

            Random los = new Random(); //tworze obiekt typu random
            int wylosowana = los.Next(1, 100+1);
            Console.WriteLine(wylosowana);
            Console.WriteLine("wylosowalem liczbe od 1 do 100. \nOdgadnij ja.");  // \n przerzuca do kolejnej linii reszte tekstu


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

            
            }
        }
    }
}
