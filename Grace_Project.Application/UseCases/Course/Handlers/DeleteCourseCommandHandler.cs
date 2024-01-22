using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Course.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Course.Handlers
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public DeleteCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (course is null)
                {
                    return false;
                }
                else
                {
                    _context.Courses.Remove(course);
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
