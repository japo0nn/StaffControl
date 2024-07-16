﻿using StaffControlServer.Data.Abstract;

namespace StaffControlServer.Data
{
    public class News : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<FileSystem>? Files { get; set; }
    }
}
