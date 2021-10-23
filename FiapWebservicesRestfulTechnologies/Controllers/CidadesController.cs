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
    public class CidadesController : ControllerBase
    {
        private readonly ILogger<CidadesController> _logger;

        private ICidadeService _cidadeService;

        public CidadesController(ILogger<CidadesController> logger, ICidadeService cidadeService)
        {
            _logger = logger;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<CidadeDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_cidadeService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(CidadeDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _cidadeService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(CidadeDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] CidadeDTO cidade)
        {
            if (cidade == null) return BadRequest();
            return Ok(_cidadeService.Create(cidade));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(CidadeDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] CidadeDTO cidade)
        {
            if (cidade == null) return BadRequest();
            return Ok(_cidadeService.Update(cidade));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _cidadeService.Delete(id);
            return NoContent();
        }
    }
}
