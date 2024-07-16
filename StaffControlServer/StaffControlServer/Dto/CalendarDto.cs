using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class CalendarDto : MainDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
