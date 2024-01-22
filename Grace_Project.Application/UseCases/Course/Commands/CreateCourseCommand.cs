using MediatR;

namespace Grace_Project.Application.UseCases.Course.Commands
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int QushilganlarSoni { get; set; }
        public decimal Narxi { get; set; }
        public int VideoSoni { get; set; }
    }
}
