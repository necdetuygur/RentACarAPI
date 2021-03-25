using AutoMapper;
using RentACar.API.DTOs;
using RentACar.Core.Models;

namespace RentACar.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Araba, ArabaDto>();
            CreateMap<ArabaDto, Araba>();

            CreateMap<Alici, AliciDto>();
            CreateMap<AliciDto, Alici>();

            CreateMap<Firma, FirmaDto>();
            CreateMap<FirmaDto, Firma>();

            CreateMap<Kiralama, KiralamaDto>();
            CreateMap<KiralamaDto, Kiralama>();
        }
    }
}
