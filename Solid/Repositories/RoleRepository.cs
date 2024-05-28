using manageServer.Entities;
using Solid.Core.Repositories;


namespace Solid.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Role> AddRoleAsync(Role r)
        {
            if (_context.Roles.ToList().Find(x => x.Name == r.Name) == null)
            {
                _context.Roles.AddAsync(r);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("תפקיד קיים במערכת");
            return r;
        }

        public async Task DeleteRoleAsync(int id)
        {
            _context.Roles.Remove(_context.Roles.ToList().Find(x => x.Id == id));
            _context.SaveChangesAsync();
        }

        public List<Role> Get()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.ToList().Find(x => x.Id == id);
        }

        public async Task<Role> UpdateRoleAsync(int id, Role r)
        {
            var update = _context.Roles.ToList().Find(x => x.Id == id);
            if (_context.Roles.ToList().Find(x => x.Name == update.Name) != null)
            {
                throw new Exception("תפקיד קיים במערכת");
            }
            if (update != null)
            {
                update.Name = r.Name;
                update.Isadministrative = r.Isadministrative;
                await _context.SaveChangesAsync();
                return update;
            }
            return null;
        }
    }
}
