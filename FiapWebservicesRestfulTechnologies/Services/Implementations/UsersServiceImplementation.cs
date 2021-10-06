using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class UsersServiceImplementation : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersServiceImplementation(IUsersRepository repository)
        {
            _repository = repository;
        }

        // Método responsável por buscar todos os usuários
        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por buscar um usuário pelo ID
        public User FindById(long id)
        {
            return _repository.FindById(id);
        }

        // Método responsável por adicionar um usuário
        public User Create(User user)
        {
            return _repository.Create(user);
        }

        // Método responsável pelo update de um usuário
        public User Update(User user)
        {
            return _repository.Update(user);
        }

        // Método responsável por deletar um usuário pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
