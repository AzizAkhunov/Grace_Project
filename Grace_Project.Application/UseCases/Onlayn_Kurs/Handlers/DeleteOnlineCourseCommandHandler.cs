using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Handlers
{
    public class DeleteOnlineCourseCommandHandler : IRequestHandler<DeleteOnlineCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public DeleteOnlineCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOnlineCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.OnlaynKurs.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (course is null)
                {
                    return false;
                }
                else
                {
                    _context.OnlaynKurs.Remove(course);
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
