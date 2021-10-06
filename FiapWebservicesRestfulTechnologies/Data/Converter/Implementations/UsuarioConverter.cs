using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.VO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class UsuarioConverter : IParser<UsuarioVO, Usuario>, IParser<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email
            };
        }

        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email
            };
        }

        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
