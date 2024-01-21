using MediatR;

namespace Grace_Project.Application.UseCases.Ochniy_Kurs.Commands
{
    public class DeleteOchniyKursCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
