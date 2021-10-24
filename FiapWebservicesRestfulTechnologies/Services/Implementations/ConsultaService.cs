using FiapWebservicesRestfulTechnologies.Data.Converter.Implementations;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class ConsultaService : IConsultaService
    {
        private readonly IRepository<Consulta> _repository;

        private readonly IRepository<Medico> _repositoryMedico;

        private readonly IRepository<Paciente> _repositoryPaciente;

        private readonly ConsultaConverter _converter;

        public ConsultaService(IRepository<Consulta> repository, IRepository<Medico> repositoryMedico, IRepository<Paciente> repositoryPaciente)
        {
            _repository = repository;
            _repositoryMedico = repositoryMedico;
            _repositoryPaciente = repositoryPaciente;
            _converter = new ConsultaConverter();
        }

        // Método responsável por buscar todos os consultas
        public List<ConsultaDTO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por buscar um consulta pelo ID
        public ConsultaDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        // Método responsável por adicionar um consultas
        public ConsultaDTO Create(ConsultaDTO consulta)
        {
            var consultaEntity = _converter.Parse(consulta);
            consultaEntity = _repository.Create(consultaEntity);
            Sms(consultaEntity.Id);
            return _converter.Parse(consultaEntity);
        }

        // Método responsável pelo update de um consulta
        public ConsultaDTO Update(ConsultaDTO consulta)
        {
            var consultaEntity = _converter.Parse(consulta);
            consultaEntity = _repository.Update(consultaEntity);
            return _converter.Parse(consultaEntity);
        }

        // Método responsável por deletar um consulta pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        // Método responsável por eviar SMS pelo ID
        public void Sms(long id)
        {
            var consultaEntity = _repository.FindById(id);
            if (consultaEntity != null)
            {
                try
                {
                    string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                    string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

                    TwilioClient.Init(accountSid, authToken);

                    consultaEntity.Medico = _repositoryMedico.FindById(consultaEntity.MedicoID);
                    consultaEntity.Paciente = _repositoryPaciente.FindById(consultaEntity.PacienteID);

                    var messageOptions = new CreateMessageOptions(new PhoneNumber("+" + consultaEntity.Telefone));
                    messageOptions.MessagingServiceSid = "MG6f11e1fdfda3c2fb2ddc7e96b9d99b17";
                    messageOptions.Body = "Olá " + consultaEntity.Paciente.Nome +
                        ", consulta médica em " + consultaEntity.Data.ToString("dd/MM/yyyy HH:mm") +
                        ", Dr(a). " + consultaEntity.Medico.Nome + " " + consultaEntity.Medico.Sobrenome;

                    var message = MessageResource.Create(messageOptions);
                    Console.WriteLine(message.Body);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
