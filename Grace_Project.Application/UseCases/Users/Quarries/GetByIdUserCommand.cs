using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Users.Quarries
{
    public class GetByIdUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
