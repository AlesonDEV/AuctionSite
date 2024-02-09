using Auctiion.DataAccess.Services;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var response = await _userRepository.RegisterAccount(registerDto);
            
            return StatusCode(response.Code, response);
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            var response = await _userRepository.LoginAccount(loginDTO);

            return StatusCode(response.Code, response);
        }
    }
}
