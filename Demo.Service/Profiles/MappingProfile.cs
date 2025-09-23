using AutoMapper;
using Demo.DataAccess.Migrations;
using Demo.Service.Dtos.EmployeesDTO;

using Demo.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
             .ForMember(dist => dist.Gender, opt => opt.MapFrom(src => src.Gender))
             .ForMember(dist => dist.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
             .ReverseMap();
            CreateMap<Employee, EmployeeDetailsDto>()
             .ForMember(dist => dist.Gender, opt => opt.MapFrom(src => src.Gender))
             .ForMember(dist => dist.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
             .ReverseMap(); ;
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
        }
    }
}
