using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.osa5.Uurimine
{
    public class Uurimine_Alamfunktsioonid
    {
        public static void ArrayNäide()
        {
            ArrayList nimed = new ArrayList();
            {
                nimed.Add("Kati");
                nimed.Add("Mati");
                nimed.Add("Juku");

                if (nimed.Contains("Mati")) { 
                    Console.WriteLine("Mati on olemas");
                }

                Console.WriteLine($"Nimesid kokku: {nimed.Count}");

                nimed.Insert(1, "Sass");

                Console.WriteLine("Mati indeks: " + nimed.IndexOf("Mati"));
                Console.WriteLine("Mari indeks: " + nimed.IndexOf("Mari"));

                nimed.Sort();
                foreach (string nimi in nimed)
                {
                    Console.WriteLine(nimi);
                }
            }
        }
        public static void Tuple()
        {
            Tuple<float, char> route = new Tuple<float, char>(2.5f, 'N');
            Console.WriteLine($"Vahemaa: {route.Item1}, Suund: {route.Item2}");
        }
    }
}
