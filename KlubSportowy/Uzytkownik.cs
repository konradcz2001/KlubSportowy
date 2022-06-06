using KlubSportowy.karnet;
using System;

namespace KlubSportowy
{
    class Uzytkownik
    {
        private string imie, nazwisko;
        public Karnet karnet { get; set; }

        public Uzytkownik(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override string ToString()
        {
            if (karnet == null || karnet.termin.CompareTo(DateTime.Now) < 0)
            {
                karnet = null;
                return imie + " " + nazwisko + "   |   KARNET: brak";
            }
            else
                return imie + " " + nazwisko + "   |   KARNET: obowiązuje do " + karnet.termin;
        }
    }
}
