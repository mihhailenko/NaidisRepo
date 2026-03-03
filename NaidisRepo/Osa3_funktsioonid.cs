namespace NaidisRepo
{
    public static class Osa3_funktsioonid
    {
        // 2. Viie arvu analüüs
        public static void ViieArvuAnaluus()
        {
            Console.Clear();
            Console.WriteLine("2. Viie arvu analüüs\n");

            // võtab sisendiks massiivi (kasutaja sisestab Tekstist_arvud() meetodi abil)
            double[] arvud = Tekstist_arvud();

            // tagastab Tuple<double, double, double> – summa, keskmine, korrutis
            var tuple = AnalüüsiArve(arvud);

            // väljastab tulemuse hästi vormindatult
            Console.WriteLine("\nTulemused:");
            Console.WriteLine("Summa: " + tuple.Item1);
            Console.WriteLine("Keskmine: " + tuple.Item2);
            Console.WriteLine("Korrutis: " + tuple.Item3);
        }

        // (kasutaja sisestab Tekstist_arvud() meetodi abil)
        public static double[] Tekstist_arvud()
        {
            Console.Write("Sisesta 5 arvu (tühikuga): ");
            string rida = Console.ReadLine();
            string[] osad = rida.Split(' ');

            double[] arvud = new double[5];

            for (int i = 0; i < 5; i++)
            {
                arvud[i] = double.Parse(osad[i]);
            }

            return arvud;
        }

        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = 0;
            double korrutis = 1;

            for (int i = 0; i < arvud.Length; i++)
            {
                summa = summa + arvud[i];
                korrutis = korrutis * arvud[i];
            }

            double keskmine = summa / arvud.Length;

            return new Tuple<double, double, double>(summa, keskmine, korrutis);
        }

        // 3. Nimed ja vanused
        public static void NimedJaVanused()
        {
            Console.Clear();
            Console.WriteLine("3. Nimed ja vanused\n");

            // Kasutaja sisestab 5 inimest (nimi ja vanus eraldi).
            List<Inimene> inimesed = new List<Inimene>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Sisesta nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                Inimene uus = new Inimene(nimi, vanus);

                inimesed.Add(uus);
            }

            var t = Statistika(inimesed);

            Console.WriteLine("\nStatistika:");
            Console.WriteLine("Vanuste summa: " + t.Item1);
            Console.WriteLine("Keskmine vanus: " + t.Item2);
            Console.WriteLine("Vanim: " + t.Item3.Nimi + " (" + t.Item3.Vanus + ")");
            Console.WriteLine("Noorim: " + t.Item4.Nimi + " (" + t.Item4.Vanus + ")");
        }

        // 3. Nimed ja vanused: Meetod Statistika(List<Inimene> inimesed)
        public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa = 0;

            Inimene vanim = inimesed[0];
            Inimene noorim = inimesed[0];

            // arvutab kogu vanuse summa ja keskmise
            // leiab vanima ja noorima inimese
            for (int i = 0; i < inimesed.Count; i++)
            {
                summa = summa + inimesed[i].Vanus;

                if (inimesed[i].Vanus > vanim.Vanus)
                {
                    vanim = inimesed[i];
                }

                if (inimesed[i].Vanus < noorim.Vanus)
                {
                    noorim = inimesed[i];
                }
            }

            double keskmine = (double)summa / inimesed.Count;

            // tagastab need väärtused Tuple<int, double, Inimene, Inimene>
            return new Tuple<int, double, Inimene, Inimene>(summa, keskmine, vanim, noorim);
        }

        // 4. "Osta elevant ära!"
        public static void OstaElevantAra()
        {
            Console.Clear();
            Console.WriteLine("4. Osta elevant ära!\n");

            string marksõna = "okei ma ostan";
            string fraas = $"Osta elevant ära! (Sisesta '{marksõna}' ostmiseks)";

            // Tee korduv sisendimeetod KuniMärksõnani(string märksõna, string fraas)
            List<string> sisestused = KuniMarksonani(marksõna, fraas);

            // kõik sisestused salvestatakse ja trükitakse lõpuks välja
            Console.WriteLine("\nKogu dialoog:");
            for (int i = 0; i < sisestused.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + sisestused[i]);
            }
        }

        // 4. "Osta elevant ära!": KuniMärksõnani(string märksõna, string fraas)
        public static List<string> KuniMarksonani(string marksona, string fraas)
        {
            List<string> lst = new List<string>();

            while (true)
            {
                // iga kord enne kirjutab uuesti fraas
                Console.WriteLine(fraas);
                Console.Write("Sinu vastus: ");
                string vastus = Console.ReadLine();

                // kõik sisestused salvestatakse
                lst.Add(vastus);

                // küsib kasutajalt sisendit seni, kuni see täpselt võrdub märksõnaga
                if (vastus == marksona)
                {
                    Console.WriteLine("Tubli! Ostad elevandi ära!");
                    break;
                }

                string meie_vastus = $"Seda räägivad kõik, et {vastus}, aga osta elevant ära!";
                lst.Add(meie_vastus);
                Console.WriteLine(meie_vastus + "\n");
            }

            return lst;
        }

        // 5. Arvamise mäng
        public static void ArvamiseMang()
        {
            Console.Clear();
            Console.WriteLine("5. Arvamise mäng\n");

            // Arvuti valib juhuslikult arvu [1–100].
            Random rnd = new Random();

            while (true)
            {
                // Kasutajal on 5 katset.
                // mäng lõppeb õigel arvamisel või viienda katse järel.
                ArvaArv(rnd);

                // Pärast mängu küsime, kas kasutaja soovib uuesti mängida.
                Console.Write("\nKas soovid uuesti mängida? (j/e): ");
                string vastus = Console.ReadLine();

                if (vastus.ToLower() != "j")
                {
                    break;
                }

                Console.Clear();
            }
        }
        public static void ArvaArv(Random rnd)
        {
            // Arvuti valib juhuslikult arvu [1–100].
            int juhuArv = rnd.Next(1, 101);

            // Kasutajal on 5 katset.
            for (int katse = 1; katse <= 5; katse++)
            {
                Console.Write("Katse " + katse + "/5. Sisesta arv (1-100): ");
                int arv = int.Parse(Console.ReadLine());

                // igal katsel ütleb, kas "liiga suur", "liiga väike" või "õige"
                if (arv == juhuArv)
                {
                    Console.WriteLine($"Õige! Arv oli {juhuArv}.");
                    // mäng lõppeb õigel arvamisel
                    return;
                }
                else if (arv > juhuArv)
                {
                    Console.WriteLine("Liiga suur.");
                }
                else
                {
                    Console.WriteLine("Liiga väike.");
                }
            }

            // mäng lõppeb ... viienda katse järel
            Console.WriteLine("Katseid sai otsa! = ( Õige arv oli " + juhuArv);
        }

        // 7. Korrutustabel
        public static void Korrutustabel()
        {
            Console.Clear();
            Console.WriteLine("7. Korrutustabel\n");

            Console.Write("Sisesta ridade arv: ");
            int read = int.Parse(Console.ReadLine());

            Console.Write("Sisesta veergude arv: ");
            int veerud = int.Parse(Console.ReadLine());

            // Kirjuta meetod GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
            GenereeriKorrutustabel(read, veerud);
        }

        // https://github.com/MarinaOleinik/Naidis_IKTpv25/commit/4e97e57
        public static int[,] GenereeriKorrutustabel(int read, int veerud)
        {
            int[,] tabel = new int[read, veerud];
            for (int i = 0; i < read; i++)
            {
                for (int j = 0; j < veerud; j++)
                {
                    tabel[i, j] = (i + 1) * (j + 1);
                    Console.Write($"{tabel[i, j]}\t");
                }
                Console.WriteLine();
            }
            return tabel;
        }

        // 8. Õpilastega mängimine
        public static void OpilastegaMangimine()
        {
            Console.Clear();
            Console.WriteLine("8. Õpilastega mängimine\n");

            // Antud on 10 õpilase nimede massiiv.
            string[] nimed = ["Artjom", "Mari", "Andres", "Anna", "Alo", "Peeter", "Ann", "Juku", "Siim", "Deniss"];

            // Asendab kolmanda ja kuuenda õpilase nime (indeksite põhjal) uue nimega "Kati" ja "Mati".
            nimed[2] = "Kati";
            nimed[5] = "Mati";

            // Kasutab while tsüklit, et tervitada ainult õpilasi, kelle nimi algab tähega "A".
            int i = 0;
            while (i < nimed.Length)
            {
                if (nimed[i].StartsWith("A"))
                {
                    Console.WriteLine($"Tere, {nimed[i]}!");
                }
                i = i + 1;
            }

            // Kasutab for tsüklit, et väljastada kõik nimed ja nende indeksid.
            for (int j = 0; j < nimed.Length; j++)
            {
                Console.WriteLine(j + " - " + nimed[j]);
            }

            // Kasutab foreach tsüklit, et väljastada kõik nimed väikeste tähtedena.
            foreach (var nimi in nimed)
            {
                Console.WriteLine(nimi.ToLower());
            }

            // Kasutab do-while tsüklit, et tervitada õpilasi seni, kuni kohtab nime "Mati".
            int i2 = 0;
            do
            {
                Console.WriteLine($"Tere, {nimed[i2]}!");

                if (nimed[i2] == "Mati")
                {
                    Console.WriteLine("Leidsin Mati!");
                    break;
                }

                i2 = i2 + 1;

            } while (i2 < nimed.Length);
        }

        // 9 – Arvude ruudud
        public static void ArvudeRuudud()
        {
            Console.Clear();
            Console.WriteLine("9. Arvude ruudud\n");

            // Antud on massiiv täisarvudega: int[] arvud = { 2, 4, 6, 8, 10, 12 };
            int[] arvud = { 2, 4, 6, 8, 10, 12 };

            // Kasutab for tsüklit, et väljastada iga arvu ruut.
            Console.WriteLine("ruudud (for)");
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.WriteLine(arvud[i] + " -> " + (arvud[i] * arvud[i]));
            }

            // Kasutab foreach tsüklit, et väljastada iga arvu kahekordne väärtus.
            Console.WriteLine("\n kahekordne arvu väärtus (foreach)");
            foreach (int a in arvud)
            {
                Console.WriteLine(a + " -> " + (a * 2));
            }

            // Kasutab while tsüklit, et loendada kui palju on arvude seas arve, mis jaguvad 3-ga.
            Console.WriteLine("\nkui palju jagub 3-ga (while)");
            int nr = 0;
            int count = 0;
            while (nr < arvud.Length)
            {
                if (arvud[nr] % 3 == 0)
                {
                    count = count + 1;
                }
                nr = nr + 1;
            }
            Console.WriteLine($"{count} numbrid jaguvad 3-ga");
        }

        // 10 – Positiivsed ja negatiivsed
        public static void PositNegNull()
        {
            Console.Clear();
            Console.WriteLine("10. Positiivsed ja negatiivsed\n");

            // Antud on massiiv 12 arvuga (sealhulgas negatiivsed, positiivsed ja nullid):
            int[] arvud = { 5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9 };

            int pos = 0;
            int neg = 0;
            int zero = 0;

            // Loe kui palju on: positiivseid arve, negatiivseid arve ja nulle
            foreach (int a in arvud)
            {
                if (a > 0)
                {
                    pos += 1;
                }
                else if (a < 0)
                {
                    neg += 1;
                }
                else
                {
                    zero += 1;
                }
            }

            Console.WriteLine($"Positiivseid: {pos}");
            Console.WriteLine($"Negatiivseid: {neg}");
            Console.WriteLine($"Nulle: {zero}");
        }

        // 11 – Keskmisest suuremad
        public static void KeskmisestSuuremad()
        {
            Console.Clear();
            Console.WriteLine("11. Keskmisest suuremad\n");

            // Genereeri 15 juhuslikku arvu vahemikus 1–100 ja salvesta need int[] massiivi.
            Random rnd = new Random();
            int[] arvud = new int[15];

            int summa = 0;

            for (int i = 0; i < arvud.Length; i++)
            {
                arvud[i] = rnd.Next(1, 101);
                summa = summa + arvud[i];
            }

            // Leia keskmine väärtus (summa / arvude arv).
            double keskmine = (double)summa / arvud.Length;

            Console.WriteLine("Arvud:");
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.Write(arvud[i] + " ");
            }

            Console.WriteLine("\n\nKeskmine: " + keskmine);
            Console.WriteLine("Suuremad kui keskmine:");

            // Väljasta ainult need arvud, mis on suuremad kui keskmine.
            for (int i = 0; i < arvud.Length; i++)
            {
                if (arvud[i] > keskmine)
                {
                    Console.Write(arvud[i] + " ");
                }
            }

            // Kasuta do-while tsüklit arvude väljastamiseks seni, kuni kohtad arvu, mis on väiksem kui 10.
            Console.WriteLine("\n\nVäljastame numbreid kuni kohtame arvu < 10 do-whileiga");
            int idx = 0;
            do
            {
                Console.Write(arvud[idx] + " ");
                idx = idx + 1;

                if (idx >= arvud.Length)
                {
                    break;
                }

            } while (arvud[idx - 1] >= 10);

            Console.WriteLine();
        }

        // 12 – Kõige suurema arvu otsing
        public static void SuurimArvJaIndeks()
        {
            Console.Clear();
            Console.WriteLine("12. Kõige suurema arvu otsing\n");

            // Antud: int[] numbrid = { 12, 56, 78, 2, 90, 43, 88, 67 };
            int[] numbrid = { 12, 56, 78, 2, 90, 43, 88, 67 };

            int max = numbrid[0];
            int maxIndex = 0;

            // Kasutab for tsüklit.
            for (int i = 1; i < numbrid.Length; i++)
            {
                // Leiab suurima arvu massiivis (ilma Max() kasutamata).
                if (numbrid[i] > max)
                {
                    max = numbrid[i];
                    // Kuvab selle arvu indeksi, mitte ainult väärtuse.
                    maxIndex = i;
                }
            }

            Console.WriteLine("Suurim arv: " + max);
            Console.WriteLine("Indeks: " + maxIndex);
        }

        // 13 – Paari- ja paaritud loendused
        public static void PaarJaPaarituStat()
        {
            Console.Clear();
            Console.WriteLine("13. Paari- ja paaritud loendused\n");

            // Genereeri List<int> 20 juhuslikust täisarvust.
            Random rnd = new Random();
            List<int> arvud = new List<int>();

            // Kasuta vaheldumisi for, foreach ja while
            for (int i = 0; i < 20; i++)
            {
                arvud.Add(rnd.Next(1, 101));
            }

            Console.WriteLine("Arvud:");
            for (int i = 0; i < arvud.Count; i++)
            {
                Console.Write(arvud[i] + " ");
            }
            Console.WriteLine();

            // Paarisarvude kogusumma (foreach)
            int paarSumma = 0;
            foreach (int a in arvud)
            {
                if (a % 2 == 0)
                {
                    paarSumma += a;
                }
            }

            // Paaritute arvude keskmine (for)
            int paarituSumma = 0;
            int paarituCount = 0;

            for (int i = 0; i < arvud.Count; i++)
            {
                if (arvud[i] % 2 != 0)
                {
                    paarituSumma += arvud[i];
                    paarituCount += 1;
                }
            }

            double paarituKeskmine = 0;
            if (paarituCount > 0)
            {
                paarituKeskmine = (double)paarituSumma / paarituCount;
            }

            // Loendada, mitu arvu on suuremad kui 50 (while)
            int idx = 0;
            int suurem50 = 0;
            while (idx < arvud.Count)
            {
                if (arvud[idx] > 50)
                {
                    suurem50 += 1;
                }
                idx += 1;
            }

            Console.WriteLine("\nPaarisarvude kogusumma: " + paarSumma);
            Console.WriteLine("Paaritute keskmine: " + paarituKeskmine);
            Console.WriteLine("Mitu arvu > 50: " + suurem50);
        }
    }
}
