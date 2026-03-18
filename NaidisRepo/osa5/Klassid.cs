using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.osa5
{
    public class Toode
    {
        public string Nimi;
        public double Kalorid100g;

        public Toode(string nimi, double kalorid100g)
        {
            Nimi = nimi;
            Kalorid100g = kalorid100g;
        }
    }

    public class Inimene
    {
        public string Nimi;
        public int Vanus;
        public string Sugu;
        public double Pikkus;
        public double Kaal;
        public double Aktiivsustase;

        public Inimene(string nimi, int vanus, string sugu, double pikkus, double kaal, double aktiivsustase)
        {
            Nimi = nimi;
            Vanus = vanus;
            Sugu = sugu;
            Pikkus = pikkus;
            Kaal = kaal;
            Aktiivsustase = aktiivsustase;
        }
    }
}
