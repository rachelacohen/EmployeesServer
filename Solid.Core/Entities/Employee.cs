using Solid.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace manageServer.Entities
{
    public enum Kind{זכר, נקבה}
    public class Employee
    {
        public int Id { get; set; }
        public string TZ { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public List<EmployeeRole> Roles { get; set; }
        public DateTime BirthDate { get; set; }
        public Kind KindOf { get; set; }
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
        public string Email { get; set; }

    }
}
