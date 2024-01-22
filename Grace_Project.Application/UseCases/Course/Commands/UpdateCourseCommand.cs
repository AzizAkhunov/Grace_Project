using MediatR;

namespace Grace_Project.Application.UseCases.Course.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QushilganlarSoni { get; set; }
        public decimal Narxi { get; set; }
        public int VideoSoni { get; set; }
    }
}
