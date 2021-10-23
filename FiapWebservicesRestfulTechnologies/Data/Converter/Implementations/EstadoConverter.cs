using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class EstadoConverter : IParser<EstadoDTO, Estado>, IParser<Estado, EstadoDTO>
    {
        public Estado Parse(EstadoDTO origin)
        {
            if (origin == null) return null;
            return new Estado
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sigla = origin.Sigla,
                PaisID = origin.PaisID
            };
        }

        public EstadoDTO Parse(Estado origin)
        {
            if (origin == null) return null;
            return new EstadoDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sigla = origin.Sigla,
                PaisID = origin.PaisID
            };
        }

        public List<Estado> Parse(List<EstadoDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<EstadoDTO> Parse(List<Estado> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
