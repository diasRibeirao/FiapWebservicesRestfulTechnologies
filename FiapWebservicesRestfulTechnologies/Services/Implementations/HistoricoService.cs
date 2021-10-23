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
    public class HistoricoService : IHistoricoService
    {
        private readonly IRepository<Historico> _repository;

        private readonly HistoricoConverter _converter;

        public Historico RefreshHistoricoInfo(Historico historico)
        {
            if (!_repository.FindAll().Any(u => u.Id.Equals(historico.Id))) return null;

            var result = _repository.FindAll().SingleOrDefault(u => u.Id.Equals(historico.Id));
            if (result != null)
            {
                try
                {
                    return _repository.Update(historico);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

          public HistoricoService(IRepository<Historico> repository)
        {
            _repository = repository;
            _converter = new HistoricoConverter();
        }

        // Método responsável por buscar todos os historicos
        public List<HistoricoDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um historico pelo ID
        public HistoricoDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um historicos
        public HistoricoDTO Create(HistoricoDTO historico)
        {
            var historicoEntity = _converter.Parse(historico);
            historicoEntity = _repository.Create(historicoEntity);
            return _converter.Parse(historicoEntity);
        }

        // Método responsável pelo update de um historico
        public HistoricoDTO Update(HistoricoDTO historico)
        {
            var historicoEntity = _converter.Parse(historico);
            historicoEntity = _repository.Update(historicoEntity);
            return _converter.Parse(historicoEntity);
        }

        // Método responsável por deletar um historico pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
