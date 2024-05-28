using manageServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IRoleService
    {
        List<Role> Get();
        Role GetById(int id);
        Task<Role> AddRoleAsync(Role e);
        Task<Role> UpdateRoleAsync(int id, Role e);
        Task DeleteRoleAsync(int id);
    }
}
