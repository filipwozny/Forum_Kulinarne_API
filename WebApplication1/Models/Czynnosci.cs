using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Czynnosci
    {
        public int Id_czynnosci { get; set; } 

        public int Id_przepisu { get; set; }

        public int Kolejnosc_w_przepisie { get; set; }

        public string Opis { get; set; }


    }
}