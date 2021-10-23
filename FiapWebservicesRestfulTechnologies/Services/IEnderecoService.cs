using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IEnderecoService
    {
        EnderecoDTO Create(EnderecoDTO endereco);

        EnderecoDTO FindById(long id);

        List<EnderecoDTO> FindAll();

        EnderecoDTO Update(EnderecoDTO endereco);

        void Delete(long id);

    }
}
