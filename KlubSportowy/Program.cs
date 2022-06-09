using KlubSportowy.produkt;
using KlubSportowy.karnet;
using System;
using System.Collections.Generic;
using System.Threading;

namespace KlubSportowy
{
    class Program
    {
        private static List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();
        private static List<Bialko> bialka = new List<Bialko>();
        private static List<Kreatyna> kreatyny = new List<Kreatyna>();
        private static List<GumaOporowa> gumyOporowe = new List<GumaOporowa>();
        private static double stanKonta = 1000;
        static void Main(string[] args)
        {
            bool kontynuuj = true;
            generujProdukty();

            while (kontynuuj)
            {
                wyswietlMenuGlowne();
                int wybor = sprawdzPoprawnoscWyboru(9);
                Console.Clear();

                switch (wybor)
                {
                    case 1: 
                        dodajUzytkownika();
                        break;
                    case 2:
                        usunUzytkownika();
                        break;
                    case 3:
                        wyswietlListeUzytkownikow();
                        pobierzDowolnyKlawisz();
                        break;
                    case 4:
                        sprzedajKarnet();
                        break;
                    case 5:
                        sprzedajProdukt();
                        break;
                    case 6:
                        zamowProdukt();
                        break;
                    case 7:
                        edytujLubDodajNowyProdukt();
                        break;
                    case 8:
                        wyswietlFinanse();
                        break;
                    case 9:
                        kontynuuj = false;
                        break;
                }

                Console.Clear();
            }
        }

        private static void edytujLubDodajNowyProdukt()
        {
            Console.Write(" 1. Edytuj stary\n" +
                            " 2. Dodaj nowy\n\n" +
                            " Wybierz odpowiedni numer: ");

            int wybor = sprawdzPoprawnoscWyboru(2);
            Console.Clear();
            if (wybor == 1)
            {
                switch (wybierzRodzajProduktu())
                {
                    case 1:
                        bialka[wybierzBialko()] = Bialko.dodajBialko();
                        break;
                    case 2:
                        kreatyny[wybierzKreatyne()] = Kreatyna.dodajKreatyne();
                        break;
                    case 3:
                        gumyOporowe[wybierzGumeOporowa()] = GumaOporowa.dodajGumeOporowa();
                        break;
                }
                Console.Clear();
                Console.WriteLine(" Edytowano pomyślnie");
            }
            else
            {
                switch (wybierzRodzajProduktu())
                {
                    case 1:
                        bialka.Add(Bialko.dodajBialko());
                        break;
                    case 2:
                        kreatyny.Add(Kreatyna.dodajKreatyne());
                        break;
                    case 3:
                        gumyOporowe.Add(GumaOporowa.dodajGumeOporowa());
                        break;
                }
                Console.Clear();
                Console.WriteLine(" Dodano pomyślnie");
            }

            Thread.Sleep(1500);
        }

        private static void sprzedajKarnet()
        {
            wyswietlListeUzytkownikow();
            if (uzytkownicy.Count > 0)
            {
                Console.Write("\n Wybierz odpowiedni numer: ");
                int wybor = sprawdzPoprawnoscWyboru(uzytkownicy.Count);
                Console.Clear();
                if(uzytkownicy[wybor - 1].karnet != null)
                {
                    Console.Write( " Użytkownik posiada już aktualny karnet.\n" +
                                   " Zakup nowego anuluje stary. Czy chcesz kontynuować?\n" +
                                   " 1. Tak\n" +
                                   " 2. Nie\n\n" +
                                   " Wybierz odpowiedni numer: ");

                    if (sprawdzPoprawnoscWyboru(2) == 1)
                    {
                        Console.Clear();
                        uzytkownicy[wybor - 1].karnet = Karnet.wybierzRodzaj(ref stanKonta);
                    }
                }
                else
                    uzytkownicy[wybor - 1].karnet = Karnet.wybierzRodzaj(ref stanKonta);
            }
            else
                pobierzDowolnyKlawisz();
        }

