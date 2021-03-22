using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RentACar.Core.Models
{
    public class Firma
    {
        public Firma()
        {
            Arabas = new Collection<Araba>();
        }
        public int FirmaID { get; set; }
        public string Unvan { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string VergiNo { get; set; }
        public ICollection<Araba> Arabas { get; set; }
    }
}
