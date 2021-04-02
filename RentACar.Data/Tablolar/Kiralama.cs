using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Data.Tablolar
{
    public partial class Kiralama
    {
        public Kiralama()
        {
            Alicis = new HashSet<Alici>();
            Arabas = new HashSet<Araba>();
        }

        public int KiralamaId { get; set; }
        public int AliciId { get; set; }
        public int ArabaId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }

        public virtual ICollection<Alici> Alicis { get; set; }
        public virtual ICollection<Araba> Arabas { get; set; }
    }
}
