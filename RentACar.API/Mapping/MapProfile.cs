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
        }
    }
}
