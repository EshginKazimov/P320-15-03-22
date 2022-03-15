using AutoMapper;
using P320.DomainModels.DTOs;
using P320.DomainModels.Entities;

namespace P320.Repository.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
