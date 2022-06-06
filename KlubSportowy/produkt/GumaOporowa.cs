using System;
using System.Collections.Generic;
using System.Text;

namespace KlubSportowy.produkt
{
    class GumaOporowa : Produkt, IProdukt
    {
        int dlugosc;

        int grubosc;

        int szerokosc;

        int opor;

        public GumaOporowa(double cenaSprzedarzy, double cenaProdukcji, int dlugosc, int grubosc, int szerokosc, int opor) : base(cenaSprzedarzy, cenaProdukcji)
        {
            this.dlugosc = dlugosc;
            this.grubosc = grubosc;
            this.szerokosc = szerokosc;
            this.opor = opor;
        }

        public static GumaOporowa dodajGumeOporowa()
        {
            Console.Write(" Podaj cenę produkcji: ");
            double cenaProdukcji = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            Console.Write(" Podaj cenę sprzedaży: ");
            double cenaSprzedazy = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            Console.Write(" Podaj długość (mm): ");
            int dlugosc = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);
            Console.Write(" Podaj grubość (mm): ");
            int grubosc = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);
            Console.Write(" Podaj szerokość (mm): ");
            int szerikosc = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);
            Console.Write(" Podaj opór (kg): ");
            int opor = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);


            return new GumaOporowa(cenaSprzedazy, cenaProdukcji, dlugosc, grubosc, szerikosc, opor);
        }

        public void wyswietlDaneProduktu()
        {
            Console.WriteLine(" Cena: " + Math.Round(cenaSprzedazy, 2) + "zł\t\tNa stanie: " + stanMagazynu + "\t\tDługość: " + dlugosc + "mm\t\tGrubość: " + grubosc + "mm\t\tSzerokość: " + szerokosc + "mm\t\tOpór: " + opor + "kg");
        }


    }
}
