using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Quarries
{
    public class GetByIdOnlaynKursCommand : IRequest<Onlayn_kurs>
    {
        public int Id { get; set; }
    }
}
