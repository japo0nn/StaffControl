namespace StaffControlServer.Data.Abstract
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
