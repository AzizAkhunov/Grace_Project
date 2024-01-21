using MediatR;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Quaries
{
    public class GetAllOchniyKursCommand : IRequest<List<Grace_Project.Domain.Entities.Ochniy_kurs>>
    {
    }
}
