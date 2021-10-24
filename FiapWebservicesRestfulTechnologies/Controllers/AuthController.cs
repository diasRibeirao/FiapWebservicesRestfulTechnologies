using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _loginService;

        public AuthController(IAuthService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("usuarios/login")]
        public IActionResult login([FromBody] LoginDTO login)
        {
            if (login == null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsUsuario(login);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("usuarios/refresh")]
        public IActionResult UsuarioRefresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO is null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsUsuario(tokenDTO);
            if (token == null) return BadRequest("Ivalid client request");
            return Ok(token);
        }

        [HttpGet]
        [Route("usuarios/revoke")]
        [Authorize("Bearer")]
        public IActionResult UsuarioRevoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeTokenUsuario(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }

        // Médicos
        [HttpPost]
        [Route("medicos/login")]
        public IActionResult MedicoLogin([FromBody] LoginDTO login)
        {
            if (login == null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsMedico(login);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("medicos/refresh")]
        public IActionResult MedicoRefresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO is null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsMedico(tokenDTO);
            if (token == null) return BadRequest("Ivalid client request");
            return Ok(token);
        }

        [HttpGet]
        [Route("medicos/revoke")]
        [Authorize("Bearer")]
        public IActionResult MedicoRevoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeTokenMedico(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }

        // Pacientes
        [HttpPost]
        [Route("pacientes/login")]
        public IActionResult PacienteLogin([FromBody] LoginDTO login)
        {
            if (login == null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsPaciente(login);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("pacientes/refresh")]
        public IActionResult PacienteRefresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO is null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentialsPaciente(tokenDTO);
            if (token == null) return BadRequest("Ivalid client request");
            return Ok(token);
        }

        [HttpGet]
        [Route("pacientes/revoke")]
        [Authorize("Bearer")]
        public IActionResult PacienteRevoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeTokenPaciente(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }
    }
}
