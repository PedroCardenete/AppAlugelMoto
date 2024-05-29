using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Model;
using TestApplication.Repositories;
using TestApplication.Repositories.Interfaces;
using TestApplication.Service;

namespace TestApplication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        //Aberto Usuario

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var response = await _userService.AddUserAsync(user);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImageCnh(IFormFile file, int id)
        {
            _userService.CheckExtensionImageCnh(file);
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     var user = await _userRepository.GetByIdAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     await _userRepository.DeleteAsync(user);
        //     return NoContent();
        // }
    }
}