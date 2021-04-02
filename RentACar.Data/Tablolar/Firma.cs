using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Data.Tablolar
{
    public partial class Firma
    {
        public Firma()
        {
            Arabas = new HashSet<Araba>();
        }

        public int FirmaId { get; set; }
        public string Unvan { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string VergiNo { get; set; }

        public virtual ICollection<Araba> Arabas { get; set; }
    }
}
