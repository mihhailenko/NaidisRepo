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
            string path = "tooted.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine($"Faili {path} ei leitud.");
                return tooted;
            }

            try
            {
                string[] read = File.ReadAllLines(path);

                foreach (string rida in read)
                {
                    if (rida != "")
                    {
                        string[] osad = rida.Split(';');

                        string nimi = osad[0];
                        double kalorid = double.Parse(osad[1]);

                        tooted.Add(new Toode(nimi, kalorid));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili lugemisel. Palun kontrolli faili sisu.");
                Console.WriteLine("Iga rida peab olema kujul: TooteNimi;Kalorid");
            }

            return tooted;
        }

        // 2  - ÜL: Maakonnad ja pealinnad (peab kuskil siin olema . . . . . nii raske on )

        // 3  - ÜL: Õpilased ja hinnete analüüs
        public static void OpilasedJaHinneteAnalyys()
        {
            Console.Clear();
            Console.WriteLine("3. ÜL: Õpilased ja hinnete analüüs\n");

            // Loome õpilaste listi
            List<Opilane> opilased = new List<Opilane>();

            Opilane op1 = new Opilane();
            op1.Nimi = "Artjom";
            op1.Hinded = new List<int>() { 4, 4, 5, 5 };

            Opilane op2 = new Opilane();
            op2.Nimi = "Dominic";
            op2.Hinded = new List<int>() { 2, 3, 4, 5 };

            Opilane op3 = new Opilane();
            op3.Nimi = "Pavel";
            op3.Hinded = new List<int>() { 5, 3, 4, 5 };

            opilased.Add(op1);
            opilased.Add(op2);
            opilased.Add(op3);

            Console.WriteLine("Õpilaste keskmised hinded:\n");

            // Näitame iga õpilase keskmist hinnet
            foreach (Opilane opilane in opilased)
            {
                double keskmine = LeiaKeskmineHinne(opilane);
                Console.WriteLine(opilane.Nimi + " - " + Math.Round(keskmine, 2));
            }

            // Võtame alguseks esimese õpilase parimaks
            Opilane parimOpilane = opilased[0];
            double parimKeskmine = LeiaKeskmineHinne(opilased[0]);

            // Otsime kõige kõrgema keskmise hinde
            for (int i = 1; i < opilased.Count; i++)
            {
                double keskmine = LeiaKeskmineHinne(opilased[i]);

                if (keskmine > parimKeskmine)
                {
                    parimKeskmine = keskmine;
                    parimOpilane = opilased[i];
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Kõige kõrgem keskmine hinne on õpilasel {parimOpilane.Nimi}");
            Console.WriteLine($"Tema keskmine hinne on {Math.Round(parimKeskmine, 2)}");

            // Sorteerime õpilased keskmise hinde järgi
            opilased = opilased.OrderByDescending(o => LeiaKeskmineHinne(o)).ToList();

            Console.WriteLine();
            Console.WriteLine("Õpilased sorteeritult keskmise hinde järgi:");

            foreach (Opilane opilane in opilased)
            {
                Console.WriteLine($"{opilane.Nimi} - {Math.Round(LeiaKeskmineHinne(opilane), 2)}");
            }
        }

        public static double LeiaKeskmineHinne(Opilane opilane)
        {
            // Leiame hinnete summa
            int summa = 0;

            foreach (int hinne in opilane.Hinded)
            {
                summa = summa + hinne;
            }

            // Arvutame keskmise hinde
            return (double)summa / opilane.Hinded.Count;
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
