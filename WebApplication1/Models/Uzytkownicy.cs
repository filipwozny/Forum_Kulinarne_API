using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace WebApplication1.Models
{

    public class Uzytkownicy { 
    
        public string Nazwa_uzytkownika { get; set; }

        public string Haslo { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public Boolean Czy_admin { get; set; }
       

        public int Numer_telefonu { get; set; }

        public string Mail { get; set; }

        
    }
}