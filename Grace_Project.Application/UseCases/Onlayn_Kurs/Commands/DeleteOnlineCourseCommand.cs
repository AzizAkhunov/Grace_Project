using MediatR;

namespace Grace_Project.Application.UseCases.Onlayn_Kurs.Commands
{
    public class DeleteOnlineCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
