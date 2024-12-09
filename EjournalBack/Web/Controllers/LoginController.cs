using EjournalBack.Infrastructure.Repositories;
using EjournalBack.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginContoller : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        
        public LoginContoller(ILogger logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            [FromBody]LoginRequest loginRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var login = loginRequest.Login;
            var passwordHash = loginRequest.PasswordHash;

            var group = await _userRepository.Authorize(login, passwordHash);
            return Ok(group);
        }
    }
}