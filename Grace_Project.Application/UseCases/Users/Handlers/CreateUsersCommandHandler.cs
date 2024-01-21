using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Users.Commands;
using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Users.Handlers
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;
        public CreateUsersCommandHandler(IGraceProjectDbContext context)
        {
            _context = context; 
        }
        public async Task<bool> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
