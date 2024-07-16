using StaffControlServer.Dto.Abstract;

namespace StaffControlServer.Dto
{
    public class NewsDto : MainDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public UserDto? User { get; set; }

        public ICollection<FileSystemDto> Files { get; set; }
    }
}
