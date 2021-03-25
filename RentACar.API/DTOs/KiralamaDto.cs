using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.API.DTOs
{
    public class KiralamaDto
    {
        public int KiralamaID { get; set; }
        [Required]
        public int AliciID { get; set; }
        [Required]
        public int ArabaID { get; set; }
        [Required]
        public DateTime BaslangicTarihi { get; set; }
        [Required]
        public DateTime BitisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
    }
}
