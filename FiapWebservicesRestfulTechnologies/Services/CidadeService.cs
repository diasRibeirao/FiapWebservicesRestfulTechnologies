using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface ICidadeService
    {
        CidadeDTO Create(CidadeDTO cidade);

        CidadeDTO FindById(long id);

        List<CidadeDTO> FindAll();

        CidadeDTO Update(CidadeDTO cidade);

        void Delete(long id);

    }
}
