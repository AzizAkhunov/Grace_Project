using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Users.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Users.Handlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<User>>
    {
        private readonly IGraceProjectDbContext _context;

        public GetAllUsersCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Users.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
