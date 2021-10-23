using FiapWebservicesRestfulTechnologies.Data.Converter.Contract;
using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Data.Converter.Implementations
{
    public class EnderecoConverter : IParser<EnderecoDTO, Endereco>, IParser<Endereco, EnderecoDTO>
    {
        public Endereco Parse(EnderecoDTO origin)
        {
            if (origin == null) return null;
            return new Endereco
            {
                Id = origin.Id,
                Cep = origin.Cep,
				Logradouro = origin.Logradouro,
				Bairro = origin.Bairro,
                CidadeID = origin.CidadeID
            };
        }

        public EnderecoDTO Parse(Endereco origin)
        {
            if (origin == null) return null;
            return new EnderecoDTO
            {
                Id = origin.Id,
                Cep = origin.Cep,
				Logradouro = origin.Logradouro,
				Bairro = origin.Bairro,
                CidadeID = origin.CidadeID
            };
        }

        public List<Endereco> Parse(List<EnderecoDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
               
        public List<EnderecoDTO> Parse(List<Endereco> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); throw new System.NotImplementedException();
        }
    }
}
