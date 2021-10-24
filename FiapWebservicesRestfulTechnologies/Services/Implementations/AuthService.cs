using FiapWebservicesRestfulTechnologies.Configurations;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private readonly IUsuarioService _usuarioService;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;
        private readonly ITokenService _tokenService;

        public AuthService(TokenConfiguration configuration, IUsuarioService usuarioService, IMedicoService medicoService, IPacienteService pacienteService, ITokenService tokenService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
            _tokenService = tokenService;
        }

        public TokenDTO ValidateCredentialsUsuario(LoginDTO login)
        {
            var usuario = _usuarioService.ValidateCredentials(login);
            if (usuario == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            usuario.RefreshToken = refreshToken;
            usuario.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _usuarioService.RefreshInfo(usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }

        public TokenDTO ValidateCredentialsUsuario(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var usuario = _usuarioService.ValidateCredentials(username);

            if (usuario == null ||
                usuario.RefreshToken != refreshToken ||
                usuario.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            usuario.RefreshToken = refreshToken;

            _usuarioService.RefreshInfo(usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }


        public bool RevokeTokenUsuario(string login)
        {
            return _usuarioService.RevokeToken(login);
        }

        public TokenDTO ValidateCredentialsMedico(LoginDTO login)
        {
            var medico = _medicoService.ValidateCredentials(login);
            if (medico == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            medico.RefreshToken = refreshToken;
            medico.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _medicoService.RefreshInfo(medico);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }

        public TokenDTO ValidateCredentialsMedico(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var medico = _medicoService.ValidateCredentials(username);

            if (medico == null ||
                medico.RefreshToken != refreshToken ||
                medico.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            medico.RefreshToken = refreshToken;

            _medicoService.RefreshInfo(medico);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeTokenMedico(string login)
        {
            return _medicoService.RevokeToken(login);
        }

        public TokenDTO ValidateCredentialsPaciente(LoginDTO login)
        {
            var paciente = _pacienteService.ValidateCredentials(login);
            if (paciente == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            paciente.RefreshToken = refreshToken;
            paciente.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _pacienteService.RefreshInfo(paciente);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                );
        }

        public TokenDTO ValidateCredentialsPaciente(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var paciente = _pacienteService.ValidateCredentials(username);

            if (paciente == null ||
                paciente.RefreshToken != refreshToken ||
                paciente.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            paciente.RefreshToken = refreshToken;

            _pacienteService.RefreshInfo(paciente);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }

        public bool RevokeTokenPaciente(string login)
        {
            return _pacienteService.RevokeToken(login);
        }
    }
}
