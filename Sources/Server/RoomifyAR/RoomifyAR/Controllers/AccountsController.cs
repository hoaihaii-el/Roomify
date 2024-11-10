using Microsoft.AspNetCore.Mvc;
using RoomifyAR.Errors;
using RoomifyAR.Repositories;
using RoomifyAR.Requests;

namespace RoomifyAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountRepo repo) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register regis)
        {
            try
            {
                return Ok(await repo.Register(regis));
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                return Ok(await repo.Login(login.UserName, login.Password));
            }
            catch (CustomException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
