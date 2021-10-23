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
    public class PacientesController : ControllerBase
    {
        private readonly ILogger<PacientesController> _logger;

        private IPacienteService _pacienteService;

        public PacientesController(ILogger<PacientesController> logger, IPacienteService pacienteService)
        {
            _logger = logger;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PacienteDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_pacienteService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PacienteDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _pacienteService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PacienteDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PacienteDTO paciente)
        {
            if (paciente == null) return BadRequest();
            return Ok(_pacienteService.Create(paciente));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PacienteDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] PacienteDTO paciente)
        {
            if (paciente == null) return BadRequest();
            return Ok(_pacienteService.Update(paciente));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _pacienteService.Delete(id);
            return NoContent();
        }
    }
}
