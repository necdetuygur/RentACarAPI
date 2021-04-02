using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Data.Tablolar
{
    public partial class Araba
    {
        public int ArabaId { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int UretimYili { get; set; }
        public string YakitTuru { get; set; }
        public string EhliyetSinifi { get; set; }
        public int KoltukSayisi { get; set; }
        public decimal GunlukUcret { get; set; }
        public int FirmaId { get; set; }
        public int? KiralamaId { get; set; }

        public virtual Firma Firma { get; set; }
        public virtual Kiralama Kiralama { get; set; }
    }
}
