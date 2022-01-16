using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Recenzje
    {
        public int Id_recenzji { get; set; }

        public int Przepis_id_przepisu { get; set; }

        public string Uzytkownik_nazwa_uzytkownika { get; set; }

        public float Ocena { get; set; }

        public string Komentarz { get; set; }

        public int Widzocnosc { get; set; }

        public DateTime Data_dodania { get; set; }

}
}