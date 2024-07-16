using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class UserRoleDto : MainDto
    {
        public virtual UserDto User { get; set; }
        public virtual RoleDto Role { get; set; }
    }
}
