using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using FileProject.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var User = await _userService.Register(user);
                if (User != null)
                    return new ObjectResult(User);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] User user)
        {
            try
            {
                var User = await _userService.Login(user);
                if (User != null)
                    return new ObjectResult(User);
                else
                    return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}