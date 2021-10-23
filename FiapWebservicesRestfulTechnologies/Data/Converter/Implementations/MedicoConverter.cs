using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class MedicoConverter : IParser<MedicoDTO, Medico>, IParser<Medico, MedicoDTO>
    {
        public Medico Parse(MedicoDTO origin)
        {
            if (origin == null) return null;
            return new Medico
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email,
                Crm = origin.Crm
            };
        }

        public MedicoDTO Parse(Medico origin)
        {
            if (origin == null) return null;
            return new MedicoDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Login = origin.Login,
                Senha = origin.Senha,
                Email = origin.Email,
                Crm = origin.Crm
            };
        }

        public List<Medico> Parse(List<MedicoDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<MedicoDTO> Parse(List<Medico> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
