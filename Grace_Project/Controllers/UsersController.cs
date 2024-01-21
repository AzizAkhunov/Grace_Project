using Grace_Project.API.DTOs;
using Grace_Project.Application.Absreaction;
using Grace_Project.Application.UseCases.Users.Commands;
using Grace_Project.Application.UseCases.Users.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Grace_Project.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private readonly IGraceProjectDbContext _context;
        private readonly CancellationToken cancellationToken;
        public UsersController(IMediator mediator, IMemoryCache memoryCache, IGraceProjectDbContext context)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
            _context = context;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UserDTO dto)
        {
            try
            {
                var command = new CreateUsersCommand
                {
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                };
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            //var res = await _mediator.Send(new GetAllUsersCommand());
            //return Ok(res);
            try
            {
                var value = _memoryCache.Get("Users_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Users_key",
                        value: await _mediator.Send(new GetAllUsersCommand()));
                }
                return Ok(_memoryCache.Get("Users_key") as List<User>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteUsersCommand { Id = id });
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserByIdAsync([FromForm]UpdateUsersCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(await _mediator.Send(dto));
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        [HttpPatch]
        public async ValueTask<IActionResult> JoinToOnlineCourse(int id,string Name , string PhoneNumber)
        {
            var course = await _context.OnlaynKurs.FirstOrDefaultAsync(x => x.Id == id);
            if (course is not null)
            {
                course.QushilganlarSoni += 1;
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Muvofaqiyatli qushildingiz!");
            }
            return BadRequest("Bunday kurs topilmadi!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdUserCommand { Id = id });
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
