namespace NaidisRepo
{
    public class Osa2_funktsioonid
    {
        // *Kui eesnimi on Juku siis lähme Jukuga kinno. Lisa valiku, kus Juku vanuse alusel otsustate mis pilet talle vaja osta.
        // <6 aastad  - tasuta
        // 6-14 - lastepilet
        // 15-65 - täispilet
        // >65 - sooduspilet
        // <0 ja >100 viga andmetega
        public static void JukuKino()
        {
            Console.Write("Sisesta eesnimi: ");
            string eesnimi = Console.ReadLine();
            int vanus = 0;

            // *Kui eesnimi on Juku siis lähme Jukuga kinno.
            if (eesnimi.ToLower() != "juku")
            {
                Console.WriteLine("See ülesanne on Juku jaoks — sinu nimi pole Juku.");
                return;
            }

            Console.WriteLine("Lähme Jukuga kinno!");
            while (true)
            {
                Console.Write("Sisesta Juku vanus: ");
                try
                {
                    vanus = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Palun sisesta korrektne täisarv.");
                }
            }

            // <0 ja >100 viga andmetega
            if (vanus < 0 || vanus > 100)
            {
                Console.WriteLine("Vigased andmed. Vanus peab olema suurem kui 0 ja väiksem kui 100.");
                return;
            }

            string pilet = "";

            // <6 aastad  - tasuta
            if (vanus < 6)
            {
                pilet = "tasuta";
                Console.WriteLine("Pilet Juku jaoks on tasuta.");
                return;
            }
            // 6-14 - lastepilet
            else if (vanus <= 14)
            {
                pilet = "lastepilet";
            }
            // 15-65 - täispilet
            else if (vanus <= 65)
            {
                pilet = "täispilet";
            }
            // >65 - sooduspilet
            else
            {
                pilet = "sooduspilet";
            }
            Console.WriteLine($"Jukule on vaja: {pilet}.");
        }

        // Küsi kahe inimese nimed ning teata, et nad on täna pinginaabrid
        public static void Pinginaabrid()
        {
            Console.Write("Sisesta 1. õpilase nimi: ");
            string n1 = Console.ReadLine();
            Console.Write("Sisesta 2. õpilase nimi: ");
            string n2 = Console.ReadLine();

            Console.WriteLine($"{n1} ja {n2} on täna pinginaabrid.");
        }

        // Küsi ristkülikukujulise toa seinte pikkused ning arvuta põranda pindala.
        // Küsi kasutajalt remondi tegemise soov, kui ta on positiivne, siis küsi kui palju maksab ruutmeeter ja leia põranda vahetamise hind
        public static void TubaPindalaJaRemont()
        {
            double a = 0;
            double b = 0;

            // Küsi ristkülikukujulise toa seinte pikkused
            while (true)
            {
                Console.Write("Sisesta sein 1 pikkus (meetrites): ");
                try
                {
                    a = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne arv (nt 3.5).");
                }

            }

            // Küsi ristkülikukujulise toa seinte pikkused
            while (true)
            {
                Console.Write("Sisesta sein 2 pikkus (meetrites): ");
                try
                {
                    b = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne arv (nt 3.5).");
                }
            }

            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Pikkused peavad olema positiivsed.");
                return;
            }

            // * ... arvuta põranda pindala
            double pindala = a * b;
            Console.WriteLine($"Põranda pindala: {Math.Round(pindala, 2)} m2");

            bool remont = false;
            while (true)
            {
                // Küsi kasutajalt remondi tegemise soov
                Console.Write("Kas soovid remonti teha? (jah/ei): ");
                string vastus = Console.ReadLine().ToLower();

                if (vastus == "jah")
                {
                    remont = true;
                    break;
                }
                if (vastus == "ei")
                {
                    remont = false;
                    break;
                }

                Console.WriteLine("Palun vasta jah või ei.");
            }

            if (!remont)
            {
                Console.WriteLine("Remonti ei tehta.");
                return;
            }

            double hind = 0;
            while (true)
            {
                // * ... kui ta on positiivne, siis küsi kui palju maksab ruutmeeter
                Console.Write("Kui palju maksab 1 m2 (eurot): ");
                try
                {
                    hind = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne arv (nt 12.5).");
                }
            }

            if (hind < 0)
            {
                Console.WriteLine("Hind ei saa olla negatiivne.");
                return;
            }

            // * ... leia põranda vahetamise hind
            double kokku = pindala * hind;
            Console.WriteLine($"Põranda vahetamise hind: {Math.Round(kokku, 2)} eurot");
        }

