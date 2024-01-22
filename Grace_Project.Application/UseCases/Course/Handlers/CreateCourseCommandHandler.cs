using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Course.Commands;
using MediatR;

namespace Grace_Project.Application.UseCases.Course.Handlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public CreateCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Domain.Entities.Course()
                {
                    Name = request.Name,
                    QushilganlarSoni = request.QushilganlarSoni,
                    Narxi = request.Narxi,
                    VideoSoni = request.VideoSoni,
                };
                await _context.Courses.AddAsync(course);
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
