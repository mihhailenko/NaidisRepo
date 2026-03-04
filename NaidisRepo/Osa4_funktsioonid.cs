using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo
{
    public static class Osa4_funktsioonid
    {
        // 1. ÜL: Lemmiktoidu salvestamine faili (StreamWriter ja try-catch)
        public static void LemmiktoiduSalvestamineFaili()
        {
            Console.Clear();
            Console.WriteLine("1. ÜL: Lemmiktoidu salvestamine faili (StreamWriter)\n");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

            Console.Write("Sisesta üks Itaalia toidu nimi (nt Lasagne või Risotto): ");
            string toit = Console.ReadLine();

             StreamWriter sw = new StreamWriter(path, true); // true = lisa lõppu
             sw.WriteLine(toit);
             sw.Close();

             Console.WriteLine("Toit on salvestatud faili Retseptid.txt");
            
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

            StreamReader sr = new StreamReader(path);
            string sisu = sr.ReadToEnd();
            sr.Close();

            Console.WriteLine("Retseptid.txt sisu:\n");
            Console.WriteLine(sisu);
        }

        // 3. ÜL: Koostisosade muutmine nimekirjas
        public static void KoostisosadeMuutmine()
        {
            Console.Clear();
            Console.WriteLine("3. ÜL: Koostisosade muutmine nimekirjas (List + File.ReadAllLines)\n");

            List<string> koostisosad_list = LaeKoostisosad();

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

        private static List<string> LaeKoostisosad()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");

            List<string> koostisosad_list = new List<string>();
            foreach (string rida in File.ReadAllLines(path))
            {
                koostisosad_list.Add(rida);
            }

            return koostisosad_list;
        }
    }
}