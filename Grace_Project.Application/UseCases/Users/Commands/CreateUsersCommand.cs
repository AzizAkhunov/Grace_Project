using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grace_Project.Application.UseCases.Users.Commands
{
    public class CreateUsersCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int OnlaynKursId { get; set; }
        public int OchniyKursId { get; set; }
        public int BepulKursId { get; set; }
    }
}
