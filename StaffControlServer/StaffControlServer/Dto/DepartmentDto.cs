using StaffControlServer.Data;
using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class DepartmentDto : MainDto
    {
        public string Name { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
