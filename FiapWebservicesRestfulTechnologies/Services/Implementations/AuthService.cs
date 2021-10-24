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
        private readonly ITokenService _tokenService;

        public AuthService(TokenConfiguration configuration, IUsuarioService usuarioService, ITokenService tokenService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
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

            _usuarioService.RefreshUsuarioInfo(usuario);

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

            var user = _usuarioService.ValidateCredentials(username);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _usuarioService.RefreshUsuarioInfo(user);

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


        public bool RevokeTokenUsuario(string userName)
        {
            return _usuarioService.RevokeToken(userName);
        }

        public TokenDTO ValidateCredentialsMedico(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        public TokenDTO ValidateCredentialsMedico(TokenDTO token)
        {
            throw new NotImplementedException();
        }

        public bool RevokeTokenMedico(string userName)
        {
            throw new NotImplementedException();
        }

        public TokenDTO ValidateCredentialsPaciente(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        public TokenDTO ValidateCredentialsPaciente(TokenDTO token)
        {
            throw new NotImplementedException();
        }

        public bool RevokeTokenPaciente(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
