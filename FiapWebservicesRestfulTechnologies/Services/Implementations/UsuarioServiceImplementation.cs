using FiapWebservicesRestfulTechnologies.Data.Converter.Implementations;
using FiapWebservicesRestfulTechnologies.Data.VO;
using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class UsuarioServiceImplementation : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        private readonly UsuarioConverter _converter;

        public UsuarioServiceImplementation(IRepository<Usuario> repository)
        {
            _repository = repository;
            _converter = new UsuarioConverter();
        }

        // Método responsável por buscar todos os usuários
        public List<UsuarioVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um usuário pelo ID
        public UsuarioVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um usuário
        public UsuarioVO Create(UsuarioVO usuario)
        {
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity = _repository.Create(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }

        // Método responsável pelo update de um usuário
        public UsuarioVO Update(UsuarioVO usuario)
        {
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity = _repository.Update(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }

        // Método responsável por deletar um usuário pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
