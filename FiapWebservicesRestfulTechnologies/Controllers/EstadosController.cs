using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Services;
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
    public class EstadosController : ControllerBase
    {
        private readonly ILogger<EstadosController> _logger;

        private IEstadoService _estadoService;

        public EstadosController(ILogger<EstadosController> logger, IEstadoService estadoService)
        {
            _logger = logger;
            _estadoService = estadoService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<EstadoDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_estadoService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(EstadoDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _estadoService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(EstadoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] EstadoDTO estado)
        {
            if (estado == null) return BadRequest();
            return Ok(_estadoService.Create(estado));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(EstadoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] EstadoDTO estado)
        {
            if (estado == null) return BadRequest();
            return Ok(_estadoService.Update(estado));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _estadoService.Delete(id);
            return NoContent();
        }
    }
}
