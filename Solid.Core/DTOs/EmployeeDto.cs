using manageServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string TZ { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public List<EmployeeRoleDto> Roles { get; set; }
        public DateTime BirthDate { get; set; }
        public Kind KindOf { get; set; }
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
        public string Email { get; set; }

    }
}
