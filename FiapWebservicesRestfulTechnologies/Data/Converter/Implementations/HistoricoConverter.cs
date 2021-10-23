using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class HistoricoConverter : IParser<HistoricoDTO, Historico>, IParser<Historico, HistoricoDTO>
    {
        public Historico Parse(HistoricoDTO origin)
        {
            if (origin == null) return null;
            return new Historico
            {
                Id = origin.Id,
                Medico = origin.Medico,
                Paciente = origin.Paciente
            };
        }

        public HistoricoDTO Parse(Historico origin)
        {
            if (origin == null) return null;
            return new HistoricoDTO
            {
                Id = origin.Id,
                Medico = origin.Medico,
                Paciente = origin.Paciente
            };
        }

        public List<Historico> Parse(List<HistoricoDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<HistoricoDTO> Parse(List<Historico> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
