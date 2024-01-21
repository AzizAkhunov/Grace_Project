using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Quaries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Handlers
{
    public class GetByIdOchniyKursCommandHandler : IRequestHandler<GetByIdOchniyKursCommand, Ochniy_kurs>
    {
        private readonly IGraceProjectDbContext _context;

        public GetByIdOchniyKursCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Ochniy_kurs> Handle(GetByIdOchniyKursCommand request, CancellationToken cancellationToken)
        {
            var kurs = await _context.OchniyKurs.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (kurs is not null)
            {
                return kurs;
            }
            return new Ochniy_kurs();
        }
    }
}
