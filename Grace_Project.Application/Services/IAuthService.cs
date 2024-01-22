using Grace_Project.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grace_Project.Application.Services
{
    public interface IAuthService
    {
        ValueTask<string> Login(RequestLogin request);
    }
}
