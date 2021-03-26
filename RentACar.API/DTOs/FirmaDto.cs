using System.Collections.Generic;

namespace RentACar.API.DTOs
{
    public class FirmaDto
    {
        public FirmaDto()
        {
            this.Arabas = new List<ArabaDto>();
        }
        public int FirmaID { get; set; }
        public string Unvan { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string VergiNo { get; set; }
        public List<ArabaDto> Arabas { get; set; }

    }
}
