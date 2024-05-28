using manageServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        Employee GetById(int id);
        Task<Employee> AddEmployeeAsync(Employee e);
        Task<Employee> UpdateEmployeeAsync( int id, Employee e);
        Task<Employee> DeleteEmployeeAsync( int id);

    }
}
