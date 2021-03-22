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
        public decimal GunlukUcret { get; set; }
        public int FirmaID { get; set; }
        public virtual Firma Firma { get; set; }
    }
}
