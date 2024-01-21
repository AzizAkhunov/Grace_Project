using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Commands;
using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Handlers
{
    public class CreateOnlineCourseCommandHandler : IRequestHandler<CreateOnlineCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public CreateOnlineCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateOnlineCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Onlayn_kurs()
                {
                    QushilganlarSoni = request.QushilganlarSoni,
                    Narxi = request.Narxi,
                    VideoSoni = request.VideoSoni,
                };
                await _context.OnlaynKurs.AddAsync(course);
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
