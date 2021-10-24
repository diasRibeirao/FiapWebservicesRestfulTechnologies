using FiapWebservicesRestfulTechnologies.Data.DTO;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IAuthService
    {
        TokenDTO ValidateCredentialsUsuario(LoginDTO login);

        TokenDTO ValidateCredentialsUsuario(TokenDTO token);

        bool RevokeTokenUsuario(string login);

        TokenDTO ValidateCredentialsMedico(LoginDTO login);

        TokenDTO ValidateCredentialsMedico(TokenDTO token);

        bool RevokeTokenMedico(string login);

        TokenDTO ValidateCredentialsPaciente(LoginDTO login);

        TokenDTO ValidateCredentialsPaciente(TokenDTO token);

        bool RevokeTokenPaciente(string login);
    }
}
