using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Course.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Course.Handlers
{
    public class GetByIdCourseCommandHandler : IRequestHandler<GetByIdCourseCommand, Domain.Entities.Course>
    {
        private readonly IGraceProjectDbContext _context;
        public GetByIdCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Course> Handle(GetByIdCourseCommand request, CancellationToken cancellationToken)
        {
            var kurs = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (kurs is not null)
            {
                return kurs;
            }
            return new Domain.Entities.Course();
        }
    }
}
