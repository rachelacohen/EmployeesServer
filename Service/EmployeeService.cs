using manageServer.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        public Task<Employee> AddEmployeeAsync(Employee e)
        {
            e.Status = true;
            return _EmployeeRepository.AddEmployeeAsync(e);
        }
        public Task<Employee> DeleteEmployeeAsync(int id)
        {
            return _EmployeeRepository.DeleteEmployeeAsync(id);
        }

        public IEnumerable<Employee> Get()
        {
            var list = _EmployeeRepository.Get().Where(x => x.Status == true).ToList();
            return list;
        }

        public Employee GetById(int id)
        {
            return _EmployeeRepository.GetById(id);
        }

        public Task<Employee> UpdateEmployeeAsync(int id, Employee e)
        {


            return _EmployeeRepository.UpdateEmployeeAsync(id, e);


        }


    }
}
