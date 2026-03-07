using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

                Console.Write("Sisesta üks Itaalia toidu nimi (nt Lasagne või Risotto): ");
                string toit = Console.ReadLine();

                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(toit);
                sw.Close();

                Console.WriteLine("Toit on salvestatud faili Retseptid.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
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

            List<string> koostisosad_list = LaeKoostisosad();

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

            try
            {
                if (koostisosad_list.Count == 0)
                {
                    Console.WriteLine("Kõigepealt tee kolmas ülesanne.");
                    return;
                }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");
                File.WriteAllLines(path, koostisosad_list);

                Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
        }

        private static List<string> LaeKoostisosad()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

            List<string> list = new List<string>();

            try
            {
                // kui faili ei ole, loome näidisfaili
                if (!File.Exists(path))
                {
                    File.WriteAllLines(path, new string[] { "Ketšup", "Tomat", "Sool", "Pipar" });
                }

                foreach (string rida in File.ReadAllLines(path))
                {
                    list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga");
            }

            return list;
        }
    }
}