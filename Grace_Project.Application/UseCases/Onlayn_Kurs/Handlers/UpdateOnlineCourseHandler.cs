using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Commands;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Handlers
{
    public class UpdateOnlineCourseHandler : IRequestHandler<UpdateOnlineCourseCommand, bool>
    {
        private readonly IGraceProjectDbContext _context;

        public UpdateOnlineCourseHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateOnlineCourseCommand request, CancellationToken cancellationToken)
        {
            Ochniy_kurs? kurs = await _context.OchniyKurs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (kurs is not null)
            {
                kurs.QushilganlarSoni = request.QushilganlarSoni;
                kurs.Narxi = request.Narxi;
                kurs.VideoSoni = request.VideoSoni;


                _context.OchniyKurs.Update(kurs);
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
