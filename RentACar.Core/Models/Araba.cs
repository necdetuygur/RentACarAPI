using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Models
{
    public class Araba
    {
        public int ArabaID { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int UretimYili { get; set; }
        public string YakitTuru { get; set; }
        public string EhliyetSinifi { get; set; }
        public int KoltukSayisi { get; set; }
    }
}
