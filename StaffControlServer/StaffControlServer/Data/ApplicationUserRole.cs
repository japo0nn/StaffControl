using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffControlServer.Data
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
