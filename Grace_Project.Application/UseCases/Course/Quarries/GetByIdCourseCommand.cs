using Grace_Project.Domain.Entities;
using MediatR;

namespace Grace_Project.Application.UseCases.Course.Quarries
{
    public class GetByIdCourseCommand : IRequest<Domain.Entities.Course>
    {
        public int Id { get; set; }
    }
}
