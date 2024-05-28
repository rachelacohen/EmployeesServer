using manageServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public bool Isadministrative { get; set;}
        //public EmployeeRoleDto EntryDate { get; set; }
        //public DateTime EntryDate { get; set;}

    }
}
