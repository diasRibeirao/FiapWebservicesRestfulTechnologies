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
    public class HistoricosController : ControllerBase
    {
        private readonly ILogger<HistoricosController> _logger;

        private IHistoricoService _historicoService;

        public HistoricosController(ILogger<HistoricosController> logger, IHistoricoService historicoService)
        {
            _logger = logger;
            _historicoService = historicoService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<HistoricoDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_historicoService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(HistoricoDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _historicoService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(HistoricoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] HistoricoDTO historico)
        {
            if (historico == null) return BadRequest();
            return Ok(_historicoService.Create(historico));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(HistoricoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] HistoricoDTO historico)
        {
            if (historico == null) return BadRequest();
            return Ok(_historicoService.Update(historico));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _historicoService.Delete(id);
            return NoContent();
        }
    }
}
