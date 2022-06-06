using System;

namespace KlubSportowy.produkt
{
    public class Bialko : Produkt, IProdukt
    {
        string smak;

        int zawartoscBialka;

        int waga;

        public Bialko(double cenaSprzedarzy, double cenaProdukcji, string smak, int zawartoscBialka, int waga) : base(cenaSprzedarzy, cenaProdukcji)
        {
            this.smak = smak;
            this.zawartoscBialka = zawartoscBialka;
            this.waga = waga;   
        }

        public static Bialko dodajBialko()
        {
            var ceny = Produkt.dodajProdukt();
            Console.Write(" Podaj smak: ");
            string smak = Console.ReadLine();
            Console.Write(" Podaj zawartość białka (%): ");
            int zawartoscBialka = Produkt.sprawdzPoprawnoscWyboru(0, 100);
            Console.Write(" Podaj wagę (g): ");
            int waga = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);

            return new Bialko(ceny.Item1, ceny.Item2, smak, zawartoscBialka, waga);
        }


        public void wyswietlDaneProduktu()
        {
            Console.WriteLine(" Cena: " + Math.Round(cenaSprzedazy, 2) + "zł\t\tNa stanie: " + stanMagazynu + "\t\tSmak: " + smak + "\t\tZawartość białka: " + zawartoscBialka + "%\t\tWaga: " + waga + "g");
        }
    }
}
