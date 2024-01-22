using MediatR;

namespace Grace_Project.Application.UseCases.Users.Commands
{
    public class UpdateUsersCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string PhoneNumber { get; set; }
    }
}
