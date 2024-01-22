using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Course.Quarries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Course.Handlers
{
    public class GetAllCoursesCommandHandler : IRequestHandler<GetAllCourseCommand, List<Domain.Entities.Course>>
    {
        private readonly IGraceProjectDbContext _context;

        public GetAllCoursesCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Course>> Handle(GetAllCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Courses.Include(x => x.Users).ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
