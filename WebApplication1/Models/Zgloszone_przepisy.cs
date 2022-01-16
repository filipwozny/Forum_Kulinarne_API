using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Zgloszone_przepisy
    {
        public int Id_zgloszenia { get; set; }

        public string Opis { get; set; }

        public int Przepis_id_przepisu { get; set; }

        public string Status_zgloszenia { get; set; }

        public DateTime Data_zgloszenia { get; set; }
    }
}