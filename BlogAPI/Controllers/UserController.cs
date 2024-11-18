using BlogAPI.Models;
using BlogAPI.Services;
using BlogAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController(IUserServices userServices) : ControllerBase
    {
        private readonly IUserServices _userServices = userServices;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userServices.GetUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateUser newUserObj)
        {
            var user = await _userServices.AddUser(newUserObj);
            if (user == null) return BadRequest();
            return Ok(new
            {
                message = "New user created succesfully",
                id = user!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateUser updatedUserObj)
        {
            var user = await _userServices.UpdateUser(id, updatedUserObj);
            if (user == null) return NotFound();

            return Ok(new
            {
                message = "User updated succesfully",
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _userServices.DeleteUser(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "User deleted succesfully",
                id
            });
        }
    }
}
