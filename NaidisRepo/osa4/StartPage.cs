using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.osa4
{
    internal class StartPage
    {

        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("4. osa Failitöötlus ja Listid");
                Console.WriteLine("Milline ÜL kas te tahaksite üle vaadata?");
                Console.WriteLine();

                Console.WriteLine("1  - ÜL: Lemmiktoidu salvestamine faili (StreamWriter)");
                Console.WriteLine("2  - ÜL: Kogu menüü kuvamine (StreamReader)");
                Console.WriteLine("3  - ÜL: Koostisosade muutmine nimekirjas (List ja File.ReadAllLines)");
                Console.WriteLine("4  - ÜL: Külmkapi kontroll ehk otsing listist (Contains)");
                Console.WriteLine("5  - ÜL: Uuendatud nimekirja salvestamine (File.WriteAllLines)");
                Console.WriteLine("6  - ÜL: Itaalia restorani menüü (Failist Tuple'isse)");
                Console.WriteLine("0  - Tagasi");
                Console.WriteLine();

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Osa4_funktsioonid.LemmiktoiduSalvestamineFaili();
                        break;
                    case "2":
                        Osa4_funktsioonid.KoguMenuuKuvamine();
                        break;
                    case "3":
                        Osa4_funktsioonid.KoostisosadeMuutmine();
                        break;
                    case "4":
                        Osa4_funktsioonid.KoostisosaOtsing();
                        break;
                    case "5":
                        Osa4_funktsioonid.KoostisosadeSalvestamine();
                        break;
                    case "6":
                        Osa4_funktsioonid.ItaaliaRestoraniMenuu();
                        break;
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Tundmatu valik. Vajuta Enter...");
                        Console.ReadLine();
                        continue;
                }

                Console.WriteLine("\nVajuta Enter, et menüüsse tagasi minna...");
                Console.ReadLine();
            }

        }
    }
}
