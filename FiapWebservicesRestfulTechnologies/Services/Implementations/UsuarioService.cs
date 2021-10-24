using FiapWebservicesRestfulTechnologies.Data.Converter.Implementations;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        private readonly UsuarioConverter _converter;

        public Usuario ValidateCredentials(LoginDTO login)
        {
            var senha = ComputeHash(login.Senha, new SHA256CryptoServiceProvider());
            return _repository.FindAll().FirstOrDefault(u => (u.Login == login.Login) && (u.Senha == senha));
        }

        public Usuario ValidateCredentials(string login)
        {
            return _repository.FindAll().SingleOrDefault(u => (u.Login == login));
        }

        public bool RevokeToken(string login)
        {
            var usuario = _repository.FindAll().SingleOrDefault(u => (u.Login == login));
            if (usuario is null) return false;
            usuario.RefreshToken = null;
            _repository.Update(usuario);
            return true;
        }

        public Usuario RefreshInfo(Usuario usuario)
        {
            if (!_repository.FindAll().Any(u => u.Id.Equals(usuario.Id))) return null;

            var result = _repository.FindAll().SingleOrDefault(u => u.Id.Equals(usuario.Id));
            if (result != null)
            {
                try
                {
                    return _repository.Update(usuario);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;
            _converter = new UsuarioConverter();
        }

        // Método responsável por buscar todos os usuários
        public List<UsuarioDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um usuário pelo ID
        public UsuarioDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um usuário
        public UsuarioDTO Create(UsuarioDTO usuario)
        {
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity.Senha = ComputeHash("admin123", new SHA256CryptoServiceProvider());
            usuarioEntity = _repository.Create(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }

        // Método responsável pelo update de um usuário
        public UsuarioDTO Update(UsuarioDTO usuario)
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
