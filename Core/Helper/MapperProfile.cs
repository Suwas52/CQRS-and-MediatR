using AutoMapper;
using CQRS_and_MediatR.Core.DTOs;
using CQRS_and_MediatR.Model;

namespace CQRS_and_MediatR.Core.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<EmployeeCreateDto, Employee>();
        }
    }
}
