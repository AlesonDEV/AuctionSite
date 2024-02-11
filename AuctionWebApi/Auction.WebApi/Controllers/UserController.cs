using Auctiion.DataAccess.Services;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

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

            var responseData = new
            {
                token = response.Token,
                message = response.Message,
            };

            return StatusCode(response.Code, responseData);
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            var response = await _userRepository.LoginAccount(loginDTO);

            var responseData = new
            {
                token = response.Token,
                message = response.Message,
            };

            return StatusCode(response.Code, responseData);
        }
    }
}
