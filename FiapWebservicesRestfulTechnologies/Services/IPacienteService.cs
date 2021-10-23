using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IPacienteService
    {

        PacienteDTO Create(PacienteDTO user);

        PacienteDTO FindById(long id);

        List<PacienteDTO> FindAll();

        PacienteDTO Update(PacienteDTO user);

        void Delete(long id);

    }
}
