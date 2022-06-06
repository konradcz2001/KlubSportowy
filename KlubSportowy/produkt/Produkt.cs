using System;
using System.Threading;

namespace KlubSportowy.produkt
{
    public abstract class Produkt
    {
        public static double kwotaSprzedazy { get; set; }

        public static double kwotaZainwestowana { get; set; }

        public double cenaSprzedazy { get; set; }

        protected double cenaProdukcji { get; set; }

        public int stanMagazynu { get; set; }

        protected Produkt(double cenaSprzedarzy, double cenaProdukcji)
        {
            this.cenaSprzedazy = cenaSprzedarzy;
            this.cenaProdukcji = cenaProdukcji;
            stanMagazynu = 0;
        }

        public void sprzedajProdukt(ref double stanKonta)
        {
            Console.Clear();
            if (stanMagazynu < 1)
            {
                Console.Write(  " Brak produktu w magazynie! Zamówić?\n" +
                                " 1. Tak\n" +
                                " 2. Nie\n\n" +
                                " Wybierz odpowiedni numer: ");
                int wybor = sprawdzPoprawnoscWyboru(1, 2);
                if(wybor == 1)
                    zamowProdukt(ref stanKonta);
            }
            else
            {
                Console.WriteLine(" Pomyślnie sprzedano");
                stanMagazynu--;
                kwotaSprzedazy += cenaSprzedazy;

                stanKonta += cenaSprzedazy;
                Thread.Sleep(1500);
            }
        }

        protected static int sprawdzPoprawnoscWyboru(int min, int max)
        {
            int wybor;

            while (!int.TryParse(Console.ReadLine(), out wybor) || wybor < min || wybor > max)
            {
                Console.Write(" Zły wybór! Spróbuj ponownie: ");
            }

            return wybor;
        }

        protected static double sprawdzPoprawnoscWyboru(double min, double max)
        {
            double wybor;

            while (!double.TryParse(Console.ReadLine(), out wybor) || wybor < min || wybor > max)
            {
                Console.Write(" Zły wybór! Spróbuj ponownie: ");
            }

            return wybor;
        }

        public void zamowProdukt(ref double stanKonta)
        {
            Console.Clear();
            Console.Write(  " Stan konta: " + Math.Round(stanKonta, 2) + "zł" +
                            "\n Cena produkcji: " + Math.Round(cenaProdukcji, 2) +
                            "\n Ile sztuk zamówić: ");

            int ilosc = 0;
            bool kontynuuj = true;

            while (kontynuuj)
            {
                if (!int.TryParse(Console.ReadLine(), out ilosc) || ilosc < 0)
                    Console.Write(" Spróbuj ponownie: ");
                else if (ilosc * cenaProdukcji > stanKonta)
                    Console.Write(" Brak wystarczających środków! Spróbuj ponownie: ");
                else
                    kontynuuj = false;
            }

            stanMagazynu += ilosc;
            stanKonta -= ilosc * cenaProdukcji;
            kwotaZainwestowana += ilosc * cenaProdukcji;

            Console.Clear();
            Console.WriteLine(  " Pomyślnie zamówiono sztuk: " + ilosc +
                                "\n Aktualny stan konta: " + Math.Round(stanKonta, 2) + "zł");
            Thread.Sleep(2000);
        }
    }
}
