using AutoMapper;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Dtos;

namespace EmployeeRegister.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
