using Grace_Project.Application.Absreaction;
using Grace_Project.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grace_Project.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGraceProjectDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(IGraceProjectDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async ValueTask<string> Login(RequestLogin request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == request.UserName);

            if (user is null)
            {
                throw new Exception("User not Found");
            }
            else if (user.PhoneNumber != request.Password)
            {
                throw new Exception("Password is wrong!!");
            }
            return _tokenService.Generate(user.Name);
        }
    }
}
