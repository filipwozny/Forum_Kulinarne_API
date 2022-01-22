using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Ilosci
    {
        public int Id { get; set; }

        public float ilosc { get; set; }

        public string skladnik_nazwa { get; set; }

        public string jednostka_nazwa { get; set; }

        public int przepis_id { get; set; }
    }
}