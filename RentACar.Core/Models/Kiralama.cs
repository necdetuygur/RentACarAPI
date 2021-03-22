using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RentACar.Core.Models
{
    public class Kiralama
    {
        public Kiralama()
        {
            Alicis = new Collection<Alici>();
            Arabas = new Collection<Araba>();
        }
        public int KiralamaID { get; set; }
        public int AliciID { get; set; }
        public int ArabaID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public ICollection<Alici> Alicis { get; set; }
        public ICollection<Araba> Arabas { get; set; }
    }
}
