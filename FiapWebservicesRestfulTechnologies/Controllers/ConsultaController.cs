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
    public class ConsultasController : ControllerBase
    {
        private readonly ILogger<ConsultasController> _logger;

        private IConsultaService _consultaService;

        public ConsultasController(ILogger<ConsultasController> logger, IConsultaService consultaService)
        {
            _logger = logger;
            _consultaService = consultaService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<ConsultaDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_consultaService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ConsultaDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _consultaService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(ConsultaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ConsultaDTO consulta)
        {
            if (consulta == null) return BadRequest();
            return Ok(_consultaService.Create(consulta));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ConsultaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] ConsultaDTO consulta)
        {
            if (consulta == null) return BadRequest();
            return Ok(_consultaService.Update(consulta));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _consultaService.Delete(id);
            return NoContent();
        }


        [HttpPost("sms/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Sms(long id)
        {
            _consultaService.Sms(id);
            return NoContent();
        }
    }
}
