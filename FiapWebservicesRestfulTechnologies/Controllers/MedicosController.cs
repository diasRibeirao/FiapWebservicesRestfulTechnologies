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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly ILogger<MedicosController> _logger;

        private IMedicoService _medicoService;

        public MedicosController(ILogger<MedicosController> logger, IMedicoService medicoService)
        {
            _logger = logger;
            _medicoService = medicoService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<MedicoDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_medicoService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(MedicoDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _medicoService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(MedicoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] MedicoDTO medico)
        {
            if (medico == null) return BadRequest();
            return Ok(_medicoService.Create(medico));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(MedicoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] MedicoDTO medico)
        {
            if (medico == null) return BadRequest();
            return Ok(_medicoService.Update(medico));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _medicoService.Delete(id);
            return NoContent();
        }
    }
}
