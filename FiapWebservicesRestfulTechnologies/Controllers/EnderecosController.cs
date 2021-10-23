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
    public class EnderecosController : ControllerBase
    {
        private readonly ILogger<EnderecosController> _logger;

        private IEnderecoService _enderecoService;

        public EnderecosController(ILogger<EnderecosController> logger, IEnderecoService enderecoService)
        {
            _logger = logger;
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<EnderecoDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_enderecoService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(EnderecoDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var user = _enderecoService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(EnderecoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] EnderecoDTO endereco)
        {
            if (endereco == null) return BadRequest();
            return Ok(_enderecoService.Create(endereco));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(EnderecoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] EnderecoDTO endereco)
        {
            if (endereco == null) return BadRequest();
            return Ok(_enderecoService.Update(endereco));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _enderecoService.Delete(id);
            return NoContent();
        }
    }
}
