using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.Itaalia_toit
{
    public class StartPage
    {
        public static void Main(string[] args)
        {
            bool tootab = true;

            // Laeme kohe programmi käivitamisel andmed mällu, et menüü poleks tühi!
            Alamfunktsionid.LaeAndmedFailist();
            Console.WriteLine("\nVajuta Enter, et avada menüü...");
            Console.ReadLine();

            while (tootab)
            {
                Console.Clear();
                Console.WriteLine("============= PEAMENÜÜ =============");
                Console.WriteLine("1 - Lae andmed uuesti failist mällu");
                Console.WriteLine("2 - Kuva restorani menüü");
                Console.WriteLine("3 - Lisa uus toit mällu");
                Console.WriteLine("4 - Kustuta toit mälust");
                Console.WriteLine("5 - Salvesta muudatused faili");
                Console.WriteLine("0 - Välju");
                Console.WriteLine("====================================");
                Console.Write("Vali tegevus (0-6): ");

                string valik = Console.ReadLine();
                Console.Clear();

                switch (valik)
                {
                    case "1":
                        Alamfunktsionid.LaeAndmedFailist();
                        break;
                    case "2":
                        Alamfunktsionid.ItaaliaRestoran();
                        break;
                    case "3":
                        Alamfunktsionid.LisaUusToit();
                        break;
                    case "4":
                        Alamfunktsionid.KustutaToit();
                        break;
                    case "5":
                        //Alamfunktsionid.SalvestaFaili();
                        break;
                    case "0":
                        Console.WriteLine("Programm suletud. Arrivederci!");
                        tootab = false;
                        break;
                    default:
                        Console.WriteLine("Vigane valik! Sisesta number 0 ja 6 vahel.");
                        break;
                }

                // Kui me pole väljumas, hoiame teksti ekraanil, kuni kasutaja on seda lugenud
                if (tootab)
                {
                    Console.WriteLine("\nVajuta Enter, et minna tagasi peamenüüsse...");
                    Console.ReadLine();
                }
            }
        }
    }
}