        // Leia 30% hinnasoodustusega hinna põhjal alghind
        public static void Alghind30Soodustus()
        {
            double soodushind = 0;
            while (true)
            {
                Console.Write("Sisesta soodushind (€): ");
                try
                {
                    soodushind = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne arv (nt 12.5).");
                }
            }

            if (soodushind < 0)
            {
                Console.WriteLine("Hind ei saa olla negatiivne.");
                return;
            }

            // Leia 30% hinnasoodustusega hinna põhjal alghind
            double alghind = soodushind / 0.7;
            Console.WriteLine($"Alghind oli: {Math.Round(alghind, 2)} €");
        }

        // Küsi temperatuur ning teata, kas see on üle kaheksateistkümne kraadi (soovitav toasoojus talvel).
        public static void Temperatuur()
        {
            double t = 0;
            while (true)
            {
                // Küsi temperatuur
                Console.Write("Sisesta temperatuur (°C): ");
                try
                {
                    t = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne arv (nt 13).");
                }
            }

            // * ... teata, kas see on üle kaheksateistkümne kraadi (soovitav toasoojus talvel).
            if (t > 17.99)
                Console.WriteLine("Temperatuur on (või üle) 18°C (soovitav toasoojus talvel).");
            else
                Console.WriteLine("Temperatuur on alla 18°C.");
        }

        // Küsi inimese pikkus ning teata, kas ta on lühike, keskmine või pikk
        public static void PikkusKategooria()
        {
            int p = 0;
            while (true)
            {
                // * Küsi inimese pikkus
                Console.Write("Sisesta pikkus (cm): ");
                try
                {
                    p = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne täisarv");
                }
            }

            // * ... teata, kas ta on lühike, keskmine või pikk
            if (p < 160)
            {
                Console.WriteLine("Sa oled lühike.");
            }
            else if (p <= 185)
            {
                Console.WriteLine("Sa oled keskmine.");
            }
            else
            {
                Console.WriteLine("Sa oled pikk.");
            }
        }

        //Küsi inimeselt pikkus ja sugu ning teata, kas ta on lühike, keskmine või pikk.
        public static void PikkusJaSugu()
        {
            //Küsi inimeselt ... sugu
            Console.Write("Sisesta sugu (m/n): ");
            string sugu = Console.ReadLine().ToLower();

            int p = 0;
            while (true)
            {
                // Küsi inimeselt ... pikkus
                Console.Write("Sisesta pikkus (cm): ");
                try
                {
                    p = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sisesta palun korrektne täisarv");
                }
            }

            // * ... teata, kas ta on lühike, keskmine või pikk.
            if (sugu == "m")
            {
                if (p < 170)
                {
                    Console.WriteLine("Meeste jaoks on sa lühike");
                }
                else if (p <= 190)
                {
                    Console.WriteLine("Meeste jaoks on sa keskmine");
                }
                else
                {
                    Console.WriteLine("Meeste jaoks on sa pikk");
                }
            }
            else if (sugu == "n")
            {
                if (p < 160)
                {
                    Console.WriteLine("Naiste jaoks on sa lühike");
                }
                else if (p <= 175)
                {
                    Console.WriteLine("Naiste jaoks on sa keskmine");
                }
                else
                {
                    Console.WriteLine("Naiste jaoks on sa pikk");
                }
            }
            else
            {
                Console.WriteLine("Tundmatu sugu. Kasuta m või n.");
            }
        }

        // Küsi inimeselt poes eraldi kas ta soovib osta piima, saia, leiba. Löö hinnad kokku ning teata, mis kõik ostetud kraam maksma läheb.
        public static void PoodOstud()
        {
            string[] kysimused = {
                "piima",
                "saia",
                "leiba"
            };
            string[] nimed = {
                "piim",
                "sai",
                "leib"
            };
            double[] hinnad = {
                1.20,
                0.70,
                0.50
            };

            double summa = 0;
            List<string> ostud = new List<string>();

            // Küsi inimeselt poes eraldi kas ta soovib osta piima, saia, leiba.
            for (int i = 0; i < kysimused.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Kas soovid osta {kysimused[i]} ({hinnad[i]} eur)? (jah/ei): ");
                    string s = Console.ReadLine().ToLower();

                    if (s == "jah")
                    {
                        // Arvame hinnad kokku
                        summa += hinnad[i];
                        ostud.Add($"{nimed[i]} ({hinnad[i]} eur)");
                        break;
                    }
                    else if (s == "ei")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Palun vasta jah või ei.");
                    }
                }
            }

            // ... teata, mis kõik ostetud kraam maksma läheb.
            if (ostud.Count == 0)
            {
                Console.WriteLine("Midagi ei ostetud.");
            }
            else
            {
                Console.WriteLine("Ostetud: " + string.Join(", ", ostud));
                Console.WriteLine("Kokku: " + Math.Round(summa, 2) + " eur");
            }
        }

    }
}