using StaffControlServer.Dto.Abstract;
using StaffControlServer.Enum;

namespace StaffControlServer.Dto
{
    public class ToDoDto : MainDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompleteDate { get; set; }
        public ToDoStatus Status { get; set; }

        public Guid? AuthorId { get; set; }
        public UserDto Author { get; set; }

        public Guid ResponsibleId { get; set; }
        public UserDto Responsible { get; set; }
    }
}
