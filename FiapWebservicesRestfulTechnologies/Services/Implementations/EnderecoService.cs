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
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepository<Endereco> _repository;

        private readonly EnderecoConverter _converter;

        public EnderecoService(IRepository<Endereco> repository)
        {
            _repository = repository;
            _converter = new EnderecoConverter();
        }

        // Método responsável por buscar todos os endereços
        public List<EnderecoDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um endereço pelo ID
        public EnderecoDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um endereço
        public EnderecoDTO Create(EnderecoDTO endereco)
        {
            var enderecoEntity = _converter.Parse(endereco);
            enderecoEntity = _repository.Create(enderecoEntity);
            return _converter.Parse(enderecoEntity);
        }

        // Método responsável pelo update de um endereco
        public EnderecoDTO Update(EnderecoDTO endereco)
        {
            var enderecoEntity = _converter.Parse(endereco);
            enderecoEntity = _repository.Update(enderecoEntity);
            return _converter.Parse(enderecoEntity);
        }

        // Método responsável por deletar um endereco pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
