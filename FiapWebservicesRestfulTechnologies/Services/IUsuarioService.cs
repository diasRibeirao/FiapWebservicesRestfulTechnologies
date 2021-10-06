using FiapWebservicesRestfulTechnologies.Data.VO;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IUsuarioService
    {
        UsuarioVO Create(UsuarioVO user);

        UsuarioVO FindById(long id);

        List<UsuarioVO> FindAll();

        UsuarioVO Update(UsuarioVO user);

        void Delete(long id);
    }
}
