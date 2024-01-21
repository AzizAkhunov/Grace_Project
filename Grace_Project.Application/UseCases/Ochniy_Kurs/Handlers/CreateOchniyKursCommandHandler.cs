using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Commands;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Commands;
using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Handlers
{
    public class CreateOchniyKursCommandHandler : IRequestHandler<CreateOchniyKursCommand,bool>
    {
        private readonly IGraceProjectDbContext _context;

        public CreateOchniyKursCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateOchniyKursCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Ochniy_kurs()
                {
                    QushilganlarSoni = request.QushilganlarSoni,
                    Narxi = request.Narxi,
                    VideoSoni = request.VideoSoni,
                };
                await _context.OchniyKurs.AddAsync(course);
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
