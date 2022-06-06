using System;
using System.Collections.Generic;
using System.Text;

namespace KlubSportowy.karnet
{
    class Ulgowy : Karnet
    {
        public static double cenaZaDzien { get; set; }
        public static double cenaZa30Dni { get; set; }
        public static double cenaZaRok { get; set; }

        public Ulgowy(int dni) : base(dni)
        {
        }
    }
}
