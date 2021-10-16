using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IUsuarioService
    {
        Usuario ValidateCredentials(UsuarioLoginDTO usuarioLogin);

        Usuario ValidateCredentials(string login);

        bool RevokeToken(string login);

        Usuario RefreshUsuarioInfo(Usuario usuario);

        UsuarioDTO Create(UsuarioDTO user);

        UsuarioDTO FindById(long id);

        List<UsuarioDTO> FindAll();

        UsuarioDTO Update(UsuarioDTO user);

        void Delete(long id);

    }
}
