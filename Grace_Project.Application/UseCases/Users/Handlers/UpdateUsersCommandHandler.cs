using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Commands;
using Grace_Project.Application.UseCases.Users.Commands;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Users.Handlers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public UpdateUsersCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user is not null)
            {
                user.Name = request.Name;
                user.PhoneNumber = request.PhoneNumber;
                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
