using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Users.Quarries
{
    public class GetAllUsersCommand : IRequest<List<User>>
    {
    }
}
