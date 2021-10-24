using FiapWebservicesRestfulTechnologies.Data.Converter.Implementations;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class CidadeService : ICidadeService
    {
        private readonly IRepository<Cidade> _repository;

        private readonly CidadeConverter _converter;

        public CidadeService(IRepository<Cidade> repository)
        {
            _repository = repository;
            _converter = new CidadeConverter();
        }

        // Método responsável por buscar todos os cidades
        public List<CidadeDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um cidade pelo ID
        public CidadeDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um cidade
        public CidadeDTO Create(CidadeDTO cidade)
        {
            var cidadeEntity = _converter.Parse(cidade);
            cidadeEntity = _repository.Create(cidadeEntity);
            return _converter.Parse(cidadeEntity);
        }

        // Método responsável pelo update de um cidade
        public CidadeDTO Update(CidadeDTO cidade)
        {
            var cidadeEntity = _converter.Parse(cidade);
            cidadeEntity = _repository.Update(cidadeEntity);
            return _converter.Parse(cidadeEntity);
        }

        // Método responsável por deletar um cidade pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
