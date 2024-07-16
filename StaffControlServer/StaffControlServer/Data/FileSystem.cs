using StaffControlServer.Data.Abstract;

namespace StaffControlServer.Data
{
    public class FileSystem : Entity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        public string FileExtension { get; set; }

        public Guid? NewsId { get; set; }
        public News? News { get; set; }
    }
}
