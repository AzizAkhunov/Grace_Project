using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Users.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Users.Handlers
{
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, User>
    {
        private readonly IGraceProjectDbContext _context;
        public GetByIdUserCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user is not null)
            {
                return user;
            }
            return new User();
        }
    }
}
