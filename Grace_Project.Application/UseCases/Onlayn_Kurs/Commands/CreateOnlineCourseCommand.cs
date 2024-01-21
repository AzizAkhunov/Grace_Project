using MediatR;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Commands
{
    public class CreateOnlineCourseCommand : IRequest<bool>
    {
        public int QushilganlarSoni { get; set; }
        public decimal Narxi { get; set; }
        public int VideoSoni { get; set; }
    }
}
