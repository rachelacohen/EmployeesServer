using manageServer.Entities;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;


namespace Solid.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployeeAsync(Employee e)
        {
            if (_context.Employees.ToList().Find(x => x.TZ == e.TZ) != null)
            {
                throw new Exception("ת.ז. קיימת במערכת");
            }

            List<Role> Roles = _context.Roles.ToList();
            List<EmployeeRole> empRole = new List<EmployeeRole>();
            foreach (EmployeeRole item in e.Roles)
            {
                var r = Roles.Find(x => x.Name == item.Role.Name);
                if(r == null)
                    throw new Exception("תפקיד לא קיים במערכת");
                EmployeeRole r2 = new EmployeeRole { EmployeeId = e.Id, Employee = e, Role = r, RoleId = r.Id, StartDate = item.StartDate };
                empRole.Add(r2);
            }
            e.Roles = empRole;
            _context.Employees.AddAsync(e);

            await _context.SaveChangesAsync();
            return e;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var item = _context.Employees.ToList().Find(x => x.Id == id);
            if (item != null)
            {
                item.Status = false;
                await _context.SaveChangesAsync();

                return item;
            }
            return null;
        }

        public List<Employee> Get()
        {
            var list = _context.Employees.Include(e => e.Roles).ThenInclude(x => x.Role).ToList();
            return list;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Include(x => x.Roles).ThenInclude(x => x.Role).ToList().Find(x => x.Id == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee e)
        {
            //var temp = _context.Employees.ToList().Find(x => x.TZ == e.TZ);
            //if (temp != null && temp.Id != e.Id)
            //{
            //    throw new Exception("ת.ז. קיימת במערכת");
            //}

            

                var update = _context.Employees.Include(e => e.Roles).FirstOrDefault(e => e.Id == id);
                if (update != null)
                {
                    _context.EmployeeRoles.RemoveRange(update.Roles);
                    update.Name = e.Name;
                    update.Status = e.Status;
                    update.TZ = e.TZ;
                List<Role> Roles = _context.Roles.ToList();
                List<EmployeeRole> empRole = new List<EmployeeRole>();
                foreach (EmployeeRole item in update.Roles)
                {
                    var r = Roles.Find(x => x.Name == item.Role.Name);
                    if (r == null)
                        throw new Exception("תפקיד לא קיים במערכת");
                    EmployeeRole r2 = new EmployeeRole { EmployeeId = e.Id, Employee = e, Role = r, RoleId = r.Id, StartDate = item.StartDate };
                    empRole.Add(r2);
                }
                update.Roles = empRole;
                    update.BirthDate = e.BirthDate;
                    update.FamilyName = e.FamilyName;
                    update.KindOf = e.KindOf;
                    update.EntryDate = e.EntryDate;
                    update.Status = true;
                    update.Email = e.Email;
                    await _context.SaveChangesAsync();
                    return update;
                }
          
            return null;
        }
    }


}
