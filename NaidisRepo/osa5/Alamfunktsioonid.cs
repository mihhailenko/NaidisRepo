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

        // 4 - ÜL: Filmide kogu
        public static void FilmideKogu()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("       4. ÜL: Filmide kogu");
            Console.WriteLine("=================================\n");

            // Loome filmide nimekirja
            List<Film> filmid = new List<Film>();

            filmid.Add(new Film() { Pealkiri = "Interstellar", Aasta = 2014, Zanr = "ulme" });
            filmid.Add(new Film() { Pealkiri = "Titanic", Aasta = 1997, Zanr = "draama" });
            filmid.Add(new Film() { Pealkiri = "The Dark Knight", Aasta = 2008, Zanr = "action" });
            filmid.Add(new Film() { Pealkiri = "Inception", Aasta = 2010, Zanr = "ulme" });
            filmid.Add(new Film() { Pealkiri = "Toy Story", Aasta = 1995, Zanr = "animatsioon" });

            // Kuvame kõik filmid
            Console.WriteLine("Kõik filmid:");
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < filmid.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filmid[i].Pealkiri} ({filmid[i].Aasta}) - {filmid[i].Zanr}");
            }

            // Kuvame olemasolevad žanrid
            List<string> zanrid = filmid.Select(f => f.Zanr.ToLower()).Distinct().ToList();

            Console.WriteLine();
            Console.WriteLine("Saadaval žanrid:");
            Console.WriteLine("---------------------------------");
            foreach (string zanrNimi in zanrid)
            {
                Console.WriteLine($"- {zanrNimi}");
            }

            // Otsime filme žanri järgi
            Console.WriteLine();
            Console.Write("Sisesta žanr: ");
            string zanr = Console.ReadLine().ToLower();

            List<Film> leitudFilmid = LeiaFilmidZanriJargi(filmid, zanr);

            Console.WriteLine();
            Console.WriteLine("Otsingu tulemus:");
            Console.WriteLine("---------------------------------");

            if (leitudFilmid.Count > 0)
            {
                for (int i = 0; i < leitudFilmid.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {leitudFilmid[i].Pealkiri} ({leitudFilmid[i].Aasta})");
                }
            }
            else
            {
                Console.WriteLine("Selle žanriga filme ei leitud.");
            }

            // Leiame uusima filmi
            Film uusimFilm = LeiaUusimFilm(filmid);

            Console.WriteLine();
            Console.WriteLine("Uusim film:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"{uusimFilm.Pealkiri} ({uusimFilm.Aasta}) - {uusimFilm.Zanr}");

            // Grupeerime filmid žanri järgi
            Dictionary<string, List<Film>> grupid = GrupeeriFilmidZanriteKaupa(filmid);

            Console.WriteLine();
            Console.WriteLine("Filmid žanrite kaupa:");
            Console.WriteLine("=================================");

            foreach (string zanrNimi in grupid.Keys)
            {
                Console.WriteLine();
                Console.WriteLine($"[{zanrNimi.ToUpper()}]");

                for (int i = 0; i < grupid[zanrNimi].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {grupid[zanrNimi][i].Pealkiri} ({grupid[zanrNimi][i].Aasta})");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Vajuta suvalist klahvi, et jätkata...");
            Console.ReadKey();
        }

        public static List<Film> LeiaFilmidZanriJargi(List<Film> filmid, string zanr)
        {
            List<Film> leitudFilmid = new List<Film>();

            foreach (Film film in filmid)
            {
                if (film.Zanr.ToLower() == zanr)
                {
                    leitudFilmid.Add(film);
                }
            }

            return leitudFilmid;
        }

        public static Film LeiaUusimFilm(List<Film> filmid)
        {
            Film uusimFilm = filmid[0];

            foreach (Film film in filmid)
            {
                if (film.Aasta > uusimFilm.Aasta)
                {
                    uusimFilm = film;
                }
            }

            return uusimFilm;
        }

        public static Dictionary<string, List<Film>> GrupeeriFilmidZanriteKaupa(List<Film> filmid)
        {
            // Loome sõnastiku žanrite jaoks
            Dictionary<string, List<Film>> grupid = new Dictionary<string, List<Film>>();

            foreach (Film film in filmid)
            {
                // Kui sellist žanri veel ei ole, loome uue nimekirja
                if (!grupid.ContainsKey(film.Zanr))
                {
                    grupid.Add(film.Zanr, new List<Film>());
                }

                // Lisame filmi õigesse žanri
                grupid[film.Zanr].Add(film);
            }

            return grupid;
        }

        // 5  - ÜL: Arvude massiivi statistika
        public static void ArvudeMassiiviStatistika()
        {
            Console.Clear();
            Console.WriteLine("5. ÜL: Arvude massiivi statistika\n");

            Console.Write("Sisesta arvud ühele reale: ");
            double[] arvud = Osa3_funktsioonid.Tekstist_arvud();

            if (arvud.Length == 0)
            {
                Console.WriteLine("Ühtegi arvu ei leitud.");
                return;
            }

            double max = arvud.Max();
            double min = arvud.Min();
            double summa = arvud.Sum();
            double keskmine = arvud.Average();
            int suuremadKuiKeskmine = arvud.Count(a => a > keskmine);


            Console.WriteLine($"\nMaksimaalne arv: {max}");
            Console.WriteLine($"Minimaalne arv: {min}");
            Console.WriteLine($"Keskmine: {keskmine}");
            Console.WriteLine($"Kogusumma: {summa}");
            Console.WriteLine($"Keskmisest suuremaid arve: {suuremadKuiKeskmine}");
           
            Array.Sort(arvud);
            Console.WriteLine("Sorteeritud arvud: " + string.Join(" ", arvud));
        }

        // 6  - ÜL: Lemmikloomade register
        public static void LemmikloomadeRegister()
        {
            Console.Clear();
            Console.WriteLine("6. ÜL: Lemmikloomade register\n");

            List<Lemmikloom> loomad = new List<Lemmikloom>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. lemmikloom");

                Console.Write("Sisesta nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta liik: ");
                string liik = Console.ReadLine();

                int vanus = KysiInt("Sisesta vanus: ");

                loomad.Add(new Lemmikloom { Nimi = nimi, Liik = liik, Vanus = vanus });
                Console.WriteLine();
            }

            Console.WriteLine("Kõik kassid:");
            KuvaKoikKassid(loomad);
            double keskmineVanus = loomad.Average(l => l.Vanus);

            Console.WriteLine($"\nLemmikloomade keskmine vanus on {Math.Round(keskmineVanus, 2)}");

            Lemmikloom vanim = loomad.OrderByDescending(l => l.Vanus).First();
            Console.WriteLine($"Vanim loom on {vanim.Nimi}, liik: {vanim.Liik}, vanus: {vanim.Vanus}");

            Console.Write("\nSisesta looma nimi otsimiseks: ");
            string otsitavNimi = Console.ReadLine();

            Lemmikloom leitudLoom = LeiaLoomNimeJargi(loomad, otsitavNimi);

            if (leitudLoom != null) { 
                Console.WriteLine($"Loom leitud: {leitudLoom.Nimi}, liik: {leitudLoom.Liik}, vanus: {leitudLoom.Vanus}");
            }
            else { 
                Console.WriteLine("Sellise nimega looma ei leitud.");
            }
        }

        public static void KuvaKoikKassid(List<Lemmikloom> loomad)
        {
            List<Lemmikloom> kassid = loomad.Where(l => l.Liik.ToLower() == "kass").ToList();

            if (kassid.Count == 0)
            {
                Console.WriteLine("Kasse ei ole.");
                return;
            }

            foreach (Lemmikloom loom in kassid)
                Console.WriteLine($"{loom.Nimi} - {loom.Vanus} a");
        }

        public static Lemmikloom LeiaLoomNimeJargi(List<Lemmikloom> loomad, string nimi)
        {
            foreach (Lemmikloom loom in loomad)
            {
                if (loom.Nimi.ToLower() == nimi.ToLower())
                {
                    return loom;
                }
            }

            return null;
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
