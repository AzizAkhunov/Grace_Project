
namespace Grace_Project.Domain.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString();
        public string? DeletedAt { get; set; }    
    }
}