        private static void wyswietlFinanse()
        {
            double wartoscProduktow = 0;
            bialka.ForEach(b => wartoscProduktow += (b.stanMagazynu * b.cenaSprzedazy));
            kreatyny.ForEach(k => wartoscProduktow += (k.stanMagazynu * k.cenaSprzedazy));
            gumyOporowe.ForEach(g => wartoscProduktow += (g.stanMagazynu * g.cenaSprzedazy));

            Console.WriteLine(" FINANSE" +
                                "\n Kwota ze sprzedaży karnetów: " + Math.Round(Karnet.kwotaSprzedazy, 2) + "zł" +
                                "\n Kwota ze sprzedaży produktów: " + Math.Round(Produkt.kwotaSprzedazy, 2) + "zł" +
                                "\n Kwota zainwestowana w produkty: " + Math.Round(Produkt.kwotaZainwestowana, 2) + "zł" +
                                "\n Wartość produktów na magazynie: " + Math.Round(wartoscProduktow, 2) + "zł" +
                                "\n Stan konta: " + Math.Round(stanKonta, 2) + "zł");

            pobierzDowolnyKlawisz();
        }

        private static void zamowProdukt()
        {
            switch (wybierzRodzajProduktu())
            {
                case 1:
                    bialka[wybierzBialko()].zamowProdukt(ref stanKonta);
                    break;
                case 2:
                    kreatyny[wybierzKreatyne()].zamowProdukt(ref stanKonta);
                    break;
                case 3:
                    gumyOporowe[wybierzGumeOporowa()].zamowProdukt(ref stanKonta);
                    break;
                default:
                    break;
            }
        }

        private static int wybierzGumeOporowa()
        {
            Console.WriteLine(" GUMY OPOROWE");
            for (int i = 0; i < gumyOporowe.Count; i++)
            {
                Console.Write(" " + (i + 1) + ".");
                gumyOporowe[i].wyswietlDaneProduktu();
            }
            Console.Write("\n Wybierz odpowiedni numer: ");
            return sprawdzPoprawnoscWyboru(gumyOporowe.Count) - 1;
        }

        private static int wybierzKreatyne()
        {
            Console.WriteLine(" KREATYNY");
            for (int i = 0; i < kreatyny.Count; i++)
            {
                Console.Write(" " + (i + 1) + ".");
                kreatyny[i].wyswietlDaneProduktu();
            }
            Console.Write("\n Wybierz odpowiedni numer: ");
            return sprawdzPoprawnoscWyboru(kreatyny.Count) - 1;
        }

        private static int wybierzBialko()
        {
            Console.WriteLine(" BIAŁKA");
            for (int i = 0; i < bialka.Count; i++)
            {
                Console.Write(" " + (i + 1) + ".");
                bialka[i].wyswietlDaneProduktu();
            }
            Console.Write("\n Wybierz odpowiedni numer: ");
            return sprawdzPoprawnoscWyboru(bialka.Count) - 1;
        }

        private static int wybierzRodzajProduktu()
        {
            Console.Write(  " RODZAJE PRODUKTÓW\n" +
                            " 1. Białko\n" +
                            " 2. Kreatyna\n" +
                            " 3. Gumy oporowe\n\n" +
                            " Wybierz odpowiedni numer: ");

            int wybor = sprawdzPoprawnoscWyboru(3);
            Console.Clear();
            return wybor;
        }

        private static void sprzedajProdukt()
        {
            switch (wybierzRodzajProduktu())
            {
                case 1:
                    bialka[wybierzBialko()].sprzedajProdukt(ref stanKonta);
                    break;
                case 2:
                    kreatyny[wybierzKreatyne()].sprzedajProdukt(ref stanKonta);
                    break;
                case 3:                    
                    gumyOporowe[wybierzGumeOporowa()].sprzedajProdukt(ref stanKonta);
                    break;
                default:
                    break;
            }
        }

        private static void usunUzytkownika()
        {
            Console.WriteLine(" USUŃ UŻYTKOWNIKA\n");
            wyswietlListeUzytkownikow();
            if (uzytkownicy.Count > 0)
            {
                Console.Write("\n Wybierz odpowiedni numer: ");
                int wybor = sprawdzPoprawnoscWyboru(uzytkownicy.Count);
                uzytkownicy.Remove(uzytkownicy[wybor - 1]);
                Console.Clear();
                Console.Write(" Usunięto pomyślnie");
                Thread.Sleep(1500);
            }
            else
                pobierzDowolnyKlawisz();
        }

