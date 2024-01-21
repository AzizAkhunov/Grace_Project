namespace Grace_Project.API.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool OnlaynKurs { get; set; } = false;
        public bool OchniyKurs { get; set; } = false;
        public bool BepulKurs { get; set; } = false;
    }
}
