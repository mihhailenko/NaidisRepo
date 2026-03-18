using System.Collections;
using System.Xml.Linq;


namespace NaidisRepo.osa5.Uurimine
{
    public class StartPage
    {

        public static void Main(string[] args)
        {
            //ArrayList nimed = new ArrayList();
            //nimed.Add("Kati");
            //nimed.Add("Mati");
            //nimed.Add("Juku");

            //if (nimed.Contains("Mati"))
            //    Console.WriteLine("Mati olemas");

            //Console.WriteLine("Nimesid kokku: " + nimed.Count);

            //nimed.Insert(1, "Sass");

            //Console.WriteLine("Mati indeks: " + nimed.IndexOf("Mati"));
            //Console.WriteLine("Mari indeks: " + nimed.IndexOf("Mari"));

            //foreach (string nimi in nimed)
            //    Console.WriteLine(nimi);

            //Tuple<float, char> route = new Tuple<float, char>(2.5 f, 'N');
            //Console.WriteLine($"Vahemaa: {route.Item1}, Suund: {route.Item2}");







            //Osa5_List3_string();
            Osa5_List3_binary();
        }

        public static void Osa5_List3()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Listi numbers sisu enne muudatust:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            numbers.Remove(1);

            Console.WriteLine("Muudatud list:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }




            List<Person> people = new List<Person>();


            //List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Kadi" });
            people.Add(new Person() { Name = "Mirje" });

            Person liza = new Person() { Name = "Lisa" };

            foreach (Person p in people)
                Console.WriteLine(p.Name);
            List<Person> people_dva = new List<Person>();


            people_dva.Add(new Person() { Name = "Artjom" });
            people_dva.Add(new Person() { Name = "Mari" });

            people.AddRange(people_dva);

            Console.WriteLine("++++++++");

            foreach (Person p in people)
                Console.WriteLine(p.Name);

            people.RemoveAt(2);


            Console.WriteLine("----------");

            foreach (Person p in people)
                Console.WriteLine(p.Name);
        
        }

        public static void Osa5_List3_string()
        {
            List<string> people = new List<string>() { "Kadi", "Mirje"};

            foreach (string p in people)
                Console.WriteLine(p);

            people.Add("Lisa");
            people.Add("Artjom");
            //people.Remove("Lisa");

            people.RemoveAt(2);

            people.Sort((a, b) => a.Length.CompareTo(b.Length));

            Console.WriteLine("List people peale sortimist ja muudatust");
            foreach (string p in people)
                Console.WriteLine(p);
        }

        public static void Osa5_List3_binary()
        {
            List<string> people = new List<string>() { "Kadi", "Mirje" };

            Console.WriteLine(people.BinarySearch("Kadi"));
        }

        public static void Osa5_LinketList4()
        {
            LinkedList<int> loetelu = new LinkedList<int>();
            loetelu.AddLast(5);
            loetelu.AddLast(3);
            loetelu.AddFirst(0);
            loetelu.AddLast(1);
            loetelu.AddFirst(2);

            loetelu.AddBefore(loetelu.Find(1), 4);
            loetelu.AddAfter(loetelu.Find(1), 6);

            foreach (int arv in loetelu) { 
                Console.WriteLine(arv);
            }


            loetelu.AddFirst(123);
            //loetelu.AddBefore(3, 456);

            loetelu.RemoveFirst();
            loetelu.RemoveLast();
            loetelu.AddLast(555);
            loetelu.Remove(555);
        }
    } 
}
