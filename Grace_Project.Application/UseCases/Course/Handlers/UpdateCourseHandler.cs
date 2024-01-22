using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Course.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Course.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public UpdateCourseHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Course? kurs = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (kurs is not null)
            {
                kurs.QushilganlarSoni = request.QushilganlarSoni;
                kurs.Narxi = request.Narxi;
                kurs.VideoSoni = request.VideoSoni;

                _context.Courses.Update(kurs);
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
