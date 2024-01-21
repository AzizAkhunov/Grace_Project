using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Onlayn_Kurs.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Handlers
{
    public class GetAllOnlineCourseCommandHandler : IRequestHandler<GetAllOnlineCourseCommand, List<Onlayn_kurs>>
    {
        private readonly IGraceProjectDbContext _context;

        public GetAllOnlineCourseCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<Onlayn_kurs>> Handle(GetAllOnlineCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.OnlaynKurs.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
