using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisRepo.Itaalia_toit
{
    public class Menu
    {
        public string Nimetus { get; set; }
        public List<string> Koostisosad { get; set; }
        public double Hind { get; set; }
        
        // konstruktor, mis loob Menu object

        public Menu(string nimetus, List<string> koostisosad, double hind)
        {
            Nimetus = nimetus;
            Koostisosad = koostisosad;
            Hind = hind;
        }

        // Meetod, mis teeb objektist tekstirea
        // Tulemus: "Nimetus;Koostisosad1;Koostisosad2,...;Hind"
        // Näiteks: "Pizza;Tomat,Juust,Peperoni;12.99"
        public string VorminaFailijaoksrea()
        {
            string ained = string.Join(",", Koostisosad);
            return $"{Nimetus};{ained};{Hind}";
        }





    }
}
