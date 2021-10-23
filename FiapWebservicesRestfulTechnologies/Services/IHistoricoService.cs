using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IHistoricoService
    {

        HistoricoDTO Create(HistoricoDTO user);

        HistoricoDTO FindById(long id);

        List<HistoricoDTO> FindAll();

        HistoricoDTO Update(HistoricoDTO historico);

        void Delete(long id);

    }
}
