using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo
{
    public class Isik
    {
        public string Nimi;  
        public int Vanus;  

        public Isik(string nimi, int vanus)
        {
            Nimi = nimi;
            Vanus = vanus;
        }

        public Isik() { }

        public void Tervita()
        {
            Console.WriteLine($"Tere, minu nimi on {Nimi}!");
        }
    }
}
