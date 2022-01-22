using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace WebApplication1.Models
{
    public class Przepisy
    {
        public int Id_przepisu { get; set; }

        public string Nazwa { get; set; }

        public float Srednia_recenzji { get; set; }

        public string Autor { get; set; }

        public string Admin_nazwa_uzytkownika { get; set; }

        public int Widocznosc { get; set; }

        public DateTime Data_dodania { get; set; }

        public string photoName { get; set; }

        public string Opis { get; set; }

    }
}