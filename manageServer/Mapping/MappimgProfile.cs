using AutoMapper;
using manageServer.Entities;
using manageServer.Models;
using Solid.Core.DTOs;
using Solid.Core.Entities;

namespace Solid.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<RolePostModel, Role>();
            CreateMap<LoginPostModel, Login>(); 
            CreateMap<EmployeeRolePostModel, EmployeeRole>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<EmployeeRole, EmployeeRoleDto>();
            CreateMap<RolePostModel2, Role>();
        }
    }
}
