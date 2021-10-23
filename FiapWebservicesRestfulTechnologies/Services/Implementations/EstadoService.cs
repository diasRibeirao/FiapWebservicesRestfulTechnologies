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
    public class EstadoService : IEstadoService
    {
        private readonly IRepository<Estado> _repository;

        private readonly EstadoConverter _converter;

        public EstadoService(IRepository<Estado> repository)
        {
            _repository = repository;
            _converter = new EstadoConverter();
        }

        // Método responsável por buscar todos os estados
        public List<EstadoDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um estado pelo ID
        public EstadoDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um estado
        public EstadoDTO Create(EstadoDTO estado)
        {
            var estadoEntity = _converter.Parse(estado);
            estadoEntity = _repository.Create(estadoEntity);
            return _converter.Parse(estadoEntity);
        }

        // Método responsável pelo update de um estado
        public EstadoDTO Update(EstadoDTO estado)
        {
            var estadoEntity = _converter.Parse(estado);
            estadoEntity = _repository.Update(estadoEntity);
            return _converter.Parse(estadoEntity);
        }

        // Método responsável por deletar um estado pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
