﻿using Grace_Project.API.DTOs;
using Grace_Project.Application.UseCases.Course.Commands;
using Grace_Project.Application.UseCases.Course.Quarries;
using Grace_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Grace_Project.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public CourseController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateOnlineCourseAsync(CourseDTO dto)
        {
            try
            {
                var command = new CreateCourseCommand
                {
                    Name = dto.Name,
                    QushilganlarSoni = dto.QushilganlarSoni,
                    Narxi = dto.Narxi,
                    VideoSoni = dto.VideoSoni,
                    Users = dto.Users
                };

         
                var value = _memoryCache.Get("Kurs_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs_key");
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
                var value = _memoryCache.Get("Kurs_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Kurs_key",
                        value: await _mediator.Send(new GetAllCourseCommand()));
                }
                return Ok(_memoryCache.Get("Kurs_key") as List<Course>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCourseAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteCourseCommand { Id = id });
                var value = _memoryCache.Get("Kurs_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserByIdAsync([FromForm] UpdateCourseCommand dto)
        {
            try
            {
                var value = _memoryCache.Get("Kurs_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs_key");
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
                var res = await _mediator.Send(new GetByIdCourseCommand { Id = id });
                var value = _memoryCache.Get("Kurs_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Kurs_key");
                }
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
