using System.Text;

namespace NaidisRepo

{
    public class StartPage
    {

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Tere tulemast minu programmisse!");
                Console.WriteLine("Milline ülesanne osa kas te tahaksite jooksma panna?");

                Console.WriteLine("1. Osa Andmetüübid");
                Console.WriteLine("2. Osa Funktsioonid");
                Console.WriteLine("3. Osa Kordused, Listid ja Massiivid");
                Console.WriteLine("4. Osa Failitöötlus");
                Console.WriteLine("5. Osa");
                Console.WriteLine("0. Välja");

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Esimene_osa();
                        break;
                    case "2":
                        Teine_osa();
                        break;
                    case "3":
                        Kolmas_osa();
                        break;
                    case "4":
                        Neljas_osa();
                        break;
                    case "5":
                        Console.WriteLine("Ei ole see ülesanne veel valmis. Tulge tagasi hiljem.");
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Äitah kasutamise eest! Tulge tagasi mõni kord veel.");
                        return;

                    default:
                        Console.WriteLine("Tundmatu valik. Vajuta Enter...");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        public static void Esimene_osa()
        {
            Console.WriteLine("1. Osa Andmetüübid");

            string tekst = "Tere tulemast C# maailma!";

            Console.WriteLine($"Oli loodud muutuja tekst, mis võrdub: {tekst}");
            Console.WriteLine("Oli loodud muutuja tekst, mis võrdub: {0}", tekst);

            Console.Write("Mis on sinu nimi?: ");
            string nimi = Console.ReadLine();

            Console.Write("Kui vana sa oled?: ");

            try
            {
                int vanus = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tere {nimi}. Sa oled {vanus} aastat vana");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                Console.Write("Arv 1");
                float a = float.Parse(Console.ReadLine());
                Console.Write("Arv 2");
                float b = float.Parse(Console.ReadLine());
                float vastus = Naidis_funktsioonid.Summa(a, b);
                Console.WriteLine($"Summa {a} ja {b} võrdub {vastus}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void Teine_osa()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("2. osa Funktsioonid");
                Console.WriteLine("Milline ÜL kas te tahaksite üle vaadata?");
                Console.WriteLine();

                Console.WriteLine("1  - ÜL: Juku kino pilet");
                Console.WriteLine("2  - ÜL: Kaks pinginaabrit");
                Console.WriteLine("3  - ÜL: Ristküliku toa pindala   remondi hind");
                Console.WriteLine("4  - ÜL: Leia alghind (30% soodustuse alghinnaga)");
                Console.WriteLine("5  - ÜL: Temperatuur > 18?");
                Console.WriteLine("6  - ÜL: Pikkuse kategooria - lühike / keskmine / pikk");
                Console.WriteLine("7  - ÜL: Pikkus   sugu - lühike / keskmine / pikk");
                Console.WriteLine("8  - ÜL: Poes ostud");
                Console.WriteLine("0  - Tagasi");
                Console.WriteLine();

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Osa2_funktsioonid.JukuKino();
                        break;
                    case "2":
                        Osa2_funktsioonid.Pinginaabrid();
                        break;
                    case "3":
                        Osa2_funktsioonid.TubaPindalaJaRemont();
                        break;
                    case "4":
                        Osa2_funktsioonid.Alghind30Soodustus();
                        break;
                    case "5":
                        Osa2_funktsioonid.Temperatuur();
                        break;
                    case "6":
                        Osa2_funktsioonid.PikkusKategooria();
                        break;
                    case "7":
                        Osa2_funktsioonid.PikkusJaSugu();
                        break;
                    case "8":
                        Osa2_funktsioonid.PoodOstud();
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


        public static void Kolmas_osa()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("3. osa Kordused, Listid ja Massiivid");
                Console.WriteLine("Milline ÜL kas te tahaksite üle vaadata?");
                Console.WriteLine();

                Console.WriteLine("1  - Juhuslike arvude ruudud"); // TODO
                Console.WriteLine("2  - Viie arvu analüüs");
                Console.WriteLine("3  - Nimed ja vanused");
                Console.WriteLine("4  - Osta elevant ära!");
                Console.WriteLine("5  - Arvamise mäng");
                Console.WriteLine("6  - Suurim neliarvuline arv"); // TODO
                Console.WriteLine("7  - Korrutustabel");
                Console.WriteLine("8  - Õpilastega mängimine");
                Console.WriteLine("9  - Arvude ruudud");
                Console.WriteLine("10 - Positiivsed ja negatiivsed");
                Console.WriteLine("11 - Keskmisest suuremad");
                Console.WriteLine("12 - Kõige suurema arvu otsing");
                Console.WriteLine("13 - Paari- ja paaritud loendused");
                Console.WriteLine("0  - Tagasi");
                Console.WriteLine();

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Console.WriteLine("Ei ole see ülesanne veel valmis. Tulge tagasi hiljem.");
                        break;
                    case "2":
                        Osa3_funktsioonid.ViieArvuAnaluus();
                        break;
                    case "3":
                        Osa3_funktsioonid.NimedJaVanused();
                        break;
                    case "4":
                        Osa3_funktsioonid.OstaElevantAra();
                        break;
                    case "5":
                        Osa3_funktsioonid.ArvamiseMang();
                        break;
                    case "6":
                        Console.WriteLine("Ei ole see ülesanne veel valmis. Tulge tagasi hiljem.");
                        //Kolmas_osa_funktsioonid.SuurimNeliarvulineArv();
                        break;
                    case "7":
                        Osa3_funktsioonid.Korrutustabel();
                        break;
                    case "8":
                        Osa3_funktsioonid.OpilastegaMangimine();
                        break;
                    case "9":
                        Osa3_funktsioonid.ArvudeRuudud();
                        break;
                    case "10":
                        Osa3_funktsioonid.PositNegNull();
                        break;
                    case "11":
                        Osa3_funktsioonid.KeskmisestSuuremad();
                        break;
                    case "12":
                        Osa3_funktsioonid.SuurimArvJaIndeks();
                        break;
                    case "13":
                        Osa3_funktsioonid.PaarJaPaarituStat();
                        break;
                    case "0":
                        Console.Clear();
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

        public static void Neljas_osa()
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
                         //Osa4_funktsioonid.KoostisosadeMuutmine();
                         break;
                     case "4":
                         //Osa4_funktsioonid.KoostisosaOtsing();
                         break;
                     case "5":
                         //Osa4_funktsioonid.KoostisosadeSalvestamine();
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