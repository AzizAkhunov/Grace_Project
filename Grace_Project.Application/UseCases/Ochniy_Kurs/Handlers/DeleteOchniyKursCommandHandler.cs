using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Handlers
{
    public class DeleteOchniyKursCommandHandler : IRequestHandler<DeleteOchniyKursCommand,bool>
    {
        private readonly IGraceProjectDbContext _context;

        public DeleteOchniyKursCommandHandler(IGraceProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOchniyKursCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.OchniyKurs.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (course is null)
                {
                    return false;
                }
                else
                {
                    _context.OchniyKurs.Remove(course);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
