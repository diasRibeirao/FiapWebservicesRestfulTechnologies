using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class ConsultaConverter : IParser<ConsultaDTO, Consulta>, IParser<Consulta, ConsultaDTO>
    {
        public Consulta Parse(ConsultaDTO origin)
        {
            if (origin == null) return null;
            return new Consulta
            {
                Id = origin.Id,
                MedicoID = origin.MedicoID,
                PacienteID = origin.PacienteID,
                Telefone = origin.Telefone,
                Data = origin.Data
            };
        }

        public ConsultaDTO Parse(Consulta origin)
        {
            if (origin == null) return null;
            return new ConsultaDTO
            {
                Id = origin.Id,
                MedicoID = origin.MedicoID,
                PacienteID = origin.PacienteID,
                Telefone = origin.Telefone,
                Data = origin.Data
            };
        }

        public List<Consulta> Parse(List<ConsultaDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<ConsultaDTO> Parse(List<Consulta> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
