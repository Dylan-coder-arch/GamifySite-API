using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamifySite_API.DBContext;
using GamifySite_API.Models;
using GamifySite_API.DTO.UserDTO;
using GamifySite_API.Mapper.UserMapper;
using GamifySite_API.Interfaces;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _userRepo.GetAllAsync();
            var userDTO = users.Select(s => s.ToUserDto()).ToList();
            return Ok(userDTO);
        }

        // GET: api/Users/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepo.GetByIDAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _userRepo.UpdateAsync(id, user);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ToUserDto());
        }

        // this is the same as "registering" technically
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] CreateUserRequestDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var userModel = user.ToUserFromCreateDto();

            await _userRepo.CreateAsync(userModel);

            return CreatedAtAction(nameof(GetUser), new { id = userModel.UserID}, userModel.ToUserDto());
        }

        // DELETE: api/Users/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userModel = await _userRepo.DeleteAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        private async Task<bool> UserExists(Guid id)
        {
            return await _userRepo.Exists(id);
        }
    }
}
