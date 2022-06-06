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
            Console.Write(" Podaj cenę produkcji: ");
            double cenaProdukcji = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            Console.Write(" Podaj cenę sprzedaży: ");
            double cenaSprzedazy = Produkt.sprawdzPoprawnoscWyboru(0, double.MaxValue);
            Console.Write(" Podaj smak: ");
            string smak = Console.ReadLine();
            Console.Write(" Podaj zawartość białka (%): ");
            int zawartoscBialka = Produkt.sprawdzPoprawnoscWyboru(0, 100);
            Console.Write(" Podaj wagę (g): ");
            int waga = Produkt.sprawdzPoprawnoscWyboru(0, int.MaxValue);

            return new Bialko(cenaSprzedazy, cenaProdukcji, smak, zawartoscBialka, waga);
        }


        public void wyswietlDaneProduktu()
        {
            Console.WriteLine(" Cena: " + Math.Round(cenaSprzedazy, 2) + "zł\t\tNa stanie: " + stanMagazynu + "\t\tSmak: " + smak + "\t\tZawartość białka: " + zawartoscBialka + "%\t\tWaga: " + waga + "g");
        }
    }
}
