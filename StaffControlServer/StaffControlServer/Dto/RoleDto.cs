using Microsoft.AspNetCore.Identity;
using StaffControlServer.Data;
using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class RoleDto : MainDto
    {
        public string Name { get; set; }

        public Guid? ParentRoleId { get; set; }
        public RoleDto? ParentRole { get; set; }

        public Guid? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
        public ICollection<UserDto> Users { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
