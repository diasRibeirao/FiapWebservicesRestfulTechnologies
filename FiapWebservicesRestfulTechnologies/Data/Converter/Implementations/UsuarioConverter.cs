using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class UsuarioConverter : IParser<UsuarioDTO, Usuario>, IParser<Usuario, UsuarioDTO>
    {
        public Usuario Parse(UsuarioDTO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Email = origin.Email
            };
        }

        public UsuarioDTO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Email = origin.Email
            };
        }

        public List<Usuario> Parse(List<UsuarioDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<UsuarioDTO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
