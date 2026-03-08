namespace NaidisRepo.osa4
{
    public static class Osa4_funktsioonid
    {
        static List<string> koostisosad_list = new List<string>();

        // 1. ÜL: Lemmiktoidu salvestamine faili (StreamWriter)
        public static void LemmiktoiduSalvestamineFaili()
        {
            Console.Clear();
            Console.WriteLine("1. ÜL: Lemmiktoidu salvestamine faili (StreamWriter)\n");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

            Console.Write("Sisesta üks Itaalia toidu nimi (nt Lasagne või Risotto): ");
            string toit = Console.ReadLine();

            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(toit);
                sw.Close();

                Console.WriteLine("Toit on salvestatud faili Retseptid.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras.");
            }
        }

        // 2. ÜL: Kogu menüü kuvamine (StreamReader)
        public static void KoguMenuuKuvamine()
        {
            Console.Clear();
            Console.WriteLine("2. ÜL: Kogu menüü kuvamine (StreamReader)\n");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

            if (!File.Exists(path))
            {
                Console.WriteLine("Faili Retseptid.txt ei ole olemas. Kõigepealt tee ÜL 1.");
                return;
            }

            try
            {
                StreamReader sr = new StreamReader(path);
                string sisu = sr.ReadToEnd();
                sr.Close();

                Console.WriteLine("Retseptid.txt sisu:\n");
                Console.WriteLine(sisu);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }
        }

        // 3. ÜL: Koostisosade muutmine nimekirjas
        public static void KoostisosadeMuutmine()
        {
            Console.Clear();
            Console.WriteLine("3. ÜL: Koostisosade muutmine nimekirjas (List + File.ReadAllLines)\n");

            koostisosad_list = LaeKoostisosad();

            Console.WriteLine("Algne nimekiri:");
            foreach (string rida in koostisosad_list)
            {
                Console.WriteLine(rida);
            }

            // Muuda esimest elementi
            if (koostisosad_list.Count > 0)
            {
                koostisosad_list[0] = "Kvaliteetne oliiviõli";
            }

            // Eemalda "Ketšup"
            koostisosad_list.Remove("Ketšup");

            Console.WriteLine("\nUuenenud nimekiri:");
            foreach (string rida in koostisosad_list)
            {
                Console.WriteLine(rida);
            }
        }

        // 4. ÜL: Külmkapi kontroll ehk otsing listist (Contains)
        public static void KoostisosaOtsing()
        {
            Console.Clear();
            Console.WriteLine("4. ÜL: Külmkapi kontroll ehk otsing listist (Contains)\n");

            if (koostisosad_list.Count == 0)
            {
                koostisosad_list = LaeKoostisosad();
            }

            Console.Write("Sisesta toiduaine nimi, mida otsida: ");
            string otsitav = Console.ReadLine();

            if (koostisosad_list.Contains(otsitav))
            {
                Console.WriteLine("Koostisosa on olemas!");
            }
            else
            {
                Console.WriteLine("Seda koostisosa meil retseptis ei ole.");
            }
        }

        // 5. ÜL: Uuendatud nimekirja salvestamine (File.WriteAllLines)
        public static void KoostisosadeSalvestamine()
        {
            Console.Clear();
            Console.WriteLine("5. ÜL: Uuendatud nimekirja salvestamine (File.WriteAllLines)\n");

            if (koostisosad_list.Count == 0)
            {
                Console.WriteLine("Kõigepealt tee kolmas ülesanne.");
                return;
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

            try
            {
                File.WriteAllLines(path, koostisosad_list);
                Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras ning fail ei ole kuskil hetkel kasutav.");
            }
        }

        // 6. ÜL: Itaalia restorani menüü (Failist Tuple'isse)
        public static void ItaaliaRestoraniMenuu()
        {
            Console.Clear();
            Console.WriteLine("6. ÜL: Itaalia restorani menüü (Failist Tuple'isse)\n");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menuu.txt");

            // kui faili ei ole, loome näidisfaili
            if (!File.Exists(path))
            {
                try
                {
                    File.WriteAllLines(path, new string[]
                    {
                        "Margherita pitsa;San Marzano tomatid, värske mozzarella, basiilik;8,50",
                        "Pasta Carbonara;Spagetid, guanciale, pecorino juust, muna;12,00",
                        "Tiramisu;Mascarpone, espresso, savoiardi küpsised;6,50"
                    });
                }
                catch (Exception)
                {
                    Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras ning fail ei ole kuskil hetkel kasutav.");
                    return;
                }
            }

            List<Tuple<string, string, double>> menuu_list = new List<Tuple<string, string, double>>();
            string[] read = new string[0];

            try
            {
                read = File.ReadAllLines(path);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras.");
                return;
            }

            foreach (string rida in read)
            {
                string[] osad = rida.Split(';');

                if (osad.Length == 3)
                {
                    try
                    {
                        double hind = double.Parse(osad[2]);
                        menuu_list.Add(Tuple.Create(osad[0], osad[1], hind));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Viga hinna lugemisel: {rida}. Viga: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("---------------- MENUU ----------------\n");

            foreach (Tuple<string, string, double> roog in menuu_list)
            {
                Console.WriteLine($"{roog.Item1.PadRight(30)}{roog.Item3} €");
                Console.WriteLine($"   Koostisosad: {roog.Item2}");
                Console.WriteLine();
            }
        }

        private static List<string> LaeKoostisosad()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");
            List<string> list = new List<string>();

            // kui faili ei ole, loome näidisfaili
            if (!File.Exists(path))
            {
                try
                {
                    File.WriteAllLines(path, new string[] { "Ketšup", "Tomat", "Sool", "Pipar" });
                }
                catch (Exception)
                {
                    Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras ning fail ei ole kuskil hetkel kasutav.");
                    return list;
                }
            }

            try
            {
                foreach (string rida in File.ReadAllLines(path))
                {
                    list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga. Palun vaadake üles ja veenduge et kõik oleks korras.");
            }

            return list;
        }
    }
}