        private static void generujProdukty()
        {
            dodajBialko(90.99, 50.55, "czekolada", 70, 900);
            dodajBialko(90.77, 50.44, "truskawka", 70, 900);
            dodajBialko(90.55, 50.12, "wanilia", 70, 900);
            dodajBialko(60.67, 30.43, "czekolada", 70, 500);
            dodajBialko(60.83, 30.56, "truskawka", 70, 500);
            dodajBialko(60.01, 30.78, "wanilia", 70, 500);

            dodajKreatyne(90.11, 60.44, "jabłczan", 500);
            dodajKreatyne(80.22, 50.33, "monohydrat", 500);
            dodajKreatyne(50.33, 35.22, "jabłczan", 250);
            dodajKreatyne(45.44, 30.11, "monohydrat", 250);

            dodajGumeOporowa(20.03, 10.13, 2080, 5, 6, 5);
            dodajGumeOporowa(25.34, 11.32, 2080, 5, 13, 15);
            dodajGumeOporowa(30.23, 12.43, 2080, 5, 22, 30);
            dodajGumeOporowa(35.45, 13.71, 2080, 5, 29, 40);

            Produkt.kwotaSprzedazy = 0;
            Produkt.kwotaZainwestowana = 0;
            Karnet.kwotaSprzedazy = 0;
            Ulgowy.cenaZaDzien = 19.99;
            Ulgowy.cenaZa30Dni = 39.99;
            Ulgowy.cenaZaRok = 399.99;
            Normalny.cenaZaDzien = 24.99;
            Normalny.cenaZa30Dni = 49.99;
            Normalny.cenaZaRok = 499.99;
        }

        
        private static void dodajBialko(double cenaSprzedarzy, double cenaProdukcji, string smak, int zawartoscBialka, int waga)
        {
            Bialko bialko = new Bialko(cenaSprzedarzy, cenaProdukcji, smak, zawartoscBialka, waga);
            bialka.Add(bialko);
        }

        private static void dodajKreatyne(double cenaSprzedarzy, double cenaProdukcji, string rodzaj, int waga)
        {
            Kreatyna kreatyna = new Kreatyna(cenaSprzedarzy, cenaProdukcji, rodzaj, waga);
            kreatyny.Add(kreatyna);
        }

        private static void dodajGumeOporowa(double cenaSprzedarzy, double cenaProdukcji, int dlugosc, int grubosc, int szerokosc, int opor)
        {
            GumaOporowa gumaOporowa = new GumaOporowa(cenaSprzedarzy, cenaProdukcji, dlugosc, grubosc, szerokosc, opor);
            gumyOporowe.Add(gumaOporowa);
        }
        private static void pobierzDowolnyKlawisz()
        {
            Console.Write("\n (wciśnij dowolny klawisz aby kontynuować)");
            Console.ReadKey();
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

        private static void wyswietlListeUzytkownikow()
        {
            Console.WriteLine(" LISTA UŻYTKOWNIKÓW");

            if (uzytkownicy.Count == 0)
                Console.WriteLine(" --- brak --- ");
            else
            {
                for(int i = 0; i < uzytkownicy.Count; i++)
                    Console.WriteLine(" " + (i + 1) + ". " + uzytkownicy[i]);
            }
        }

        private static void dodajUzytkownika()
        {
            Console.Write(" Podaj imię: ");
            string imie = Console.ReadLine();
            Console.Write(" Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();

            uzytkownicy.Add(new Uzytkownik(imie, nazwisko));
            Console.Clear();
            Console.Write(" Dodano pomyślnie");
            Thread.Sleep(1500);
        }

        private static void wyswietlMenuGlowne()
        {
            Console.Write(  " KLUB SPORTOWY\n" +
                            " 1. Dodaj użytkownika\n" +
                            " 2. Usuń użytkownika\n" +
                            " 3. Lista użytkowników\n" +
                            " 4. Sprzedaj karnet\n" +
                            " 5. Sprzedaj produkt\n" +
                            " 6. Zamów produkt\n" +
                            " 7. Edytuj lub dodaj nowy produkt\n" +
                            " 8. Finanse\n" +
                            " 9. Zakończ program\n\n" +
                            " Wybierz odpowiedni numer: ");
        }
    }
}
