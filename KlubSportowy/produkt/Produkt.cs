﻿using System;
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

        protected Produkt(double cenaSprzedazy, double cenaProdukcji)
        {
            this.cenaSprzedazy = cenaSprzedazy;
            this.cenaProdukcji = cenaProdukcji;
            stanMagazynu = 0;
        }

        protected static Tuple<double, double> dodajProdukt()
        {
            Console.Write(" Podaj cenę produkcji: ");
            double cenaProdukcji = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            Console.Write(" Podaj cenę sprzedaży: ");
            double cenaSprzedazy = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            return Tuple.Create(cenaSprzedazy, cenaProdukcji);
        }

        public void sprzedajProdukt(ref double stanKonta)
        {
            Console.Clear();
            Console.Write(" Ile sztuk zamówić: ");

            int ilosc = 0;
            bool kontynuuj = true;

            while (kontynuuj)
            {
                if (!int.TryParse(Console.ReadLine(), out ilosc) || ilosc < 0)
                    Console.Write(" Spróbuj ponownie: ");
                else
                    kontynuuj = false;
            }

            if (stanMagazynu < ilosc)
            {
                Console.Write(  " Brak danej ilości w magazynie! Zamówić?\n" +
                                " 1. Tak\n" +
                                " 2. Nie\n\n" +
                                " Wybierz odpowiedni numer: ");
                int wybor = sprawdzPoprawnoscWyboru(1, 2);
                if(wybor == 1)
                    zamowProdukt(ref stanKonta);
            }
            else
            {
                Console.WriteLine(" Pomyślnie sprzedano sztuk: " + ilosc);
                stanMagazynu -= ilosc;
                kwotaSprzedazy += cenaSprzedazy * ilosc;

                stanKonta += cenaSprzedazy * ilosc;
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
                            "\n Cena produkcji: " + Math.Round(cenaProdukcji, 2) + "zł" +
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
