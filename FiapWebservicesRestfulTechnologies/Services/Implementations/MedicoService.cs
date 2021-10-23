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
    public class MedicoService : IMedicoService
    {
        private readonly IRepository<Medico> _repository;

        private readonly MedicoConverter _converter;

        public Medico RefreshMedicoInfo(Medico medico)
        {
            if (!_repository.FindAll().Any(u => u.Id.Equals(medico.Id))) return null;

            var result = _repository.FindAll().SingleOrDefault(u => u.Id.Equals(medico.Id));
            if (result != null)
            {
                try
                {
                    return _repository.Update(medico);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

          public MedicoService(IRepository<Medico> repository)
        {
            _repository = repository;
            _converter = new MedicoConverter();
        }

        // Método responsável por buscar todos os médicos
        public List<MedicoDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um médico pelo ID
        public MedicoDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um médico
        public MedicoDTO Create(MedicoDTO medico)
        {
            var medicoEntity = _converter.Parse(medico);
            medicoEntity = _repository.Create(medicoEntity);
            return _converter.Parse(medicoEntity);
        }

        // Método responsável pelo update de um médico
        public MedicoDTO Update(MedicoDTO medico)
        {
            var medicoEntity = _converter.Parse(medico);
            medicoEntity = _repository.Update(medicoEntity);
            return _converter.Parse(medicoEntity);
        }

        // Método responsável por deletar um médico pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
