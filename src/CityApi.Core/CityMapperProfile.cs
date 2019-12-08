using AutoMapper;
using CityApi.Core.Models;

namespace CityApi.Core
{
    public class CityMapperProfile : Profile
    {
        public CityMapperProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CountryName,
                    opts => opts.MapFrom(
                        src => src.Country.Name
                    )).ReverseMap();
        }
    }
}
