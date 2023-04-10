using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ServiceResponse<int>> RegisterUser(UserRequestModel user)
        {
            return await _authService.Register(user, user.Password);
        }
        [HttpPost("LoginUser")]
        public async Task<ServiceResponse<string>> LoginUser(string username, string password)
        {
            return await _authService.Login(username, password);
        }
    }
}
