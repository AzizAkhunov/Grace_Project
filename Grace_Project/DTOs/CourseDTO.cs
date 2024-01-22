namespace Grace_Project.API.DTOs
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public int QushilganlarSoni { get; set; }
        public decimal Narxi { get; set; }
        public int VideoSoni { get; set; }

        public ICollection<int>? Users { get; set; }
    }
}
