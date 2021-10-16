﻿using FiapWebservicesRestfulTechnologies.Data.DTO;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UsuarioLoginDTO usuarioLogin)
        {
            if (usuarioLogin == null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentials(usuarioLogin);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO is null) return BadRequest("Ivalid client request");
            var token = _loginService.ValidateCredentials(tokenDTO);
            if (token == null) return BadRequest("Ivalid client request");
            return Ok(token);
        }


        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeToken(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }
    }
}
