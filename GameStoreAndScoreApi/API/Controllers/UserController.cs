using GameStoreAndScoreApi.Application.DTOs;
using GameStoreAndScoreApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAndScoreApi.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost]
        //public IActionResult CreateUser([FromBody] CreateUserDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var userId = _userService.Create(dto);

        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { id = userId },
        //        null
        //    );
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var userId = await _userService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = userId }, null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update( int id, [FromBody] UpdateUserDto dto)
        {
            var updated = await _userService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) 
                return NotFound();

            return NoContent();
        }
    }
}
