
using AutoMapper;
using manageServer.Entities;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Mapping
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<EmployeeRole, EmployeeRoleDto>();

        }
    }
}
