using System.ComponentModel.DataAnnotations;

namespace RentACar.API.DTOs
{
    public class ArabaDto
    {
        public int ArabaID { get; set; }
        [Required]
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int UretimYili { get; set; }
        public string YakitTuru { get; set; }
        public string EhliyetSinifi { get; set; }
        public int KoltukSayisi { get; set; }
    }
}
