using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Quarries
{
    public class GetAllOnlineCourseCommand : IRequest<List<Onlayn_kurs>>
    {
    }
}
