using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.Itaalia_toit
{
    public class Alamfunktsionid
    {
        static string MenuPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menu.txt");
        static List<Menu> MenuList = new List<Menu>();

        public static void LaeAndmedFailist()
        {
            Console.WriteLine("laetakse andmeid failist...");
            if (File.Exists(MenuPath))
            {
                string[] osad = File.ReadAllLines(MenuPath);
                foreach (string line in osad)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        string nimetus = parts[0];
                        List<string> koostisosad = new List<string>(parts[1].Split(','));
                        double hind = double.Parse(parts[2].Replace('.', ','));
                        Menu MenuItem = new Menu(nimetus, koostisosad, hind);
                        MenuList.Add(MenuItem);
                    }
                    Console.WriteLine($"Andmed on edukalt laaditud. Kokku on {MenuList.Count} toitu");
                }
            }
            else
            {
                Console.WriteLine("Andmefaili ei leitud. Palun veenduge, et 'Menu.txt' on olemas. ");
            }
        }
        public static void ItaaliaRestoran()
        {
            Console.Clear();
            Console.WriteLine("Tere tulemast Itaalia restoraani!");
            Console.WriteLine("=================================");
            Console.WriteLine("Menüü:");
            Console.WriteLine("=================================");
            if (MenuList.Count == 0)
            {
                Console.WriteLine("Menüü on tühi. Palun laadige andmed failist.(Valik 1)");
            }
            else
            {
                foreach (Menu item in MenuList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Nimetus:{item.Nimetus}"); // Nimetus roheliselt 
                    Console.ResetColor();
                    Console.WriteLine($"Koostisosad: {string.Join(", ", item.Koostisosad)}"); // Koostisosad Tavalise värviga
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Hind: {item.Hind}€"); //Hind punaselt
                    Console.ResetColor();
                    Console.WriteLine("---------------------------------");
                }
            }
        }
        public static void LisaUusToit()
        {
            Console.WriteLine("Sisesta uue toidu info...");
            Console.WriteLine("Nimetus: ");
            string nimetus = Console.ReadLine();
            Console.WriteLine("Koostisosad: ");
            List<string> koostisosad = new List<string>();
            while (true)
            {
                Console.WriteLine("Aine (või vajuta Enter, et Lõpetada):");
                string aine = Console.ReadLine();
                if (string.IsNullOrEmpty(aine))
                {
                    break; // Lõpetame koostisosade sisestamine 
                }
                koostisosad.Add(aine);

            }
            Console.Write("Sisesta hind (nt 12.99): ");
            double hind = double.Parse(Console.ReadLine().Replace('.', ','));
            MenuList.Add(new Menu(nimetus, koostisosad, hind));
            Console.WriteLine($"Uus toit {nimetus} on menüüsse lisatud!");
        }
        public static void SalvestAndmedFaili()
        {
            Console.WriteLine("Salvestatakse andmed faili...");
            try
            {
                List<string> failiread = new List<string>();
                foreach (Menu item in MenuList)
                {
                    failiread.Add(item.VorminaFailijaoksrea());
                }
                File.WriteAllLines(MenuPath, failiread);
                Console.WriteLine("Andmed on edukalt salvestanud faili");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Andmete salvestamisel tekkis viga: {e.Message}");
            }
        }
        public static void KustutaToit()
        {
            Console.WriteLine("Sisesta kustutava toidu nimetus;");
            string nimetus = Console.ReadLine();
            Menu itemToRemove = MenuList.Find(item => item.Nimetus.Equals(nimetus, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                MenuList.Remove(itemToRemove);
                Console.WriteLine($"Toit {nimetus} on menüüst kustutatud.");
            }
            else
            {
                Console.WriteLine($"Toitu nimega{nimetus} ei leitud menüüst.");
            }
        }
        public static void ToiduInformatsioon()
        {
            Console.WriteLine("Sisesta otsiva toidu nimetus: ");
            string nimetus = Console.ReadLine();
            Menu itemToFind = MenuList.Find(item => item.Nimetus.Equals(nimetus, StringComparison.OrdinalIgnoreCase));
            if (itemToFind != null)
            {
                Console.WriteLine($"Toit {nimetus} koostab: ");
            }
            else
            {
                Console.WriteLine($"Toitu nimega {nimetus} ei leitud menüüs.");
            }
        }
    }
}
