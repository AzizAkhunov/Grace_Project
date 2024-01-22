namespace Grace_Project.Domain.Entities
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public int QushilganlarSoni { get; set; }
        public decimal Narxi { get; set; }
        public int VideoSoni { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
