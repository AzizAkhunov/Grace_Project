using Grace_Project.API.DTOs;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Commands;
using Grace_Project.Application.UseCases.Ochniy_Kurs.Quaries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Grace_Project.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OchniyCourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public OchniyCourseController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCourseAsync(OchniyKursDTO dto)
        {
            try
            {
                var command = new CreateOchniyKursCommand
                {
                    QushilganlarSoni = dto.QushilganlarSoni,
                    Narxi = dto.Narxi,
                    VideoSoni = dto.VideoSoni,
                };
                var value = _memoryCache.Get("Kurs2_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs2_key");
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCoursesAsync()
        {
            try
            {
                var value = _memoryCache.Get("Kurs2_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Kurs2_key",
                        value: await _mediator.Send(new GetAllOchniyKursCommand()));
                }
                return Ok(_memoryCache.Get("Kurs2_key") as List<Ochniy_kurs>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCourseAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteOchniyKursCommand { Id = id });
                var value = _memoryCache.Get("Kurs2_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs2_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateOchniyKursByIdAsync([FromForm] UpdateOchniyKursCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Kurs2_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs2_key");
                }
                return Ok(await _mediator.Send(dto));
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdOchniyKursCommand { Id = id });
                var value = _memoryCache.Get("Kurs2_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs2_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
