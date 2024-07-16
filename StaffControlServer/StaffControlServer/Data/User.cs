using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
using StaffControlServer.Data.Abstract;
using StaffControlServer.Dto;
using StaffControlServer.Enum;

namespace StaffControlServer.Data
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? TwoFactorCode { get; set; }

        public Guid? ParentUserId { get; set; }
        public User ParentUser { get; set; }

        public Guid? FileId { get; set; }
        public FileSystem File { get; set; }

        public ICollection<ToDo> ToDoList { get; set; }

        public ICollection<Calendar> Calendars { get; set; }

        public ICollection<Role> Roles { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
