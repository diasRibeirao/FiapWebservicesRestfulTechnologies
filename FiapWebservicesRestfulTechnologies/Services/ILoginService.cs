using FiapWebservicesRestfulTechnologies.Data.DTO;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UsuarioLoginDTO usuarioLogin);

        TokenDTO ValidateCredentials(TokenDTO token);

        bool RevokeToken(string userName);
    }
}
