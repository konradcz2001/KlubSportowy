using System;
using System.Threading;

namespace KlubSportowy.karnet
{
    abstract class Karnet
    {
        public static double kwotaSprzedazy { get; set; }

        public DateTime termin { get; }

        protected Karnet(int dni)
        {
            termin = DateTime.Now.AddDays(dni);
        }

        public static Karnet wybierzRodzaj(ref double stanKonta)
        {
            Console.Write(  " Wybierz rodzaj karnetu: " +
                            "\n 1. Normalny " +
                            "\n 2. Ulgowy " + 
                            "\n\n Wybierz odpowiedni numer: ");

            Karnet karnet = null;
            switch (sprawdzPoprawnoscWyboru(2))
            {
                case 1:
                    karnet = new Normalny(wybierzOkres(true, ref stanKonta));
                    break;
                case 2:
                    karnet = new Ulgowy(wybierzOkres(false, ref stanKonta));
                    break;
            }

            Console.Clear();
            Console.WriteLine(" Pomyślnie sprzedano");
            Thread.Sleep(1500);
            return karnet;
        }

        private static int wybierzOkres(bool normalny, ref double stanKonta)
        {
            Console.Clear();
            Console.WriteLine(" Wybierz okres karnetu: ");

            if (normalny)
            {
                Console.WriteLine(  " 1. 1 dzień\tCena: " + Math.Round(Normalny.cenaZaDzien, 2) + "zł" +
                                    "\n 2. 30 dni\tCena: " + Math.Round(Normalny.cenaZa30Dni, 2) + "zł" +
                                    "\n 3. 365 dni\tCena: " + Math.Round(Normalny.cenaZaRok, 2) + "zł");
            }
            else
            {
                Console.WriteLine(" 1. 1 dzień\tCena: " + Math.Round(Ulgowy.cenaZaDzien, 2) + "zł" +
                                    "\n 2. 30 dni\tCena: " + Math.Round(Ulgowy.cenaZa30Dni, 2) + "zł" +
                                    "\n 3. 365 dni\tCena: " + Math.Round(Ulgowy.cenaZaRok, 2) + "zł");
            }
            Console.Write("\n Wybierz odpowiedni numer: ");

            switch (sprawdzPoprawnoscWyboru(3))
            {
                case 1:
                    if (normalny)
                    {
                        kwotaSprzedazy += Normalny.cenaZaDzien;
                        stanKonta += Normalny.cenaZaDzien;
                    }
                    else
                    {
                        kwotaSprzedazy += Ulgowy.cenaZaDzien;
                        stanKonta += Ulgowy.cenaZaDzien;
                    }
                    return 1;
                case 2:
                    if (normalny)
                    {
                        kwotaSprzedazy += Normalny.cenaZa30Dni;
                        stanKonta += Normalny.cenaZa30Dni;
                    }
                    else
                    {
                        kwotaSprzedazy += Ulgowy.cenaZa30Dni;
                        stanKonta += Ulgowy.cenaZa30Dni;
                    }
                    return 30;
                case 3:
                    if (normalny)
                    {
                        kwotaSprzedazy += Normalny.cenaZaRok;
                        stanKonta += Normalny.cenaZaRok;
                    }
                    else
                    {
                        kwotaSprzedazy += Ulgowy.cenaZaRok;
                        stanKonta += Ulgowy.cenaZaRok;
                    }
                    return 365;
            }
            return 0;
        }

        private static int sprawdzPoprawnoscWyboru(int max)
        {
            int wybor;

            while (!int.TryParse(Console.ReadLine(), out wybor) || wybor < 1 || wybor > max)
            {
                Console.Write(" Zły wybór! Spróbuj ponownie: ");
            }

            return wybor;
        }
    }
}
