using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User  user)
        {
            if (user == null) return BadRequest();
            return Ok(_userService.Create(user));
        }

        [HttpPut]
        public IActionResult Putt([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return Ok(_userService.Update(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
