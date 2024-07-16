using StaffControlServer.Data.Abstract;
using StaffControlServer.Enum;

namespace StaffControlServer.Data
{
    public class ToDo : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompleteDate { get; set; }
        public ToDoStatus Status {  get; set; } = ToDoStatus.Awaiting;
        
        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public Guid ResponsibleId { get; set; }
        public User Responsible { get; set; }
    }
}
