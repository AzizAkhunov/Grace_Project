using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Handlers
{
    public class GetByIdOnlineCourseCommandHandler : IRequestHandler<GetByIdOnlaynKursCommand, Onlayn_kurs>
    {
        private readonly IGraceProjectDbContext _context;
        public GetByIdOnlineCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Onlayn_kurs> Handle(GetByIdOnlaynKursCommand request, CancellationToken cancellationToken)
        {
            var kurs = await _context.OnlaynKurs.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (kurs is not null)
            {
                return kurs;
            }
            return new Onlayn_kurs();
        }
    }
}
