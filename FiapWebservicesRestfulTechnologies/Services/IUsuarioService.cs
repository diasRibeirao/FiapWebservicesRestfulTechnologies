using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IUsuarioService
    {
        Usuario ValidateCredentials(LoginDTO login);

        Usuario ValidateCredentials(string login);

        bool RevokeToken(string login);

        Usuario RefreshUsuarioInfo(Usuario usuario);

        UsuarioDTO Create(UsuarioDTO usuario);

        UsuarioDTO FindById(long id);

        List<UsuarioDTO> FindAll();

        UsuarioDTO Update(UsuarioDTO usuario);

        void Delete(long id);

    }
}
