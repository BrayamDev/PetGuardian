using AutoMapper;
using PetGuardianAPI.DTOs;
using PetGuardianAPI.Entidades;

namespace PetGuardianAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mapper de vacunas
            CreateMap<vacunas, VacunasDTO>().ReverseMap();
            CreateMap<VacunasCreacionDTO, vacunas>();
            //Mapper de adopdantes
            CreateMap<adoptantes, AdoptantesDTO>().ReverseMap();
            CreateMap<AdoptantesCreacionDTO, adoptantes>()
                .ForMember(x => x.foto, options => options.Ignore());
            CreateMap<AdoptantePathDTO, adoptantes>().ReverseMap();
            //Mapper de tipo de animal
            CreateMap <tipoAnimal, TipoAnimalDTO>().ReverseMap();
            CreateMap<TipoAnimalCreacionDTO, tipoAnimal>();
            //Mapper de fundaciones
            CreateMap<fundaciones, FundacionDTO>().ReverseMap();
            CreateMap<FundacionCreacionDTO, fundaciones>();
            //Mapper para animales
            CreateMap<animales, AnimalesDTO>().ReverseMap();
            CreateMap<AnimalCreacionDTO, animales>()
                .ForMember(x => x.imagen, options => options.Ignore());
            CreateMap<AnimalPatchDTO, animales>().ReverseMap();

        }
    }
}
