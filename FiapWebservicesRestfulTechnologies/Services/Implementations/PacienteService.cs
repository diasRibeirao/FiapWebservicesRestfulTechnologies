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
    public class PacienteService : IPacienteService
    {
        private readonly IRepository<Paciente> _repository;

        private readonly PacienteConverter _converter;

        public Paciente ValidateCredentials(LoginDTO login)
        {
            var senha = ComputeHash(login.Senha, new SHA256CryptoServiceProvider());
            return _repository.FindAll().FirstOrDefault(u => (u.Login == login.Login) && (u.Senha == senha));
        }

        public Paciente ValidateCredentials(string login)
        {
            return _repository.FindAll().SingleOrDefault(u => (u.Login == login));
        }

        public bool RevokeToken(string login)
        {
            var paciente = _repository.FindAll().SingleOrDefault(u => (u.Login == login));
            if (paciente is null) return false;
            paciente.RefreshToken = null;
            _repository.Update(paciente);
            return true;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public Paciente RefreshInfo(Paciente paciente)
        {
            if (!_repository.FindAll().Any(u => u.Id.Equals(paciente.Id))) return null;

            var result = _repository.FindAll().SingleOrDefault(u => u.Id.Equals(paciente.Id));
            if (result != null)
            {
                try
                {
                    return _repository.Update(paciente);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        public PacienteService(IRepository<Paciente> repository)
        {
            _repository = repository;
            _converter = new PacienteConverter();
        }

        // Método responsável por buscar todos os pacientes
        public List<PacienteDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um paciente pelo ID
        public PacienteDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um paciente
        public PacienteDTO Create(PacienteDTO paciente)
        {
            var pacienteEntity = _converter.Parse(paciente);
            pacienteEntity.Senha = ComputeHash("admin123", new SHA256CryptoServiceProvider());
            pacienteEntity = _repository.Create(pacienteEntity);
            return _converter.Parse(pacienteEntity);
        }

        // Método responsável pelo update de um paciente
        public PacienteDTO Update(PacienteDTO paciente)
        {
            var pacienteEntity = _converter.Parse(paciente);
            pacienteEntity = _repository.Update(pacienteEntity);
            return _converter.Parse(pacienteEntity);
        }

        // Método responsável por deletar um paciente pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
