using StaffControlServer.Data.Abstract;

namespace StaffControlServer.Data
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
