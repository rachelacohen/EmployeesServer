using manageServer.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }
        public Task<Role> AddRoleAsync(Role e)
        {
            try
            {
                return _RoleRepository.AddRoleAsync(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task DeleteRoleAsync(int id)
        {
            return _RoleRepository.DeleteRoleAsync(id);
        }

        public List<Role> Get()
        {
            return _RoleRepository.Get();
        }

        public Role GetById(int id)
        {
            return _RoleRepository.GetById(id);
        }

        public Task<Role> UpdateRoleAsync(int id, Role e)
        {
            try
            {
                return _RoleRepository.UpdateRoleAsync(id, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
