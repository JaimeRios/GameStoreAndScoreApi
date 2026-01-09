using GameStoreAndScoreApi.DTOs;
using GameStoreAndScoreApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAndScoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = _userService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = userId },
                null
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
