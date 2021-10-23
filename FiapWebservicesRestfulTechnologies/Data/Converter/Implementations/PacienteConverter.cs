using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class PacienteConverter : IParser<PacienteDTO, Paciente>, IParser<Paciente, PacienteDTO>
    {
        public Paciente Parse(PacienteDTO origin)
        {
            if (origin == null) return null;
            return new Paciente
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email,
                Plano = origin.Plano
            };
        }

        public PacienteDTO Parse(Paciente origin)
        {
            if (origin == null) return null;
            return new PacienteDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email,
                Plano = origin.Plano
            };
        }

        public List<Paciente> Parse(List<PacienteDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<PacienteDTO> Parse(List<Paciente> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
