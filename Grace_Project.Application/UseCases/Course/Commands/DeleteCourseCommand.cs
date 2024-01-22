using MediatR;

namespace Grace_Project.Application.UseCases.Course.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
