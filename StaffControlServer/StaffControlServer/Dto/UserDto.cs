using Microsoft.AspNetCore.Identity;
using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class UserDto : MainDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ParentUserId { get; set; }
        public UserDto? ParentUser { get; set; }

        public FileSystemDto? File { get; set; }

        public List<ToDoDto> ToDoList { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
