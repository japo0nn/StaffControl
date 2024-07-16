using StaffControlServer.Enum;

namespace StaffControlServer.Views
{
    public class TaskFilterViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ToDoStatus? ToDoStatus { get; set; }
    }
}
