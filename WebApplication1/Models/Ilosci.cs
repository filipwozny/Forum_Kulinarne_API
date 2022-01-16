using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Ilosci
    {
        public int Id { get; set; }

        public float Ilosc { get; set; }

        public string Skladnik_nazwa { get; set; }

        public string Jednostka_nazwa { get; set; }

        public int Przepis_id { get; set; }
    }
}