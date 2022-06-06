using System;

namespace KlubSportowy.produkt
{
    class Kreatyna : Produkt, IProdukt
    {
        string rodzaj;

        int waga;

        public Kreatyna(double cenaSprzedarzy, double cenaProdukcji, string rodzaj, int waga) : base(cenaSprzedarzy, cenaProdukcji)
        {
            this.waga = waga;
            this.rodzaj = rodzaj;
        }

        public static Kreatyna dodajKreatyne()
        {
            var ceny = Produkt.dodajProdukt();
            Console.Write(" Podaj rodzaj: ");
            string rodzaj = Console.ReadLine();
            Console.Write(" Podaj wagę (g): ");
            int waga = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);

            return new Kreatyna(ceny.Item1, ceny.Item2, rodzaj, waga);
        }

        public void wyswietlDaneProduktu()
        {
            Console.WriteLine(" Cena: " + Math.Round(cenaSprzedazy, 2) + "zł\t\tNa stanie: " + stanMagazynu + "\t\tRodzaj: " + rodzaj + "\t\tWaga: " + waga + "g");
        }


    }
}
