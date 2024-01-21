using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Quaries
{
    public class GetByIdOchniyKursCommand : IRequest<Ochniy_kurs>
    {
        public int Id { get; set; }
    }
}
