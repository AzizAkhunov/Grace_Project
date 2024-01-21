using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Quaries;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Handlers
{
    public class GetAllOchniyKursCommandHandler : IRequestHandler<GetAllOchniyKursCommand,List<Ochniy_kurs>>
    {
        private readonly IGraceProjectDbContext _context;

        public GetAllOchniyKursCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ochniy_kurs>> Handle(GetAllOchniyKursCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.OchniyKurs.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
