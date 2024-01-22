using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Course.Quarries
{
    public class GetAllCourseCommand : IRequest<List<Domain.Entities.Course>>
    {
    }
}
