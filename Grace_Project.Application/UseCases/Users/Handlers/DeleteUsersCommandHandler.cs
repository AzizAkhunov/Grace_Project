using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Users.Handlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public DeleteUsersCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (user is null)
                {
                    return false;
                }
                else
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
