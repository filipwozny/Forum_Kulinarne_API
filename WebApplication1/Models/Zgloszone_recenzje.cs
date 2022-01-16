using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Zgloszone_recenzje
    {
        public int Id_zgloszenia { get; set; }

        public string Opis { get; set; }

        public string Status_zgloszenia { get; set; }

        public DateTime Data_zgloszenia { get; set; }

        public int Recenzje_id_recenzji { get; set; }

    }
}