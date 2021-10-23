using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class CidadeConverter : IParser<CidadeDTO, Cidade>, IParser<Cidade, CidadeDTO>
    {
        public Cidade Parse(CidadeDTO origin)
        {
            if (origin == null) return null;
            return new Cidade
            {
                Id = origin.Id,
                Nome = origin.Nome,
                EstadoID = origin.EstadoID
            };
        }

        public CidadeDTO Parse(Cidade origin)
        {
            if (origin == null) return null;
            return new CidadeDTO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                EstadoID = origin.EstadoID
            };
        }

        public List<Cidade> Parse(List<CidadeDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<CidadeDTO> Parse(List<Cidade> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
