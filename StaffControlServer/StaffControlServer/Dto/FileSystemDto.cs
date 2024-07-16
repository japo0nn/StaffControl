using StaffControlServer.Dto.Abstract;
using System.Security.Policy;

namespace StaffControlServer.Dto
{
    public class FileSystemDto : MainDto
    {
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string FileBase64 { get; set; }
    }
}
