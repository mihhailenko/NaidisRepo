namespace NaidisRepo.osa5
{
    public class StartPage
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("5. osa Andmestruktuurid ja nendega töötamine");
                Console.WriteLine("Milline ÜL kas te tahaksite üle vaadata?");
                Console.WriteLine();

                Console.WriteLine("1  - ÜL: Kalorite kalkulaator klassidega");
                Console.WriteLine("2  - ÜL: Maakonnad ja pealinnad");
                Console.WriteLine("3  - ÜL: Õpilased ja hinnete analüüs");
                Console.WriteLine("4  - ÜL: Filmide kogu");
                Console.WriteLine("5  - ÜL: Arvude massiivi statistika");
                Console.WriteLine("6  - ÜL: Lemmikloomade register");
                Console.WriteLine("7  - ÜL: Valuutakalkulaator");
                Console.WriteLine("0  - Välju");
                Console.WriteLine();

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Osa5_funktsioonid.KaloriteKalkulaator();
                        break;
                    case "2":
                        //Osa5_funktsioonid.MaakonnadJaPealinnad();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
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
