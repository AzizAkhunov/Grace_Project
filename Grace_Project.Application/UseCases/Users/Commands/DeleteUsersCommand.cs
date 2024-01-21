using MediatR;

namespace Grace_Project.Application.UseCases.Users.Commands
{
    public class DeleteUsersCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
