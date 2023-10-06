using AutoMapper;
using MagicVilla_VillaAPI2.Models;
using MagicVilla_VillaAPI2.Models.Dto;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_VillaAPI2
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

        }
    }
}
