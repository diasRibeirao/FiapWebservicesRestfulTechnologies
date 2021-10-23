using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IEstadoService
    {
        EstadoDTO Create(EstadoDTO estado);

        EstadoDTO FindById(long id);

        List<EstadoDTO> FindAll();

        EstadoDTO Update(EstadoDTO estado);

        void Delete(long id);

    }
}
