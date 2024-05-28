using manageServer.Entities;
using Solid.Core.Entities;

namespace manageServer.Models
{
    public class EmployeePostModel
    {
        public string Email { get; set; }
        public string TZ { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public List<EmployeeRolePostModel> Roles { get; set; }
        public DateTime BirthDate { get; set; }
        public Kind KindOf { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
