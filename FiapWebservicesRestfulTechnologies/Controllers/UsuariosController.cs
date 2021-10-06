using FiapWebservicesRestfulTechnologies.Data.VO;
using FiapWebservicesRestfulTechnologies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FiapWebservicesRestfulTechnologies.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;

        private IUsuarioService _userService;

        public UsuariosController(ILogger<UsuariosController> logger, IUsuarioService userService)
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
        public IActionResult Post([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_userService.Create(usuario));
        }

        [HttpPut]
        public IActionResult Putt([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_userService.Update(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
