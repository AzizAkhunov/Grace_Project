namespace Grace_Project.Domain.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
