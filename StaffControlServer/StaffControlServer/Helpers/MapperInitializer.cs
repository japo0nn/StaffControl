using AutoMapper;
using StaffControlServer.Data;
using StaffControlServer.Dto;

namespace StaffControlServer.Helpers
{
    public class MapperInitializer
    {
        private static readonly object _locker = new object();
        public static void Initialize()
        {
            lock (_locker)
            {
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<User, UserDto>()
                        .ForMember(
                            dest => dest.Username,
                            opt => opt.MapFrom(src => src.UserName));

                    cfg.CreateMap<Role, RoleDto>();

                    cfg.CreateMap<ToDo, ToDoDto>();
                    cfg.CreateMap<News, NewsDto>();
                    cfg.CreateMap<Calendar, CalendarDto>();
                    cfg.CreateMap<Department, DepartmentDto>();
                    cfg.CreateMap<ApplicationUserRole, UserRoleDto>();

                    cfg.CreateMap<FileSystem, FileSystemDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => src.FileExtension))
                    .ForMember(dest => dest.FileBase64, opt => opt.MapFrom(src => GetFileBase64(src.FilePath)));
                });
            }
        }
        private static string GetFileBase64(string filePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return Convert.ToBase64String(fileBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }
    }

}
