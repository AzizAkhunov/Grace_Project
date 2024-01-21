namespace Grace_Project.Domain.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int OnlaynKursId { get; set; }
        public bool OnlaynKurs { get; set; } = false;
        public bool OchniyKurs { get; set; } = false;
        public bool BepulKurs { get; set; } = false;
    }
}
