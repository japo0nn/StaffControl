using StaffControlServer.Data.Abstract;

namespace StaffControlServer.Data
{
    public class Calendar : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
