using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.PaisesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v1/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;

        private IPaisService _paisService;

        public PaisesController(ILogger<UsuariosController> logger, IPaisService paisService)
        {
            _logger = logger;
            _paisService = paisService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Pais>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_paisService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Pais))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _paisService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Pais))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Pais pais)
        {
            if (pais == null) return BadRequest();
            return Ok(_paisService.Create(pais));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Pais))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Pais pais)
        {
            if (pais == null) return BadRequest();
            return Ok(_paisService.Update(pais));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _paisService.Delete(id);
            return NoContent();
        }
    }
}
