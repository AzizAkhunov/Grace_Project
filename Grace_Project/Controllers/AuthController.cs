﻿using Grace_Project.Application.Models;
using Grace_Project.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grace_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;

        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(RequestLogin request)
        {
            try
            {
                var token = await _authService.Login(request);

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Username or Password is not valid");
            }
        }
    }
}
