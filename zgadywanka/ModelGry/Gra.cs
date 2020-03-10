using System;
using System.Collections.Generic;

namespace ModelGry
{
    public class Gra
    {

        //dane
        private readonly int wylosowana; //dane są wylosowane bez możliwosci zmiany przez komp. 
        public StanGry Stan { get; private set; }

        public List<Ruch> HistoriaGry { get; }



        //metody

        public Gra(int a = 1, int b = 100)
        {
            Random rnd = new Random();
            wylosowana = rnd.Next(a, b + 1);
            Stan = StanGry.Trwa;
            HistoriaGry = new List<Ruch>();  //utworzyć i zainicjować wszystkie rzeczy
        }

        public int Wylosowana  //lub get można zapisać w formie  public int Wylosowana => wylosowana;
        {
            get
            {
                if (Stan == StanGry.Zakonczona)
                    return wylosowana;
                else
                    throw new NotSupportedException("w trakcie gry nie dostaniesz tej informacji");
            }
        }

        public Odp Odpowiedz(int propozycja)
        {
            
            if (wylosowana > propozycja)
            {
                HistoriaGry.Add(new Ruch(propozycja, Odp.ZaMalo));
                return Odp.ZaMalo;
            }
            if (wylosowana < propozycja)
            {
                HistoriaGry.Add(new Ruch(propozycja, Odp.ZaDuzo));

                return Odp.ZaDuzo;
            }

            else
            {
                HistoriaGry.Add(new Ruch(propozycja, Odp.Trafiono));
                Stan = StanGry.Zakonczona;
                return Odp.Trafiono;
            }

        }
        public void Poddaj()
        {
            Stan = StanGry.Zakonczona;

        }



    }
    public enum StanGry //opisuje stany gry
    {
        Rozpoczeta,
        Trwa,
        Zapauzowana,
        Zakonczona
    }
    public enum Odp
    {
        ZaMalo = -1,
        Trafiono = 0,
        ZaDuzo = 1
    }
}
