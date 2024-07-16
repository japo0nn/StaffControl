using Microsoft.AspNetCore.Identity;
using StaffControlServer.Data.Abstract;
using StaffControlServer.Dto;

namespace StaffControlServer.Data
{
    public class Role : IdentityRole<Guid>
    {
        public Guid? ParentRoleId { get; set; }
        public Role ParentRole { get; set; }

        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<User> Users { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
