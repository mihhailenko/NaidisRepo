using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.osa5
{
    public class Alamfunktsioonid
    {
        // 1. ÜL: Kalorite kalkulaator klassidega
        public static void KaloriteKalkulaator()
        {
            Console.Clear();
            Console.WriteLine("1. ÜL: Kalorite kalkulaator klassidega\n");

            List<Toode> tooted = LaeTooted();

            Console.Write("Sisesta oma nimi: ");
            string nimi = Console.ReadLine();

            int vanus = KysiInt("Sisesta oma vanus: ");

            Console.Write("Sisesta oma sugu (m/n): ");
            string sugu = Console.ReadLine().ToLower();

            double pikkus = KysiDouble("Sisesta oma pikkus cm: ");
            double kaal = KysiDouble("Sisesta oma kaal kg: ");

            Console.WriteLine();
            Console.WriteLine("Aktiivsustase:");
            Console.WriteLine("1 - vähe aktiivne");
            Console.WriteLine("2 - kerge aktiivsus");
            Console.WriteLine("3 - keskmine aktiivsus");
            Console.WriteLine("4 - väga aktiivne");
            Console.WriteLine("5 - eriti aktiivne");

            int aktiivsus = KysiInt("Sisesta oma aktiivsustase: ");

            Inimene inimene = new Inimene(nimi, vanus, sugu, pikkus, kaal, aktiivsus);
            double paevaneKalor = ArvutaPaevaneEnergia(inimene);

            Console.WriteLine();
            Console.WriteLine($"{inimene.Nimi}, sinu päevane energiavajadus on umbes {Math.Round(paevaneKalor, 2)} kcal.");
            Console.WriteLine();
            Console.WriteLine("Toitude soovituslik kogus grammides päevas:");

            foreach (Toode toode in tooted)
            {
                double grammid = paevaneKalor / toode.Kalorid100g * 100;
                Console.WriteLine(toode.Nimi.PadRight(20) + Math.Round(grammid, 2) + " g");
            }
        }

        public static double ArvutaPaevaneEnergia(Inimene inimene)
        {
            double bmr = 0;

            if (inimene.Sugu == "m")
            {
                bmr = 88.362 + (13.397 * inimene.Kaal) + (4.799 * inimene.Pikkus) - (5.677 * inimene.Vanus);
            }
            else
            {
                bmr = 447.593 + (9.247 * inimene.Kaal) + (3.098 * inimene.Pikkus) - (4.330 * inimene.Vanus);
            }

            return bmr * inimene.Aktiivsustase;
        }

        public static List<Toode> LaeTooted()
        {
            List<Toode> tooted = new List<Toode>();

            Toode t1 = new Toode("Riis", 130);
            tooted.Add(t1);

            Toode t2 = new Toode("Kanafilee", 165);
            tooted.Add(t2);

            Toode t3 = new Toode("Kaerahelbed", 366);
            tooted.Add(t3);

            Toode t4 = new Toode("Banaan", 89);
            tooted.Add(t4);

            Toode t5 = new Toode("Kodujuust", 98);
            tooted.Add(t5);

            return tooted;
        }

        public static int KysiInt(string kysimus)
        {
            while (true)
            {
                Console.Write(kysimus);
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisestasid vale arvu.");
                }
            }
        }

        public static double KysiDouble(string kysimus)
        {
            while (true)
            {
                Console.Write(kysimus);
                try
                {
                    return double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisestasid vale arvu.");
                }
            }
        }
    }
}
