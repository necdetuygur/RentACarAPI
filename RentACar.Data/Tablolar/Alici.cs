using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Data.Tablolar
{
    public partial class Alici
    {
        public int AliciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TckimlikNo { get; set; }
        public string CepTel { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public int? KiralamaId { get; set; }

        public virtual Kiralama Kiralama { get; set; }
    }
}
